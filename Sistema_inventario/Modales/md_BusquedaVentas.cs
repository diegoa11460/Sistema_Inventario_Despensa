using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace Sistema_inventario.Modales
{
    public partial class md_BusquedaVentas : Form
    {
        // Ticket de la venta seleccionada, para devolverlo al formulario padre
        public string _Ticket { get; set; }
        public int _IdVentaSeleccionado { get; set; }

        // Guardamos la lista completa para filtrar en memoria sin volver a consultar la base
        private List<Venta> _listaCompleta;

        public md_BusquedaVentas()
        {
            InitializeComponent();

            // Enganchamos estos eventos por código porque no estaban conectados en el Designer
            this.Load += md_BusquedaVentas_Load;
            this.tablabusquedaVentas.CellDoubleClick += tablabusquedaVentas_CellDoubleClick;
            this.txtBusqueda.TextChanged += txtBusqueda_TextChanged;
            this.txtBuscarNombre.SelectedIndexChanged += txtBuscarNombre_SelectedIndexChanged;
            this.btnlimpiar.Click += btnlimpiar_Click;
        }

        private void md_BusquedaVentas_Load(object sender, EventArgs e)
        {
            // Cargamos las opciones del combo de criterio de búsqueda
            txtBuscarNombre.Items.Clear();
            txtBuscarNombre.Items.AddRange(new object[] { "Ticket", "Cliente", "Usuario" });
            txtBuscarNombre.SelectedIndex = 0;

            CargarVentas();
        }

        private void CargarVentas()
        {
            try
            {
                _listaCompleta = new CN_Venta().ObtenerListaVentas();
                PintarTabla(_listaCompleta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las ventas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PintarTabla(List<Venta> lista)
        {
            System.Globalization.CultureInfo cultura = System.Globalization.CultureInfo.GetCultureInfo("es-PY");

            tablabusquedaVentas.Rows.Clear();

            foreach (Venta v in lista)
            {
                int n = tablabusquedaVentas.Rows.Add();
                DataGridViewRow fila = tablabusquedaVentas.Rows[n];

                // Mapeamos cada columna en orden correcto.
                // ColNumeroDocumento y ColRazonSocial conservan su header original,
                // pero en Ventas muestran el Documento y Nombre del Cliente.
                fila.Cells[0].Value = v.FechaRegistro;
                fila.Cells[1].Value = v.Ticket;
                fila.Cells[2].Value = v.oCliente != null ? v.oCliente.Documento : "0";
                fila.Cells[3].Value = v.oCliente != null ? v.oCliente.NombreCompleto : "Consumidor Final";
                fila.Cells[4].Value = v.MontoTotal.ToString("N0", cultura);

                if (fila.Cells.Count > 5)
                {
                    fila.Cells[5].Value = v.oUsuario != null ? v.oUsuario.NombreCompleto : "Desconocido";
                }

                // Guardamos el objeto completo en el Tag
                fila.Tag = v;
            }
        }

        // Filtra en vivo según lo que el usuario escribe en txtBusqueda,
        // usando el criterio elegido en txtBuscarNombre (el combo)
        private void AplicarFiltro()
        {
            if (_listaCompleta == null) return;

            string filtro = txtBusqueda.Text.Trim().ToLower();
            string criterio = txtBuscarNombre.SelectedItem != null ? txtBuscarNombre.SelectedItem.ToString() : "";

            if (string.IsNullOrEmpty(filtro))
            {
                PintarTabla(_listaCompleta);
                return;
            }

            List<Venta> filtrado;

            switch (criterio)
            {
                case "Cliente":
                    filtrado = _listaCompleta.Where(v =>
                        v.oCliente != null && v.oCliente.NombreCompleto != null &&
                        v.oCliente.NombreCompleto.ToLower().Contains(filtro)).ToList();
                    break;

                case "Usuario":
                    filtrado = _listaCompleta.Where(v =>
                        v.oUsuario != null && v.oUsuario.NombreCompleto != null &&
                        v.oUsuario.NombreCompleto.ToLower().Contains(filtro)).ToList();
                    break;

                case "Ticket":
                default:
                    filtrado = _listaCompleta.Where(v =>
                        v.Ticket != null && v.Ticket.ToLower().Contains(filtro)).ToList();
                    break;
            }

            PintarTabla(filtrado);
        }

        // Se dispara cuando el usuario escribe en el textbox de búsqueda
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        // Se dispara cuando el usuario cambia el criterio de búsqueda (Ticket/Cliente/Usuario)
        private void txtBuscarNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        // Doble clic en una fila: selecciona esa venta, asigna los valores y cierra el modal
        private void tablabusquedaVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = tablabusquedaVentas.Rows[e.RowIndex];

                // Extraemos los datos directamente del objeto Venta guardado en el Tag
                if (fila.Tag is Venta v)
                {
                    _Ticket = v.Ticket;
                    _IdVentaSeleccionado = v.IdVenta;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            PintarTabla(_listaCompleta);
        }

        private void tablabusquedaVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}