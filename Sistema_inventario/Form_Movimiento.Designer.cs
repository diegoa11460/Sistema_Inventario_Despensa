namespace Sistema_inventario
{
    partial class Form_Movimiento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFiltroFecha = new System.Windows.Forms.Label();
            this.txtBuscarProducto = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboFiltroFecha = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnbuscar = new FontAwesome.Sharp.IconButton();
            this.btnlimpiar = new FontAwesome.Sharp.IconButton();
            this.btnExplorapdf = new FontAwesome.Sharp.IconButton();
            this.tablaMovimientos = new System.Windows.Forms.DataGridView();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.ColFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStockAnterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStockActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tablaMovimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Movimientos de Stock";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(65)))), ((int)(((byte)(110)))));
            this.label2.Location = new System.Drawing.Point(25, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Buscar por Producto";
            // 
            // lblFiltroFecha
            // 
            this.lblFiltroFecha.AutoSize = true;
            this.lblFiltroFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltroFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(65)))), ((int)(((byte)(110)))));
            this.lblFiltroFecha.Location = new System.Drawing.Point(232, 68);
            this.lblFiltroFecha.Name = "lblFiltroFecha";
            this.lblFiltroFecha.Size = new System.Drawing.Size(88, 15);
            this.lblFiltroFecha.TabIndex = 7;
            this.lblFiltroFecha.Text = "Filtro de Fecha";
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.BorderRadius = 5;
            this.txtBuscarProducto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarProducto.DefaultText = "";
            this.txtBuscarProducto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscarProducto.Location = new System.Drawing.Point(25, 86);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.PlaceholderText = "Escriba el producto...";
            this.txtBuscarProducto.SelectedText = "";
            this.txtBuscarProducto.Size = new System.Drawing.Size(200, 28);
            this.txtBuscarProducto.TabIndex = 2;
            this.txtBuscarProducto.TextChanged += new System.EventHandler(this.txtBuscarProducto_TextChanged);
            // 
            // cboFiltroFecha
            // 
            this.cboFiltroFecha.BackColor = System.Drawing.Color.Transparent;
            this.cboFiltroFecha.BorderRadius = 5;
            this.cboFiltroFecha.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFiltroFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroFecha.FocusedColor = System.Drawing.Color.Empty;
            this.cboFiltroFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboFiltroFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboFiltroFecha.ItemHeight = 22;
            this.cboFiltroFecha.Items.AddRange(new object[] {
            "Todos",
            "Hoy",
            "Ayer",
            "Esta Semana",
            "Este Mes",
            "Personalizado"});
            this.cboFiltroFecha.Location = new System.Drawing.Point(235, 86);
            this.cboFiltroFecha.Name = "cboFiltroFecha";
            this.cboFiltroFecha.Size = new System.Drawing.Size(140, 28);
            this.cboFiltroFecha.TabIndex = 8;
            this.cboFiltroFecha.SelectedIndexChanged += new System.EventHandler(this.cboFiltroFecha_SelectedIndexChanged);
            // 
            // btnbuscar
            // 
            this.btnbuscar.BackColor = System.Drawing.Color.White;
            this.btnbuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscar.FlatAppearance.BorderSize = 0;
            this.btnbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnbuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.btnbuscar.IconChar = FontAwesome.Sharp.IconChar.Sistrix;
            this.btnbuscar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.btnbuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscar.IconSize = 16;
            this.btnbuscar.Location = new System.Drawing.Point(615, 86);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(85, 28);
            this.btnbuscar.TabIndex = 3;
            this.btnbuscar.Text = " Buscar";
            this.btnbuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbuscar.UseVisualStyleBackColor = false;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.BackColor = System.Drawing.Color.White;
            this.btnlimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiar.FlatAppearance.BorderSize = 0;
            this.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnlimpiar.ForeColor = System.Drawing.Color.Black;
            this.btnlimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiar.IconColor = System.Drawing.Color.Black;
            this.btnlimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiar.IconSize = 16;
            this.btnlimpiar.Location = new System.Drawing.Point(721, 86);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(85, 28);
            this.btnlimpiar.TabIndex = 4;
            this.btnlimpiar.Text = " Limpiar";
            this.btnlimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnlimpiar.UseVisualStyleBackColor = false;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // btnExplorapdf
            // 
            this.btnExplorapdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExplorapdf.BackColor = System.Drawing.Color.White;
            this.btnExplorapdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExplorapdf.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnExplorapdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExplorapdf.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExplorapdf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnExplorapdf.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            this.btnExplorapdf.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnExplorapdf.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExplorapdf.IconSize = 18;
            this.btnExplorapdf.Location = new System.Drawing.Point(790, 12);
            this.btnExplorapdf.Name = "btnExplorapdf";
            this.btnExplorapdf.Size = new System.Drawing.Size(150, 30);
            this.btnExplorapdf.TabIndex = 5;
            this.btnExplorapdf.Text = " Descargar PDF";
            this.btnExplorapdf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExplorapdf.UseVisualStyleBackColor = false;
            this.btnExplorapdf.Click += new System.EventHandler(this.btnExplorapdf_Click);
            // 
            // tablaMovimientos
            // 
            this.tablaMovimientos.AllowUserToAddRows = false;
            this.tablaMovimientos.AllowUserToDeleteRows = false;
            this.tablaMovimientos.AllowUserToResizeRows = false;
            this.tablaMovimientos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaMovimientos.BackgroundColor = System.Drawing.Color.White;
            this.tablaMovimientos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tablaMovimientos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tablaMovimientos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaMovimientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaMovimientos.ColumnHeadersHeight = 35;
            this.tablaMovimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColFecha,
            this.ColProducto,
            this.ColTipo,
            this.ColMotivo,
            this.ColCantidad,
            this.ColStockAnterior,
            this.ColStockActual,
            this.ColUsuario,
            this.ColObservacion});
            this.tablaMovimientos.EnableHeadersVisualStyles = false;
            this.tablaMovimientos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tablaMovimientos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablaMovimientos.Location = new System.Drawing.Point(30, 131);
            this.tablaMovimientos.Name = "tablaMovimientos";
            this.tablaMovimientos.ReadOnly = true;
            this.tablaMovimientos.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablaMovimientos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.tablaMovimientos.RowTemplate.Height = 32;
            this.tablaMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaMovimientos.Size = new System.Drawing.Size(936, 400);
            this.tablaMovimientos.TabIndex = 6;
            this.tablaMovimientos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaMovimientos_CellContentClick);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(385, 88);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(100, 24);
            this.dtpDesde.TabIndex = 9;
            this.dtpDesde.Visible = false;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(495, 88);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(100, 24);
            this.dtpHasta.TabIndex = 10;
            this.dtpHasta.Visible = false;
            // 
            // ColFecha
            // 
            this.ColFecha.HeaderText = "Fecha";
            this.ColFecha.Name = "ColFecha";
            this.ColFecha.ReadOnly = true;
            // 
            // ColProducto
            // 
            this.ColProducto.HeaderText = "Producto";
            this.ColProducto.Name = "ColProducto";
            this.ColProducto.ReadOnly = true;
            // 
            // ColTipo
            // 
            this.ColTipo.HeaderText = "Tipo";
            this.ColTipo.Name = "ColTipo";
            this.ColTipo.ReadOnly = true;
            // 
            // ColMotivo
            // 
            this.ColMotivo.HeaderText = "Motivo";
            this.ColMotivo.Name = "ColMotivo";
            this.ColMotivo.ReadOnly = true;
            // 
            // ColCantidad
            // 
            this.ColCantidad.HeaderText = "Cantidad";
            this.ColCantidad.Name = "ColCantidad";
            this.ColCantidad.ReadOnly = true;
            // 
            // ColStockAnterior
            // 
            this.ColStockAnterior.HeaderText = "Stock Anterior";
            this.ColStockAnterior.Name = "ColStockAnterior";
            this.ColStockAnterior.ReadOnly = true;
            // 
            // ColStockActual
            // 
            this.ColStockActual.HeaderText = "Stock Actual";
            this.ColStockActual.Name = "ColStockActual";
            this.ColStockActual.ReadOnly = true;
            // 
            // ColUsuario
            // 
            this.ColUsuario.HeaderText = "Usuario";
            this.ColUsuario.Name = "ColUsuario";
            this.ColUsuario.ReadOnly = true;
            // 
            // ColObservacion
            // 
            this.ColObservacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColObservacion.HeaderText = "Observación";
            this.ColObservacion.MinimumWidth = 3;
            this.ColObservacion.Name = "ColObservacion";
            this.ColObservacion.ReadOnly = true;
            this.ColObservacion.Width = 104;
            // 
            // Form_Movimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 560);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.cboFiltroFecha);
            this.Controls.Add(this.lblFiltroFecha);
            this.Controls.Add(this.tablaMovimientos);
            this.Controls.Add(this.btnExplorapdf);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.txtBuscarProducto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_Movimiento";
            this.Text = "Form_Movimiento";
            this.Load += new System.EventHandler(this.Form_Movimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaMovimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFiltroFecha;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscarProducto;
        private Guna.UI2.WinForms.Guna2ComboBox cboFiltroFecha;
        private FontAwesome.Sharp.IconButton btnbuscar;
        private FontAwesome.Sharp.IconButton btnlimpiar;
        private FontAwesome.Sharp.IconButton btnExplorapdf;
        private System.Windows.Forms.DataGridView tablaMovimientos;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStockAnterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStockActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColObservacion;
    }
}