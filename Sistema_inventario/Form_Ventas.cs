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
using iTextSharp.text.pdf;
using System.IO;

namespace Sistema_inventario
{
    public partial class Form_Ventas : Form
    {
        // =========================================================
        // VARIABLES GLOBALES DEL FORMULARIO
        // =========================================================
        private Usuario _UsuarioActual;
        private int idClienteActual = 1; // 1 por defecto (Consumidor Final)

        // Lote elegido en mdProductoVentas para el producto que está en las cajas
        // de "Información de Productos", pendiente de agregar al carrito.
        private int _idDetalleCompraActual = 0;

        // =========================================================
        // CONSTRUCTOR DEL FORMULARIO
        // =========================================================
        public Form_Ventas(Usuario oUsuario)
        {
            InitializeComponent();
            _UsuarioActual = oUsuario;
        }

        // =========================================================
        // EVENTO: AL CARGAR EL FORMULARIO
        // =========================================================
        private void Form_Ventas_Load(object sender, EventArgs e)
        {
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.Add("Efectivo");
            cmbMetodoPago.Items.Add("Transferencia");
            cmbMetodoPago.SelectedIndex = 0;

            txtpagarcon.Text = "";
            txtcambio.Text = "";
            txttotalpagar.Text = "0";

            txtNumerodocumento.Text = "0";
            txtracliente.Text = "Consumidor Final";
            idClienteActual = 1;

            // El botón de imprimir ticket arranca bloqueado hasta que se marque el checkbox
            btnImprimirTicket.Enabled = false;
        }

