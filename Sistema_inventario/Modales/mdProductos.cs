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
    public partial class mdProductos : Form
    {
        public mdProductos()
        {
            InitializeComponent();
        }

        public Producto ProductoSeleccionado { get; private set; }

        private void mdProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
            AplicarFormatoNumerico("ColStock");
            AplicarFormatoNumerico("ColPrecioCompra");
            AplicarFormatoNumerico("ColPrecioVent");

            txtBuscarNombre.Items.Clear();
            txtBuscarNombre.Items.Add("Codigo");
            txtBuscarNombre.Items.Add("Nombre");
            txtBuscarNombre.SelectedIndex = 0;

            tablaProductos.CellDoubleClick -= tablaProductos_CellContentClick;
            tablaProductos.CellDoubleClick += tablaProductos_CellContentClick;
        }

        private void AplicarFormatoNumerico(string nombreColumna)
        {
            if (tablaProductos.Columns.Contains(nombreColumna))
            {
                tablaProductos.Columns[nombreColumna].DefaultCellStyle.Format = "N0";
            }
        }

        private void tablaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            if (iRow < 0 || iColum < 0) return;
            if (tablaProductos.Rows[iRow].IsNewRow) return;

            var celdaPrecioVenta = tablaProductos.Rows[iRow].Cells["ColPrecioVent"].Value;

            if (celdaPrecioVenta == null || celdaPrecioVenta == DBNull.Value)
            {
                MessageBox.Show("Este producto no tiene Precio de Venta cargado.");
                return;
            }

            // Nombre real de columna confirmado en el Designer: "ColPrecioVent" (sin la "a" final)
            ProductoSeleccionado = new Producto()
            {
                IdProducto = Convert.ToInt32(tablaProductos.Rows[iRow].Cells["ColIdProducto"].Value.ToString()),
                Codigo = tablaProductos.Rows[iRow].Cells["ColCodigo"].Value.ToString(),
                Nombre = tablaProductos.Rows[iRow].Cells["ColNombre"].Value.ToString(),
                PrecioCompra = Convert.ToDecimal(tablaProductos.Rows[iRow].Cells["ColPrecioCompra"].Value.ToString()),
                Stock = Convert.ToInt32(Convert.ToDecimal(tablaProductos.Rows[iRow].Cells["ColStock"].Value.ToString())),
                PrecioVenta = Convert.ToDecimal(celdaPrecioVenta.ToString())
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void CargarProductos()
        {
            tablaProductos.Rows.Clear();

            List<Producto> lista = new CN_Producto().Listar();

            foreach (Producto item in lista)
            {
                if (item.Estado == true)
                {
                    tablaProductos.Rows.Add(new object[] {
                item.IdProducto,
                item.Codigo,
                item.Nombre,
                item.oCategoria.Descripcion,
                item.Stock,

                item.PrecioCompra,
                item.PrecioVenta
            });
                }
            }
        }

        private void AplicarFiltroBusqueda()
        {
            string filtro = txtBusqueda.Text.Trim().ToUpper();
            if (txtBuscarNombre.SelectedItem == null) return;

            string opcionSeleccionada = txtBuscarNombre.SelectedItem.ToString();

            // Columna 1 = Codigo, Columna 2 = Nombre
            int columnaBusqueda = opcionSeleccionada == "Codigo" ? 1 : 2;

            tablaProductos.ClearSelection();
            tablaProductos.CurrentCell = null;

            foreach (DataGridViewRow row in tablaProductos.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells[columnaBusqueda].Value != null)
                {
                    row.Visible = row.Cells[columnaBusqueda].Value.ToString().ToUpper().Contains(filtro);
                }
            }

            tablaProductos.Refresh();
        }

        private void txtBusqueda_TextChanged_1(object sender, EventArgs e)
        {
            AplicarFiltroBusqueda();
        }

        private void txtBuscarNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltroBusqueda();
        }

        // 🌟 CORRECCIÓN: Se agregó la lógica para limpiar la búsqueda
        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            txtBuscarNombre.SelectedIndex = 0;

            foreach (DataGridViewRow row in tablaProductos.Rows)
            {
                row.Visible = true;
            }
        }

        // Eventos vacíos que no afectan
        private void label2_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}