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
    public partial class mdProveedor : Form
    {
        public mdProveedor()
        {
            InitializeComponent();
        }
        public Proveedor ProveedorSeleccionado { get; private set; }
        private void mdProveedor_Load(object sender, EventArgs e)
        {
            CargarProveedores();

            txtBuscarNombre.Items.Clear();
            txtBuscarNombre.Items.Add("Documento");
            txtBuscarNombre.Items.Add("RazonSocial");
            txtBuscarNombre.SelectedIndex = 0;

            tablaProveedores.CellDoubleClick -= tablaProveedores_CellDoubleClick;
            tablaProveedores.CellDoubleClick += tablaProveedores_CellDoubleClick;
        }
        private void tablaProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            if (iRow >= 0 && iColum >= 0)
            {
                ProveedorSeleccionado = new Proveedor()
                {
             
                    IdProveedor = Convert.ToInt32(tablaProveedores.Rows[iRow].Cells["ColIdProducto"].Value.ToString()),
                    Documento = tablaProveedores.Rows[iRow].Cells["ColDocumento"].Value.ToString(),
                    RazonSocial = tablaProveedores.Rows[iRow].Cells["ColRazonSocial"].Value.ToString()
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

     

        private void CargarProveedores()
        {
            tablaProveedores.Rows.Clear();
            List<Proveedor> lista = new CN_Proveedor().Listar();

            foreach (Proveedor item in lista)
            {
                tablaProveedores.Rows.Add(new object[] {
                    item.IdProveedor,
                    item.Documento,
                    item.RazonSocial
                });
            }
        }

        private void AplicarFiltroBusqueda()
        {
            string filtro = txtBusqueda.Text.Trim().ToUpper();
            if (txtBuscarNombre.SelectedItem == null) return;

            string opcionSeleccionada = txtBuscarNombre.SelectedItem.ToString();
            int columnaBusqueda = opcionSeleccionada == "Documento" ? 1 : 2;

            tablaProveedores.ClearSelection();
            tablaProveedores.CurrentCell = null;

            foreach (DataGridViewRow row in tablaProveedores.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells[columnaBusqueda].Value != null)
                {
                    row.Visible = row.Cells[columnaBusqueda].Value.ToString().ToUpper().Contains(filtro);
                }
            }

            tablaProveedores.Refresh(); 
        }

        private void txtBusqueda_TextChanged_1(object sender, EventArgs e)
        {
            AplicarFiltroBusqueda();
        }
        private void btnLimpiarBusqueda_Click_1(object sender, EventArgs e)
        {

            txtBusqueda.Text = "";
            txtBuscarNombre.SelectedIndex = 0;

            foreach (DataGridViewRow row in tablaProveedores.Rows)
                row.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}