using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Sistema_inventario.Modales
{
    public partial class mdProductoVentas : Form
    {
        // Usuario logueado, necesario para registrar quién dio de baja un lote vencido.
        // El constructor sin parámetros se mantiene solo para que el diseñador visual
        // de Visual Studio pueda abrir este formulario; en tiempo de ejecución real
        // siempre se debería usar el constructor con Usuario.
        private Usuario _usuarioActual;

        public mdProductoVentas()
        {
            InitializeComponent();
        }

        public mdProductoVentas(Usuario oUsuarioActual)
        {
            InitializeComponent();
            _usuarioActual = oUsuarioActual;
        }

        /// <summary>Producto elegido, con PrecioVenta ya sobrescrito por el precio real del lote elegido.</summary>
        public Producto ProductoSeleccionado { get; private set; }

        /// <summary>IdDetalleCompra del lote elegido — usar esto para completar DetalleVenta.IdDetalleCompra.</summary>
        public int IdDetalleCompraSeleccionado { get; private set; }

        private void mdProductoVentas_Load_1(object sender, EventArgs e)
        {
            CargarProductos();
            AplicarFormatoNumerico("ColStock");
            AplicarFormatoNumerico("ColPrecioCompra");
            AplicarFormatoNumerico("ColPrecioVent");
            AplicarFormatoFecha("ColFechaVencimiento");

            txtBuscarNombre.Items.Clear();
            txtBuscarNombre.Items.Add("Codigo");
            txtBuscarNombre.Items.Add("Nombre");
            txtBuscarNombre.SelectedIndex = 0;
        }

        private void AplicarFormatoNumerico(string nombreColumna)
        {
            if (tablaProductos.Columns.Contains(nombreColumna))
            {
                tablaProductos.Columns[nombreColumna].DefaultCellStyle.Format = "N0";
            }
        }

        private void AplicarFormatoFecha(string nombreColumna)
        {
            if (tablaProductos.Columns.Contains(nombreColumna))
            {
                tablaProductos.Columns[nombreColumna].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void tablaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            if (iRow < 0 || iColum < 0) return;
            if (tablaProductos.Rows[iRow].IsNewRow) return;

            var celdaVencimiento = tablaProductos.Rows[iRow].Cells["ColFechaVencimiento"].Value;
            if (celdaVencimiento != null && DateTime.TryParse(celdaVencimiento.ToString(), out DateTime fechaVencimiento))
            {
                if (fechaVencimiento.Date < DateTime.Today)
                {
                    DialogResult quiereBaja = MessageBox.Show(
                        $"Este lote venció el {fechaVencimiento:dd/MM/yyyy} y no puede venderse.\n\n" +
                        "¿Querés darlo de baja ahora? Esto va a restar el stock restante de este lote " +
                        "y quedará registrado en Movimiento.",
                        "Lote vencido",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (quiereBaja == DialogResult.Yes)
                    {
                        int idDetalleCompra = Convert.ToInt32(tablaProductos.Rows[iRow].Cells["ColIdDetalleCompra"].Value.ToString());
                        int idUsuario = _usuarioActual?.IdUsuario ?? 0;

                        bool ok = new CN_Compra().RegistrarBajaPorVencimiento(idDetalleCompra, idUsuario, out string mensajeBaja);

                        MessageBox.Show(mensajeBaja, ok ? "Baja registrada" : "No se pudo dar de baja",
                            MessageBoxButtons.OK, ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                        if (ok)
                        {
                            CargarProductos(); // refresca la lista: el lote ya no debería aparecer
                        }
                    }

                    return;
                }
            }

            var celdaPrecioVenta = tablaProductos.Rows[iRow].Cells["ColPrecioVent"].Value;
            if (celdaPrecioVenta == null || celdaPrecioVenta == DBNull.Value)
            {
                MessageBox.Show("Este lote no tiene Precio de Venta cargado.");
                return;
            }

            ProductoSeleccionado = new Producto()
            {
                IdProducto = Convert.ToInt32(tablaProductos.Rows[iRow].Cells["ColIdProducto"].Value.ToString()),
                Codigo = tablaProductos.Rows[iRow].Cells["ColCodigo"].Value?.ToString() ?? "",
                Nombre = tablaProductos.Rows[iRow].Cells["ColNombre"].Value?.ToString() ?? "",
                PrecioCompra = Convert.ToDecimal(tablaProductos.Rows[iRow].Cells["ColPrecioCompra"].Value.ToString()),
                Stock = Convert.ToInt32(Convert.ToDecimal(tablaProductos.Rows[iRow].Cells["ColStock"].Value.ToString())),
                // PrecioVenta acá es el del LOTE (DetalleCompra.PrecioVenta), no el agregado de Producto,
                // porque puede variar de un lote a otro.
                PrecioVenta = Convert.ToDecimal(celdaPrecioVenta.ToString())
            };

            IdDetalleCompraSeleccionado = Convert.ToInt32(tablaProductos.Rows[iRow].Cells["ColIdDetalleCompra"].Value.ToString());

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CargarProductos()
        {
            try
            {
                tablaProductos.Rows.Clear();

                List<Producto> productos = new CN_Producto().Listar();
                List<LoteDisponible> lotes = new CN_Compra().ObtenerLotesDisponibles(out string mensaje);

                if (!string.IsNullOrEmpty(mensaje))
                {
                    MessageBox.Show("Error al cargar los lotes: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (productos == null || lotes == null) return;

                foreach (LoteDisponible lote in lotes)
                {
                    if (lote.Disponible <= 0) continue;

                    // Ya NO filtramos por Estado: un producto desactivado (descontinuado)
                    // puede seguir teniendo lotes con stock real que hay que poder vender
                    // hasta agotar — desactivar solo debería impedir comprar MÁS, no vender
                    // lo que ya existe.
                    Producto producto = productos.FirstOrDefault(p => p.IdProducto == lote.IdProducto);
                    if (producto == null) continue; // el producto ya no existe en absoluto

                    string categoriaDesc = producto.oCategoria != null ? producto.oCategoria.Descripcion : "Sin Categoría";

                    tablaProductos.Rows.Add(new object[] {
                        producto.IdProducto,
                        lote.IdDetalleCompra,
                        producto.Codigo ?? "",
                        producto.Nombre ?? "",
                        categoriaDesc,
                        lote.NroLote ?? "",
                        lote.Disponible,
                        producto.PrecioCompra,
                        lote.PrecioVenta,
                        lote.FechaVencimiento
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltroBusqueda()
        {
            string filtro = txtBusqueda.Text.Trim().ToUpper();
            if (txtBuscarNombre.SelectedItem == null) return;

            string opcionSeleccionada = txtBuscarNombre.SelectedItem.ToString();
            // Columnas: 0=IdProducto(oculta) 1=IdDetalleCompra(oculta) 2=Codigo 3=Nombre ...
            int columnaBusqueda = opcionSeleccionada == "Codigo" ? 2 : 3;

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

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            txtBuscarNombre.SelectedIndex = 0;

            foreach (DataGridViewRow row in tablaProductos.Rows)
            {
                row.Visible = true;
            }
        }

        private void txtBuscarNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltroBusqueda();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroBusqueda();
        }

        // Evento vacío requerido por el Designer (label1.Click += ...), no afecta nada
        private void label1_Click(object sender, EventArgs e) { }
    }
}