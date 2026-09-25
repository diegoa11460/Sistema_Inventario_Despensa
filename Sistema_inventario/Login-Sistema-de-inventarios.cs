using CapaEntidad;
using CapaNegocio;
using Sistema_inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace Sistema_inventario
{
    public partial class Login_Sistema_de_inventarios : Form
    {
        public Login_Sistema_de_inventarios()
        {
            InitializeComponent();

            // Arrancamos con el sistema de enmascarado NATIVO (más prolijo visualmente).
            // OJO: mientras esté en true, "PasswordChar" queda ignorado por el control.
            textclave.UseSystemPasswordChar = true;

            // Bloquea el tamaño de la ventana incluso ante Aero Snap / atajos de Windows
            // (FixedToolWindow evita el arrastre manual del borde, pero no siempre evita
            // que Windows la estire al hacer Snap contra el borde de la pantalla).
            this.MaximumSize = this.ClientSize + (this.Size - this.ClientSize);
            this.MinimumSize = this.MaximumSize;
        }

        // =========================================================================
        // 🔓 BOTÓN INGRESAR
        // =========================================================================
        private void iconButton1_Click(object sender, EventArgs e)
        {
            // Buscamos al usuario por su Documento y su Clave
            Usuario ousuario = new CN_Usuario().Listar().Where(u => u.Documento == textnombre.Text && u.Clave == textclave.Text).FirstOrDefault();

            // Verificamos si encontramos una coincidencia (Si escribió bien sus datos)
            if (ousuario != null)
            {
                // =========================================================================
                // 🔒 EL CANDADO MÁGICO DE ESTADO (¡AQUÍ ESTÁ LA MAGIA!)
                // =========================================================================
                if (ousuario.Estado == false)
                {
                    // Le mostramos el mensaje exacto que pediste
                    MessageBox.Show(
                        "Tu cuenta está inactiva.\n\nSolo el Administrador puede darte acceso, por favor comunícate con él.",
                        "Acceso Denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop
                    );

                    // Limpiamos las cajas por seguridad para que no quede su contraseña ahí escrita
                    textclave.Clear();

                    // 🛑 ESTO ES CLAVE: El 'return' frena el código aquí mismo y evita que entre al sistema
                    return;
                }
                // =========================================================================

                // SI EL USUARIO SÍ ESTÁ ACTIVO (Estado == true), el código pasa directo para acá:
                Inicios form = new Inicios(ousuario);
                form.Show();
                this.Hide();

                form.FormClosing += frm_closing;
            }
            else
            {
                // Si escribió mal la cédula o la contraseña
                MessageBox.Show("No se encontró el usuario o la contraseña es incorrecta.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        // CORREGIDO: Se agregó el método faltante para que no rompa el evento FormClosing
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            textnombre.Clear();
            textclave.Clear();
            this.Show();
        }

        // =========================================================================
        // 👁️ BOTÓN DEL OJITO (Mostrar / Ocultar contraseña)
        // =========================================================================
        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            var btnOjito = (FontAwesome.Sharp.IconButton)sender;

            // FIX: "UseSystemPasswordChar" tiene prioridad sobre "PasswordChar".
            // Si no lo apagamos acá, el control sigue enmascarando el texto con el
            // carácter del sistema aunque PasswordChar se ponga en '\0', y el ojito
            // nunca revela nada (solo cambiaba el ícono).
            if (textclave.UseSystemPasswordChar)
            {
                // Mostrar contraseña en texto plano
                textclave.UseSystemPasswordChar = false;
                textclave.PasswordChar = '\0';
                btnOjito.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
            else
            {
                // Volver a ocultar la contraseña
                textclave.UseSystemPasswordChar = true;
                btnOjito.IconChar = FontAwesome.Sharp.IconChar.Eye;
            }

            // Actualizamos el botón visualmente
            btnOjito.Invalidate();
            btnOjito.Refresh();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- Métodos vacíos exigidos por el diseñador (No los borres para que no rompa el diseño) ---
        private void label1_Click(object sender, EventArgs e) { }
        private void Login_Sistema_de_inventarios_Load(object sender, EventArgs e) { }
        private void label14_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void Login_Sistema_de_inventarios_Load_1(object sender, EventArgs e)
        {

        }
    }



}