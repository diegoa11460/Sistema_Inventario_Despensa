using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;

namespace Sistema_inventario
{
    public partial class Inicios : System.Windows.Forms.Form
    {
        public Action<object, FormClosedEventArgs> FromClosing { get; internal set; }

        private static Usuario usuarioActual;
        private static Control MenuActivo = null;
        private static Form FormularioActivo = null;

        private Dictionary<Control, Form> _formulariosCache = new Dictionary<Control, Form>();
        private Timer _animadorTimer = new Timer();
        private Form _formularioAAnimar = null;

        // =========================================================================================
        // 🔥 ESTO ES LA MAGIA: ELIMINA EL PARPADEO BLANCO DE LOS PANELES Y HACE LA ANIMACIÓN FLUIDA
        // =========================================================================================
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED (Doble buffer avanzado para toda la ventana)
                return cp;
            }
        }
        // =========================================================================================

        public Inicios(Usuario objusuario)
        {
            InitializeComponent();
            usuarioActual = objusuario;

            // Activamos el doble buffer tradicional también para asegurar
            this.DoubleBuffered = true;

            // Doble buffer para los contenedores principales (Evita que el fondo se ponga blanco)
            ActivarDobleBuffer(panel_inicio);
            ActivarDobleBuffer(panel_vertical);

            AplicarDiseñoModernoMenu();

            panel_vertical.Dock = DockStyle.Left;
            panel_inicio.Dock = DockStyle.Fill;
            panel_inicio.BringToFront();

            this.Load += new System.EventHandler(this.Inicio_Load);
            this.Shown += new System.EventHandler(this.Inicios_Shown);

            _animadorTimer.Interval = 10;
            _animadorTimer.Tick += AnimadorTimer_Tick;
        }

        // Método auxiliar para aplicar doble buffer por reflexión a cualquier panel
        private void ActivarDobleBuffer(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        private async void Inicios_Shown(object sender, EventArgs e)
        {
            // Le damos un pequeño respiro a la UI para que estabilice los tamaños
            await Task.Delay(50);

            // Abrimos el formulario central
            AbrirFormulario(menu_inicio, () => new Form_Inicio());
        }

        private async void Inicio_Load(object sender, EventArgs e)
        {
            string descRol = "Sin Rol";

            if (usuarioActual != null)
            {
                descRol = (usuarioActual.oRol != null) ? usuarioActual.oRol.Descripcion : "Sin Rol";
                lblusuario.Text = descRol + ": " + usuarioActual.NombreCompleto;
            }

            try
            {
                List<Permiso> listaPermisos = await Task.Run(() => new CN_Permiso().Listar(usuarioActual.IdUsuario));
                List<string> menusPermitidos = listaPermisos.Select(p => p.NombreMenu).ToList();

                // Módulos principales
                menu_inicio.Visible = true;
                Menu_Ventas.Visible = menusPermitidos.Contains("Menu_Ventas");
                Menu_Compras.Visible = menusPermitidos.Contains("Menu_Compras");
                Menu_cliente.Visible = menusPermitidos.Contains("Menu_cliente");
                Menu_Productos.Visible = menusPermitidos.Contains("Menu_Productos");
                Menu_Categoria.Visible = menusPermitidos.Contains("Menu_Categoria");
                Menu_proveedor.Visible = menusPermitidos.Contains("Menu_proveedor");
                Menu_movimiento.Visible = menusPermitidos.Contains("Menu_movimiento");
                Menu_Reportes.Visible = menusPermitidos.Contains("Menu_Reportes");
                Menu_Historial.Visible = menusPermitidos.Contains("Menu_Historial");
                Menu_Usuario.Visible = menusPermitidos.Contains("Menu_Usuario");
                label7.Visible = menusPermitidos.Contains("Menu_Usuario");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar permisos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AnimadorTimer_Tick(object sender, EventArgs e)
        {
            if (_formularioAAnimar != null)
            {
                _formularioAAnimar.Height += 55;

                if (_formularioAAnimar.Height >= panel_inicio.Height)
                {
                    _formularioAAnimar.Height = panel_inicio.Height;
                    _formularioAAnimar.Dock = DockStyle.Fill;
                    _animadorTimer.Stop();
                }
            }
        }

        private void AbrirFormulario(Control menu, Func<Form> crearFormulario)
        {
            if (MenuActivo == menu) return;

            // 1. Evitamos que la ventana intente redibujarse mientras cambiamos el contenido
            this.SuspendLayout();

            // 2. Cerrar o esconder el formulario anterior
            if (FormularioActivo != null)
            {
                if (MenuActivo.Name != "Menu_Acerca")
                {
                    FormularioActivo.Dispose();
                    _formulariosCache.Remove(MenuActivo);
                }
                else
                {
                    FormularioActivo.Hide();
                }
            }

            // 3. Pintar el menú seleccionado
            if (MenuActivo != null) MenuActivo.BackColor = panel_vertical.BackColor;
            menu.BackColor = Color.SteelBlue;
            MenuActivo = menu;

            // 4. Crear o recuperar el nuevo formulario
            Form formulario;
            if (menu.Name == "Menu_Acerca" && _formulariosCache.TryGetValue(menu, out formulario) && !formulario.IsDisposed)
            {
                // Recuperamos de caché
            }
            else
            {
                formulario = crearFormulario();
                ConfigurarFormulario(formulario);
                if (menu.Name == "Menu_Acerca") _formulariosCache[menu] = formulario;
            }

            // 5. Mostrar el formulario limpio
            _animadorTimer.Stop();

            formulario.Dock = DockStyle.Fill;
            formulario.BringToFront();
            formulario.Show();

            FormularioActivo = formulario;

            // 6. Volvemos a activar el dibujo de la ventana (Hace que el cambio sea instantáneo)
            this.ResumeLayout();
        }

        private void ConfigurarFormulario(Form formulario)
        {
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.BackColor = Color.White;

            // Evita artefactos visuales ("ghosting") dentro del hijo
            ActivarDobleBuffer(formulario);

            panel_inicio.Controls.Add(formulario);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel_vertical.Visible = !panel_vertical.Visible;
        }

        private void AplicarDiseñoModernoMenu()
        {
            foreach (Control control in flowMenu.Controls)
            {
                if (control is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Cursor = Cursors.Hand;
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.MouseOverBackColor = Color.SteelBlue;
                    btn.FlatAppearance.MouseDownBackColor = Color.CornflowerBlue;
                }
            }
        }
        
        private void Menu_movimiento_Click(object sender, EventArgs e) => AbrirFormulario((Control)sender, () => new Form_Movimiento());
        private void Ventas_Click(object sender, EventArgs e) => AbrirFormulario((Control)sender, () => new Form_Ventas(usuarioActual));
        private void Productos_Click(object sender, EventArgs e) => AbrirFormulario((Control)sender, () => new Form_Productos());
        private void iconButton10_Click(object sender, EventArgs e) => AbrirFormulario((Control)sender, () => new Form_Inicio());
        private void Menu_Usuario_Click(object sender, EventArgs e) => AbrirFormulario((Control)sender, () => new frmGestionUsuarios());
        private void Categoria_Click(object sender, EventArgs e) => AbrirFormulario((Control)sender, () => new Form_Categoria());
        private void Menu_cliente_Click(object sender, EventArgs e) => AbrirFormulario((Control)sender, () => new txtnombre());
        private void Menu_proveedor_Click(object sender, EventArgs e) => AbrirFormulario((Control)sender, () => new Form_Proveedores());
        private void Menu_Reportes_Click(object sender, EventArgs e) => AbrirFormulario((Control)sender, () => new Form_Reportes());
        private void Menu_Compras_Click(object sender, EventArgs e) => AbrirFormulario((Control)sender, () => new Form_Compras(usuarioActual));
        private void Menu_Acerca_Click(object sender, EventArgs e) => AbrirFormulario((Control)sender, () => new Form_Negocio());
        private void Menu_Ver_detalle_Click_1(object sender, EventArgs e) => AbrirFormulario((Control)sender, () => new Form_Ver_detalle());

        // --- Eventos vacíos ---
        private void lblusuario_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void panel1_Paint_1(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void button3_Click_1(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void panel2_Paint_1(object sender, PaintEventArgs e) { }
        private void button6_Click(object sender, EventArgs e) { }
        private void button7_Click(object sender, EventArgs e) { }
        private void pictureBox6_Click(object sender, EventArgs e) { }
        private void button9_Click(object sender, EventArgs e) { }
        private void pictureBox7_Click(object sender, EventArgs e) { }
        private void pictureBox8_Click(object sender, EventArgs e) { }
        private void button5_Click(object sender, EventArgs e) { }
        private void button12_Click(object sender, EventArgs e) { }
        private void label16_Click(object sender, EventArgs e) { }
        private void label17_Click(object sender, EventArgs e) { }
        private void button10_Click(object sender, EventArgs e) { }
        private void roles_Click(object sender, EventArgs e) { }
        private void reloj_21_Click(object sender, EventArgs e) { }
        private void button3_Click_2(object sender, EventArgs e) { }
        private void iconButton1_Click(object sender, EventArgs e) { }
        private void panel4_Paint(object sender, PaintEventArgs e) { }
        private void Contenedor_Paint(object sender, PaintEventArgs e) { }
        private void Menu_Salida_Click(object sender, EventArgs e) { }
        private void label19_Click(object sender, EventArgs e) { }
        private void iconButton9_Click(object sender, EventArgs e) { }
        private void iconButton1_Click_3(object sender, EventArgs e) { }
    }
}