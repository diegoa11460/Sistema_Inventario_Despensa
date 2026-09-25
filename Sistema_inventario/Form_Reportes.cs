using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CapaNegocio;

namespace Sistema_inventario
{
    public partial class Form_Reportes : Form
    {
        private readonly CN_Reportes negocio = new CN_Reportes();
        private const int DIAS_ALERTA_VENCIMIENTO = 30;
        private const int DIAS_ALERTA_CRITICA = 7; // por debajo de este umbral, la fila de vencimiento se pinta en rojo

        // Fecha de referencia para el balance semanal: cualquier fecha dentro de la semana que se quiere ver.
        // Arranca en hoy (semana actual) y se actualiza al navegar con los botones o el DateTimePicker.
        private DateTime fechaReferenciaSemana = DateTime.Today;

        public Form_Reportes()
        {
            InitializeComponent();
            ConfigurarGrillas();

            // Enganchados a mano por si no se conectaron en el Designer (mismo patrón usado en Form_DetalleVentas)
            dtpSemana.MaxDate = DateTime.Today; // no tiene sentido consultar una semana futura
            dtpSemana.Value = DateTime.Today;
            dtpSemana.ValueChanged += dtpSemana_ValueChanged;
            btnSemanaAnterior.Click += btnSemanaAnterior_Click;
            btnSemanaSiguiente.Click += btnSemanaSiguiente_Click;
        }

        // Fuerza el color navy en los encabezados de las 4 tablas por código, sin depender
        // de que el Designer lo aplique correctamente en tiempo de ejecución. También
        // desactiva el ordenamiento por clic, que hacía que WinForms pintara el header
        // con el celeste del tema del sistema al ordenar una columna.
        private void ConfigurarGrillas()
        {
            // dgvVencimientos solo trae Producto/Vence desde el Designer. Se agregan Lote y
            // Cantidad restante por código para no depender de reabrir el Designer de este form.
            if (!dgvVencimientos.Columns.Contains("colVencLote"))
            {
                dgvVencimientos.Columns.Insert(dgvVencimientos.Columns.Count, new DataGridViewTextBoxColumn
                {
                    Name = "colVencLote",
                    HeaderText = "Lote",
                    Width = 90
                });
            }

            if (!dgvVencimientos.Columns.Contains("colVencCantidad"))
            {
                dgvVencimientos.Columns.Insert(dgvVencimientos.Columns.Count, new DataGridViewTextBoxColumn
                {
                    Name = "colVencCantidad",
                    HeaderText = "Cantidad",
                    Width = 80
                });
            }

            DataGridView[] grillas = { dgvVencimientos, dgvStockCritico, dgvMasVendidos, dgvMenosVendidos };

            var estiloEncabezado = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(22, 34, 68),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 9.5F),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                SelectionBackColor = System.Drawing.Color.FromArgb(22, 34, 68),
                SelectionForeColor = System.Drawing.Color.White
            };

