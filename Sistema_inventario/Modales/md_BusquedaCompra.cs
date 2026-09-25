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
    public partial class md_BusquedaCompra : Form
    {
        // Número de documento de la compra seleccionada, para devolverlo al formulario padre
        public string _NumeroDocumento { get; set; }
        public int _IdCompraSeleccionado { get; set; }

        // Guardamos la lista completa para filtrar en memoria sin volver a consultar la base
        private List<Compra> _listaCompleta;

        public md_BusquedaCompra()
        {
            InitializeComponent();

            // Enganchamos estos eventos por código porque no estaban conectados en el Designer
            this.Load += md_BusquedaCompra_Load;
            this.tablabusquedacompra.CellDoubleClick += tablabusquedacompra_CellDoubleClick;
        }

        private void md_BusquedaCompra_Load(object sender, EventArgs e)
        {
            // Cargamos las opciones del combo de criterio de búsqueda
            txtBuscarNombre.Items.Clear();
            txtBuscarNombre.Items.AddRange(new object[] { "Numero Documento", "Razon Social", "Usuario" });
            txtBuscarNombre.SelectedIndex = 0;

            CargarCompras();
        }

        private void CargarCompras()
        {
            try
            {
                _listaCompleta = new CN_Compra().ObtenerListaCompras();
                PintarTabla(_listaCompleta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las compras: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PintarTabla(List<Compra> lista)
        {
            System.Globalization.CultureInfo cultura = System.Globalization.CultureInfo.GetCultureInfo("es-PY");

            tablabusquedacompra.Rows.Clear();

            foreach (Compra c in lista)
            {
                int n = tablabusquedacompra.Rows.Add();
                DataGridViewRow fila = tablabusquedacompra.Rows[n];

                // Mapeamos cada columna en orden correcto
                fila.Cells[0].Value = c.FechaRegistro;
                fila.Cells[1].Value = c.TipoDocumento;

                // Mostramos el número de factura de la compra (ej. 00003) en esta columna
                fila.Cells[2].Value = c.NumeroDocumento;

                fila.Cells[3].Value = c.oProveedor != null ? c.oProveedor.RazonSocial : "";
                fila.Cells[4].Value = c.MontoTotal.ToString("N0", cultura);

                // Verificamos si existe la columna 5 para el usuario de forma segura
                if (fila.Cells.Count > 5)
                {
                    fila.Cells[5].Value = c.oUsuario != null ? c.oUsuario.NombreCompleto : "Desconocido";
                }

                // Guardamos el objeto completo en el Tag
                fila.Tag = c;
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

            List<Compra> filtrado;

            switch (criterio)
            {
                case "Razon Social":
                    filtrado = _listaCompleta.Where(c =>
                        c.oProveedor != null && c.oProveedor.RazonSocial != null &&
                        c.oProveedor.RazonSocial.ToLower().Contains(filtro)).ToList();
                    break;

                case "Usuario":
                    filtrado = _listaCompleta.Where(c =>
                        c.oUsuario != null && c.oUsuario.NombreCompleto != null &&
                        c.oUsuario.NombreCompleto.ToLower().Contains(filtro)).ToList();
                    break;

                case "Numero Documento":
                default:
                    filtrado = _listaCompleta.Where(c =>
                        c.NumeroDocumento != null && c.NumeroDocumento.ToLower().Contains(filtro)).ToList();
                    break;
            }

            PintarTabla(filtrado);
        }

        // Se dispara cuando el usuario escribe en el textbox de búsqueda
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        // Se dispara cuando el usuario cambia el criterio de búsqueda (Numero/RazonSocial/Usuario)
        private void txtBuscarNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        // Doble clic en una fila: selecciona esa compra, asigna los valores y cierra el modal
        private void tablabusquedacompra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = tablabusquedacompra.Rows[e.RowIndex];

                // Extraemos los datos directamente del objeto Compra guardado en el Tag
                if (fila.Tag is Compra c)
                {
                    _NumeroDocumento = c.NumeroDocumento;
                    _IdCompraSeleccionado = c.IdCompra;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tablabusquedacompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void md_BusquedaCompra_Load_1(object sender, EventArgs e)
        {

        }
    }
}