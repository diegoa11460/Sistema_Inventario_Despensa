using Sistema_inventario.Modales;
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

namespace Sistema_inventario
{
    public partial class Form_Compras : Form
    {
        public Form_Compras()
        {
            InitializeComponent();
        }

        private Usuario _UsuarioActual;

        // 2. Modificamos el constructor para que exija un usuario
        public Form_Compras(Usuario oUsuario)
        {
            InitializeComponent();
            _UsuarioActual = oUsuario; // Lo guardamos
        }
        private void Form_Compras_Load(object sender, EventArgs e)
        {
            txtTipodocumentos.Items.Clear();

          
            txtTipodocumentos.Items.Add("Factura");
            txtTipodocumentos.Items.Add("Nota de Remisión");
            txtTipodocumentos.Items.Add("Recibo");

            txtTipodocumentos.SelectedIndex = 1;

            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            textIdproducto.Text = "0";
            txtIdProveedor.Text = "0";

            // El RUC del proveedor se carga solo desde el buscador, no se edita a mano
            txtNumerodocumento.ReadOnly = true;
        }
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtIdProveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            mdProveedor frm = new mdProveedor();
            frm.StartPosition = FormStartPosition.CenterParent;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtIdProveedor.Text = frm.ProveedorSeleccionado.IdProveedor.ToString();
                txtNumerodocumento.Text = frm.ProveedorSeleccionado.Documento;
                txtrazonsocial.Text = frm.ProveedorSeleccionado.RazonSocial;
            }
        }

       
        private void txtcodigoproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                e.SuppressKeyPress = true;


                Producto oProducto = new CN_Producto().Listar().FirstOrDefault(p => p.Codigo == txtcodigoproducto.Text && p.Estado == true);


                if (oProducto != null)
                {
                    txtcodigoproducto.BackColor = Color.Honeydew;

                    textIdproducto.Text = oProducto.IdProducto.ToString();
                    txtProductos.Text = oProducto.Nombre;
                    txtpreciocompras.Text = oProducto.PrecioCompra.ToString("N0");
                    txtprecioventas.Text = oProducto.PrecioVenta.ToString("N0");

                    txtcantida.Select();
                }
                else
                {
                    txtcodigoproducto.BackColor = Color.MistyRose;


                    textIdproducto.Text = "0";
                    txtProductos.Text = "";
                    txtpreciocompras.Text = "";
                    txtprecioventas.Text = "";
                }
            }
        }

        private void txtagregar_Click(object sender, EventArgs e)
        {
            decimal preciocompra = 0;
            decimal precioventa = 0;
            bool producto_existe = false;

            // 1. Validar que se haya seleccionado un producto (El ID no puede ser "0" ni estar vacío)
            if (string.IsNullOrEmpty(textIdproducto.Text) || textIdproducto.Text == "0")
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // 2. Validar que el Precio de Compra sea un número válido
            if (!decimal.TryParse(txtpreciocompras.Text, out preciocompra))
            {
                MessageBox.Show("Precio Compra - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpreciocompras.Select();
                return;
            }

            // 3. Validar que el Precio de Venta sea un número válido
            if (!decimal.TryParse(txtprecioventas.Text, out precioventa))
            {
                MessageBox.Show("Precio Venta - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtprecioventas.Select();
                return;
            }

            // 4. Verificar si el producto ya existe en el DataGridView
            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                // Aseguramos de no leer la fila nueva vacía que a veces pone el grid abajo
                if (fila.Cells["CIDproducto"].Value != null)
                {
                    if (fila.Cells["CIDproducto"].Value.ToString() == textIdproducto.Text)
                    {
                        producto_existe = true;
                        break;
                    }
                }
            }

            if (!producto_existe)
            {
                // 5. Calculamos el Subtotal (Cantidad * PrecioCompra)
                decimal subtotal = Convert.ToDecimal(txtcantida.Value) * preciocompra;

                // 6. Agregamos TODA la información a tu DataGridView
                dgvdata.Rows.Add(new object[] {
            textIdproducto.Text,
            txtProductos.Text,
            preciocompra.ToString("N0"),
            precioventa.ToString("N0"),
            txtcantida.Value.ToString(),
            txtnrolote.Text,
            dtpfechavencimiento.Value.ToString("dd/MM/yyyy"),
            subtotal.ToString("N0"),
            ""
        });

                // 7. Actualizamos el Total a Pagar general (Llamamos a la función)
                calcularTotal();

                // 8. Limpiamos las cajitas de texto de arriba para buscar el siguiente (Llamamos a la función)
                limpiarCajasProducto();
            }
            else
            {
                MessageBox.Show("El producto ya existe en la lista. Si desea agregar más, elimínelo y vuelva a agregarlo con la cantidad correcta.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void calcularTotal()
        {
            decimal total = 0;

            // Recorremos todas las filas que están en la tabla
            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    // Borramos el espacio extra, dejamos exactamente "CSubTotal"
                    if (row.Cells["CSubTotal"].Value != null)
                    {
                        total += Convert.ToDecimal(row.Cells["CSubTotal"].Value);
                    }
                }
            }

            // Mostramos el total en la caja de texto
            txttotalpagar.Text = total.ToString("N0");
        }
        private void limpiarCajasProducto()
        {
            // Limpiamos todo para que la pantalla quede lista para pistolear o escribir el siguiente código
            textIdproducto.Text = "0";
            txtcodigoproducto.Text = "";
            txtcodigoproducto.BackColor = Color.White; // Le quitamos el fondo verde o rojo
            txtProductos.Text = "";
            txtpreciocompras.Text = "";
            txtprecioventas.Text = "";

            // Regresamos la cantidad a 1
            txtcantida.Value = 1;

            // Limpiamos el lote y devolvemos la fecha a la actual
            txtnrolote.Text = "";
            dtpfechavencimiento.Value = DateTime.Now;

            // Mandamos el cursor directo al código del producto
            txtcodigoproducto.Select();
        }
        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // 1. Evitamos que dé error al pintar los títulos y el margen izquierdo
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            // 2. Apuntamos a la columna de eliminar
            if (dgvdata.Columns[e.ColumnIndex].Name == "btneliminae")
            {
                // ¡LA SOLUCIÓN ESTÁ AQUÍ! 
                // 3. Verificamos si la fila que se está pintando es la fila vacía del final.
                // Si es la fila vacía, usamos 'return' para salir y no dibujar el basurero.
                if (e.RowIndex == dgvdata.NewRowIndex)
                {
                    return;
                }

                // Pinta el fondo y los bordes normales de la celda
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Tomamos el ancho y alto de tu imagen
                var w = Properties.Resources.eliminar.Width;
                var h = Properties.Resources.eliminar.Height;

                // Matemáticas para calcular el centro exacto de la celda
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                // Dibujamos la imagen exactamente en ese centro
                e.Graphics.DrawImage(Properties.Resources.eliminar, new Rectangle(x, y, w, h));

                // Le decimos a Windows que ya terminamos de pintar esta celda
                e.Handled = true;
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Si hacen clic por accidente en los títulos grises de arriba, ignoramos para que no dé error
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgvdata.Columns[e.ColumnIndex].Name == "btneliminae")
            {
                // 3. Borramos la fila exacta en la que el cajero hizo clic
                dgvdata.Rows.RemoveAt(e.RowIndex);

                // 4. Como quitamos un producto del carrito, volvemos a calcular el total a pagar
                calcularTotal();
            }
        }

        private void txtpreciocompras_TextChanged(object sender, EventArgs e)
        {
            if (txtpreciocompras.Text == "") return;

            // Pausamos temporalmente el evento para evitar bucles infinitos
            txtpreciocompras.TextChanged -= txtpreciocompras_TextChanged;

            // Quitamos cualquier punto anterior para limpiar el número real
            string numeroLimpio = txtpreciocompras.Text.Replace(".", "").Replace(",", "");

            // Si es un número válido, le aplicamos el formato con separador de miles
            if (decimal.TryParse(numeroLimpio, out decimal numero))
            {
                txtpreciocompras.Text = numero.ToString("N0");
                txtpreciocompras.Select(txtpreciocompras.Text.Length, 0); // Mantiene el cursor al final
            }

            // Volvemos a activar el evento
            txtpreciocompras.TextChanged += txtpreciocompras_TextChanged;
        }

        private void txtpreciocompras_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Bloquea cualquier tecla que no sea un número o la tecla de borrar
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtprecioventas_TextChanged(object sender, EventArgs e)
        {
            // Si la caja está vacía, no hacemos nada
            if (txtprecioventas.Text == "") return;

            // Pausamos el evento temporalmente
            txtprecioventas.TextChanged -= txtprecioventas_TextChanged;

            // Limpiamos los puntos ocultos
            string numeroLimpio = txtprecioventas.Text.Replace(".", "").Replace(",", "");

            // Aplicamos el formato automático de miles (ej: 15000 a 15.000)
            if (decimal.TryParse(numeroLimpio, out decimal numero))
            {
                txtprecioventas.Text = numero.ToString("N0");
                txtprecioventas.Select(txtprecioventas.Text.Length, 0); // Dejamos el cursor al final
            }

            // Volvemos a activar el evento
            txtprecioventas.TextChanged += txtprecioventas_TextChanged;
        }

        private void txtprecioventas_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitimos usar la tecla borrar y escribir números. Bloqueamos letras y símbolos.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtnrolote_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitimos ingresar números y usar la tecla de borrar. 
            // No dejamos escribir letras porque el sistema pondrá la palabra "LOTE-" automáticamente.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtnrolote_TextChanged(object sender, EventArgs e)
        {
            // 1. Si la caja está vacía, no hacemos nada
            if (txtnrolote.Text == "") return;

            // 2. Apagamos el evento temporalmente para que no se congele la pantalla
            txtnrolote.TextChanged -= txtnrolote_TextChanged;

            // 3. Limpiamos la palabra "LOTE-" por si ya estaba escrita, 
            // así nos quedamos SOLO con los números nuevos que vas tecleando.
            string numerosLimpio = txtnrolote.Text.Replace("LOTE-", "").Trim();

            // 4. Si realmente quedó algún número escrito, le pegamos el "LOTE-" adelante
            if (numerosLimpio.Length > 0)
            {
                txtnrolote.Text = "LOTE-" + numerosLimpio;

                // 5. Mandamos el cursor al final de la palabra 
                // para que puedas seguir escribiendo el resto de los números sin que el cursor salte.
                txtnrolote.Select(txtnrolote.Text.Length, 0);
            }
            else
            {
                // Si borraste todos los números con la tecla borrar, limpiamos la caja completa
                txtnrolote.Text = "";
            }

            // 6. Volvemos a encender el evento
            txtnrolote.TextChanged += txtnrolote_TextChanged;
        }

        private void txtTipodocumentos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textregistra_Click(object sender, EventArgs e)
        {
            // 1. Validar que exista un proveedor seleccionado
            if (txtIdProveedor.Text == "" || txtIdProveedor.Text == "0")
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // 2. Validar que el número de factura esté cargado
            if (string.IsNullOrWhiteSpace(txtNumeroFactura.Text))
            {
                MessageBox.Show("Debe ingresar el número de factura", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNumeroFactura.Select();
                return;
            }

            // 3. Validar que la grilla tenga productos cargados
            if (dgvdata.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar productos en el detalle", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // 4. Crear el DataTable con la estructura exacta del TYPE de SQL
            DataTable dtDetalle = new DataTable();
            dtDetalle.Columns.Add("IdProducto", typeof(int));
            dtDetalle.Columns.Add("PrecioCompra", typeof(decimal));
            dtDetalle.Columns.Add("PrecioVenta", typeof(decimal));
            dtDetalle.Columns.Add("Cantidad", typeof(int));
            dtDetalle.Columns.Add("SubTotal", typeof(decimal));
            dtDetalle.Columns.Add("NroLote", typeof(string));
            dtDetalle.Columns.Add("FechaVencimiento", typeof(string));

            // 5. Recorrer el DataGridView para armar la tabla
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.Cells["CIDproducto"].Value != null && row.Cells["CIDproducto"].Value.ToString() != "")
                {
                    string fechaOriginal = row.Cells["CFechaVencimiento"].Value.ToString();
                    string fechaParaSQL = "";

                    if (!string.IsNullOrEmpty(fechaOriginal))
                    {
                        fechaParaSQL = Convert.ToDateTime(fechaOriginal).ToString("yyyy-MM-dd");
                    }

                    dtDetalle.Rows.Add(
                        Convert.ToInt32(row.Cells["CIDproducto"].Value),
                        Convert.ToDecimal(row.Cells["CPrecioCompra"].Value),
                        Convert.ToDecimal(row.Cells["CPrecioVenta"].Value),
                        Convert.ToInt32(row.Cells["CCantidad"].Value),
                        Convert.ToDecimal(row.Cells["CSubTotal"].Value),
                        row.Cells["CNroLote"].Value.ToString(),
                        fechaParaSQL
                    );
                }
            }

            // 6. Crear el objeto Compra (Cabecera)
            Compra oCompra = new Compra()
            {
                oUsuario = new Usuario() { IdUsuario = _UsuarioActual.IdUsuario },
                oProveedor = new Proveedor() { IdProveedor = Convert.ToInt32(txtIdProveedor.Text) },
                TipoDocumento = txtTipodocumentos.SelectedItem.ToString(),
                NumeroDocumento = txtNumeroFactura.Text,
                MontoTotal = Convert.ToDecimal(txttotalpagar.Text)
            };

            string mensaje = string.Empty;

            // 7. Enviar a la Capa de Negocio
            bool respuesta = new CN_Compra().Registrar(oCompra, dtDetalle, out mensaje);

            // 8. Mostrar el resultado
            if (respuesta)
            {
                MessageBox.Show("¡Compra registrada exitosamente!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvdata.Rows.Clear();
                txttotalpagar.Text = "0";
                txtIdProveedor.Text = "";
                txtNumerodocumento.Text = "";
                txtrazonsocial.Text = "";
                txtNumeroFactura.Text = "";
            }
            else
            {
                MessageBox.Show("No se pudo registrar la compra: \n" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btdetallecompra_Click(object sender, EventArgs e)
        {
            // 1. Creamos una variable del formulario que queremos abrir
            Form_DetalleCompras frmDetalle = new Form_DetalleCompras();

            // 2. Le decimos que aparezca centrado en la pantalla (Opcional, pero se ve mejor)
            frmDetalle.StartPosition = FormStartPosition.CenterParent;

            // 3. Lo mostramos en pantalla como ventana emergente
            frmDetalle.ShowDialog();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtNumeroFactura_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            mdProductos frm = new mdProductos();
            frm.StartPosition = FormStartPosition.CenterParent;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                textIdproducto.Text = frm.ProductoSeleccionado.IdProducto.ToString();
                txtcodigoproducto.Text = frm.ProductoSeleccionado.Codigo;
                txtProductos.Text = frm.ProductoSeleccionado.Nombre;

                // Formato sin decimales, con separador de miles (ej: 8.500)
                txtpreciocompras.Text = frm.ProductoSeleccionado.PrecioCompra.ToString("N0");
                txtprecioventas.Text = frm.ProductoSeleccionado.PrecioVenta.ToString("N0");

                txtcantida.Select();
            }
        }
    }
}
