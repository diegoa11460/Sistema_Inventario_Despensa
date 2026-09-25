using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; // 🌟 MUY IMPORTANTE para MemoryStream
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_inventario
{
    public partial class Form_Negocio : Form
    {
        public Form_Negocio()
        {
            InitializeComponent();
        }

        // ---------------------------------------------------------
        // EVENTO LOAD: CARGAR DATOS AL ABRIR LA VENTANA (ULTRA FLUIDO)
        // ---------------------------------------------------------
        private async void Form_Negocio_Load(object sender, EventArgs e)
        {
            // 1. TRUCO DE ORO: Pausar 50ms antes de hacer cualquier cosa.
            // Esto permite que el formulario se dibuje y despliegue en pantalla
            // de forma INSTANTÁNEA (como el efecto cortina), antes de atacar la base de datos.
            await Task.Delay(50);

            Cursor.Current = Cursors.WaitCursor;
            this.UseWaitCursor = true;

            try
            {
                // Ejecutamos TODO el trabajo pesado (BD y procesamiento de bytes) en el fondo
                var resultado = await Task.Run(() =>
                {
                    bool obtenidoLogo;
                    byte[] byteimage = new CN_Negocio().ObtenerLogo(out obtenidoLogo);
                    Negocio datos = new CN_Negocio().ObtenerDatos();

                    // 2. Convertimos la imagen EN SEGUNDO PLANO. 
                    // Esto evita que decodificar la imagen congele la interfaz gráfica.
                    Image logoConvertido = null;
                    if (obtenidoLogo && byteimage != null && byteimage.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(byteimage))
                        {
                            logoConvertido = Image.FromStream(ms);
                        }
                    }

                    return (logoConvertido, datos);
                });

                // 3. Volvemos al hilo de UI solo para "pegar" los datos listos (Es instantáneo)
                if (resultado.logoConvertido != null)
                {
                    picturelogo.Image = resultado.logoConvertido;
                }

                textBox1.Text = resultado.datos.Nombre;
                textRuc.Text = resultado.datos.RUC;
                textdireccion.Text = resultado.datos.Direccion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos del negocio: \n" + ex.Message,
                    "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                this.UseWaitCursor = false;
            }
        }

        // ---------------------------------------------------------
        // EVENTOS VACÍOS DE TU DISEÑO
        // ---------------------------------------------------------
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void picturelogo_Click(object sender, EventArgs e) { }
        private void textRuc_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textdireccion_TextChanged(object sender, EventArgs e) { }

        // ---------------------------------------------------------
        // BOTÓN: SUBIR IMAGEN DESDE LA PC
        // ---------------------------------------------------------
        private void btnsubirimagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png";
            oOpenFileDialog.Title = "Seleccionar Logo";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Cargamos la imagen seleccionada directamente en tu PictureBox
                picturelogo.Image = Image.FromFile(oOpenFileDialog.FileName);
            }
        }

        // ---------------------------------------------------------
        // BOTÓN: GUARDAR LOS DATOS Y EL LOGO
        // ---------------------------------------------------------
        private async void txtguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            // 1. Creamos el objeto Negocio con los datos escritos en las cajas
            Negocio obj = new Negocio()
            {
                Nombre = textBox1.Text,
                RUC = textRuc.Text,
                Direccion = textdireccion.Text
            };

            Cursor.Current = Cursors.WaitCursor;
            this.UseWaitCursor = true;
            txtguardar.Enabled = false;

            try
            {
                // 2. Convertimos la imagen a bytes en el hilo de UI (rápido, no toca BD)
                byte[] byteimage = FileToByteArray(picturelogo.Image);

                // 3. Guardado en base de datos: se hace en segundo plano para no congelar la ventana
                var (respuesta, respuestaLogo, msg) = await Task.Run(() =>
                {
                    string msgInterno;
                    bool ok = new CN_Negocio().GuardarDatos(obj, out msgInterno);
                    bool okLogo = false;

                    if (ok)
                    {
                        string msgLogo;
                        okLogo = new CN_Negocio().ActualizarLogo(byteimage, out msgLogo);
                        msgInterno = msgLogo;
                    }

                    return (ok, okLogo, msgInterno);
                });

                if (respuesta)
                {
                    MessageBox.Show("Los cambios fueron guardados exitosamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo guardar los cambios: \n" + msg, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar: \n" + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                this.UseWaitCursor = false;
                txtguardar.Enabled = true;
            }
        }

        // ---------------------------------------------------------
        // MÉTODO AUXILIAR: CONVERTIR IMAGEN A BYTES PARA GUARDAR
        // ---------------------------------------------------------
        public byte[] FileToByteArray(Image image)
        {
            // Si no hay imagen, devolvemos un arreglo vacío
            if (image == null) return new byte[0];

            using (MemoryStream ms = new MemoryStream())
            {
                // Guardamos la imagen en el stream usando su formato original (png/jpg)
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
    }
}