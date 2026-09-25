using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace Sistema_inventario
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void CargarRoles()
        {
            try
            {
                List<Rol> listaRoles = new CN_Rol().Listar();
                comboBox1.DataSource = listaRoles;
                comboBox1.DisplayMember = "Descripcion";
                comboBox1.ValueMember = "IdRol";
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) return;

            if (comboBox1.Text == "Administrador")
            {
                chkProductos.Checked = true; chkProductos.Enabled = false;
                chkProveedores.Checked = true; chkProveedores.Enabled = false;
                chkCategorias.Checked = true; chkCategorias.Enabled = false;
                chkVentas.Checked = true; chkVentas.Enabled = false;
                chkEntradas.Checked = true; chkEntradas.Enabled = false;
                chkSalidas.Checked = true; chkSalidas.Enabled = false;
                chkReportes.Checked = true; chkReportes.Enabled = false;
            }
            else if (comboBox1.Text == "Empleado")
            {
                chkProductos.Checked = false; chkProductos.Enabled = true;
                chkProveedores.Checked = false; chkProveedores.Enabled = true;
                chkCategorias.Checked = false; chkCategorias.Enabled = true;
                chkVentas.Checked = false; chkVentas.Enabled = true;
                chkEntradas.Checked = false; chkEntradas.Enabled = true;
                chkSalidas.Checked = false; chkSalidas.Enabled = true;
                chkReportes.Checked = false; chkReportes.Enabled = true;
            }
        }

        private void iconButtonGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas de campos vacíos
            if (string.IsNullOrWhiteSpace(textDocumento.Text) || string.IsNullOrWhiteSpace(textNombre.Text) || string.IsNullOrWhiteSpace(textClave.Text))
            {
                MessageBox.Show("Completá Documento, Nombre completo y Clave.", "Campos obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validación de duplicidad (Documento Y Correo)
            try
            {
                List<Usuario> listaUsuarios = new CN_Usuario().Listar();

                // Buscamos si el documento ya existe
                bool documentoExiste = listaUsuarios.Any(u => u.Documento == textDocumento.Text.Trim());

                // Buscamos si el correo ya existe (siempre y cuando el campo no esté vacío)
                bool correoExiste = !string.IsNullOrWhiteSpace(textCorreo.Text) &&
                                    listaUsuarios.Any(u => u.Correo == textCorreo.Text.Trim());

                if (documentoExiste)
                {
                    MessageBox.Show("Ya existe un usuario registrado con ese número de documento.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textDocumento.Focus();
                    return;
                }

                if (correoExiste)
                {
                    MessageBox.Show("Ya existe un usuario registrado con ese mismo correo electrónico.", "Correo Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textCorreo.Focus();
                    return;
                }
            }
            catch { /* Si la carga falla, el proceso continúa y el error se mostrará en el guardado */ }

            // 3. Otras validaciones de formato y longitud
            if (textDocumento.Text.Trim().Length < 7) { MessageBox.Show("El documento debe tener al menos 7 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (textClave.Text.Length < 7) { MessageBox.Show("La clave debe tener al menos 7 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (textClave.Text != textConfirmarClave.Text) { MessageBox.Show("La clave y la confirmación no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // 4. Intento de Registro
            try
            {
                Usuario oUsuario = new Usuario()
                {
                    Documento = textDocumento.Text.Trim(),
                    NombreCompleto = textNombre.Text.Trim(),
                    Correo = textCorreo.Text.Trim(),
                    Clave = textClave.Text,
                    Estado = checkBox1.Checked,
                    oRol = new Rol() { IdRol = Convert.ToInt32(comboBox1.SelectedValue) }
                };

                string mensaje;
                int idGenerado = new CN_Usuario().Registrar(oUsuario, out mensaje);

                if (idGenerado > 0)
                {
                    // Guardado de permisos...
                    int idRolSeleccionado = Convert.ToInt32(comboBox1.SelectedValue);
                    List<string> listaMenus = new List<string>();

                    if (chkProductos.Checked) listaMenus.Add("Menu_Productos");
                    if (chkProveedores.Checked) listaMenus.Add("Menu_proveedor");
                    if (chkCategorias.Checked) listaMenus.Add("Menu_Categoria");
                    if (chkVentas.Checked) listaMenus.Add("Menu_Ventas");
                    if (chkEntradas.Checked) listaMenus.Add("Menu_Compras");
                    if (chkSalidas.Checked) listaMenus.Add("Menu_Movimiento");
                    if (chkReportes.Checked) listaMenus.Add("Menu_Reportes");
                    if (chkReportes.Checked) listaMenus.Add("Menu_Reportes");
                    if (chkHistoria.Checked) listaMenus.Add("Menu_Historia");

                    if (comboBox1.Text == "Administrador") listaMenus.Add("Menu_Usuario");

                    new CN_Permiso().Guardar(idRolSeleccionado, listaMenus);

                    MessageBox.Show("Usuario registrado y permisos actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("Error al registrar en base de datos: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            textDocumento.Clear(); textNombre.Clear(); textCorreo.Clear(); textClave.Clear(); textConfirmarClave.Clear();
            comboBox1.SelectedIndex = -1; checkBox1.Checked = true;
            chkProductos.Checked = false; chkProductos.Enabled = true;
            // ... resto de tu limpieza
            textDocumento.Focus();
        }

        // Eventos vacíos
        private void iconButtonCancelar_Click(object sender, EventArgs e) { LimpiarFormulario(); }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void chkHistoria_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}