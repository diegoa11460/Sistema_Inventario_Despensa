using CapaEntidad;
using CapaNegocio;
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;

namespace Sistema_inventario
{
    public partial class Form_DetalleVentas : Form
    {
        public Form_DetalleVentas()
        {
            InitializeComponent();

            // btnlimpiar y btnExplorapdf no quedaron enganchados en el Designer
            this.btnlimpiar.Click += btnlimpiar_Click;
           
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            // 1. Si la caja de texto está VACÍA, abrimos el modal para que el empleado elija
            if (txtbuscarnumerodocumento.Text.Trim() == "")
            {
                using (var modal = new md_BusquedaVentas())
                {
                    var resultado = modal.ShowDialog();

                    // 2. Si el usuario realmente le dio doble clic a una fila...
                    if (resultado == DialogResult.OK)
                    {
                        // Pegamos el ticket en la caja de texto
                        txtbuscarnumerodocumento.Text = modal._Ticket;

                        // 3. Ejecutamos la búsqueda AQUÍ ADENTRO
                        BuscarVenta();
                    }
                }
            }
            else
            {
                // 4. Si la caja YA TIENE UN TICKET (porque el empleado lo escribió a mano),
                // saltamos el modal y buscamos directamente.
                BuscarVenta();
            }
        }

