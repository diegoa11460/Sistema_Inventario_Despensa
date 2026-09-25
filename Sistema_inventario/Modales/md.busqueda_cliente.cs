using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_inventario.Modales
{
    public partial class md : Form
    {
        public md()
        {
            InitializeComponent();

            // 1. Configurar las opciones de búsqueda
            txtBuscarNombre.Items.Clear();
            txtBuscarNombre.Items.Add("Documento");
            txtBuscarNombre.Items.Add("Nombre");
            txtBuscarNombre.SelectedIndex = 0;

            // 2. Cargar los clientes al iniciar
            CargarClientes();

            // 3. Enlazar el evento de doble clic
            tablaClientes.CellDoubleClick -= tablaClientes_CellContentClick;
            tablaClientes.CellDoubleClick += tablaClientes_CellContentClick;
        }

        // Propiedad para enviar el cliente seleccionado de vuelta a Form_Ventas
        public Cliente ClienteSeleccionado { get; private set; }

        private void CargarClientes()
        {
            tablaClientes.Rows.Clear();

            try
            {
                List<Cliente> lista = new CN_Cliente().Listar();

                foreach (Cliente item in lista)
                {
                    if (item.Estado == true)
                    {
                        // Respetamos estrictamente las 3 columnas configuradas en tu diseñador
                        // Col 0: ID (oculta), Col 1: Documento, Col 2: Nombre
                        tablaClientes.Rows.Add(new object[] {
                            item.IdCliente,
                            item.Documento,
                            item.NombreCompleto
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void AplicarFiltroBusqueda()
        {
            string filtro = txtBusqueda.Text.Trim().ToUpper();
            if (txtBuscarNombre.SelectedItem == null) return;

            string opcionSeleccionada = txtBuscarNombre.SelectedItem.ToString();

            // Columna 1 = Documento, Columna 2 = Nombre
            int columnaBusqueda = opcionSeleccionada == "Documento" ? 1 : 2;

            tablaClientes.ClearSelection();
            tablaClientes.CurrentCell = null;

            foreach (DataGridViewRow row in tablaClientes.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells[columnaBusqueda].Value != null)
                {
                    row.Visible = row.Cells[columnaBusqueda].Value.ToString().ToUpper().Contains(filtro);
                }
            }

            tablaClientes.Refresh();
        }

        private void tablaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;

            if (iRow < 0) return;
            if (tablaClientes.Rows[iRow].IsNewRow) return;

            // Extraemos los datos usando los nombres exactos de las columnas configuradas en el diseñador
            ClienteSeleccionado = new Cliente()
            {
                IdCliente = Convert.ToInt32(tablaClientes.Rows[iRow].Cells["ColIdCliente"].Value.ToString()),
                Documento = tablaClientes.Rows[iRow].Cells["ColDocumento"].Value.ToString(),
                NombreCompleto = tablaClientes.Rows[iRow].Cells["ColNombre"].Value.ToString()
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroBusqueda();
        }

        private void txtBuscarNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltroBusqueda();
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            txtBuscarNombre.SelectedIndex = 0;

            foreach (DataGridViewRow row in tablaClientes.Rows)
            {
                row.Visible = true;
            }
        }

        private void md_Load(object sender, EventArgs e)
        {
            // Ya no es necesario poner código aquí, todo está en el constructor
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void md_Load_1(object sender, EventArgs e)
        {

        }
    }
}