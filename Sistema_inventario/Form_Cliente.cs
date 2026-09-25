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
    public partial class txtnombre : Form
    {
        public txtnombre()
        {
            InitializeComponent();
        }

        // =======================================================
        // 1. EVENTO LOAD (AL ABRIR EL FORMULARIO)
        // =======================================================
        private void txtnombre_Load(object sender, EventArgs e)
        {
            // 🌟 Conectamos el evento del clic a la tabla de forma segura
            tablaClientes.CellContentClick -= tablaClientes_CellContentClick;
            tablaClientes.CellContentClick += tablaClientes_CellContentClick;

            // Cargamos los datos en la tabla
            CargarClientes();

            // Preparamos la lista de Estado
            if (cboEstado != null)
            {
                cboEstado.Items.Clear();
                cboEstado.Items.Add("Activo");
                cboEstado.Items.Add("No Activo");
                cboEstado.SelectedIndex = 0;
            }

            // Preparamos el buscador por columnas
            if (txtBuscarNombre != null)
            {
                txtBuscarNombre.Items.Clear();
                txtBuscarNombre.Items.Add("Documento");
                txtBuscarNombre.Items.Add("Nombre");
                txtBuscarNombre.Items.Add("Telefono");
                txtBuscarNombre.Items.Add("Estado");
                txtBuscarNombre.SelectedIndex = 0;
            }

            // Bloqueamos la caja del ID para que no se escriba manualmente
            if (txtIdcliente != null)
            {
                txtIdcliente.ReadOnly = true;
            }
        }

        // =======================================================
        // 2. MÉTODO CARGAR CLIENTES A LA TABLA
        // =======================================================
        private void CargarClientes()
        {
            tablaClientes.Rows.Clear();
            List<Cliente> lista = new CN_Cliente().Listar();

            foreach (Cliente item in lista)
            {
                int indiceFila = tablaClientes.Rows.Add();
                DataGridViewRow row = tablaClientes.Rows[indiceFila];

                row.Cells["ColDocumento"].Value = item.Documento;
                row.Cells["ColNombre"].Value = item.NombreCompleto;
                row.Cells["ColTelefono"].Value = item.Telefono;
                row.Cells["ColEstado"].Value = item.Estado == true ? "Activo" : "No Activo";

                // El Id lo guardamos oculto en el Tag
                row.Tag = item.IdCliente;
            }
        }

        // =======================================================
        // 3. PASAR DATOS DE LA TABLA A LAS CAJAS DE TEXTO
        // =======================================================
        private void tablaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = tablaClientes.Rows[e.RowIndex];

                // Rellenado DIRECTO de las cajas de texto
                txtIdcliente.Text = row.Tag?.ToString() ?? "0";
                txtdocumentos.Text = row.Cells["ColDocumento"].Value?.ToString() ?? "";
                txtNombreCompleto.Text = row.Cells["ColNombre"].Value?.ToString() ?? "";
                txtTelefono.Text = row.Cells["ColTelefono"].Value?.ToString() ?? "";
                cboEstado.Text = row.Cells["ColEstado"].Value?.ToString() ?? "Activo";
            }
        }

        // =======================================================
        // 4. BOTÓN GUARDAR (REGISTRAR O EDITAR)
        // =======================================================
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            // Captura directa y limpia
            string nombreIngresado = txtNombreCompleto.Text.Trim();
            string telefonoIngresado = txtTelefono.Text.Trim();
            string documentoLimpio = txtdocumentos.Text.Trim();

            // 🛑 VALIDACIÓN BÁSICA
            if (string.IsNullOrWhiteSpace(documentoLimpio) || string.IsNullOrWhiteSpace(nombreIngresado))
            {
                MessageBox.Show("Debe ingresar al menos el Documento y el Nombre Completo del cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🛡️ CAPTURA SEGURA DEL ID
            int idActual = 0;
            if (txtIdcliente.Text.Trim() != "")
            {
                int.TryParse(txtIdcliente.Text, out idActual);
            }

            string mensaje = string.Empty;
            txtdocumentos.Text = documentoLimpio; // Devolvemos el texto sin espacios a la caja visual

            // --- CREACIÓN DEL OBJETO CLIENTE ---
            Cliente objCliente = new Cliente()
            {
                IdCliente = idActual,
                Documento = documentoLimpio,
                NombreCompleto = nombreIngresado,
                Telefono = telefonoIngresado,
                Estado = cboEstado.Text == "Activo"
            };

            // --- GUARDADO EN BASE DE DATOS ---
            if (objCliente.IdCliente == 0) // Registrar nuevo
            {
                int idGenerado = new CN_Cliente().Registrar(objCliente, out mensaje);

                if (idGenerado != 0)
                {
                    MessageBox.Show("Cliente registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientes();
                    LimpiarCajas();
                }
                else
                {
                    MessageBox.Show(mensaje, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else // Editar existente
            {
                bool resultado = new CN_Cliente().Editar(objCliente, out mensaje);

                if (resultado)
                {
                    MessageBox.Show("Cliente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientes();
                    LimpiarCajas();
                }
                else
                {
                    MessageBox.Show(mensaje, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // =======================================================
        // 5. BOTÓN ELIMINAR
        // =======================================================
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            int idActual = 0;
            if (txtIdcliente.Text.Trim() != "")
            {
                int.TryParse(txtIdcliente.Text, out idActual);
            }

            if (idActual <= 0)
            {
                MessageBox.Show("Por favor, seleccione un cliente de la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar este cliente de forma definitiva?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            string mensaje = string.Empty;
            Cliente objCliente = new Cliente() { IdCliente = idActual };

            bool respuesta = new CN_Cliente().Eliminar(objCliente, out mensaje);

            if (respuesta)
            {
                MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarClientes();
                LimpiarCajas();
            }
            else
            {
                MessageBox.Show(mensaje, "Acción Denegada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =======================================================
        // 6. BOTÓN LIMPIAR CAJAS (NUEVO REGISTRO)
        // =======================================================
        private void btnlimpiar_Click_1(object sender, EventArgs e)
        {
            LimpiarCajas();
            tablaClientes.ClearSelection();
            txtdocumentos.Focus();
        }

        private void LimpiarCajas()
        {
            txtIdcliente.Text = "0";
            txtdocumentos.Text = "";
            txtNombreCompleto.Text = "";
            txtTelefono.Text = "";

            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;

            txtdocumentos.Select();
        }

        // =======================================================
        // 7. FILTROS Y BÚSQUEDA
        // =======================================================
        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";

            if (txtBuscarNombre.Items.Count > 0)
            {
                txtBuscarNombre.SelectedIndex = 0;
            }

            foreach (DataGridViewRow row in tablaClientes.Rows)
            {
                row.Visible = true;
            }
        }

        private void AplicarFiltroBusqueda()
        {
            string filtro = txtBusqueda.Text.Trim().ToUpper();

            if (txtBuscarNombre.SelectedItem == null) return;

            string opcionSeleccionada = txtBuscarNombre.SelectedItem.ToString();
            string columnaBusqueda = "ColNombre"; // Por defecto Nombre

            if (opcionSeleccionada == "Documento") columnaBusqueda = "ColDocumento";
            else if (opcionSeleccionada == "Nombre") columnaBusqueda = "ColNombre";
            else if (opcionSeleccionada == "Telefono") columnaBusqueda = "ColTelefono";
            else if (opcionSeleccionada == "Estado") columnaBusqueda = "ColEstado";

            // 🌟 LA SOLUCIÓN: Quitamos la selección activa de la tabla antes de filtrar.
            // Esto evita que Windows Forms bloquee la acción de ocultar la fila.
            tablaClientes.CurrentCell = null;

            foreach (DataGridViewRow row in tablaClientes.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells[columnaBusqueda].Value != null)
                {
                    // Si el texto de la celda contiene lo que escribimos, se muestra (true), sino se oculta (false)
                    row.Visible = row.Cells[columnaBusqueda].Value.ToString().ToUpper().Contains(filtro);
                }
                else
                {
                    // Si la celda está vacía (null), la ocultamos directamente
                    row.Visible = false;
                }
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroBusqueda();
        }

        // =======================================================
        // 8. EVENTOS VACÍOS DEL DISEÑADOR (NO BORRAR)
        // =======================================================
        private void label2_Click(object sender, EventArgs e) { }
        private void txtBuscarNombre_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtdocumentos_TextChanged(object sender, EventArgs e) { }
        private void txtIdProductos_TextChanged(object sender, EventArgs e) { }
        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }
        private void txtTelefono_TextChanged(object sender, EventArgs e) { }
        private void txtIdcliente_TextChanged(object sender, EventArgs e) { }
        private void tablaProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}