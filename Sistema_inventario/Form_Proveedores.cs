using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sistema_inventario
{
    public partial class Form_Proveedores : Form
    {
        public Form_Proveedores()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void CargarProveedores()
        {
            tablaProveedores.Rows.Clear();
            List<Proveedor> lista = new CN_Proveedor().Listar();

            foreach (Proveedor item in lista)
            {
                // 🌟 AHORA MANDAMOS EXACTAMENTE 6 DATOS PARA TUS 6 COLUMNAS
                tablaProveedores.Rows.Add(new object[] {
            item.IdProveedor,                             // [0] -> Va a tu columna "ID"
            item.Documento,                               // [1] -> Va a "Documento"
            item.RazonSocial,                             // [2] -> Va a "Razon Social"
            item.Correo,                                  // [3] -> Va a "Correo"
            item.Telefono,                                // [4] -> Va a "Telefono"
            item.Estado == true ? "Activo" : "No Activo"  // [5] -> Va a "Estado"
        });
            }
        }


        private void Form_Proveedores_Load(object sender, EventArgs e)
        {
            // 🌟 AQUÍ ESTÁ LA SOLUCIÓN: Conectamos el evento del clic a tu tabla
            tablaProveedores.CellClick -= tablaProveedores_CellClick;
            tablaProveedores.CellClick += tablaProveedores_CellClick;

            // 1. Cargamos los datos en la tabla
            CargarProveedores();

            // 2. Preparamos la lista de Estado para que no esté vacía
            if (cboEstado != null)
            {
                cboEstado.Items.Clear();
                cboEstado.Items.Add("Activo");
                cboEstado.Items.Add("No Activo");
                cboEstado.SelectedIndex = 0;
            }

            // 3. Preparamos el buscador (Sin tildes)
            if (txtBuscarNombre != null)
            {
                txtBuscarNombre.Items.Clear();
                txtBuscarNombre.Items.Add("Documento");
                txtBuscarNombre.Items.Add("RazonSocial");
                txtBuscarNombre.Items.Add("Correo");
                txtBuscarNombre.Items.Add("Telefono");
                txtBuscarNombre.Items.Add("Estado");
                txtBuscarNombre.SelectedIndex = 0;
            }

            // 4. Bloqueamos la caja del ID
            txtIdProveedor.ReadOnly = true;
        }



        private void tablaProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validamos que se haya hecho clic en una fila válida (y no en los títulos de las columnas)
            if (e.RowIndex >= 0)
            {
                // Guardamos la fila entera a la que se le hizo clic
                DataGridViewRow row = tablaProveedores.Rows[e.RowIndex];

                // Rellenamos los detalles pasando los datos de la fila a las cajas de texto correspondientes
                // (Usamos los números de columnas que configuraste en tu imagen)
                txtIdProveedor.Text = row.Cells[0].Value?.ToString() ?? "0";
                txtDocumento.Text = row.Cells[1].Value?.ToString() ?? "";
                txtRazonSocial.Text = row.Cells[2].Value?.ToString() ?? "";
                txtcorreo.Text = row.Cells[3].Value?.ToString() ?? "";
                txttelefono.Text = row.Cells[4].Value?.ToString() ?? "";

                // Para la lista desplegable del estado, simplemente le pasamos el texto ("Activo" o "No Activo")
                cboEstado.Text = row.Cells[5].Value?.ToString() ?? "Activo";
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 🛑 1. VALIDACIÓN BÁSICA: Que los campos clave no estén vacíos
            if (string.IsNullOrWhiteSpace(txtDocumento.Text) || string.IsNullOrWhiteSpace(txtRazonSocial.Text))
            {
                MessageBox.Show("Debe ingresar al menos el Documento y la Razón Social del proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🛡️ 2. CAPTURA SEGURA DEL ID (Evita que el programa explote si la caja está vacía)
            int idActual = 0;
            if (txtIdProveedor.Text.Trim() != "")
            {
                idActual = Convert.ToInt32(txtIdProveedor.Text);
            }

            string mensaje = string.Empty;

            // 🔒 3. NORMALIZAR DOCUMENTO: quitamos espacios extra a los lados por si teclearon un espacio sin querer
            string documentoLimpio = txtDocumento.Text.Trim();
            txtDocumento.Text = documentoLimpio;

            // 🛑 4. VALIDACIÓN: Detectar si realmente hubo cambios antes de editar
            if (idActual > 0) // Solo verificamos si es un proveedor existente (Edición)
            {
                bool hayCambios = false;

                foreach (DataGridViewRow row in tablaProveedores.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == idActual.ToString())
                    {
                        // Comparamos los textos de las cajas con los de la tabla
                        if (documentoLimpio != row.Cells[1].Value?.ToString()) hayCambios = true;
                        if (txtRazonSocial.Text.Trim() != row.Cells[2].Value?.ToString()) hayCambios = true;
                        if (txtcorreo.Text.Trim() != row.Cells[3].Value?.ToString()) hayCambios = true;
                        if (txttelefono.Text.Trim() != row.Cells[4].Value?.ToString()) hayCambios = true;
                        if (cboEstado.Text != row.Cells[5].Value?.ToString()) hayCambios = true;

                        break; // Encontramos la fila, salimos del bucle
                    }
                }

                if (!hayCambios)
                {
                    MessageBox.Show("No editaste nada. Modifica algún dato para poder guardar los cambios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; // 🛑 Cancelamos el guardado
                }
            }

            // --- 5. CREACIÓN DEL OBJETO PROVEEDOR ---
            Proveedor objProveedor = new Proveedor()
            {
                IdProveedor = idActual,
                Documento = documentoLimpio,
                RazonSocial = txtRazonSocial.Text.Trim(),
                Correo = txtcorreo.Text.Trim(),
                Telefono = txttelefono.Text.Trim(),
                Estado = cboEstado.Text == "Activo"
            };

            // --- 6. GUARDADO EN BASE DE DATOS ---
            if (objProveedor.IdProveedor == 0) // Registrar nuevo proveedor
            {
                int idGenerado = new CN_Proveedor().Registrar(objProveedor, out mensaje);

                if (idGenerado != 0)
                {
                    MessageBox.Show("Proveedor registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProveedores();
                    LimpiarCajas();
                }
                else
                {
                    // Si el documento (RUC) está duplicado, el error saltará aquí gracias a SQL
                    MessageBox.Show(mensaje, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else // Editar proveedor existente
            {
                bool resultado = new CN_Proveedor().Editar(objProveedor, out mensaje);

                if (resultado)
                {
                    MessageBox.Show("Proveedor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProveedores();
                    LimpiarCajas();
                }
                else
                {
                    MessageBox.Show(mensaje, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void LimpiarCajas()
        {
            txtIdProveedor.Text = "0";
            txtDocumento.Text = "";
            txtRazonSocial.Text = "";
            txtcorreo.Text = "";
            txttelefono.Text = "";

            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;

            txtDocumento.Select(); // Pone el cursor parpadeando en el Documento
        }


        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            // 1. Llamamos a tu función que vacía todas las cajas de texto y reinicia el estado
            LimpiarCajas();

            // 2. ¡La magia visual! Esto quita el color azul de la fila que estaba seleccionada en la tabla
            tablaProveedores.ClearSelection();

            // 3. Mandamos el cursor (la rayita parpadeante) a la caja del Documento para que puedas escribir rápido
            txtDocumento.Focus();
        }
        private void txtBuscarNombre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void tablaProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtIdProveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";

            // 2. Volvemos a poner la lista de opciones en el primero ("Documento")
            if (txtBuscarNombre.Items.Count > 0)
            {
                txtBuscarNombre.SelectedIndex = 0;
            }

            // 3. Recorremos la tabla de PROVEEDORES y volvemos a mostrar todas las filas
            foreach (DataGridViewRow row in tablaProveedores.Rows)
            {
                row.Visible = true;
            }
        }
        private void AplicarFiltroBusqueda()
        {
            string filtro = txtBusqueda.Text.Trim().ToUpper();

            // Si la lista está vacía o no hay nada seleccionado, cortamos para evitar errores
            if (txtBuscarNombre.SelectedItem == null) return;

            string opcionSeleccionada = txtBuscarNombre.SelectedItem.ToString();
            int columnaBusqueda = 1; // Por defecto buscará en la columna Documento

            // Relacionamos la palabra con el número de columna de tu tabla
            if (opcionSeleccionada == "Documento") columnaBusqueda = 1;
            else if (opcionSeleccionada == "RazonSocial") columnaBusqueda = 2;
            else if (opcionSeleccionada == "Correo") columnaBusqueda = 3;
            else if (opcionSeleccionada == "Telefono") columnaBusqueda = 4;
            else if (opcionSeleccionada == "Estado") columnaBusqueda = 5;

            // Recorremos la tabla y mostramos solo los que coinciden con lo que estás escribiendo
            foreach (DataGridViewRow row in tablaProveedores.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells[columnaBusqueda].Value != null)
                {
                    row.Visible = row.Cells[columnaBusqueda].Value.ToString().ToUpper().Contains(filtro);
                }
            }
        }

       
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroBusqueda();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // 1. Captura segura del ID
            int idActual = 0;
            if (txtIdProveedor.Text.Trim() != "")
            {
                idActual = Convert.ToInt32(txtIdProveedor.Text);
            }

            // 2. Verificamos que haya seleccionado uno
            if (idActual <= 0)
            {
                MessageBox.Show("Por favor, seleccione un proveedor de la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Pedimos confirmación antes de disparar la orden
            if (MessageBox.Show("¿Está seguro de eliminar este proveedor de forma definitiva?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return; // Si dice que NO, cortamos la ejecución aquí
            }

            string mensaje = string.Empty;
            Proveedor objProveedor = new Proveedor() { IdProveedor = idActual };

            // 4. Mandamos la orden a la Capa de Negocio
            bool respuesta = new CN_Proveedor().Eliminar(objProveedor, out mensaje);

            // 5. Evaluamos el resultado
            if (respuesta)
            {
                MessageBox.Show("Proveedor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProveedores();
                LimpiarCajas();
            }
            else
            {
                // 🛑 Si el proveedor está relacionado a una compra/venta, la base de datos lo rechaza 
                // y el mensaje de advertencia aparecerá exactamente aquí.
                MessageBox.Show(mensaje, "Acción Denegada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
