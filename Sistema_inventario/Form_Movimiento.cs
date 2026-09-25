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
    public partial class Form_Movimiento : Form
    {
        public Form_Movimiento()
        {
            InitializeComponent();

            // Config visual fija de la grilla: se hace UNA sola vez, no en cada carga
            tablaMovimientos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            tablaMovimientos.EnableHeadersVisualStyles = false;
            tablaMovimientos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(22, 34, 68);
            tablaMovimientos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            tablaMovimientos.ColumnHeadersDefaultCellStyle.Font = new Font(tablaMovimientos.Font, FontStyle.Bold);
            tablaMovimientos.ColumnHeadersHeight = 38;
            tablaMovimientos.RowTemplate.Height = 32;
            tablaMovimientos.BorderStyle = BorderStyle.None;
            tablaMovimientos.GridColor = Color.FromArgb(235, 236, 240);
        }

        // 1. EVENTO LOAD
        private void Form_Movimiento_Load(object sender, EventArgs e)
        {
            // 1. Primero cargamos TODOS los datos desde la base de datos a la grilla
            CargarMovimientos();

            // 2. Luego seleccionamos "Hoy" por defecto.
            // Esto disparará automáticamente el evento del ComboBox y filtrará la grilla
            if (cboFiltroFecha.Items.Count > 0)
            {
                cboFiltroFecha.SelectedItem = "Hoy";
            }
        }

        // MÉTODO PRIVADO: carga la tabla, con manejo de errores
        private void CargarMovimientos()
        {
            tablaMovimientos.Rows.Clear();

            string mensaje;
            List<Movimiento> lista;
            try
            {
                lista = new CN_Movimiento().Listar(out mensaje);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar el historial de movimientos.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(mensaje))
            {
                MessageBox.Show(
                    "No se pudo cargar el historial de movimientos.\n\n" + mensaje,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            foreach (Movimiento item in lista)
            {
                // LÓGICA DE USUARIO (Ej: ADM DIEGO)
                string usuarioTexto = "-";
                if (item.oUsuario != null)
                {
                    string rolOriginal = (item.oUsuario.oRol?.Descripcion ?? "").ToUpper();
                    string nombreCompleto = (item.oUsuario.NombreCompleto ?? "").ToUpper();

                    string primerNombre = "";
                    if (!string.IsNullOrEmpty(nombreCompleto))
                    {
                        primerNombre = nombreCompleto.Split(' ')[0];
                    }

                    string prefijo = "USR";
                    if (rolOriginal.Contains("ADMINISTRADOR"))
                        prefijo = "ADM";
                    else if (rolOriginal.Contains("EMPLEADO"))
                        prefijo = "EMP";
                    else if (rolOriginal.Length >= 3)
                        prefijo = rolOriginal.Substring(0, 3);

                    usuarioTexto = $"{prefijo} {primerNombre}";
                }

                // Texto de tipo con flecha
                string tipoTexto = item.TipoMovimiento;
                if (item.TipoMovimiento == "ENTRADA")
                    tipoTexto = "▲ ENTRADA";
                else if (item.TipoMovimiento == "SALIDA")
                    tipoTexto = "▼ SALIDA";

                int idx = tablaMovimientos.Rows.Add(new object[] {
                    item.FechaRegistro.ToString("dd/MM/yyyy HH:mm"),
                    item.oProducto?.Nombre ?? "-",
                    tipoTexto,
                    item.Motivo,
                    item.Cantidad.ToString("0.##"),
                    item.StockAnterior.ToString("0.##"),
                    item.StockActual.ToString("0.##"),
                    usuarioTexto,
                    item.Observacion
                });

                DataGridViewRow row = tablaMovimientos.Rows[idx];

                // 🔥 TRUCO: Guardamos la fecha real en el Tag de la celda para poder filtrar matemáticamente
                row.Cells["ColFecha"].Tag = item.FechaRegistro;

                // 🌟 Badge según tipo
                if (item.TipoMovimiento == "ENTRADA")
                {
                    row.Cells["ColTipo"].Style.BackColor = Color.FromArgb(230, 255, 230);
                    row.Cells["ColTipo"].Style.ForeColor = Color.FromArgb(0, 128, 0);
                    row.Cells["ColTipo"].Style.Font = new Font(tablaMovimientos.Font, FontStyle.Bold);
                    row.Cells["ColTipo"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (item.TipoMovimiento == "SALIDA")
                {
                    row.Cells["ColTipo"].Style.BackColor = Color.FromArgb(255, 235, 235);
                    row.Cells["ColTipo"].Style.ForeColor = Color.FromArgb(178, 34, 34);
                    row.Cells["ColTipo"].Style.Font = new Font(tablaMovimientos.Font, FontStyle.Bold);
                    row.Cells["ColTipo"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                row.Cells["ColCantidad"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.Cells["ColStockAnterior"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.Cells["ColStockActual"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // =======================================================
        // LÓGICA DE FILTRADO UNIFICADA (TEXTO + FECHA)
        // =======================================================

        private void AplicarFiltros()
        {
            // 1. Obtenemos el texto a buscar
            string filtroTexto = txtBuscarProducto.Text.Trim().ToUpper();

            // 2. Obtenemos el rango de fechas
            ObtenerRangoFechas(out DateTime? fechaInicio, out DateTime? fechaFin);

            // Evitamos error visual si la celda actual se va a ocultar
            tablaMovimientos.CurrentCell = null;

            // 3. Recorremos las filas para ocultar/mostrar
            foreach (DataGridViewRow row in tablaMovimientos.Rows)
            {
                if (row.IsNewRow) continue;

                // Evaluar coincidencia de Texto
                string nombreProducto = row.Cells["ColProducto"].Value?.ToString().ToUpper() ?? "";
                bool coincideTexto = string.IsNullOrEmpty(filtroTexto) || nombreProducto.Contains(filtroTexto);

                // Evaluar coincidencia de Fecha
                bool coincideFecha = true;
                if (fechaInicio != null && fechaFin != null && row.Cells["ColFecha"].Tag != null)
                {
                    // Recuperamos la fecha real que guardamos en el Tag al cargar la tabla
                    DateTime fechaFila = (DateTime)row.Cells["ColFecha"].Tag;
                    coincideFecha = (fechaFila >= fechaInicio.Value && fechaFila <= fechaFin.Value);
                }

                // La fila será visible solo si cumple ambas condiciones
                row.Visible = coincideTexto && coincideFecha;
            }
        }

        private void ObtenerRangoFechas(out DateTime? fechaInicio, out DateTime? fechaFin)
        {
            fechaInicio = null;
            fechaFin = null;
            DateTime hoy = DateTime.Today;

            string filtro = cboFiltroFecha.SelectedItem?.ToString();

            switch (filtro)
            {
                case "Hoy":
                    fechaInicio = hoy;
                    fechaFin = hoy.AddDays(1).AddSeconds(-1);
                    break;
                case "Ayer":
                    fechaInicio = hoy.AddDays(-1);
                    fechaFin = hoy.AddSeconds(-1);
                    break;
                case "Esta Semana":
                    int diff = (7 + (hoy.DayOfWeek - DayOfWeek.Monday)) % 7;
                    fechaInicio = hoy.AddDays(-1 * diff).Date;
                    fechaFin = hoy.AddDays(1).AddSeconds(-1);
                    break;
                case "Este Mes":
                    fechaInicio = new DateTime(hoy.Year, hoy.Month, 1);
                    fechaFin = fechaInicio.Value.AddMonths(1).AddSeconds(-1);
                    break;
                case "Personalizado":
                    fechaInicio = dtpDesde.Value.Date;
                    fechaFin = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);
                    break;
                case "Todos":
                default:
                    break; // Se mantienen en null, lo que significa que no hay filtro de fecha
            }
        }

        // =======================================================
        // EVENTOS DE LOS CONTROLES
        // =======================================================

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cboFiltroFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mostrar u ocultar calendarios según la selección
            bool esPersonalizado = (cboFiltroFecha.SelectedItem?.ToString() == "Personalizado");
            dtpDesde.Visible = esPersonalizado;
            dtpHasta.Visible = esPersonalizado;

            // Nota: Si agregas Labels con texto "Desde:" y "Hasta:", deberías ocultarlos aquí también usando .Visible = esPersonalizado;

            AplicarFiltros(); // Actualiza la tabla automáticamente al cambiar el filtro
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            if (cboFiltroFecha.SelectedItem?.ToString() == "Personalizado") AplicarFiltros();
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            if (cboFiltroFecha.SelectedItem?.ToString() == "Personalizado") AplicarFiltros();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtBuscarProducto.Text = "";

            // Vuelve al filtro de "Hoy" por defecto
            cboFiltroFecha.SelectedItem = "Hoy";

            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now;

            txtBuscarProducto.Focus();
        }

        private void btnExplorapdf_Click(object sender, EventArgs e)
        {
            // Lógica de exportar a PDF (pendiente)
        }

        private void tablaMovimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lógica al hacer clic en celdas
        }
    }
}