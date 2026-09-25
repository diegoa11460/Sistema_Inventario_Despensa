using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 🌟 Enlaces a tu Base de Datos y Lógica
using CapaEntidad;
using CapaNegocio;

namespace Sistema_inventario
{
    public partial class Form_Categoria : Form
    {
        private const int ID_CATEGORIA_PROTEGIDA = 1;

        public Form_Categoria()
        {
            InitializeComponent();
        }

        // =======================================================
        // 🛠️ MÉTODOS AYUDANTES
        // =======================================================
        private void LimpiarCajas()
        {
            txtIdCategoria.Text = "0";
            txtDescripcion.Text = "";
            cboEstado.SelectedIndex = 0;

            // Se vuelve a habilitar para nuevas categorías
            cboEstado.Enabled = true;

            txtDescripcion.Select();
        }

        private void CargarCategorias()
        {
            dgvCategorias.Rows.Clear();
            List<Categoria> lista = new CN_Categoria().Listar();

            foreach (Categoria item in lista)
            {
                dgvCategorias.Rows.Add(new object[] {
                    item.IdCategoria,
                    item.Descripcion,
                    item.Estado == true ? "Activo" : "No Activo"
                });
            }
        }

        private bool ValidarFormulario(int idActual)
        {
            if (idActual == 0 && string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show(
                    "No seleccionaste ninguna categoría de la tabla y el campo Descripción está vacío.\n\n" +
                    "• Si querés editar una categoría existente, seleccionala primero en la tabla.\n" +
                    "• Si querés crear una nueva, escribí la descripción antes de guardar.",
                    "Debe completar los datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción no puede estar vacía.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            if (txtDescripcion.Text.Trim().Length < 3)
            {
                MessageBox.Show("La descripción debe tener al menos 3 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            // OPTIMIZACIÓN: Busca duplicados directamente en la tabla visual
            bool yaExiste = false;
            foreach (DataGridViewRow row in dgvCategorias.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[0].Value.ToString() != idActual.ToString())
                {
                    if (row.Cells[1].Value.ToString().Trim().Equals(txtDescripcion.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        yaExiste = true;
                        break;
                    }
                }
            }

            if (yaExiste)
            {
                MessageBox.Show("Ya existe una categoría con esa descripción en la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            return true;
        }

        // =======================================================
        // 🚀 EVENTOS AL ABRIR EL FORMULARIO
        // =======================================================
        private void Form_Categoria_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Clear();
            cboEstado.Items.Add("Activo");
            cboEstado.Items.Add("No Activo");
            cboEstado.SelectedIndex = 0;

            txtIdCategoria.ReadOnly = true;
            txtIdCategoria.TabStop = false;

            txtBuscarNombre.Items.Clear();
            txtBuscarNombre.Items.Add("Descripción");
            txtBuscarNombre.Items.Add("Estado");
            txtBuscarNombre.SelectedIndex = 0;

            LimpiarCajas();
            CargarCategorias();
        }

        // =======================================================
        // 💾 BOTÓN GUARDAR (btnguarda)
        // =======================================================
        private void btnguarda_Click(object sender, EventArgs e)
        {
            int idActual = Convert.ToInt32(txtIdCategoria.Text);

            if (!ValidarFormulario(idActual))
                return;

            string mensaje = string.Empty;

            Categoria objCategoria = new Categoria()
            {
                IdCategoria = idActual,
                Descripcion = txtDescripcion.Text.Trim(),
                Estado = cboEstado.Text == "Activo"
            };

            if (objCategoria.IdCategoria == 0)
            {
                int idGenerado = new CN_Categoria().Registrar(objCategoria, out mensaje);

                if (idGenerado != 0)
                {
                    MessageBox.Show("Categoría guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCategorias();
                    LimpiarCajas();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                bool resultado = new CN_Categoria().Editar(objCategoria, out mensaje);

                if (resultado)
                {
                    MessageBox.Show("Categoría editada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCategorias();
                    LimpiarCajas();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =======================================================
        // 🗑️ BOTÓN ELIMINAR (bteliminar)
        // =======================================================
        private void bteliminar_Click(object sender, EventArgs e)
        {
            int idActual = Convert.ToInt32(txtIdCategoria.Text);

            if (idActual <= 0)
            {
                MessageBox.Show("Por favor, seleccione una categoría de la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (idActual == ID_CATEGORIA_PROTEGIDA)
            {
                MessageBox.Show("Esta categoría es del sistema y no se puede eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar esta categoría?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            string mensaje = string.Empty;
            Categoria objCategoria = new Categoria() { IdCategoria = idActual };

            bool respuesta = new CN_Categoria().Eliminar(objCategoria, out mensaje);

            if (respuesta)
            {
                MessageBox.Show("Categoría eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCategorias();
                LimpiarCajas();
            }
            else
            {
                // Evaluamos si el mensaje original contiene indicios de que está relacionado a otra tabla
                string mensajeError = mensaje.ToLower();

                if (mensajeError.Contains("reference") ||
                    mensajeError.Contains("conflicto") ||
                    mensajeError.Contains("producto") ||
                    mensajeError.Contains("foreign key"))
                {
                    mensaje = "No se puede eliminar la categoría porque tiene productos relacionados a ella.\nLe recomendamos cambiar su estado a 'No Activo' desde el botón guardar.";
                }

                MessageBox.Show(mensaje, "No se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =======================================================
        // 🖱️ SELECCIONAR DATOS DE LA TABLA AL HACER CLIC
        // =======================================================
        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvCategorias.Rows[e.RowIndex];

            // Llenamos las cajas de texto con los datos de la fila
            txtIdCategoria.Text = row.Cells[0].Value?.ToString() ?? "0";
            txtDescripcion.Text = row.Cells[1].Value?.ToString() ?? "";
            cboEstado.Text = row.Cells[2].Value?.ToString() ?? "Activo";

            // Habilitamos el ComboBox SIEMPRE para que puedas cambiar su estado libremente
            cboEstado.Enabled = true;
        }

        // =======================================================
        // 🔍 BÚSQUEDA
        // =======================================================
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AplicarFiltroBusqueda();
        }

        private void AplicarFiltroBusqueda()
        {
            string filtro = txtBusqueda.Text.Trim().ToUpper();
            int columnaBusqueda = txtBuscarNombre.SelectedIndex == 1 ? 2 : 1;

            foreach (DataGridViewRow row in dgvCategorias.Rows)
            {
                if (row.Cells[columnaBusqueda].Value != null)
                {
                    row.Visible = row.Cells[columnaBusqueda].Value.ToString().ToUpper().Contains(filtro);
                }
            }
        }

        // =======================================================
        // 🧹 BOTÓN LIMPIAR BÚSQUEDA (Escoba / iconButton2)
        // =======================================================
        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            txtBuscarNombre.SelectedIndex = 0;

            foreach (DataGridViewRow row in dgvCategorias.Rows)
            {
                row.Visible = true;
            }

            LimpiarCajas();
        }

        private void txtBuscarNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBusqueda.Text))
            {
                AplicarFiltroBusqueda();
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroBusqueda();
        }

        // =======================================================
        // ⚡ NUEVO: GUARDAR AL PRESIONAR "ENTER"
        // =======================================================
        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnguarda_Click(sender, e);
            }
        }

        // =======================================================
        // 🛑 EVENTOS VACÍOS EXIGIDOS POR EL DISEÑADOR
        // =======================================================
        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void iconButton2_Click(object sender, EventArgs e) { btnLimpiarBusqueda_Click(sender, e); }
        private void txtBuscarNombre_TextChanged(object sender, EventArgs e) { }
        private void guna2Panel5_Paint(object sender, PaintEventArgs e) { }
        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtIdCategoria_TextChanged(object sender, EventArgs e) { }
        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void guna2Panel5_Paint_1(object sender, PaintEventArgs e) { }
    }
}