            foreach (var grilla in grillas)
            {
                grilla.EnableHeadersVisualStyles = false;
                grilla.ColumnHeadersDefaultCellStyle = estiloEncabezado;

                foreach (DataGridViewColumn columna in grilla.Columns)
                {
                    columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        // Item interno para el combo de meses: guarda mes/año, no solo el texto
        private class MesItem
        {
            public string Nombre { get; set; }
            public int Mes { get; set; }
            public int Anio { get; set; }
            public override string ToString() => Nombre;
        }

        private void Form_Reportes_Load(object sender, EventArgs e)
        {
            CargarComboMeses();

            if (cboMes.Items.Count > 0)
                cboMes.SelectedIndex = cboMes.Items.Count - 1; // el mes actual ahora queda al final de la lista; dispara cboMes_SelectedIndexChanged y genera el primer reporte

            CargarVentasSemana(); // carga inicial de la semana actual; luego la navegación la dispara dtpSemana_ValueChanged
        }

        private void CargarComboMeses()
        {
            cboMes.Items.Clear();

            DateTime hoy = DateTime.Now;
            CultureInfo cultura = new CultureInfo("es-ES");

            // Últimos 12 meses, del más antiguo al más reciente (orden cronológico normal),
            // así el mes actual queda al final de la lista en vez de arriba de todo
            for (int i = 11; i >= 0; i--)
            {
                DateTime fecha = hoy.AddMonths(-i);
                string nombreMes = cultura.DateTimeFormat.GetMonthName(fecha.Month);
                nombreMes = char.ToUpper(nombreMes[0]) + nombreMes.Substring(1);

                cboMes.Items.Add(new MesItem
                {
                    Nombre = $"{nombreMes} {fecha.Year}",
                    Mes = fecha.Month,
                    Anio = fecha.Year
                });
            }
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        // Orquesta la generación completa del reporte:
        // - deshabilita los controles y muestra reloj de arena mientras carga (evita doble clic y da feedback visual)
        // - acumula los mensajes de error de cada sub-reporte en vez de mostrar un MessageBox por cada uno
        // - envuelve todo en try/catch como red de seguridad ante una excepción no controlada de la Capa de Negocio
        private void GenerarReporte()
        {
            if (!(cboMes.SelectedItem is MesItem mesSeleccionado))
                return;

            var errores = new List<string>();

            btnGenerarReporte.Enabled = false;
            cboMes.Enabled = false;
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

            try
            {
                CargarBalance(mesSeleccionado.Mes, mesSeleccionado.Anio, errores);
                CargarVencimientos(errores);
                CargarStockCritico(errores);
                CargarRankingProductos(mesSeleccionado.Mes, mesSeleccionado.Anio, errores);

                if (errores.Count > 0)
                {
                    var detalle = new StringBuilder();
                    foreach (var error in errores)
                        detalle.AppendLine("- " + error);

                    MessageBox.Show("No se pudieron cargar algunos datos del reporte:\n\n" + detalle,
                        "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al generar el reporte: " + ex.Message,
                    "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGenerarReporte.Enabled = true;
                cboMes.Enabled = true;
                System.Windows.Forms.Cursor.Current = Cursors.Default;
            }
        }

        private void CargarBalance(int mes, int anio, List<string> errores)
        {
            var balance = negocio.ObtenerBalance(mes, anio, out string mensaje);

            if (!string.IsNullOrEmpty(mensaje))
            {
                errores.Add("Balance: " + mensaje);
                return;
            }

            lblIngresosValor.Text = "Gs. " + balance.Ingresos.ToString("N0");
            lblComprasValor.Text = "Gs. " + balance.Compras.ToString("N0");
            lblGananciaValor.Text = "Gs. " + balance.Ganancia.ToString("N0");
        }

        // Además de listar los vencimientos, resalta la fila:
        // rojo si vence en DIAS_ALERTA_CRITICA días o menos, amarillo si vence dentro del resto de la ventana de alerta
        private void CargarVencimientos(List<string> errores)
        {
            var lista = negocio.ObtenerVencimientos(DIAS_ALERTA_VENCIMIENTO, out string mensaje);

            if (!string.IsNullOrEmpty(mensaje))
            {
                errores.Add("Vencimientos: " + mensaje);
                return;
            }

            dgvVencimientos.Rows.Clear();

            var colorCritico = System.Drawing.Color.FromArgb(255, 205, 205);
            var colorAlerta = System.Drawing.Color.FromArgb(255, 244, 200);

            foreach (var item in lista)
            {
                int filaIndex = dgvVencimientos.Rows.Add(
                    item.Producto,
                    item.FechaVencimiento.ToString("dd/MM/yyyy"),
                    item.NroLote,
                    item.Cantidad.ToString("0.##"));

                int diasRestantes = (item.FechaVencimiento.Date - DateTime.Now.Date).Days;
                var fila = dgvVencimientos.Rows[filaIndex];

                fila.DefaultCellStyle.BackColor = diasRestantes <= DIAS_ALERTA_CRITICA
                    ? colorCritico
                    : colorAlerta;
            }
        }

        // Además de listar el stock crítico, resalta todas las filas en rojo suave
        // (ya vienen filtradas como críticas desde CN_Reportes, así que no hay niveles intermedios)
        private void CargarStockCritico(List<string> errores)
        {
            var lista = negocio.ObtenerStockCritico(out string mensaje);

            if (!string.IsNullOrEmpty(mensaje))
            {
                errores.Add("Stock crítico: " + mensaje);
                return;
            }

            dgvStockCritico.Rows.Clear();

            var colorCritico = System.Drawing.Color.FromArgb(255, 205, 205);

            foreach (var item in lista)
            {
                int filaIndex = dgvStockCritico.Rows.Add(item.Producto, item.Stock.ToString("0.##"));
                dgvStockCritico.Rows[filaIndex].DefaultCellStyle.BackColor = colorCritico;
            }
        }

        private void CargarRankingProductos(int mes, int anio, List<string> errores)
        {
            var masVendidos = negocio.ObtenerMasVendidos(mes, anio, out string mensaje1);
            var menosVendidos = negocio.ObtenerMenosVendidos(mes, anio, out string mensaje2);

            if (!string.IsNullOrEmpty(mensaje1))
                errores.Add("Más vendidos: " + mensaje1);

            if (!string.IsNullOrEmpty(mensaje2))
                errores.Add("Menos vendidos: " + mensaje2);

            if (!string.IsNullOrEmpty(mensaje1) || !string.IsNullOrEmpty(mensaje2))
                return;

            dgvMasVendidos.Rows.Clear();
            foreach (var item in masVendidos)
                dgvMasVendidos.Rows.Add(item.Producto, item.CantidadVendida.ToString("0.##"));

            dgvMenosVendidos.Rows.Clear();
            foreach (var item in menosVendidos)
                dgvMenosVendidos.Rows.Add(item.Producto, item.CantidadVendida.ToString("0.##"));
        }

        // Devuelve el lunes de la semana a la que pertenece 'fecha' (semana de lunes a domingo)
        private DateTime ObtenerLunesDeSemana(DateTime fecha)
        {
            int diasHastaLunes = ((int)fecha.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
            return fecha.Date.AddDays(-diasHastaLunes);
        }

        private void dtpSemana_ValueChanged(object sender, EventArgs e)
        {
            fechaReferenciaSemana = dtpSemana.Value.Date;
            CargarVentasSemana();
        }

        private void btnSemanaAnterior_Click(object sender, EventArgs e)
        {
            // Cambiar dtpSemana.Value dispara dtpSemana_ValueChanged, que ya recarga el reporte
            dtpSemana.Value = dtpSemana.Value.AddDays(-7);
        }

        private void btnSemanaSiguiente_Click(object sender, EventArgs e)
        {
            DateTime nuevaFecha = dtpSemana.Value.AddDays(7);

            // No dejar avanzar a una semana futura (MaxDate ya lo bloquea, pero VS puede no aplicarlo hasta actualizar)
            if (nuevaFecha > dtpSemana.MaxDate)
                nuevaFecha = dtpSemana.MaxDate;

            dtpSemana.Value = nuevaFecha;
        }

        // Balance semanal (lunes a domingo) de la semana que contiene fechaReferenciaSemana:
        // grafica el total vendido por día y resalta en rojo el día con más ventas.
        // Requiere el control chartVentasSemanal (Chart), dtpSemana, btnSemanaAnterior,
        // btnSemanaSiguiente y opcionalmente lblDiaMasVentas / lblRangoSemana agregados en el Designer.
        private void CargarVentasSemana()
        {
            DateTime lunes = ObtenerLunesDeSemana(fechaReferenciaSemana);
            DateTime domingo = lunes.AddDays(6);

            var lista = negocio.ObtenerVentasSemana(lunes, domingo, out string mensaje);

            if (!string.IsNullOrEmpty(mensaje))
            {
                MessageBox.Show("Error al cargar el balance semanal: " + mensaje, "Reportes",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lblRangoSemana != null)
                lblRangoSemana.Text = $"Semana del {lunes:dd/MM/yyyy} al {domingo:dd/MM/yyyy}";

            // No tiene sentido "avanzar" más allá de la semana que contiene hoy
            btnSemanaSiguiente.Enabled = lunes < ObtenerLunesDeSemana(DateTime.Today);

            chartVentasSemanal.Series.Clear();
            chartVentasSemanal.ChartAreas.Clear();
            chartVentasSemanal.Legends.Clear();
            chartVentasSemanal.BackColor = System.Drawing.Color.White;

            var area = new ChartArea("AreaVentasSemana")
            {
                BackColor = System.Drawing.Color.White
            };
            area.AxisX.Title = "Día";
            area.AxisY.Title = "Total vendido (Gs.)";
            area.AxisX.TitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            area.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            area.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            area.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            area.AxisY.LabelStyle.Format = "N0"; // separador de miles en el eje (12000 -> 12,000)
            area.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(230, 230, 230);
            area.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(230, 230, 230);
            area.AxisX.LineColor = System.Drawing.Color.FromArgb(200, 200, 200);
            area.AxisY.LineColor = System.Drawing.Color.FromArgb(200, 200, 200);
            // Un poco de margen arriba del valor más alto para que la etiqueta de datos no quede pegada al borde
            area.AxisY.IsStartedFromZero = true;
            chartVentasSemanal.ChartAreas.Add(area);

            // Gráfico de barras en vez de líneas: cada día es un valor independiente,
            // evita el efecto de "pico" engañoso que dibuja una línea al conectar días sin ventas
            var serie = new Series("Ventas")
            {
                ChartType = SeriesChartType.Column,
                Color = System.Drawing.Color.FromArgb(100, 160, 255),
                BorderWidth = 1,
                BorderColor = System.Drawing.Color.FromArgb(70, 130, 225),
                IsValueShownAsLabel = true,
                LabelFormat = "N0",
                Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold)
            };
            serie["PointWidth"] = "0.55"; // barras más angostas, se ven menos apretadas con 7 categorías

            decimal maxTotal = -1;
            int indiceMax = -1;

            for (int i = 0; i < lista.Count; i++)
            {
                serie.Points.AddXY(lista[i].DiaSemana, lista[i].Total);

                if (lista[i].Total > maxTotal)
                {
                    maxTotal = lista[i].Total;
                    indiceMax = i;
                }
            }

            chartVentasSemanal.Series.Add(serie);

            // Resalta en rojo la barra del día con más ventas de la semana
            if (indiceMax >= 0 && maxTotal > 0)
            {
                serie.Points[indiceMax].Color = System.Drawing.Color.FromArgb(220, 50, 50);
                serie.Points[indiceMax].BorderColor = System.Drawing.Color.FromArgb(180, 30, 30);
            }

            if (lblDiaMasVentas != null)
            {
                lblDiaMasVentas.Text = indiceMax >= 0 && maxTotal > 0
                    ? $"Día con más ventas: {lista[indiceMax].DiaSemana} (Gs. {maxTotal:N0})"
                    : "Todavía no hay ventas esta semana";
            }
        }

        // Manejadores ya enganchados en el Designer que no requieren lógica adicional por ahora
        private void tabBalance_Click_1(object sender, EventArgs e) { }
        private void pnlIngresos_Paint_1(object sender, PaintEventArgs e) { }
        private void pnlCompras_Paint(object sender, PaintEventArgs e) { }
        private void dgvVencimientos_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvStockCritico_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void tabSemanal_Click(object sender, EventArgs e)
        {

        }
    }
}