        private void BuscarVenta()
        {
            string mensaje;
            Venta oVenta = new CN_Venta().ObtenerVenta(txtbuscarnumerodocumento.Text, out mensaje);

            if (oVenta.IdVenta != 0)
            {
                System.Globalization.CultureInfo cultura = System.Globalization.CultureInfo.GetCultureInfo("es-PY");

                txtfecha.Text = oVenta.FechaRegistro;
                txttipodocumento.Text = oVenta.MetodoPago;
                txtticketventa.Text = oVenta.Ticket;
                txtdocumentocliente.Text = oVenta.oCliente != null ? oVenta.oCliente.Documento : "0";
                txtnombrecliente.Text = oVenta.oCliente != null ? oVenta.oCliente.NombreCompleto : "Consumidor Final";

                if (oVenta.oUsuario != null && oVenta.oUsuario.oRol != null)
                {
                    txtusuario.Text = oVenta.oUsuario.oRol.Descripcion + " - " + oVenta.oUsuario.NombreCompleto;
                }
                else if (oVenta.oUsuario != null)
                {
                    txtusuario.Text = oVenta.oUsuario.NombreCompleto;
                }
                else
                {
                    txtusuario.Text = "Desconocido";
                }

                txtpagocon.Text = oVenta.MontoRecibido.ToString("N0", cultura);
                txtcambio.Text = oVenta.MontoCambio.ToString("N0", cultura);
                txmontototal.Text = oVenta.MontoTotal.ToString("N0", cultura);

                txttabladetalleventa.Rows.Clear();

                if (oVenta.oDetalleVenta != null)
                {
                    foreach (DetalleVenta dv in oVenta.oDetalleVenta)
                    {
                        int n = txttabladetalleventa.Rows.Add();
                        DataGridViewRow fila = txttabladetalleventa.Rows[n];

                        fila.Cells["CIDproducto"].Value = dv.oProducto.IdProducto;
                        fila.Cells["CProducto"].Value = dv.oProducto.Nombre;
                        fila.Cells["CPrecioVenta"].Value = dv.PrecioVenta.ToString("N0", cultura);
                        fila.Cells["CCantidad"].Value = dv.Cantidad;
                        fila.Cells["CSubTotal"].Value = dv.SubTotal.ToString("N0", cultura);
                    }
                }
            }
            else
            {
                txtfecha.Text = "";
                txttipodocumento.Text = "";
                txtticketventa.Text = "";
                txtusuario.Text = "";
                txtdocumentocliente.Text = "";
                txtnombrecliente.Text = "";
                txtpagocon.Text = "0";
                txtcambio.Text = "0";
                txmontototal.Text = "0";
                txttabladetalleventa.Rows.Clear();

                // Si CD_Venta devolvió un mensaje, es un error real (conexión/consulta);
                // si vino vacío, simplemente no se encontró ese ticket.
                if (!string.IsNullOrEmpty(mensaje))
                {
                    MessageBox.Show("Error al buscar la venta: \n" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("No se encontró ninguna venta con ese ticket.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtbuscarnumerodocumento.Text = "";
            txtfecha.Text = "";
            txttipodocumento.Text = "";
            txtticketventa.Text = "";
            txtusuario.Text = "";
            txtdocumentocliente.Text = "";
            txtnombrecliente.Text = "";
            txtpagocon.Text = "0";
            txtcambio.Text = "0";
            txmontototal.Text = "0";
            txttabladetalleventa.Rows.Clear();

            txtbuscarnumerodocumento.Focus();
        }

        private void btnExplorapdf_Click_1(object sender, EventArgs e)
        {
            // 1. Verificamos que el usuario no intente descargar un ticket vacío
            if (txtticketventa.Text == "")
            {
                MessageBox.Show("No se encontraron resultados para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // 2. Leemos la plantilla HTML (Asegúrate de que la ruta sea correcta)
            string Texto_Html = Properties.Resources.PlantillaVenta.ToString();

            // 3. Obtenemos los datos del negocio (Si tienes una clase Negocio, puedes dejar esto. Si no, usa textos fijos)
            Negocio odatos = new CN_Negocio().ObtenerDatos();

            // 4. Reemplazamos las variables de la cabecera en el HTML
            Texto_Html = Texto_Html.Replace("@nombrenegocio", odatos.Nombre.ToUpper());
            Texto_Html = Texto_Html.Replace("@docnegocio", odatos.RUC);
            Texto_Html = Texto_Html.Replace("@direcnegocio", odatos.Direccion);

            Texto_Html = Texto_Html.Replace("@tipodocumento", txttipodocumento.Text.ToUpper());
            Texto_Html = Texto_Html.Replace("@numerodocumento", txtticketventa.Text); // Usamos el Ticket

            Texto_Html = Texto_Html.Replace("@doccliente", txtdocumentocliente.Text);
            Texto_Html = Texto_Html.Replace("@nombrecliente", txtnombrecliente.Text);
            Texto_Html = Texto_Html.Replace("@fecharegistro", txtfecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", txtusuario.Text);

            // 5. Creamos las filas de la tabla de productos leyendo el DataGridView
            string filas = string.Empty;
            foreach (DataGridViewRow row in txttabladetalleventa.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["CProducto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["CPrecioVenta"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["CCantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["CSubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Texto_Html = Texto_Html.Replace("@filas", filas);

            // 6. Reemplazamos los totales en la parte inferior
            Texto_Html = Texto_Html.Replace("@montototal", txmontototal.Text);
            Texto_Html = Texto_Html.Replace("@pagocon", txtpagocon.Text);
            Texto_Html = Texto_Html.Replace("@cambio", txtcambio.Text);

            // 7. Configuramos el cuadro de diálogo para guardar el PDF
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Venta_{0}.pdf", txtticketventa.Text); // Nombre por defecto del archivo
            savefile.Filter = "Pdf Files|*.pdf";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    // Creamos el documento PDF en tamaño A4
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // 8. Insertamos el Logo del negocio (Opcional, si falla puedes comentarlo)
                    bool obtenido = true;
                    byte[] byteimage = new CN_Negocio().ObtenerLogo(out obtenido);

                    if (obtenido)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteimage);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        pdfDoc.Add(img);
                    }

                    // 9. Convertimos el HTML procesado al PDF
                    using (StringReader sr = new StringReader(Texto_Html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                    MessageBox.Show("Documento Generado Exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // =========================================================
        // Stubs generados por el Designer (doble clic en cada control
        // crea automáticamente estos TextChanged/CellContentClick).
        // Se dejan vacíos a propósito, igual que en Form_DetalleCompras.
        // =========================================================
        private void Form_DetalleVentas_Load_1(object sender, EventArgs e) { }
        private void txtbuscarnumerodocumento_TextChanged(object sender, EventArgs e) { }
        private void txmontototal_TextChanged(object sender, EventArgs e) { }
        private void txttabladetalleventa_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtnombrecliente_TextChanged(object sender, EventArgs e) { }
        private void Idcliente_TextChanged(object sender, EventArgs e) { }
        private void txtdocumentocliente_TextChanged(object sender, EventArgs e) { }
        private void txtticketventa_TextChanged(object sender, EventArgs e) { }
        private void txtusuario_TextChanged(object sender, EventArgs e) { }
        private void txttipodocumento_TextChanged(object sender, EventArgs e) { }
        private void txtfecha_TextChanged(object sender, EventArgs e) { }
        private void txtpagocon_TextChanged(object sender, EventArgs e) { }
        private void txtcambio_TextChanged(object sender, EventArgs e) { }

       
    }
}