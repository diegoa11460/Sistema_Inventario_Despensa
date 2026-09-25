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
    public partial class frmGestionUsuarios : Form
    {
        public frmGestionUsuarios()
        {
            InitializeComponent();
            BloquearCampos();
        }



        private void CargarUsuarios()
        {
            guna2DataGridView1.Rows.Clear();
            List<Usuario> lista = new CN_Usuario().Listar();

            foreach (Usuario item in lista)
            {
                string estadoTexto = item.Estado == true ? "Activo" : "No Activo";

                int index = guna2DataGridView1.Rows.Add(new object[] {
            item.Documento,
            item.IdUsuario,
            item.NombreCompleto,
            item.Correo,
            item.oRol.Descripcion,
            estadoTexto,
            "Eliminar"
        });

                // 🌟 NUEVO: Guardamos la contraseña original oculta en la fila para usarla después
                guna2DataGridView1.Rows[index].Tag = item.Clave;

                // 🎨 SI EL USUARIO NO ESTÁ ACTIVO, LO PINTAMOS DE GRIS Y CURSIVA
                if (item.Estado == false)
                {
                    guna2DataGridView1.Rows[index].DefaultCellStyle.ForeColor = Color.Gray;
                    guna2DataGridView1.Rows[index].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Italic);
                }
            }
        }



        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmUsuarios ventanaRegistro = new frmUsuarios();
            ventanaRegistro.ShowDialog();
            CargarUsuarios();
        }


        private void frmGestionUsuarios_Load(object sender, EventArgs e)
        {
            
           
        }


        private void frmGestionUsuarios_Shown(object sender, EventArgs e)
        {
            CargarUsuarios();
        }


        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
    {
        // Capturamos la fila entera que el usuario acaba de tocar
        DataGridViewRow fila = guna2DataGridView1.Rows[e.RowIndex];

                // 1. El ID oculto (Recuerda que debes agregar un TextBox a tu diseño, 
                // llamarlo txtId y ponerle la propiedad Visible = False)
                txtId.Text = fila.Cells["IdUsuario"].Value.ToString(); 
        
        // 2. Las cajas de texto con TUS nombres exactos
        txtdocumento.Text = fila.Cells["Documento"].Value.ToString();
        textNombre.Text = fila.Cells["Nombre"].Value.ToString();
        textCorreo.Text = fila.Cells["Correo"].Value.ToString(); 
        
        // 3. La selección del Rol
        comboBox1.Text = fila.Cells["Rol"].Value.ToString();
                txtContrasenaActual.Text = fila.Tag.ToString();
                txtCambiarContrasena.Text = "";


                // 4. El CheckBox del Estado
                string estado = fila.Cells["Estado"].Value.ToString();
        
        if (estado == "Activo")
        {
            guna2CheckBox1.Checked = true; 
        }
        else
        {
            guna2CheckBox1.Checked = false;
        }

                BloquearCampos();
            }
        }

        private void btnedictar_Click(object sender, EventArgs e)
        {
            // 1. Verificamos que se haya seleccionado a alguien en la tabla
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Por favor, seleccione un usuario de la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Esto detiene la acción si no hay nadie seleccionado
            }

            // 2. 🔓 Llamamos al método que quita el candado para permitir escribir
            DesbloquearCampos();

            // 3. Le avisamos al administrador que ya puede hacer los cambios
            MessageBox.Show("Modo Edición Activado.\n\nYa puedes modificar los datos y presionar el botón 'Guardar' cuando termines.", "Modo Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // 1. Validamos que haya alguien seleccionado
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("No hay ningún usuario en modo edición para guardar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // =========================================================================
            // 🌟 VERIFICAMOS SI REALMENTE SE MODIFICÓ ALGO ANTES DE GUARDAR (¡CORREGIDO!)
            // =========================================================================
            bool huboCambios = false;

            foreach (DataGridViewRow fila in guna2DataGridView1.Rows)
            {
                if (fila.Cells["IdUsuario"].Value != null && fila.Cells["IdUsuario"].Value.ToString() == txtId.Text)
                {
                    bool estadoOriginal = (fila.Cells["Estado"].Value.ToString() == "Activo");

                    // Comparamos los campos de texto, combos, check y la NUEVA CONTRASEÑA
                    if (textNombre.Text != fila.Cells["Nombre"].Value.ToString() ||
                        textCorreo.Text != fila.Cells["Correo"].Value.ToString() ||
                        comboBox1.Text != fila.Cells["Rol"].Value.ToString() ||
                        guna2CheckBox1.Checked != estadoOriginal ||
                        txtCambiarContrasena.Text != "") // 🌟 ¡CLAVE! Si esta caja no está vacía, significa que el admin quiere cambiar la clave.
                    {
                        huboCambios = true;
                    }
                    break;
                }
            }

            // Si todo está exactamente igual...
            if (huboCambios == false)
            {
                MessageBox.Show("No se guardó nada porque no editaste ningún dato.", "Sin cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BloquearCampos();
                return;
            }
            // =========================================================================

            // 3. Asignamos el ID del Rol leyendo el texto de la caja
            int idRolSeleccionado = 0;

            if (comboBox1.Text == "Administrador")
            {
                idRolSeleccionado = 1;
            }
            else if (comboBox1.Text == "Empleado" || comboBox1.Text == "Empleada")
            {
                idRolSeleccionado = 2;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un Rol válido de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Empaquetamos los datos con la clave inteligente
            Usuario objUsuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(txtId.Text),
                Documento = txtdocumento.Text,
                NombreCompleto = textNombre.Text,
                Correo = textCorreo.Text,

                // Si la caja de cambiar clave está vacía, conserva la actual. Si tiene texto, usa la nueva.
                Clave = txtCambiarContrasena.Text == "" ? txtContrasenaActual.Text : txtCambiarContrasena.Text,

                oRol = new Rol() { IdRol = idRolSeleccionado },
                Estado = guna2CheckBox1.Checked
            };

            string mensaje = string.Empty;

            // 5. Enviamos los datos a la base de datos
            bool respuesta = new CN_Usuario().Editar(objUsuario, out mensaje);

            // 6. Verificamos si la base de datos aceptó el cambio
            if (respuesta)
            {
                MessageBox.Show("Los cambios se han guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios();    // Actualizamos la tabla para refrescar los datos
                BloquearCampos();    // Volvemos a bloquear y pintar de gris las cajas

                // 🧹 Limpiamos la caja de cambiar contraseña para la próxima edición
                txtCambiarContrasena.Text = "";
            }
            else
            {
                MessageBox.Show(mensaje, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bteliminar_Click(object sender, EventArgs e)
        {
            // 1. Verificamos que el Administrador haya seleccionado a alguien en la tabla verde
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Por favor, seleccione un usuario de la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. ⚠️ EL MENSAJE DE CONFIRMACIÓN EXACTO QUE PEDISTE
            DialogResult botonPresionado = MessageBox.Show(
                "¿Desea dar de baja a este empleado?\n\nSe eliminarán los datos del usuario para que ya no tenga acceso, pero NO se borrará la actividad ni las ventas que ha hecho en la despensa.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // 3. Si el Administrador presiona el botón "Sí"...
            if (botonPresionado == DialogResult.Yes)
            {
                // Empaquetamos el ID del usuario que vamos a eliminar/desactivar
                Usuario objUsuario = new Usuario()
                {
                    IdUsuario = Convert.ToInt32(txtId.Text)
                };

                string mensaje = string.Empty;

                // Llamamos a la Capa de Negocio que preparaste antes
                bool respuesta = new CN_Usuario().Eliminar(objUsuario, out mensaje);

                // Si la base de datos responde que TODO SALIÓ BIEN:
                if (respuesta)
                {
                    // Mostramos el mensaje que nos mandó SQL Server (ya sea que lo borró o lo desactivó)
                    MessageBox.Show(mensaje, "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 🧹 Limpiamos TODAS las cajas de texto de la izquierda para que queden en blanco
                    txtId.Text = "";
                    txtdocumento.Text = "";
                    textNombre.Text = "";
                    textCorreo.Text = "";
                    txtContrasenaActual.Text = "";
                    txtCambiarContrasena.Text = "";
                    guna2CheckBox1.Checked = false;

                    // Opcional: Si tienes un elemento por defecto en el ComboBox, lo volvemos a poner
                    if (comboBox1.Items.Count > 0) { comboBox1.SelectedIndex = 0; }

                    // Recargamos la tabla para que el usuario desaparezca o se pinte de gris
                    CargarUsuarios();

                    // Ponemos los candados de seguridad de nuevo
                    BloquearCampos();
                }
                else
                {
                    // Si hubo algún error de conexión o de SQL, lo mostramos aquí
                    MessageBox.Show(mensaje, "Error al procesar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtdocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmGestionUsuarios_Load_1(object sender, EventArgs e)
        {

        }

        private void textCorreo_TextChanged(object sender, EventArgs e)
        {

        }


        // MÉTODO PARA PONER EL CANDADO Y PINTAR DE GRIS
        private void BloquearCampos()
        {
            txtdocumento.ReadOnly = true;
            textNombre.ReadOnly = true;
            textCorreo.ReadOnly = true;
            comboBox1.Enabled = false;
            guna2CheckBox1.Enabled = false;

            // 🌟 Pinta AMBAS cajas de contraseñas de gris oscuro y las bloquea
            txtCambiarContrasena.ReadOnly = true;
            txtCambiarContrasena.BackColor = Color.LightGray;

            txtContrasenaActual.ReadOnly = true;
            txtContrasenaActual.BackColor = Color.LightGray;
        }

        // MÉTODO PARA QUITAR EL CANDADO Y PINTAR DE BLANCO (Solo al dar a Editar)
        private void DesbloquearCampos()
        {
            textNombre.ReadOnly = false;
            textCorreo.ReadOnly = false;
            comboBox1.Enabled = true;
            guna2CheckBox1.Enabled = true;

            // 🌟 Pone AMBAS cajas de contraseñas en color blanco y permite escribir
            txtCambiarContrasena.ReadOnly = false;
            txtCambiarContrasena.BackColor = Color.White;

            txtContrasenaActual.ReadOnly = false;
            txtContrasenaActual.BackColor = Color.White;
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void textClaveConfirmar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
