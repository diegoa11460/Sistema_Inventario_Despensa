// 🌟 Enlazamos con tus capas
using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_inventario
{
    public partial class Form_Productos : Form
    {
        public Form_Productos()
        {
            InitializeComponent();
        }

        // =======================================================
        // 🛠️ MÉTODOS AYUDANTES
        // =======================================================
        private void LimpiarCajas()
        {
            txtIdProductos.Text = "0"; 
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtStockMinimo.Text = "0";
            txtPrecioCompra.Text = "0";
            txtPrecioVenta.Text = "0";

            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;
            if (cboCategoria.Items.Count > 0) cboCategoria.SelectedIndex = 0;

            cboEstado.Enabled = true;
            txtCodigo.Select();
        }

        private void CargarProductos()
        {
            tablaProductos.Rows.Clear();
            List<Producto> lista = new CN_Producto().Listar();

            foreach (Producto item in lista)
            {
                string stockMinSinDecimales = Convert.ToInt32(item.StockMinimo).ToString();

                tablaProductos.Rows.Add(new object[] {
            item.IdProducto,                 // [0]
            item.Codigo,                     // [1]
            item.Descripcion,                // [2]
            item.Nombre,                     // [3]
            item.oCategoria.Descripcion,     // [4] -> Categoría
            item.Stock.ToString("N0"),                      // [5] -> Stock Actual
            stockMinSinDecimales,            // [6] -> Stock Mínimo limpio
            item.PrecioCompra.ToString("N0"), // [7] -> Precio Compra limpio (ej: 8.500)
            item.PrecioVenta.ToString("N0"),  // [8] -> Precio Venta limpio (ej: 12.000)
            item.Estado == true ? "Activo" : "No Activo" // [9] -> Estado
        });
            }
        }
        // =======================================================
        // 🚀 EVENTOS AL ABRIR EL FORMULARIO
        // =======================================================
        private void Form_Productos_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Clear();
            cboEstado.Items.Add("Activo");
            cboEstado.Items.Add("No Activo");
            cboEstado.SelectedIndex = 0;

            List<Categoria> listaCategorias = new CN_Categoria().Listar();
            cboCategoria.DataSource = listaCategorias;
            cboCategoria.DisplayMember = "Descripcion";
            cboCategoria.ValueMember = "IdCategoria";

            txtBuscarNombre.Items.Clear();
            txtBuscarNombre.Items.Add("Código");
            txtBuscarNombre.Items.Add("Nombre");
            txtBuscarNombre.Items.Add("Categoría");
            txtBuscarNombre.Items.Add("Descripcion");
            txtBuscarNombre.SelectedIndex = 0;

            txtIdProductos.ReadOnly = true;

            // Aseguramos que el clic en la tabla funcione
            tablaProductos.CellClick -= tablaProductos_CellClick;
            tablaProductos.CellClick += tablaProductos_CellClick;

            LimpiarCajas();
            CargarProductos();
        }

        private void cboCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Verificamos que haya seleccionado un objeto de la lista
            if (cboCategoria.SelectedItem != null)
            {
                // Convertimos el ítem seleccionado a nuestra clase Categoria
                Categoria categoriaSeleccionada = (Categoria)cboCategoria.SelectedItem;

                // Si su estado es inactivo (asumiendo que sea false o 0 en tu clase)
                if (categoriaSeleccionada.Estado == false)
                {
                    MessageBox.Show("Esta categoría se encuentra INACTIVA.\nSolo va a funcionar si el administrador activa de nuevo su estado desde la ventana de Categorías.",
                                    "Categoría Inactiva",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificamos si el producto está inactivo
            if (cboEstado.Text == "No Activo")
            {
                // 🔒 BLOQUEAR (Todo se pone oscuro y no se puede editar)
                txtCodigo.Enabled = false;
                txtNombre.Enabled = false;
                txtDescripcion.Enabled = false;
                cboCategoria.Enabled = false;
                txtStockMinimo.Enabled = false;
                txtPrecioCompra.Enabled = false;
                txtPrecioVenta.Enabled = false;
            }
            else
            {
                // 🔓 DESBLOQUEAR (Vuelve a la normalidad si es Activo)
                txtCodigo.Enabled = true;
                txtNombre.Enabled = true;
                txtDescripcion.Enabled = true;
                cboCategoria.Enabled = true;
                txtStockMinimo.Enabled = true;
                txtPrecioCompra.Enabled = true;
                txtPrecioVenta.Enabled = true;
            }
        }














        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            // 🛑 1. VALIDACIÓN BÁSICA: Que no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("No se seleccionó ni ingresó ningún producto. Por favor, complete los datos antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🛑 2. VALIDACIÓN DE CATEGORÍA INACTIVA
            if (cboCategoria.SelectedItem != null)
            {
                Categoria catSeleccionada = (Categoria)cboCategoria.SelectedItem;
                if (catSeleccionada.Estado == false)
                {
                    MessageBox.Show("No puedes guardar un producto usando una categoría INACTIVA. Por favor, selecciona una categoría activa o habilítala primero.", "Advertencia del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            int idActual = Convert.ToInt32(txtIdProductos.Text);
            string mensaje = string.Empty;

            // 🔒 3. NORMALIZAR CÓDIGO: sin espacios extra, todo en mayúsculas
            string codigoNormalizado = txtCodigo.Text.Trim().ToUpper();
            txtCodigo.Text = codigoNormalizado;

            // 🛑 4. VALIDACIÓN DE CÓDIGO DUPLICADO (Conectado a tu Base de Datos)
            if (new CN_Producto().ExisteCodigo(codigoNormalizado, idActual))
            {
                MessageBox.Show("Ya existe un producto registrado con ese código. Ingresá uno diferente.",
                    "Código duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                txtCodigo.SelectAll();
                return; // 🛑 Cortamos acá, el producto no se guarda
            }

            // 🛡️ LIMPIEZA DE DATOS (Stock y Precios)
            string strStock = txtStockMinimo.Text.Split(',')[0].Split('.')[0];
            if (string.IsNullOrWhiteSpace(strStock)) strStock = "0";

            decimal precioCompra = 0;
            string txtCompraLimpio = txtPrecioCompra.Text.Trim().Replace(".", "").Replace(",", ".");
            decimal.TryParse(txtCompraLimpio, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out precioCompra);

            decimal precioVenta = 0;
            string txtVentaLimpio = txtPrecioVenta.Text.Trim().Replace(".", "").Replace(",", ".");
            decimal.TryParse(txtVentaLimpio, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out precioVenta);

            int idCat = 0;
            if (cboCategoria.SelectedValue != null)
            {
                int.TryParse(cboCategoria.SelectedValue.ToString(), out idCat);
            }

            // 🛑 5. NUEVA VALIDACIÓN: Detectar si realmente hubo cambios antes de editar
            if (idActual > 0) // Solo verificamos si es un producto existente (Edición)
            {
                bool hayCambios = false;

                // Buscamos el producto actual en la tabla para comparar lo que tiene escrito
                foreach (DataGridViewRow row in tablaProductos.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == idActual.ToString())
                    {
                        // Comparamos los textos (Usamos el codigoNormalizado)
                        if (codigoNormalizado != row.Cells[1].Value?.ToString()) hayCambios = true;
                        if (txtDescripcion.Text.Trim() != row.Cells[2].Value?.ToString()) hayCambios = true;
                        if (txtNombre.Text.Trim() != row.Cells[3].Value?.ToString()) hayCambios = true;
                        if (cboCategoria.Text != row.Cells[4].Value?.ToString()) hayCambios = true;
                        if (cboEstado.Text != row.Cells[9].Value?.ToString()) hayCambios = true;

                        // Comparamos el stock 
                        if (strStock != row.Cells[6].Value?.ToString()) hayCambios = true;

                        // Comparamos los precios convirtiendo el de la tabla a decimal exacto para evitar errores de puntos
                        decimal gridPrecioCompra = 0;
                        decimal.TryParse(row.Cells[7].Value?.ToString().Replace(".", "").Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out gridPrecioCompra);
                        if (precioCompra != gridPrecioCompra) hayCambios = true;

                        decimal gridPrecioVenta = 0;
                        decimal.TryParse(row.Cells[8].Value?.ToString().Replace(".", "").Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out gridPrecioVenta);
                        if (precioVenta != gridPrecioVenta) hayCambios = true;

                        break; // Encontramos la fila, salimos del bucle para no buscar más
                    }
                }

                // Si después de comparar caja por caja, nada cambió:
                if (!hayCambios)
                {
                    MessageBox.Show("No editaste nada. Modifica algún dato para poder guardar los cambios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; // 🛑 El 'return' cancela el guardado y no va a la base de datos
                }
            }

            // --- 6. CREACIÓN DEL OBJETO Y GUARDADO EN BASE DE DATOS ---
            Producto objProducto = new Producto()
            {
                IdProducto = idActual,
                Codigo = codigoNormalizado, // Usamos el código ya limpio
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                oCategoria = new Categoria() { IdCategoria = idCat },
                StockMinimo = Convert.ToDecimal(strStock),
                PrecioCompra = precioCompra,
                PrecioVenta = precioVenta,
                Estado = cboEstado.Text == "Activo"
            };

            if (objProducto.IdProducto == 0) // Registrar nuevo producto
            {
                int idGenerado = new CN_Producto().Registrar(objProducto, out mensaje);

                if (idGenerado != 0)
                {
                    MessageBox.Show("Producto registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProductos();
                    LimpiarCajas();
                }
                else
                {
                    MessageBox.Show(mensaje, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else // Editar producto existente
            {
                bool resultado = new CN_Producto().Editar(objProducto, out mensaje);

                if (resultado)
                {
                    MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProductos();
                    LimpiarCajas();
                }
                else
                {
                    MessageBox.Show(mensaje, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        // 🗑️ BOTÓN DAR DE BAJA (Conectado a tu botón rojo)
        // =======================================================
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            int idActual = Convert.ToInt32(txtIdProductos.Text);

            if (idActual <= 0)
            {
                MessageBox.Show("Por favor, seleccione un producto de la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🛑 NUEVA VALIDACIÓN: Revisar el stock antes de preguntar si desea eliminar
            decimal stockActual = 0;

            // Buscamos el stock de ese producto directamente en la tabla visual
            foreach (DataGridViewRow row in tablaProductos.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == idActual.ToString())
                {
                    // La celda [5] es donde guardamos el Stock Actual según tu diseño
                    stockActual = Convert.ToDecimal(row.Cells[5].Value.ToString());
                    break;
                }
            }

            // Si hay mercadería, bloqueamos la eliminación
            if (stockActual > 0)
            {
                MessageBox.Show($"No puedes dar de baja un producto que aún tiene mercadería en stock ({stockActual} unidades).\nSi ya no lo vendes, primero registra una Salida o Ajuste para dejar el stock en 0.",
                                "Acción Denegada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Cortamos la ejecución aquí
            }

            // ⚠️ Si el stock es 0, recién ahí pedimos confirmación
            if (MessageBox.Show("¿Está seguro de dar de baja este producto de forma definitiva?", "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            string mensaje = string.Empty;
            Producto objProducto = new Producto() { IdProducto = idActual };

            // Mandamos la orden a la Capa de Negocio
            bool respuesta = new CN_Producto().Eliminar(objProducto, out mensaje);

            if (respuesta)
            {
                MessageBox.Show("Producto dado de baja correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProductos();
                LimpiarCajas();
            }
            else
            {
                MessageBox.Show(mensaje, "Error al dar de baja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // =======================================================
        // 🖱️ SELECCIONAR DATOS DE LA TABLA
        // =======================================================
        private void tablaProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = tablaProductos.Rows[e.RowIndex];

            txtIdProductos.Text = row.Cells[0].Value?.ToString() ?? "0";
            txtCodigo.Text = row.Cells[1].Value?.ToString() ?? "";
            txtDescripcion.Text = row.Cells[2].Value?.ToString() ?? "";
            txtNombre.Text = row.Cells[3].Value?.ToString() ?? "";
            cboCategoria.Text = row.Cells[4].Value?.ToString() ?? "";

            // Asignamos y limpiamos el Stock Mínimo de una sola vez para que no aparezca el ,00
            string valorStockMin = row.Cells[6].Value?.ToString() ?? "0";
            txtStockMinimo.Text = valorStockMin.Split(',')[0].Split('.')[0];

            txtPrecioCompra.Text = row.Cells[7].Value?.ToString() ?? "0";
            txtPrecioVenta.Text = row.Cells[8].Value?.ToString() ?? "0";
            cboEstado.Text = row.Cells[9].Value?.ToString() ?? "Activo";
        }


        private void AplicarFiltroBusqueda()
        {
            string filtro = txtBusqueda.Text.Trim().ToUpper();
            int columnaBusqueda = 1; // Código

            if (txtBuscarNombre.SelectedIndex == 1) columnaBusqueda = 3;      // Nombre
            else if (txtBuscarNombre.SelectedIndex == 2) columnaBusqueda = 4; // Categoría
            else if (txtBuscarNombre.SelectedIndex == 3) columnaBusqueda = 2; // Descripcion 👈 agregado

            foreach (DataGridViewRow row in tablaProductos.Rows)
            {
                if (row.Cells[columnaBusqueda].Value != null)
                    row.Visible = row.Cells[columnaBusqueda].Value.ToString().ToUpper().Contains(filtro);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e) { AplicarFiltroBusqueda(); }
        private void txtBuscarNombre_SelectedIndexChanged(object sender, EventArgs e) { AplicarFiltroBusqueda();
        
        
        }
        private void txtBusqueda_TextChanged(object sender, EventArgs e) { AplicarFiltroBusqueda(); }

        private void btnNuevo_Click(object sender, EventArgs e) { LimpiarCajas(); }



        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            txtBuscarNombre.SelectedIndex = 0;
            foreach (DataGridViewRow row in tablaProductos.Rows) { row.Visible = true; }
            LimpiarCajas();
        }

        // =======================================================
        // 🛑 EVENTOS VACÍOS EXIGIDOS POR EL DISEÑADOR (NO BORRAR)
        // =======================================================
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void guna2Panel5_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void pictureBox4_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel3_Paint(object sender, PaintEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void guna2Panel4_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void txtIdProductos_TextChanged(object sender, EventArgs e) { }
        private void txCategoria_SelectedIndexChanged(object sender, EventArgs e) {
        
        
        
        
        
        }
        private void tablaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void tablaProductos_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }

        private void btnLimpiarBusqueda_Click_1(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            txtBuscarNombre.SelectedIndex = 0;

            foreach (DataGridViewRow row in tablaProductos.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            // 1. Vaciamos los textos de las cajas (ID, Nombre, Precios, etc.)
            txtIdProductos.Text = "0";
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtStockMinimo.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();

            // 2. Volvemos a poner los desplegables en su primer valor
            if (cboCategoria.Items.Count > 0) cboCategoria.SelectedIndex = 0;

            // Al poner el estado en el índice 0 ("Activo"), ¡tu código anterior 
            // desbloqueará automáticamente todas las cajas oscuras!
            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;

            // 3. ¡LA CLAVE AQUÍ! Esto quita la selección azul de la tabla
            tablaProductos.ClearSelection();

            // 4. Ponemos el cursor parpadeando en el Código para escribir uno nuevo rápido
            txtCodigo.Focus();
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificamos que haya seleccionado un objeto de la lista
            if (cboCategoria.SelectedItem != null)
            {
                // Convertimos el ítem seleccionado a nuestra clase Categoria
                Categoria categoriaSeleccionada = (Categoria)cboCategoria.SelectedItem;

                // Si su estado es inactivo (asumiendo que sea false o 0 en tu clase)
                if (categoriaSeleccionada.Estado == false)
                {
                    MessageBox.Show("Esta categoría se encuentra INACTIVA.\nSolo va a funcionar si el administrador activa de nuevo su estado desde la Modulo de Categorías.",
                                    "Categoría Inactiva",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            // 1. Verificación inicial
            if (tablaProductos.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // 2. Crear el DataTable y agregar las columnas
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn columna in tablaProductos.Columns)
            {
                // Solo agregamos columnas que tengan título y que estén visibles
                if (columna.HeaderText != "" && columna.Visible)
                {
                    dt.Columns.Add(columna.HeaderText, typeof(string));
                }
            }

            // 3. Llenar el DataTable con las filas de la tabla visual
            foreach (DataGridViewRow row in tablaProductos.Rows)
            {
                if (row.Visible)
                {
                    DataRow dr = dt.NewRow();
                    int indiceDestino = 0;

                    foreach (DataGridViewColumn columna in tablaProductos.Columns)
                    {
                        if (columna.HeaderText != "" && columna.Visible)
                        {
                            // Copiamos el valor de la celda. Si es nulo, dejamos un espacio en blanco
                            dr[indiceDestino] = row.Cells[columna.Index].Value?.ToString() ?? "";
                            indiceDestino++;
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }

            // 4. Guardar usando ClosedXML
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = string.Format("Reporte_Productos_{0}.xlsx", DateTime.Now.ToString("ddMMyyyy_HHmmss"));
            guardar.Filter = "Archivos Excel | *.xlsx";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XLWorkbook wb = new XLWorkbook();

                    // Creamos la hoja en blanco primero
                    var hoja = wb.Worksheets.Add("Inventario");

                    // --- NUEVO: Agregar Título y Fecha/Hora exacta ---
                    hoja.Cell("A1").Value = "Reporte de Inventario de Productos";
                    hoja.Cell("A1").Style.Font.Bold = true;
                    hoja.Cell("A1").Style.Font.FontSize = 14;

                    hoja.Cell("A2").Value = "Generado el: " + DateTime.Now.ToString("dd/MM/yyyy") + " a las " + DateTime.Now.ToString("HH:mm:ss");
                    hoja.Cell("A2").Style.Font.Italic = true;

                    // --- Insertar la tabla de productos a partir de la fila 4 ---
                    hoja.Cell("A4").InsertTable(dt);

                    // Ajustar el ancho de las columnas automáticamente
                    hoja.ColumnsUsed().AdjustToContents();

                    wb.SaveAs(guardar.FileName);
                    MessageBox.Show("Reporte de Excel generado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el documento Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecioCompra_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecioVenta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}