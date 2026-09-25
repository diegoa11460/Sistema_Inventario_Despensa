namespace Sistema_inventario
{
    partial class Form_Reportes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblMes = new System.Windows.Forms.Label();
            this.cboMes = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnGenerarReporte = new FontAwesome.Sharp.IconButton();
            this.btnDescargarInforme = new FontAwesome.Sharp.IconButton();
            this.tabControlReportes = new System.Windows.Forms.TabControl();
            this.tabBalance = new System.Windows.Forms.TabPage();
            this.chartGananciaMensual = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblResumenGanancia = new System.Windows.Forms.Label();
            this.pnlIngresos = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIngresosComparacion = new System.Windows.Forms.Label();
            this.lblIngresosValor = new System.Windows.Forms.Label();
            this.lblIngresosTitulo = new System.Windows.Forms.Label();
            this.pnlCompras = new Guna.UI2.WinForms.Guna2Panel();
            this.lblComprasComparacion = new System.Windows.Forms.Label();
            this.lblComprasValor = new System.Windows.Forms.Label();
            this.lblComprasTitulo = new System.Windows.Forms.Label();
            this.pnlGanancia = new Guna.UI2.WinForms.Guna2Panel();
            this.lblGananciaComparacion = new System.Windows.Forms.Label();
            this.lblGananciaValor = new System.Windows.Forms.Label();
            this.lblGananciaTitulo = new System.Windows.Forms.Label();

            // Pestaña Alertas
            this.tabAlertas = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelAlertas = new System.Windows.Forms.TableLayoutPanel();
            this.lblVencimientos = new System.Windows.Forms.Label();
            this.dgvVencimientos = new System.Windows.Forms.DataGridView();
            this.ColVencProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColVencFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStockCritico = new System.Windows.Forms.DataGridView();
            this.ColStockProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStockCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblStockCritico = new System.Windows.Forms.Label();

            // Pestaña Productos
            this.tabProductos = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelProductos = new System.Windows.Forms.TableLayoutPanel();
            this.lblMasVendidos = new System.Windows.Forms.Label();
            this.dgvMasVendidos = new System.Windows.Forms.DataGridView();
            this.ColMasProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMasCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMenosVendidos = new System.Windows.Forms.DataGridView();
            this.ColMenosProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMenosCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMenosVendidos = new System.Windows.Forms.Label();

            // Pestaña Semanal
            this.tabSemanal = new System.Windows.Forms.TabPage();
            this.lblTituloSemanal = new System.Windows.Forms.Label();
            this.btnSemanaAnterior = new System.Windows.Forms.Button();
            this.dtpSemana = new System.Windows.Forms.DateTimePicker();
            this.btnSemanaSiguiente = new System.Windows.Forms.Button();
            this.lblRangoSemana = new System.Windows.Forms.Label();
            this.chartVentasSemanal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblDiaMasVentas = new System.Windows.Forms.Label();

            this.tabControlReportes.SuspendLayout();
            this.tabBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGananciaMensual)).BeginInit();
            this.pnlIngresos.SuspendLayout();
            this.pnlCompras.SuspendLayout();
            this.pnlGanancia.SuspendLayout();
            this.tabAlertas.SuspendLayout();
            this.tableLayoutPanelAlertas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVencimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockCritico)).BeginInit();
            this.tabProductos.SuspendLayout();
            this.tableLayoutPanelProductos.SuspendLayout(); // Suspender layout de la tabla productos
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasVendidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenosVendidos)).BeginInit();
            this.tabSemanal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasSemanal)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.lblTitulo.Location = new System.Drawing.Point(25, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(291, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Panel de Control y Reportes";
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(65)))), ((int)(((byte)(110)))));
            this.lblMes.Location = new System.Drawing.Point(25, 60);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(90, 15);
            this.lblMes.TabIndex = 1;
            this.lblMes.Text = "Mes de Análisis";
            // 
            // cboMes
            // 
            this.cboMes.BackColor = System.Drawing.Color.Transparent;
            this.cboMes.BorderRadius = 5;
            this.cboMes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboMes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FocusedColor = System.Drawing.Color.Empty;
            this.cboMes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboMes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboMes.ItemHeight = 30;
            this.cboMes.Location = new System.Drawing.Point(25, 78);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(200, 36);
            this.cboMes.TabIndex = 2;
            this.cboMes.SelectedIndexChanged += new System.EventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.btnGenerarReporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarReporte.FlatAppearance.BorderSize = 0;
            this.btnGenerarReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarReporte.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGenerarReporte.ForeColor = System.Drawing.Color.White;
            this.btnGenerarReporte.IconChar = FontAwesome.Sharp.IconChar.Rocket;
            this.btnGenerarReporte.IconColor = System.Drawing.Color.White;
            this.btnGenerarReporte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGenerarReporte.IconSize = 18;
            this.btnGenerarReporte.Location = new System.Drawing.Point(238, 78);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(160, 36);
            this.btnGenerarReporte.TabIndex = 3;
            this.btnGenerarReporte.Text = " Generar Reporte";
            this.btnGenerarReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerarReporte.UseVisualStyleBackColor = false;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // btnDescargarInforme
            // 
            this.btnDescargarInforme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDescargarInforme.BackColor = System.Drawing.Color.White;
            this.btnDescargarInforme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargarInforme.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDescargarInforme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargarInforme.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDescargarInforme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDescargarInforme.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            this.btnDescargarInforme.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDescargarInforme.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDescargarInforme.IconSize = 18;
            this.btnDescargarInforme.Location = new System.Drawing.Point(660, 68);
            this.btnDescargarInforme.Name = "btnDescargarInforme";
            this.btnDescargarInforme.Size = new System.Drawing.Size(260, 38);
            this.btnDescargarInforme.TabIndex = 4;
            this.btnDescargarInforme.Text = " Descargar Informe (PDF)";
            this.btnDescargarInforme.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDescargarInforme.UseVisualStyleBackColor = false;
            // 
            // tabControlReportes
            // 
            this.tabControlReportes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlReportes.Controls.Add(this.tabBalance);
            this.tabControlReportes.Controls.Add(this.tabAlertas);
            this.tabControlReportes.Controls.Add(this.tabProductos);
            this.tabControlReportes.Controls.Add(this.tabSemanal);
            this.tabControlReportes.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.tabControlReportes.ItemSize = new System.Drawing.Size(150, 34);
            this.tabControlReportes.Location = new System.Drawing.Point(12, 148);
            this.tabControlReportes.Name = "tabControlReportes";
            this.tabControlReportes.SelectedIndex = 0;
            this.tabControlReportes.Size = new System.Drawing.Size(908, 389);
            this.tabControlReportes.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlReportes.TabIndex = 6;
            // 
            // tabBalance
            // 
            this.tabBalance.BackColor = System.Drawing.Color.White;
            this.tabBalance.Controls.Add(this.chartGananciaMensual);
            this.tabBalance.Controls.Add(this.lblResumenGanancia);
            this.tabBalance.Controls.Add(this.pnlIngresos);
            this.tabBalance.Controls.Add(this.pnlCompras);
            this.tabBalance.Controls.Add(this.pnlGanancia);
            this.tabBalance.Location = new System.Drawing.Point(4, 38);
            this.tabBalance.Name = "tabBalance";
            this.tabBalance.Padding = new System.Windows.Forms.Padding(20);
            this.tabBalance.Size = new System.Drawing.Size(900, 347);
            this.tabBalance.TabIndex = 0;
            this.tabBalance.Text = "💵 Balance";
            this.tabBalance.Click += new System.EventHandler(this.tabBalance_Click_1);
            // 
            // chartGananciaMensual
            // 
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
            chartArea1.AxisY.LabelStyle.Format = "N0";
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            chartArea1.Name = "AreaGananciaMensual";
            this.chartGananciaMensual.ChartAreas.Add(chartArea1);
            this.chartGananciaMensual.Location = new System.Drawing.Point(12, 175);
            this.chartGananciaMensual.Name = "chartGananciaMensual";
            series1.ChartArea = "AreaGananciaMensual";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            series1.IsValueShownAsLabel = true;
            series1.LabelFormat = "N0";
            series1.Name = "GananciaMensual";
            this.chartGananciaMensual.Series.Add(series1);
            this.chartGananciaMensual.Size = new System.Drawing.Size(876, 120);
            this.chartGananciaMensual.TabIndex = 3;
            this.chartGananciaMensual.Text = "chartGananciaMensual";
            // 
            // lblResumenGanancia
            // 
            this.lblResumenGanancia.AutoSize = true;
            this.lblResumenGanancia.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblResumenGanancia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(65)))), ((int)(((byte)(110)))));
            this.lblResumenGanancia.Location = new System.Drawing.Point(12, 300);
            this.lblResumenGanancia.Name = "lblResumenGanancia";
            this.lblResumenGanancia.Size = new System.Drawing.Size(163, 15);
            this.lblResumenGanancia.TabIndex = 4;
            this.lblResumenGanancia.Text = "Mejor mes: —  ·  Peor mes: —";
            // 
            // pnlIngresos
            // 
            this.pnlIngresos.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            this.pnlIngresos.BorderRadius = 12;
            this.pnlIngresos.BorderThickness = 1;
            this.pnlIngresos.Controls.Add(this.lblIngresosComparacion);
            this.pnlIngresos.Controls.Add(this.lblIngresosValor);
            this.pnlIngresos.Controls.Add(this.lblIngresosTitulo);
            this.pnlIngresos.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.pnlIngresos.Location = new System.Drawing.Point(12, 44);
            this.pnlIngresos.Name = "pnlIngresos";
            this.pnlIngresos.Size = new System.Drawing.Size(215, 112);
            this.pnlIngresos.TabIndex = 0;
            // 
            // lblIngresosComparacion
            // 
            this.lblIngresosComparacion.AutoSize = true;
            this.lblIngresosComparacion.BackColor = System.Drawing.Color.Transparent;
            this.lblIngresosComparacion.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblIngresosComparacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(130)))));
            this.lblIngresosComparacion.Location = new System.Drawing.Point(18, 88);
            this.lblIngresosComparacion.Name = "lblIngresosComparacion";
            this.lblIngresosComparacion.Size = new System.Drawing.Size(103, 13);
            this.lblIngresosComparacion.TabIndex = 2;
            this.lblIngresosComparacion.Text = "vs mes anterior: —";
            // 
            // lblIngresosValor
            // 
            this.lblIngresosValor.AutoSize = true;
            this.lblIngresosValor.BackColor = System.Drawing.Color.Transparent;
            this.lblIngresosValor.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblIngresosValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.lblIngresosValor.Location = new System.Drawing.Point(18, 48);
            this.lblIngresosValor.Name = "lblIngresosValor";
            this.lblIngresosValor.Size = new System.Drawing.Size(77, 37);
            this.lblIngresosValor.TabIndex = 1;
            this.lblIngresosValor.Text = "Gs. 0";
            // 
            // lblIngresosTitulo
            // 
            this.lblIngresosTitulo.AutoSize = true;
            this.lblIngresosTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblIngresosTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIngresosTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblIngresosTitulo.Location = new System.Drawing.Point(18, 18);
            this.lblIngresosTitulo.Name = "lblIngresosTitulo";
            this.lblIngresosTitulo.Size = new System.Drawing.Size(140, 15);
            this.lblIngresosTitulo.TabIndex = 0;
            this.lblIngresosTitulo.Text = "INGRESOS POR VENTAS";
            // 
            // pnlCompras
            // 
            this.pnlCompras.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(220)))), ((int)(((byte)(180)))));
            this.pnlCompras.BorderRadius = 12;
            this.pnlCompras.BorderThickness = 1;
            this.pnlCompras.Controls.Add(this.lblComprasComparacion);
            this.pnlCompras.Controls.Add(this.lblComprasValor);
            this.pnlCompras.Controls.Add(this.lblComprasTitulo);
            this.pnlCompras.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            this.pnlCompras.Location = new System.Drawing.Point(273, 44);
            this.pnlCompras.Name = "pnlCompras";
            this.pnlCompras.Size = new System.Drawing.Size(207, 112);
            this.pnlCompras.TabIndex = 1;
            // 
            // lblComprasComparacion
            // 
            this.lblComprasComparacion.AutoSize = true;
            this.lblComprasComparacion.BackColor = System.Drawing.Color.Transparent;
            this.lblComprasComparacion.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblComprasComparacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(130)))));
            this.lblComprasComparacion.Location = new System.Drawing.Point(18, 88);
            this.lblComprasComparacion.Name = "lblComprasComparacion";
            this.lblComprasComparacion.Size = new System.Drawing.Size(103, 13);
            this.lblComprasComparacion.TabIndex = 2;
            this.lblComprasComparacion.Text = "vs mes anterior: —";
            // 
            // lblComprasValor
            // 
            this.lblComprasValor.AutoSize = true;
            this.lblComprasValor.BackColor = System.Drawing.Color.Transparent;
            this.lblComprasValor.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblComprasValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.lblComprasValor.Location = new System.Drawing.Point(18, 48);
            this.lblComprasValor.Name = "lblComprasValor";
            this.lblComprasValor.Size = new System.Drawing.Size(77, 37);
            this.lblComprasValor.TabIndex = 1;
            this.lblComprasValor.Text = "Gs. 0";
            // 
            // lblComprasTitulo
            // 
            this.lblComprasTitulo.AutoSize = true;
            this.lblComprasTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblComprasTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblComprasTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(110)))), ((int)(((byte)(0)))));
            this.lblComprasTitulo.Location = new System.Drawing.Point(18, 18);
            this.lblComprasTitulo.Name = "lblComprasTitulo";
            this.lblComprasTitulo.Size = new System.Drawing.Size(139, 15);
            this.lblComprasTitulo.TabIndex = 0;
            this.lblComprasTitulo.Text = "INVERSIÓN (COMPRAS)";
            // 
            // pnlGanancia
            // 
            this.pnlGanancia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlGanancia.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.pnlGanancia.BorderRadius = 12;
            this.pnlGanancia.BorderThickness = 1;
            this.pnlGanancia.Controls.Add(this.lblGananciaComparacion);
            this.pnlGanancia.Controls.Add(this.lblGananciaValor);
            this.pnlGanancia.Controls.Add(this.lblGananciaTitulo);
            this.pnlGanancia.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlGanancia.Location = new System.Drawing.Point(524, 44);
            this.pnlGanancia.Name = "pnlGanancia";
            this.pnlGanancia.Size = new System.Drawing.Size(206, 112);
            this.pnlGanancia.TabIndex = 2;
            // 
            // lblGananciaComparacion
            // 
            this.lblGananciaComparacion.AutoSize = true;
            this.lblGananciaComparacion.BackColor = System.Drawing.Color.Transparent;
            this.lblGananciaComparacion.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblGananciaComparacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(130)))));
            this.lblGananciaComparacion.Location = new System.Drawing.Point(18, 88);
            this.lblGananciaComparacion.Name = "lblGananciaComparacion";
            this.lblGananciaComparacion.Size = new System.Drawing.Size(103, 13);
            this.lblGananciaComparacion.TabIndex = 2;
            this.lblGananciaComparacion.Text = "vs mes anterior: —";
            // 
            // lblGananciaValor
            // 
            this.lblGananciaValor.AutoSize = true;
            this.lblGananciaValor.BackColor = System.Drawing.Color.Transparent;
            this.lblGananciaValor.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblGananciaValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.lblGananciaValor.Location = new System.Drawing.Point(18, 48);
            this.lblGananciaValor.Name = "lblGananciaValor";
            this.lblGananciaValor.Size = new System.Drawing.Size(77, 37);
            this.lblGananciaValor.TabIndex = 1;
            this.lblGananciaValor.Text = "Gs. 0";
            // 
            // lblGananciaTitulo
            // 
            this.lblGananciaTitulo.AutoSize = true;
            this.lblGananciaTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblGananciaTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGananciaTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.lblGananciaTitulo.Location = new System.Drawing.Point(18, 18);
            this.lblGananciaTitulo.Name = "lblGananciaTitulo";
            this.lblGananciaTitulo.Size = new System.Drawing.Size(147, 15);
            this.lblGananciaTitulo.TabIndex = 0;
            this.lblGananciaTitulo.Text = "GANANCIA NETA (aprox.)";
            // 
            // tabAlertas
            // 
            this.tabAlertas.BackColor = System.Drawing.Color.White;
            this.tabAlertas.Controls.Add(this.tableLayoutPanelAlertas);
            this.tabAlertas.Location = new System.Drawing.Point(4, 38);
            this.tabAlertas.Name = "tabAlertas";
            this.tabAlertas.Padding = new System.Windows.Forms.Padding(20);
            this.tabAlertas.Size = new System.Drawing.Size(900, 347);
            this.tabAlertas.TabIndex = 1;
            this.tabAlertas.Text = "⚠️ Alertas Críticas";
            // 
            // tableLayoutPanelAlertas
            // 
            this.tableLayoutPanelAlertas.ColumnCount = 2;
            this.tableLayoutPanelAlertas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAlertas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAlertas.Controls.Add(this.lblVencimientos, 0, 0);
            this.tableLayoutPanelAlertas.Controls.Add(this.lblStockCritico, 1, 0);
            this.tableLayoutPanelAlertas.Controls.Add(this.dgvVencimientos, 0, 1);
            this.tableLayoutPanelAlertas.Controls.Add(this.dgvStockCritico, 1, 1);
            this.tableLayoutPanelAlertas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAlertas.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanelAlertas.Name = "tableLayoutPanelAlertas";
            this.tableLayoutPanelAlertas.RowCount = 2;
            this.tableLayoutPanelAlertas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelAlertas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAlertas.Size = new System.Drawing.Size(860, 307);
            this.tableLayoutPanelAlertas.TabIndex = 0;
            // 
            // lblVencimientos
            // 
            this.lblVencimientos.AutoSize = true;
            this.lblVencimientos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVencimientos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblVencimientos.Location = new System.Drawing.Point(3, 0);
            this.lblVencimientos.Name = "lblVencimientos";
            this.lblVencimientos.Size = new System.Drawing.Size(244, 19);
            this.lblVencimientos.TabIndex = 0;
            this.lblVencimientos.Text = "⏰ Próximos a Vencer (o vencidos)";
            // 
            // dgvVencimientos
            // 
            this.dgvVencimientos.AllowUserToAddRows = false;
            this.dgvVencimientos.AllowUserToDeleteRows = false;
            this.dgvVencimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVencimientos.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.dgvVencimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVencimientos.BackgroundColor = System.Drawing.Color.White;
            this.dgvVencimientos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVencimientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVencimientos.ColumnHeadersHeight = 34;
            this.dgvVencimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColVencProducto,
            this.ColVencFecha});
            this.dgvVencimientos.EnableHeadersVisualStyles = false;
            this.dgvVencimientos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvVencimientos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.dgvVencimientos.Name = "dgvVencimientos";
            this.dgvVencimientos.ReadOnly = true;
            this.dgvVencimientos.RowHeadersVisible = false;
            this.dgvVencimientos.RowTemplate.Height = 30;
            this.dgvVencimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVencimientos.TabIndex = 1;
            this.dgvVencimientos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVencimientos_CellContentClick);
            // 
            // ColVencProducto
            // 
            this.ColVencProducto.HeaderText = "Producto";
            this.ColVencProducto.Name = "ColVencProducto";
            this.ColVencProducto.ReadOnly = true;
            // 
            // ColVencFecha
            // 
            this.ColVencFecha.HeaderText = "Vence";
            this.ColVencFecha.Name = "ColVencFecha";
            this.ColVencFecha.ReadOnly = true;
            // 
            // lblStockCritico
            // 
            this.lblStockCritico.AutoSize = true;
            this.lblStockCritico.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStockCritico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblStockCritico.Location = new System.Drawing.Point(440, 0);
            this.lblStockCritico.Name = "lblStockCritico";
            this.lblStockCritico.Size = new System.Drawing.Size(221, 19);
            this.lblStockCritico.TabIndex = 2;
            this.lblStockCritico.Text = "📦 Stock Crítico (para reponer)";
            // 
            // dgvStockCritico
            // 
            this.dgvStockCritico.AllowUserToAddRows = false;
            this.dgvStockCritico.AllowUserToDeleteRows = false;
            this.dgvStockCritico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStockCritico.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.dgvStockCritico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStockCritico.BackgroundColor = System.Drawing.Color.White;
            this.dgvStockCritico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStockCritico.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStockCritico.ColumnHeadersHeight = 34;
            this.dgvStockCritico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColStockProducto,
            this.ColStockCantidad});
            this.dgvStockCritico.EnableHeadersVisualStyles = false;
            this.dgvStockCritico.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvStockCritico.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.dgvStockCritico.Name = "dgvStockCritico";
            this.dgvStockCritico.ReadOnly = true;
            this.dgvStockCritico.RowHeadersVisible = false;
            this.dgvStockCritico.RowTemplate.Height = 30;
            this.dgvStockCritico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockCritico.TabIndex = 3;
            this.dgvStockCritico.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockCritico_CellContentClick);
            // 
            // ColStockProducto
            // 
            this.ColStockProducto.HeaderText = "Producto";
            this.ColStockProducto.Name = "ColStockProducto";
            this.ColStockProducto.ReadOnly = true;
            // 
            // ColStockCantidad
            // 
            this.ColStockCantidad.HeaderText = "Stock Actual";
            this.ColStockCantidad.Name = "ColStockCantidad";
            this.ColStockCantidad.ReadOnly = true;
            // 
            // tabProductos
            // 
            this.tabProductos.BackColor = System.Drawing.Color.White;
            this.tabProductos.Controls.Add(this.tableLayoutPanelProductos); // Aplicado nuevo TableLayoutPanel a Productos
            this.tabProductos.Location = new System.Drawing.Point(4, 38);
            this.tabProductos.Name = "tabProductos";
            this.tabProductos.Padding = new System.Windows.Forms.Padding(20);
            this.tabProductos.Size = new System.Drawing.Size(900, 347);
            this.tabProductos.TabIndex = 2;
            this.tabProductos.Text = "🏆 Productos";
            // 
            // tableLayoutPanelProductos
            // 
            this.tableLayoutPanelProductos.ColumnCount = 2;
            this.tableLayoutPanelProductos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelProductos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelProductos.Controls.Add(this.lblMasVendidos, 0, 0);
            this.tableLayoutPanelProductos.Controls.Add(this.lblMenosVendidos, 1, 0);
            this.tableLayoutPanelProductos.Controls.Add(this.dgvMasVendidos, 0, 1);
            this.tableLayoutPanelProductos.Controls.Add(this.dgvMenosVendidos, 1, 1);
            this.tableLayoutPanelProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelProductos.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanelProductos.Name = "tableLayoutPanelProductos";
            this.tableLayoutPanelProductos.RowCount = 2;
            this.tableLayoutPanelProductos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelProductos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProductos.Size = new System.Drawing.Size(860, 307);
            this.tableLayoutPanelProductos.TabIndex = 0;
            // 
            // lblMasVendidos
            // 
            this.lblMasVendidos.AutoSize = true;
            this.lblMasVendidos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMasVendidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblMasVendidos.Location = new System.Drawing.Point(3, 0);
            this.lblMasVendidos.Name = "lblMasVendidos";
            this.lblMasVendidos.Size = new System.Drawing.Size(195, 19);
            this.lblMasVendidos.TabIndex = 0;
            this.lblMasVendidos.Text = "⭐ Los Más Vendidos (Top 5)";
            // 
            // dgvMasVendidos
            // 
            this.dgvMasVendidos.AllowUserToAddRows = false;
            this.dgvMasVendidos.AllowUserToDeleteRows = false;
            this.dgvMasVendidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMasVendidos.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.dgvMasVendidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMasVendidos.BackgroundColor = System.Drawing.Color.White;
            this.dgvMasVendidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMasVendidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMasVendidos.ColumnHeadersHeight = 34;
            this.dgvMasVendidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMasProducto,
            this.ColMasCantidad});
            this.dgvMasVendidos.EnableHeadersVisualStyles = false;
            this.dgvMasVendidos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvMasVendidos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.dgvMasVendidos.Name = "dgvMasVendidos";
            this.dgvMasVendidos.ReadOnly = true;
            this.dgvMasVendidos.RowHeadersVisible = false;
            this.dgvMasVendidos.RowTemplate.Height = 30;
            this.dgvMasVendidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMasVendidos.TabIndex = 1;
            // 
            // ColMasProducto
            // 
            this.ColMasProducto.HeaderText = "Producto";
            this.ColMasProducto.Name = "ColMasProducto";
            this.ColMasProducto.ReadOnly = true;
            // 
            // ColMasCantidad
            // 
            this.ColMasCantidad.HeaderText = "Unid. Vendidas";
            this.ColMasCantidad.Name = "ColMasCantidad";
            this.ColMasCantidad.ReadOnly = true;
            // 
            // lblMenosVendidos
            // 
            this.lblMenosVendidos.AutoSize = true;
            this.lblMenosVendidos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMenosVendidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.lblMenosVendidos.Location = new System.Drawing.Point(440, 0);
            this.lblMenosVendidos.Name = "lblMenosVendidos";
            this.lblMenosVendidos.Size = new System.Drawing.Size(219, 19);
            this.lblMenosVendidos.TabIndex = 2;
            this.lblMenosVendidos.Text = "🧊 Los Menos Vendidos (Top 5)";
            // 
            // dgvMenosVendidos
            // 
            this.dgvMenosVendidos.AllowUserToAddRows = false;
            this.dgvMenosVendidos.AllowUserToDeleteRows = false;
            this.dgvMenosVendidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMenosVendidos.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.dgvMenosVendidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMenosVendidos.BackgroundColor = System.Drawing.Color.White;
            this.dgvMenosVendidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMenosVendidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMenosVendidos.ColumnHeadersHeight = 34;
            this.dgvMenosVendidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMenosProducto,
            this.ColMenosCantidad});
            this.dgvMenosVendidos.EnableHeadersVisualStyles = false;
            this.dgvMenosVendidos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvMenosVendidos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.dgvMenosVendidos.Name = "dgvMenosVendidos";
            this.dgvMenosVendidos.ReadOnly = true;
            this.dgvMenosVendidos.RowHeadersVisible = false;
            this.dgvMenosVendidos.RowTemplate.Height = 30;
            this.dgvMenosVendidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMenosVendidos.TabIndex = 3;
            // 
            // ColMenosProducto
            // 
            this.ColMenosProducto.HeaderText = "Producto";
            this.ColMenosProducto.Name = "ColMenosProducto";
            this.ColMenosProducto.ReadOnly = true;
            // 
            // ColMenosCantidad
            // 
            this.ColMenosCantidad.HeaderText = "Unid. Vendidas";
            this.ColMenosCantidad.Name = "ColMenosCantidad";
            this.ColMenosCantidad.ReadOnly = true;
            // 
            // tabSemanal
            // 
            this.tabSemanal.BackColor = System.Drawing.Color.White;
            this.tabSemanal.Controls.Add(this.lblTituloSemanal);
            this.tabSemanal.Controls.Add(this.btnSemanaAnterior);
            this.tabSemanal.Controls.Add(this.dtpSemana);
            this.tabSemanal.Controls.Add(this.btnSemanaSiguiente);
            this.tabSemanal.Controls.Add(this.lblRangoSemana);
            this.tabSemanal.Controls.Add(this.chartVentasSemanal);
            this.tabSemanal.Controls.Add(this.lblDiaMasVentas);
            this.tabSemanal.Location = new System.Drawing.Point(4, 38);
            this.tabSemanal.Name = "tabSemanal";
            this.tabSemanal.Padding = new System.Windows.Forms.Padding(20);
            this.tabSemanal.Size = new System.Drawing.Size(900, 347);
            this.tabSemanal.TabIndex = 3;
            this.tabSemanal.Text = "📅 Semana";
            this.tabSemanal.Click += new System.EventHandler(this.tabSemanal_Click);
            // 
            // lblTituloSemanal
            // 
            this.lblTituloSemanal.AutoSize = true;
            this.lblTituloSemanal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloSemanal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.lblTituloSemanal.Location = new System.Drawing.Point(30, 25);
            this.lblTituloSemanal.Name = "lblTituloSemanal";
            this.lblTituloSemanal.Size = new System.Drawing.Size(275, 19);
            this.lblTituloSemanal.TabIndex = 0;
            this.lblTituloSemanal.Text = "📈 Balance Semanal (Lunes a Domingo)";
            // 
            // btnSemanaAnterior
            // 
            this.btnSemanaAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.btnSemanaAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSemanaAnterior.FlatAppearance.BorderSize = 0;
            this.btnSemanaAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSemanaAnterior.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSemanaAnterior.ForeColor = System.Drawing.Color.White;
            this.btnSemanaAnterior.Location = new System.Drawing.Point(30, 54);
            this.btnSemanaAnterior.Name = "btnSemanaAnterior";
            this.btnSemanaAnterior.Size = new System.Drawing.Size(34, 28);
            this.btnSemanaAnterior.TabIndex = 1;
            this.btnSemanaAnterior.Text = "‹";
            this.btnSemanaAnterior.UseVisualStyleBackColor = false;
            // 
            // dtpSemana
            // 
            this.dtpSemana.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpSemana.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSemana.Location = new System.Drawing.Point(70, 55);
            this.dtpSemana.Name = "dtpSemana";
            this.dtpSemana.Size = new System.Drawing.Size(130, 24);
            this.dtpSemana.TabIndex = 2;
            // 
            // btnSemanaSiguiente
            // 
            this.btnSemanaSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.btnSemanaSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSemanaSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSemanaSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSemanaSiguiente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSemanaSiguiente.ForeColor = System.Drawing.Color.White;
            this.btnSemanaSiguiente.Location = new System.Drawing.Point(206, 54);
            this.btnSemanaSiguiente.Name = "btnSemanaSiguiente";
            this.btnSemanaSiguiente.Size = new System.Drawing.Size(34, 28);
            this.btnSemanaSiguiente.TabIndex = 3;
            this.btnSemanaSiguiente.Text = "›";
            this.btnSemanaSiguiente.UseVisualStyleBackColor = false;
            // 
            // lblRangoSemana
            // 
            this.lblRangoSemana.AutoSize = true;
            this.lblRangoSemana.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRangoSemana.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(65)))), ((int)(((byte)(110)))));
            this.lblRangoSemana.Location = new System.Drawing.Point(255, 61);
            this.lblRangoSemana.Name = "lblRangoSemana";
            this.lblRangoSemana.Size = new System.Drawing.Size(128, 17);
            this.lblRangoSemana.TabIndex = 4;
            this.lblRangoSemana.Text = "Semana del — al —";
            // 
            // chartVentasSemanal
            // 
            chartArea2.Name = "ChartArea1";
            this.chartVentasSemanal.ChartAreas.Add(chartArea2);
            legend1.Name = "Legend1";
            this.chartVentasSemanal.Legends.Add(legend1);
            this.chartVentasSemanal.Location = new System.Drawing.Point(30, 92);
            this.chartVentasSemanal.Name = "chartVentasSemanal";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Ventas";
            this.chartVentasSemanal.Series.Add(series2);
            this.chartVentasSemanal.Size = new System.Drawing.Size(728, 208);
            this.chartVentasSemanal.TabIndex = 5;
            this.chartVentasSemanal.Text = "chartVentasSemanal";
            // 
            // lblDiaMasVentas
            // 
            this.lblDiaMasVentas.AutoSize = true;
            this.lblDiaMasVentas.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDiaMasVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblDiaMasVentas.Location = new System.Drawing.Point(30, 308);
            this.lblDiaMasVentas.Name = "lblDiaMasVentas";
            this.lblDiaMasVentas.Size = new System.Drawing.Size(149, 17);
            this.lblDiaMasVentas.TabIndex = 6;
            this.lblDiaMasVentas.Text = "Día con más ventas: —";
            // 
            // Form_Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(971, 570);
            this.Controls.Add(this.tabControlReportes);
            this.Controls.Add(this.btnDescargarInforme);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.cboMes);
            this.Controls.Add(this.lblMes);
            this.Controls.Add(this.lblTitulo);
            this.Name = "Form_Reportes";
            this.Text = "Panel de Control y Reportes";
            this.Load += new System.EventHandler(this.Form_Reportes_Load);
            this.tabControlReportes.ResumeLayout(false);
            this.tabBalance.ResumeLayout(false);
            this.tabBalance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGananciaMensual)).EndInit();
            this.pnlIngresos.ResumeLayout(false);
            this.pnlIngresos.PerformLayout();
            this.pnlCompras.ResumeLayout(false);
            this.pnlCompras.PerformLayout();
            this.pnlGanancia.ResumeLayout(false);
            this.pnlGanancia.PerformLayout();
            this.tabAlertas.ResumeLayout(false);
            this.tableLayoutPanelAlertas.ResumeLayout(false);
            this.tableLayoutPanelAlertas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVencimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockCritico)).EndInit();
            this.tabProductos.ResumeLayout(false);
            this.tableLayoutPanelProductos.ResumeLayout(false);
            this.tableLayoutPanelProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasVendidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenosVendidos)).EndInit();
            this.tabSemanal.ResumeLayout(false);
            this.tabSemanal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasSemanal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMes;
        private Guna.UI2.WinForms.Guna2ComboBox cboMes;
        private FontAwesome.Sharp.IconButton btnGenerarReporte;
        private FontAwesome.Sharp.IconButton btnDescargarInforme;
        private System.Windows.Forms.TabControl tabControlReportes;
        private System.Windows.Forms.TabPage tabBalance;
        private Guna.UI2.WinForms.Guna2Panel pnlIngresos;
        private System.Windows.Forms.Label lblIngresosComparacion;
        private System.Windows.Forms.Label lblIngresosValor;
        private System.Windows.Forms.Label lblIngresosTitulo;
        private Guna.UI2.WinForms.Guna2Panel pnlCompras;
        private System.Windows.Forms.Label lblComprasComparacion;
        private System.Windows.Forms.Label lblComprasValor;
        private System.Windows.Forms.Label lblComprasTitulo;
        private Guna.UI2.WinForms.Guna2Panel pnlGanancia;
        private System.Windows.Forms.Label lblGananciaComparacion;
        private System.Windows.Forms.Label lblGananciaValor;
        private System.Windows.Forms.Label lblGananciaTitulo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGananciaMensual;
        private System.Windows.Forms.Label lblResumenGanancia;
        private System.Windows.Forms.TabPage tabAlertas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAlertas;
        private System.Windows.Forms.Label lblVencimientos;
        private System.Windows.Forms.DataGridView dgvVencimientos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColVencProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColVencFecha;
        private System.Windows.Forms.DataGridView dgvStockCritico;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStockProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStockCantidad;
        private System.Windows.Forms.Label lblStockCritico;

        // Pestaña Productos
        private System.Windows.Forms.TabPage tabProductos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelProductos;
        private System.Windows.Forms.Label lblMasVendidos;
        private System.Windows.Forms.DataGridView dgvMasVendidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMasProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMasCantidad;
        private System.Windows.Forms.DataGridView dgvMenosVendidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMenosProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMenosCantidad;
        private System.Windows.Forms.Label lblMenosVendidos;

        // Pestaña Semanal
        private System.Windows.Forms.TabPage tabSemanal;
        private System.Windows.Forms.Label lblTituloSemanal;
        private System.Windows.Forms.Button btnSemanaAnterior;
        private System.Windows.Forms.DateTimePicker dtpSemana;
        private System.Windows.Forms.Button btnSemanaSiguiente;
        private System.Windows.Forms.Label lblRangoSemana;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentasSemanal;
        private System.Windows.Forms.Label lblDiaMasVentas;
    }
}