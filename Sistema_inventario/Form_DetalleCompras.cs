using CapaEntidad;
using CapaNegocio;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Sistema_inventario
{
    public partial class Form_DetalleCompras : Form
    {
        public Form_DetalleCompras()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            // 1. Si la caja de texto está VACÍA, abrimos el modal para que el empleado elija
            if (txtbuscarnumerodocumento.Text.Trim() == "")
            {
                using (var modal = new Modales.md_BusquedaCompra())
                {
                    var resultado = modal.ShowDialog();

                    // 2. Si el usuario realmente le dio doble clic a una fila...
                    if (resultado == DialogResult.OK)
                    {
                        // Pegamos el número en la caja de texto
                        txtbuscarnumerodocumento.Text = modal._NumeroDocumento;

                        // 3. Ejecutamos la búsqueda AQUÍ ADENTRO
                        BuscarCompra();
                    }
                }
            }
            else
            {
                // 4. Si la caja YA TIENE UN NÚMERO (porque el empleado lo escribió a mano), 
                // saltamos el modal y buscamos directamente.
                BuscarCompra();
            }
        }

        private void BuscarCompra()

        {

            Compra oCompra = new CN_Compra().ObtenerCompra(txtbuscarnumerodocumento.Text);

            if (oCompra.IdCompra != 0)
            {
                System.Globalization.CultureInfo cultura = System.Globalization.CultureInfo.GetCultureInfo("es-PY");

                txtfecha.Text = oCompra.FechaRegistro;
                txttipodocumento.Text = oCompra.TipoDocumento;
                txtdocumento.Text = oCompra.oProveedor.Documento;
                txtrazonsocial.Text = oCompra.oProveedor.RazonSocial;
                txtnumerocompra.Text = oCompra.NumeroDocumento;

                if (oCompra.oUsuario != null && oCompra.oUsuario.oRol != null)
                {
                    txtusuario.Text = oCompra.oUsuario.oRol.Descripcion + " - " + oCompra.oUsuario.NombreCompleto;
                }
                else if (oCompra.oUsuario != null)
                {
                    txtusuario.Text = oCompra.oUsuario.NombreCompleto;
                }
                else
                {
                    txtusuario.Text = "Desconocido";
                }

                txttabladetallecompra.Rows.Clear();

                List<Detalle_Compra> detalle = new CN_Compra().ObtenerDetalleCompra(oCompra.IdCompra);
     
                foreach (Detalle_Compra dc in detalle)
                {
                    int n = txttabladetallecompra.Rows.Add();
                    DataGridViewRow fila = txttabladetallecompra.Rows[n];

                    fila.Cells["CIDproducto"].Value = dc.oProducto.IdProducto;
                    fila.Cells["CProducto"].Value = dc.oProducto.Nombre;
                    fila.Cells["CPrecioCompra"].Value = dc.PrecioCompra.ToString("N0", cultura);
                    fila.Cells["CPrecioVenta"].Value = dc.PrecioVenta.ToString("N0", cultura);
                    fila.Cells["CCantidad"].Value = dc.Cantidad;
                    fila.Cells["CNroLote"].Value = dc.NroLote;
                    fila.Cells["CFechaVencimiento"].Value = dc.FechaVencimiento;
                    fila.Cells["CSubTotal"].Value = dc.SubTotal.ToString("N0", cultura);
                }

                txmontototal.Text = oCompra.MontoTotal.ToString("N0", cultura);
            }
            else
            {
                txtfecha.Text = "";
                txttipodocumento.Text = "";
                txtusuario.Text = "";
                txtdocumento.Text = "";
                txtrazonsocial.Text = "";
                txttabladetallecompra.Rows.Clear();
                txmontototal.Text = "0";

                MessageBox.Show("No se encontró ninguna compra con ese número.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtbuscarnumerodocumento.Text = "";
            txtfecha.Text = "";
            txttipodocumento.Text = "";
            txtusuario.Text = "";
            txtdocumento.Text = "";
            txtrazonsocial.Text = "";
            txttabladetallecompra.Rows.Clear();
            txmontototal.Text = "0";
            txtnumerocompra.Text = "";

            txtbuscarnumerodocumento.Focus();
        }

        private void btnExplorapdf_Click(object sender, EventArgs e)
        {
            if (txttipodocumento.Text == "")
            {
                MessageBox.Show("No se encontraron resultados para exportar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string Texto_Html = System.Text.Encoding.UTF8.GetString(Properties.Resources.PlantillaCompra);
            Negocio odatos = new CN_Negocio().ObtenerDatos();

            Texto_Html = Texto_Html.Replace("@nombrenegocio", odatos.Nombre.ToUpper());
            Texto_Html = Texto_Html.Replace("@docnegocio", odatos.RUC);
            Texto_Html = Texto_Html.Replace("@direcnegocio", odatos.Direccion);

            Texto_Html = Texto_Html.Replace("@tipodocumento", txttipodocumento.Text.ToUpper());
            Texto_Html = Texto_Html.Replace("@numerodocumento", txtnumerocompra.Text);

            Texto_Html = Texto_Html.Replace("@docproveedor", txtdocumento.Text);
            Texto_Html = Texto_Html.Replace("@nombreproveedor", txtrazonsocial.Text);
            Texto_Html = Texto_Html.Replace("@fecharegistro", txtfecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", txtusuario.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow row in txttabladetallecompra.Rows)
            {
                if (!row.IsNewRow)
                {
                    filas += "<tr>";
                    filas += "<td>" + row.Cells["CProducto"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["CPrecioCompra"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["CPrecioVenta"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["CCantidad"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["CNroLote"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["CFechaVencimiento"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["CSubTotal"].Value.ToString() + "</td>";
                    filas += "</tr>";
                }
            }
            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", txmontototal.Text);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Compra_{0}.pdf", txtbuscarnumerodocumento.Text);
            savefile.Filter = "Archivos PDF (*.pdf)|*.pdf";
            savefile.DefaultExt = "pdf";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                    {
                        // Creamos el documento PDF
                        Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        // 1. DIBUJAR EL LOGO
                        bool obtenido = true;
                        byte[] byteImage = new CN_Negocio().ObtenerLogo(out obtenido);

                        if (obtenido && byteImage.Length > 0)
                        {
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                            img.ScaleToFit(60, 60);
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(60));
                            pdfDoc.Add(img);
                        }

                        // 2. DIBUJAR EL HTML (Ya sin la etiqueta <img> para evitar conflictos)
                        using (StringReader sr = new StringReader(Texto_Html))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }

                        pdfDoc.Close();
                        stream.Close();

                        MessageBox.Show("¡Documento PDF generado exitosamente!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el PDF: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form_DetalleCompras_Load(object sender, EventArgs e) { }
        private void guna2TextBox3_TextChanged(object sender, EventArgs e) { }
        private void txtdocumento_TextChanged(object sender, EventArgs e) { }
        private void txtrazonsocial_TextChanged(object sender, EventArgs e) { }
        private void txtusuario_TextChanged(object sender, EventArgs e) { }
        private void Idproveedor_TextChanged(object sender, EventArgs e) { }
        private void txtfecha_TextChanged(object sender, EventArgs e) { }
        private void txttipodocumento_TextChanged(object sender, EventArgs e) { }
        private void txtbuscarnumerodocumento_TextChanged(object sender, EventArgs e) { }
        private void txmontototal_TextChanged(object sender, EventArgs e) { }
        private void txttabladetallecompra_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void txtnumerocompra_TextChanged(object sender, EventArgs e)
        {

        }
    }
}