        // =========================================================
        // BÚSQUEDA DE PRODUCTO MEDIANTE MODAL
        // =========================================================
        private void btnbusquedaproducto_Click(object sender, EventArgs e)
        {
            // mdProductoVentas es el formulario exclusivo para las ventas: ya lista
            // lotes (no productos agregados) y bloquea ahí mismo si un lote está
            // vencido, así que acá ya no hace falta re-validar el vencimiento.
            mdProductoVentas frm = new mdProductoVentas(_UsuarioActual);
            frm.StartPosition = FormStartPosition.CenterParent;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.ProductoSeleccionado != null)
                {
                    txidproducto.Text = frm.ProductoSeleccionado.IdProducto.ToString();
                    txtcodigoproducto.Text = frm.ProductoSeleccionado.Codigo;
                    txtProductos.Text = frm.ProductoSeleccionado.Nombre;
                    txtprecioventa.Text = frm.ProductoSeleccionado.PrecioVenta.ToString("N0");
                    txtpreciostock.Text = frm.ProductoSeleccionado.Stock.ToString();

                    // Guardamos qué lote exacto se eligió, para que viaje con esta línea
                    // del carrito hasta el registro final de la venta.
                    _idDetalleCompraActual = frm.IdDetalleCompraSeleccionado;

                    txtcantida.Select();
                }
            }
        }

        // =========================================================
        // BÚSQUEDA DE CLIENTE MEDIANTE MODAL
        // =========================================================
        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            md frm = new md();
            frm.StartPosition = FormStartPosition.CenterParent;

            if (frm.ShowDialog() == DialogResult.OK && frm.ClienteSeleccionado != null)
            {
                // Guardamos el ID real en la variable global
                idClienteActual = frm.ClienteSeleccionado.IdCliente;
                txtNumerodocumento.Text = frm.ClienteSeleccionado.Documento;
                txtracliente.Text = frm.ClienteSeleccionado.NombreCompleto;
            }
            else
            {
                // Si no selecciona nada, se mantiene como Consumidor Final (ID 1)
                idClienteActual = 1;
                txtNumerodocumento.Text = "0";
                txtracliente.Text = "Consumidor Final";
            }
        }

        // =========================================================
        // CREACIÓN DEL OBJETO VENTA
        // =========================================================
        private Venta GetOVenta()
        {
            return new Venta()
            {
                oUsuario = new Usuario() { IdUsuario = _UsuarioActual.IdUsuario },
                IdCliente = idClienteActual, // Usamos directamente la variable global
                MetodoPago = cmbMetodoPago.SelectedItem.ToString(),
                Ticket = "TK-" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                MontoRecibido = Convert.ToDecimal(txtpagarcon.Text == "" ? "0" : txtpagarcon.Text.Replace(".", "")),
                MontoCambio = Convert.ToDecimal(txtcambio.Text == "" ? "0" : txtcambio.Text.Replace(".", "")),
                MontoTotal = Convert.ToDecimal(txttotalpagar.Text == "" ? "0" : txttotalpagar.Text.Replace(".", ""))
            };
        }

        // =========================================================
        // BOTÓN AZUL: AGREGAR PRODUCTO A LA GRILLA (CARRITO)
        // =========================================================
        private void txtagregar_Click(object sender, EventArgs e)
        {
            decimal precioventa = 0;
            bool producto_existe = false;

            // 1. Validar que se haya seleccionado un producto
            if (string.IsNullOrEmpty(txidproducto.Text) || txidproducto.Text == "0")
            {
                MessageBox.Show("Debe seleccionar un producto.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // 2. Validar formato de precio
            string precioLimpio = txtprecioventa.Text.Replace(".", "").Replace(",", "");
            if (!decimal.TryParse(precioLimpio, out precioventa))
            {
                MessageBox.Show("Precio Venta - Formato moneda incorrecto.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // 3. Validar stock disponible
            int stockDisponible = Convert.ToInt32(txtpreciostock.Text);
            int cantidadPedida = Convert.ToInt32(txtcantida.Value);

            if (cantidadPedida > stockDisponible)
            {
                MessageBox.Show("La cantidad ingresada supera el stock disponible (" + stockDisponible + " unidades).", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Verificar duplicados en la grilla
            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                if (fila.Cells["CIDproducto"].Value != null)
                {
                    if (fila.Cells["CIDproducto"].Value.ToString() == txidproducto.Text)
                    {
                        producto_existe = true;
                        break;
                    }
                }
            }

            // 5. Si no existe, se agrega a la tabla
            if (!producto_existe)
            {
                decimal subtotal = cantidadPedida * precioventa;

                dgvdata.Rows.Add(new object[] {
                    txidproducto.Text,
                    txtProductos.Text,
                    precioventa.ToString("N0"),
                    cantidadPedida.ToString(),
                    subtotal.ToString("N0"),
                    _idDetalleCompraActual.ToString(),
                    ""
                });

                calcularTotal();
                limpiarCajasProducto();
            }
            else
            {
                MessageBox.Show("El producto ya existe en la lista. Si desea agregar más, elimínelo y vuelva a agregarlo con la cantidad correcta.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // =========================================================
        // FUNCIONES AUXILIARES (Cálculos y Limpieza)
        // =========================================================
        private void calcularTotal()
        {
            decimal total = 0;
            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells["CSubTotal"].Value != null)
                    {
                        string subTotalLimpio = row.Cells["CSubTotal"].Value.ToString().Replace(".", "").Replace(",", "");
                        total += Convert.ToDecimal(subTotalLimpio);
                    }
                }
            }
            txttotalpagar.Text = total.ToString("N0");
        }

        private void limpiarCajasProducto()
        {
            txidproducto.Text = "0";
            txtcodigoproducto.Text = "";
            txtcodigoproducto.BackColor = Color.White;
            txtProductos.Text = "";
            txtprecioventa.Text = "";
            txtpreciostock.Text = "";
            txtcantida.Value = 1;
            _idDetalleCompraActual = 0;
            txtcodigoproducto.Select();
        }

        private void txtpagarcon_TextChanged(object sender, EventArgs e)
        {
            // Evita que el auto-formateo dispare este mismo evento en bucle
            txtpagarcon.TextChanged -= txtpagarcon_TextChanged;

            int cursorPos = txtpagarcon.SelectionStart;
            int largoAnterior = txtpagarcon.Text.Length;

            // Se queda solo con los dígitos que el usuario escribió (ignora puntos/comas ya puestos)
            string soloDigitos = new string(txtpagarcon.Text.Where(char.IsDigit).ToArray());

            if (string.IsNullOrEmpty(soloDigitos))
            {
                txtpagarcon.Text = "";
                txtcambio.Text = "0";
                txtpagarcon.TextChanged += txtpagarcon_TextChanged;
                return;
            }

            decimal montoPago = Convert.ToDecimal(soloDigitos);

            // Formatea con separador de miles EN VIVO mientras se escribe
            string textoFormateado = montoPago.ToString("N0");
            txtpagarcon.Text = textoFormateado;

            // Reposiciona el cursor para que no salte al final al insertar el separador
            int largoNuevo = textoFormateado.Length;
            int nuevaPosicion = cursorPos + (largoNuevo - largoAnterior);
            txtpagarcon.SelectionStart = Math.Max(0, Math.Min(nuevaPosicion, textoFormateado.Length));

            txtpagarcon.TextChanged += txtpagarcon_TextChanged;

            string totalLimpio = txttotalpagar.Text.Replace(".", "").Replace(",", "");

            if (decimal.TryParse(totalLimpio, out decimal montoTotal))
            {
                decimal cambio = montoPago - montoTotal;
                txtcambio.Text = cambio >= 0 ? cambio.ToString("N0") : "0";
            }
            else
            {
                txtcambio.Text = "0";
            }
        }

        // =========================================================
        // BOTÓN "X" DE LA GRILLA: ELIMINAR PRODUCTO DEL CARRITO DE VENTA
        // =========================================================
        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Si hacen clic por accidente en los títulos grises de arriba, ignoramos para que no dé error
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgvdata.Columns[e.ColumnIndex].Name == "btneliminae")
            {
                // 2. Borramos la fila exacta en la que el cajero hizo clic
                dgvdata.Rows.RemoveAt(e.RowIndex);

                // 3. Como quitamos un producto del carrito, volvemos a calcular el total a pagar
                calcularTotal();
            }
        }

        // =========================================================
        // EVENTOS VACÍOS DEL DISEÑADOR
        // =========================================================
        private void txtfecha_TextChanged(object sender, EventArgs e) { }
        private void txtTipodocumentos_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtracliente_TextChanged(object sender, EventArgs e) { }
        private void txtprecioventa_TextChanged(object sender, EventArgs e) { }
        private void txtpreciostock_TextChanged(object sender, EventArgs e) { }
        private void txtProductos_TextChanged(object sender, EventArgs e) { }
        private void txtcodigoproducto_TextChanged(object sender, EventArgs e) { }
        private void gr_Enter(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void txidproducto_TextChanged(object sender, EventArgs e) { }
        private void txtIdcliente_TextChanged(object sender, EventArgs e) { }
        private void txtcambio_TextChanged(object sender, EventArgs e) { }
        private void txttotalpagar_TextChanged(object sender, EventArgs e) { }

        // =========================================================
        // BOTÓN VERDE: REGISTRAR VENTA EN LA BASE DE DATOS
        // =========================================================
        // =========================================================
        // BOTÓN VERDE: REGISTRAR VENTA EN LA BASE DE DATOS
        // =========================================================
        private void txtagregar_Click_1(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto a la venta.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(txtpagarcon.Text))
            {
                MessageBox.Show("Aún no ingresó el monto con el que paga el cliente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpagarcon.Focus();
                return;
            }

            if (Convert.ToDecimal(txtpagarcon.Text.Replace(".", "")) < Convert.ToDecimal(txttotalpagar.Text.Replace(".", "")))
            {
                MessageBox.Show("El monto con el que paga es menor al total a pagar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpagarcon.Focus();
                return;
            }

            DataTable dtDetalle = new DataTable();
            dtDetalle.Columns.Add("IdProducto", typeof(int));
            dtDetalle.Columns.Add("PrecioVenta", typeof(decimal));
            dtDetalle.Columns.Add("Cantidad", typeof(int));
            dtDetalle.Columns.Add("SubTotal", typeof(decimal));
            dtDetalle.Columns.Add("IdDetalleCompra", typeof(int));

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                // Validar que la fila tenga un ID de producto válido en la grilla
                if (row.Cells["CIDproducto"].Value != null && row.Cells["CIDproducto"].Value.ToString() != "")
                {
                    string precioLimpio = row.Cells["CPrecioVenta"].Value.ToString().Replace(".", "").Replace(",", "");
                    string subTotalLimpio = row.Cells["CSubTotal"].Value.ToString().Replace(".", "").Replace(",", "");

                    int idDetalleCompra = 0;
                    if (row.Cells["CIdDetalleCompra"].Value != null && int.TryParse(row.Cells["CIdDetalleCompra"].Value.ToString(), out int parsedDetalle))
                    {
                        idDetalleCompra = parsedDetalle;
                    }

                    dtDetalle.Rows.Add(
                        Convert.ToInt32(row.Cells["CIDproducto"].Value),
                        Convert.ToDecimal(precioLimpio),
                        Convert.ToInt32(row.Cells["CCantidad"].Value),
                        Convert.ToDecimal(subTotalLimpio),
                        idDetalleCompra
                    );
                }
            }

            // Asegurarse de que el DataTable tenga elementos antes de enviar a la capa de negocio
            if (dtDetalle.Rows.Count == 0)
            {
                MessageBox.Show("No hay detalles de productos válidos para registrar en la venta.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Venta oVenta = GetOVenta();
            string mensaje = string.Empty;

            bool respuesta = new CN_Venta().Registrar(oVenta, dtDetalle, out mensaje);

            if (respuesta)
            {
                MessageBox.Show("¡Venta registrada exitosamente!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvdata.Rows.Clear();
                txtNumerodocumento.Text = "0";
                txtracliente.Text = "Consumidor Final";
                idClienteActual = 1;
                txtpagarcon.Text = "";
                txtcambio.Text = "";
                txttotalpagar.Text = "0";
                cmbMetodoPago.SelectedIndex = 0;
                chkGenerarTicket.Checked = false;
                btnImprimirTicket.Enabled = false;
            }
            else
            {
                if (mensaje.Contains("CHK_Producto_StockNoNegativo"))
                {
                    MessageBox.Show("No hay suficiente stock para vender esta cantidad. Solo disponible lo que marca el sistema (0).", "Sin Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar registrar la venta:\n\n" + mensaje, "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =========================================================
        // CHECKBOX: ¿GENERAR E IMPRIMIR TICKET?
        // =========================================================
        private void chkGenerarTicket_CheckedChanged(object sender, EventArgs e)
        {
            // El ticket no exige identificar al cliente — sigue pudiendo quedar
            // como Consumidor Final. groupBox1 queda disponible por si el cajero
            // igual quiere cargar los datos del cliente, pero no es obligatorio.
            groupBox1.Enabled = true;

            // Solo se puede imprimir si el cajero marcó que quiere ticket
            btnImprimirTicket.Enabled = chkGenerarTicket.Checked;
        }

        // =========================================================
        // BOTÓN: IMPRIMIR TICKET (impresora física o PDF)
        // =========================================================
        private void btnImprimirTicket_Click(object sender, EventArgs e)
        {
            if (!chkGenerarTicket.Checked)
            {
                MessageBox.Show("Debe marcar \"¿Generar e imprimir ticket?\" antes de imprimir.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgvdata.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos cargados para imprimir el ticket.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(txtpagarcon.Text))
            {
                MessageBox.Show("Aún no ingresó el monto con el que paga el cliente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpagarcon.Focus();
                return;
            }

            if (Convert.ToDecimal(txtpagarcon.Text.Replace(".", "")) < Convert.ToDecimal(txttotalpagar.Text.Replace(".", "")))
            {
                MessageBox.Show("El monto con el que paga es menor al total a pagar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpagarcon.Focus();
                return;
            }

            Negocio oNegocio = new CN_Negocio().ObtenerDatos();

            DialogResult tienePrinter = MessageBox.Show(
                "¿Tiene una impresora conectada y lista para imprimir el ticket?",
                "Imprimir Ticket",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (tienePrinter == DialogResult.Yes)
            {
                System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
                doc.PrintPage += (s, ev) => ImprimirTicket_PrintPage(ev, oNegocio);

                PrintPreviewDialog preview = new PrintPreviewDialog();
                preview.Document = doc;
                preview.Width = 420;
                preview.Height = 650;
                preview.ShowDialog();
            }
            else
            {
                GenerarTicketPdf(oNegocio);
            }
        }

        // =========================================================
        // IMPRESIÓN FÍSICA DEL TICKET (GDI)
        // =========================================================
        private void ImprimirTicket_PrintPage(System.Drawing.Printing.PrintPageEventArgs e, Negocio oNegocio)
        {
            Font fontTitulo = new Font("Consolas", 11, FontStyle.Bold);
            Font fontNormal = new Font("Consolas", 9);
            Font fontNegrita = new Font("Consolas", 9, FontStyle.Bold);

            float y = 10;
            float anchoTicket = 280; // Aprox 80mm
            float margenDerecho = anchoTicket - 10;

            StringFormat formatoDerecha = new StringFormat() { Alignment = StringAlignment.Far };

            void EscribirCentrado(string texto, Font font)
            {
                float ancho = e.Graphics.MeasureString(texto, font).Width;
                e.Graphics.DrawString(texto, font, Brushes.Black, (anchoTicket - ancho) / 2, y);
                y += font.GetHeight() + 2;
            }

            void DibujarLinea()
            {
                y += 3;
                e.Graphics.DrawLine(Pens.Black, 5, y, margenDerecho, y);
                y += 5;
            }

            // --- CABECERA ---
            EscribirCentrado(string.IsNullOrEmpty(oNegocio.Nombre) ? "MI NEGOCIO" : oNegocio.Nombre, fontTitulo);
            if (!string.IsNullOrEmpty(oNegocio.RUC)) EscribirCentrado("RUC: " + oNegocio.RUC, fontNormal);
            if (!string.IsNullOrEmpty(oNegocio.Direccion)) EscribirCentrado(oNegocio.Direccion, fontNormal);

            DibujarLinea();
            e.Graphics.DrawString("Fecha: " + txtfecha.Text, fontNormal, Brushes.Black, 5, y); y += fontNormal.GetHeight();
            e.Graphics.DrawString("Cliente: " + txtracliente.Text, fontNormal, Brushes.Black, 5, y); y += fontNormal.GetHeight();
            DibujarLinea();

            // --- ENCABEZADOS DE COLUMNA ---
            e.Graphics.DrawString("CANT  DESCRIPCIÓN", fontNegrita, Brushes.Black, 5, y);
            e.Graphics.DrawString("TOTAL", fontNegrita, Brushes.Black, margenDerecho, y, formatoDerecha);
            y += fontNegrita.GetHeight() + 2;

            // --- DETALLE DE PRODUCTOS ---
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.Cells["CProducto"].Value != null)
                {
                    string nombre = Truncar(row.Cells["CProducto"].Value.ToString(), 18);
                    string cantidad = row.Cells["CCantidad"].Value.ToString().PadRight(4);
                    string subtotal = row.Cells["CSubTotal"].Value.ToString();

                    e.Graphics.DrawString(cantidad + " " + nombre, fontNormal, Brushes.Black, 5, y);
                    e.Graphics.DrawString(subtotal, fontNormal, Brushes.Black, margenDerecho, y, formatoDerecha);
                    y += fontNormal.GetHeight() + 2;
                }
            }

            DibujarLinea();

            // --- TOTALES ---
            e.Graphics.DrawString("Método de pago: " + cmbMetodoPago.SelectedItem?.ToString(), fontNormal, Brushes.Black, 5, y);
            y += fontNormal.GetHeight() + 5;

            e.Graphics.DrawString("TOTAL:", fontTitulo, Brushes.Black, 5, y);
            e.Graphics.DrawString(txttotalpagar.Text, fontTitulo, Brushes.Black, margenDerecho, y, formatoDerecha);
            y += fontTitulo.GetHeight() + 2;

            e.Graphics.DrawString("Paga con:", fontNormal, Brushes.Black, 5, y);
            e.Graphics.DrawString(txtpagarcon.Text, fontNormal, Brushes.Black, margenDerecho, y, formatoDerecha);
            y += fontNormal.GetHeight() + 2;

            e.Graphics.DrawString("Cambio:", fontNormal, Brushes.Black, 5, y);
            e.Graphics.DrawString(txtcambio.Text, fontNormal, Brushes.Black, margenDerecho, y, formatoDerecha);
            y += fontNormal.GetHeight() + 10;

            EscribirCentrado("¡Gracias por su compra!", fontNormal);
        }

        // =========================================================
        // GENERACIÓN DEL TICKET EN PDF (iTextSharp)
        // =========================================================
        private void GenerarTicketPdf(Negocio oNegocio)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Archivo PDF|*.pdf";
            dlg.FileName = "Ticket_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                // Altura dinámica: 300 base + 15 por cada producto
                float alturaDinamica = 300f + (dgvdata.Rows.Count * 15f);
                iTextSharp.text.Document documentoPdf = new iTextSharp.text.Document(new iTextSharp.text.Rectangle(226f, alturaDinamica), 10, 10, 10, 10);

                using (FileStream fs = new FileStream(dlg.FileName, FileMode.Create))
                {
                    iTextSharp.text.pdf.PdfWriter.GetInstance(documentoPdf, fs);
                    documentoPdf.Open();

                    iTextSharp.text.Font fontTitulo = iTextSharp.text.FontFactory.GetFont("Courier", 11, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font fontNormal = iTextSharp.text.FontFactory.GetFont("Courier", 9);
                    iTextSharp.text.Font fontNegrita = iTextSharp.text.FontFactory.GetFont("Courier", 9, iTextSharp.text.Font.BOLD);

                    iTextSharp.text.pdf.PdfPCell CrearCelda(string texto, iTextSharp.text.Font fuente, int alineacion)
                    {
                        return new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(texto, fuente)) { Border = 0, HorizontalAlignment = alineacion };
                    }

                    // --- CABECERA ---
                    documentoPdf.Add(new iTextSharp.text.Paragraph(string.IsNullOrEmpty(oNegocio.Nombre) ? "MI NEGOCIO" : oNegocio.Nombre, fontTitulo) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                    if (!string.IsNullOrEmpty(oNegocio.RUC)) documentoPdf.Add(new iTextSharp.text.Paragraph("RUC: " + oNegocio.RUC, fontNormal) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                    if (!string.IsNullOrEmpty(oNegocio.Direccion)) documentoPdf.Add(new iTextSharp.text.Paragraph(oNegocio.Direccion, fontNormal) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                    documentoPdf.Add(new iTextSharp.text.Paragraph("-----------------------------------", fontNormal));
                    documentoPdf.Add(new iTextSharp.text.Paragraph("Fecha: " + txtfecha.Text, fontNormal));
                    documentoPdf.Add(new iTextSharp.text.Paragraph("Cliente: " + txtracliente.Text, fontNormal));
                    documentoPdf.Add(new iTextSharp.text.Paragraph("-----------------------------------", fontNormal));

                    // --- TABLA DE PRODUCTOS ---
                    iTextSharp.text.pdf.PdfPTable tablaItems = new iTextSharp.text.pdf.PdfPTable(3) { WidthPercentage = 100 };
                    tablaItems.SetWidths(new float[] { 1f, 3f, 1.5f });

                    tablaItems.AddCell(CrearCelda("CANT", fontNegrita, iTextSharp.text.Element.ALIGN_LEFT));
                    tablaItems.AddCell(CrearCelda("DESC", fontNegrita, iTextSharp.text.Element.ALIGN_LEFT));
                    tablaItems.AddCell(CrearCelda("TOTAL", fontNegrita, iTextSharp.text.Element.ALIGN_RIGHT));

                    foreach (DataGridViewRow row in dgvdata.Rows)
                    {
                        if (row.Cells["CProducto"].Value != null)
                        {
                            tablaItems.AddCell(CrearCelda(row.Cells["CCantidad"].Value.ToString(), fontNormal, iTextSharp.text.Element.ALIGN_LEFT));
                            tablaItems.AddCell(CrearCelda(Truncar(row.Cells["CProducto"].Value.ToString(), 18), fontNormal, iTextSharp.text.Element.ALIGN_LEFT));
                            tablaItems.AddCell(CrearCelda(row.Cells["CSubTotal"].Value.ToString(), fontNormal, iTextSharp.text.Element.ALIGN_RIGHT));
                        }
                    }
                    documentoPdf.Add(tablaItems);

                    documentoPdf.Add(new iTextSharp.text.Paragraph("----------------------------------------", fontNormal));

                    // --- TABLA DE TOTALES ---
                    iTextSharp.text.pdf.PdfPTable tablaTotales = new iTextSharp.text.pdf.PdfPTable(2) { WidthPercentage = 100 };
                    tablaTotales.SetWidths(new float[] { 2f, 1f });

                    tablaTotales.AddCell(CrearCelda("Método: " + cmbMetodoPago.SelectedItem?.ToString(), fontNormal, iTextSharp.text.Element.ALIGN_LEFT));
                    tablaTotales.AddCell(CrearCelda("", fontNormal, iTextSharp.text.Element.ALIGN_RIGHT));

                    tablaTotales.AddCell(CrearCelda("TOTAL:", fontTitulo, iTextSharp.text.Element.ALIGN_LEFT));
                    tablaTotales.AddCell(CrearCelda(txttotalpagar.Text, fontTitulo, iTextSharp.text.Element.ALIGN_RIGHT));

                    tablaTotales.AddCell(CrearCelda("Paga con:", fontNormal, iTextSharp.text.Element.ALIGN_LEFT));
                    tablaTotales.AddCell(CrearCelda(txtpagarcon.Text, fontNormal, iTextSharp.text.Element.ALIGN_RIGHT));

                    tablaTotales.AddCell(CrearCelda("Cambio:", fontNormal, iTextSharp.text.Element.ALIGN_LEFT));
                    tablaTotales.AddCell(CrearCelda(txtcambio.Text, fontNormal, iTextSharp.text.Element.ALIGN_RIGHT));

                    documentoPdf.Add(tablaTotales);

                    documentoPdf.Add(new iTextSharp.text.Paragraph("\n¡Gracias por su compra!", fontNormal) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });

                    documentoPdf.Close();
                }

                if (MessageBox.Show("Ticket guardado como PDF. ¿Desea abrirlo?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(dlg.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Truncar(string texto, int max)
        {
            return texto.Length <= max ? texto : texto.Substring(0, max);
        }
    }
}