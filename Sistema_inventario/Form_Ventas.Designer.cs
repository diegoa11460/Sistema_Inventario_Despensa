namespace Sistema_inventario
{
    partial class Form_Ventas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.gr = new System.Windows.Forms.GroupBox();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.txtfecha = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIdcliente = new System.Windows.Forms.TextBox();
            this.btnBusqueda = new FontAwesome.Sharp.IconButton();
            this.txtracliente = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNumerodocumento = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txidproducto = new System.Windows.Forms.TextBox();
            this.txtpreciostock = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtprecioventa = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnbusquedaproducto = new FontAwesome.Sharp.IconButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtcantida = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProductos = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtcodigoproducto = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.CIDproducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIdDetalleCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btneliminae = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.txtpagarcon = new Guna.UI2.WinForms.Guna2TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtcambio = new Guna.UI2.WinForms.Guna2TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txttotalpagar = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkGenerarTicket = new System.Windows.Forms.CheckBox();
            this.btnImprimirTicket = new FontAwesome.Sharp.IconButton();
            this.textregistra = new FontAwesome.Sharp.IconButton();
            this.txtagregar = new FontAwesome.Sharp.IconButton();
            this.gr.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtcantida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Registrar Ventas";
            // 
            // gr
            // 
            this.gr.Controls.Add(this.cmbMetodoPago);
            this.gr.Controls.Add(this.lblMetodoPago);
            this.gr.Controls.Add(this.txtfecha);
            this.gr.Controls.Add(this.label2);
            this.gr.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.gr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.gr.Location = new System.Drawing.Point(28, 65);
            this.gr.Name = "gr";
            this.gr.Size = new System.Drawing.Size(320, 85);
            this.gr.TabIndex = 7;
            this.gr.TabStop = false;
            this.gr.Text = "Información de Ventas";
            this.gr.Enter += new System.EventHandler(this.gr_Enter);
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoPago.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Location = new System.Drawing.Point(135, 43);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(170, 25);
            this.cmbMetodoPago.TabIndex = 2;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMetodoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.lblMetodoPago.Location = new System.Drawing.Point(132, 25);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(95, 15);
            this.lblMetodoPago.TabIndex = 2;
            this.lblMetodoPago.Text = "Método de Pago";
            // 
            // txtfecha
            // 
            this.txtfecha.BorderRadius = 5;
            this.txtfecha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtfecha.DefaultText = "";
            this.txtfecha.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtfecha.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtfecha.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtfecha.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtfecha.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtfecha.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtfecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txtfecha.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtfecha.Location = new System.Drawing.Point(15, 43);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.PlaceholderText = "";
            this.txtfecha.SelectedText = "";
            this.txtfecha.Size = new System.Drawing.Size(105, 27);
            this.txtfecha.TabIndex = 1;
            this.txtfecha.TextChanged += new System.EventHandler(this.txtfecha_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIdcliente);
            this.groupBox1.Controls.Add(this.btnBusqueda);
            this.groupBox1.Controls.Add(this.txtracliente);
            this.groupBox1.Controls.Add(this.txtNumerodocumento);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.groupBox1.Location = new System.Drawing.Point(365, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(565, 85);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información de Cliente";
            // 
            // txtIdcliente
            // 
            this.txtIdcliente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIdcliente.Location = new System.Drawing.Point(310, 14);
            this.txtIdcliente.Name = "txtIdcliente";
            this.txtIdcliente.Size = new System.Drawing.Size(31, 23);
            this.txtIdcliente.TabIndex = 54;
            this.txtIdcliente.Visible = false;
            this.txtIdcliente.TextChanged += new System.EventHandler(this.txtIdcliente_TextChanged);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.btnBusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBusqueda.FlatAppearance.BorderSize = 0;
            this.btnBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusqueda.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBusqueda.ForeColor = System.Drawing.Color.White;
            this.btnBusqueda.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBusqueda.IconColor = System.Drawing.Color.White;
            this.btnBusqueda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBusqueda.IconSize = 16;
            this.btnBusqueda.Location = new System.Drawing.Point(142, 43);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(36, 27);
            this.btnBusqueda.TabIndex = 52;
            this.btnBusqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBusqueda.UseVisualStyleBackColor = false;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // txtracliente
            // 
            this.txtracliente.BorderRadius = 5;
            this.txtracliente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtracliente.DefaultText = "";
            this.txtracliente.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtracliente.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtracliente.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtracliente.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtracliente.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtracliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtracliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txtracliente.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtracliente.Location = new System.Drawing.Point(187, 43);
            this.txtracliente.Name = "txtracliente";
            this.txtracliente.PlaceholderText = "";
            this.txtracliente.SelectedText = "";
            this.txtracliente.Size = new System.Drawing.Size(190, 27);
            this.txtracliente.TabIndex = 53;
            this.txtracliente.TextChanged += new System.EventHandler(this.txtracliente_TextChanged);
            // 
            // txtNumerodocumento
            // 
            this.txtNumerodocumento.BorderRadius = 5;
            this.txtNumerodocumento.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNumerodocumento.DefaultText = "";
            this.txtNumerodocumento.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNumerodocumento.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNumerodocumento.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNumerodocumento.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNumerodocumento.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtNumerodocumento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNumerodocumento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txtNumerodocumento.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtNumerodocumento.Location = new System.Drawing.Point(15, 43);
            this.txtNumerodocumento.Name = "txtNumerodocumento";
            this.txtNumerodocumento.PlaceholderText = "";
            this.txtNumerodocumento.SelectedText = "";
            this.txtNumerodocumento.Size = new System.Drawing.Size(121, 27);
            this.txtNumerodocumento.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label4.Location = new System.Drawing.Point(184, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nombre Cliente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label5.Location = new System.Drawing.Point(12, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Documento";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txidproducto);
            this.groupBox2.Controls.Add(this.txtpreciostock);
            this.groupBox2.Controls.Add(this.txtprecioventa);
            this.groupBox2.Controls.Add(this.btnbusquedaproducto);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtcantida);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtProductos);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtcodigoproducto);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.groupBox2.Location = new System.Drawing.Point(28, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(902, 125);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Información de Productos";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txidproducto
            // 
            this.txidproducto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txidproducto.Location = new System.Drawing.Point(256, 14);
            this.txidproducto.Name = "txidproducto";
            this.txidproducto.Size = new System.Drawing.Size(26, 23);
            this.txidproducto.TabIndex = 71;
            this.txidproducto.Visible = false;
            this.txidproducto.TextChanged += new System.EventHandler(this.txidproducto_TextChanged);
            // 
            // txtpreciostock
            // 
            this.txtpreciostock.BorderRadius = 5;
            this.txtpreciostock.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpreciostock.DefaultText = "";
            this.txtpreciostock.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtpreciostock.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtpreciostock.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpreciostock.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpreciostock.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtpreciostock.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtpreciostock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txtpreciostock.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtpreciostock.Location = new System.Drawing.Point(588, 43);
            this.txtpreciostock.Name = "txtpreciostock";
            this.txtpreciostock.PlaceholderText = "";
            this.txtpreciostock.SelectedText = "";
            this.txtpreciostock.Size = new System.Drawing.Size(130, 27);
            this.txtpreciostock.TabIndex = 70;
            this.txtpreciostock.TextChanged += new System.EventHandler(this.txtpreciostock_TextChanged);
            // 
            // txtprecioventa
            // 
            this.txtprecioventa.BorderRadius = 5;
            this.txtprecioventa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtprecioventa.DefaultText = "";
            this.txtprecioventa.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtprecioventa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtprecioventa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtprecioventa.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtprecioventa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtprecioventa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtprecioventa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txtprecioventa.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtprecioventa.Location = new System.Drawing.Point(451, 43);
            this.txtprecioventa.Name = "txtprecioventa";
            this.txtprecioventa.PlaceholderText = "";
            this.txtprecioventa.SelectedText = "";
            this.txtprecioventa.Size = new System.Drawing.Size(130, 27);
            this.txtprecioventa.TabIndex = 69;
            this.txtprecioventa.TextChanged += new System.EventHandler(this.txtprecioventa_TextChanged);
            // 
            // btnbusquedaproducto
            // 
            this.btnbusquedaproducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.btnbusquedaproducto.FlatAppearance.BorderSize = 0;
            this.btnbusquedaproducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbusquedaproducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnbusquedaproducto.ForeColor = System.Drawing.Color.White;
            this.btnbusquedaproducto.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbusquedaproducto.IconColor = System.Drawing.Color.White;
            this.btnbusquedaproducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbusquedaproducto.IconSize = 16;
            this.btnbusquedaproducto.Location = new System.Drawing.Point(126, 43);
            this.btnbusquedaproducto.Name = "btnbusquedaproducto";
            this.btnbusquedaproducto.Size = new System.Drawing.Size(38, 27);
            this.btnbusquedaproducto.TabIndex = 68;
            this.btnbusquedaproducto.UseVisualStyleBackColor = false;
            this.btnbusquedaproducto.Click += new System.EventHandler(this.btnbusquedaproducto_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label11.Location = new System.Drawing.Point(12, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 15);
            this.label11.TabIndex = 63;
            this.label11.Text = "Cantidad";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label9.Location = new System.Drawing.Point(585, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 15);
            this.label9.TabIndex = 58;
            this.label9.Text = "Stock";
            // 
            // txtcantida
            // 
            this.txtcantida.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtcantida.Location = new System.Drawing.Point(15, 96);
            this.txtcantida.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtcantida.Name = "txtcantida";
            this.txtcantida.Size = new System.Drawing.Size(195, 24);
            this.txtcantida.TabIndex = 62;
            this.txtcantida.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label8.Location = new System.Drawing.Point(448, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 15);
            this.label8.TabIndex = 57;
            this.label8.Text = "Precio Venta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label7.Location = new System.Drawing.Point(167, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 15);
            this.label7.TabIndex = 55;
            this.label7.Text = "Producto";
            // 
            // txtProductos
            // 
            this.txtProductos.BorderRadius = 5;
            this.txtProductos.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProductos.DefaultText = "";
            this.txtProductos.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProductos.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProductos.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductos.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductos.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtProductos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txtProductos.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtProductos.Location = new System.Drawing.Point(170, 43);
            this.txtProductos.Name = "txtProductos";
            this.txtProductos.PlaceholderText = "";
            this.txtProductos.SelectedText = "";
            this.txtProductos.Size = new System.Drawing.Size(275, 27);
            this.txtProductos.TabIndex = 54;
            this.txtProductos.TextChanged += new System.EventHandler(this.txtProductos_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label6.Location = new System.Drawing.Point(12, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Cod. Producto";
            // 
            // txtcodigoproducto
            // 
            this.txtcodigoproducto.BorderRadius = 5;
            this.txtcodigoproducto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcodigoproducto.DefaultText = "";
            this.txtcodigoproducto.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtcodigoproducto.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtcodigoproducto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtcodigoproducto.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtcodigoproducto.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtcodigoproducto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtcodigoproducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txtcodigoproducto.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtcodigoproducto.Location = new System.Drawing.Point(15, 43);
            this.txtcodigoproducto.Name = "txtcodigoproducto";
            this.txtcodigoproducto.PlaceholderText = "";
            this.txtcodigoproducto.SelectedText = "";
            this.txtcodigoproducto.Size = new System.Drawing.Size(105, 27);
            this.txtcodigoproducto.TabIndex = 53;
            this.txtcodigoproducto.TextChanged += new System.EventHandler(this.txtcodigoproducto_TextChanged);
            // 
            // dgvdata
            // 
            this.dgvdata.AllowUserToAddRows = false;
            this.dgvdata.AllowUserToDeleteRows = false;
            this.dgvdata.AllowUserToResizeRows = false;
            this.dgvdata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvdata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvdata.BackgroundColor = System.Drawing.Color.White;
            this.dgvdata.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvdata.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvdata.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdata.ColumnHeadersHeight = 35;
            this.dgvdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CIDproducto,
            this.CProducto,
            this.CPrecioVenta,
            this.CCantidad,
            this.CSubTotal,
            this.CIdDetalleCompra,
            this.btneliminae});
            this.dgvdata.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvdata.EnableHeadersVisualStyles = false;
            this.dgvdata.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvdata.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.dgvdata.Location = new System.Drawing.Point(28, 321);
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            this.dgvdata.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvdata.RowHeadersVisible = false;
            this.dgvdata.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvdata.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvdata.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvdata.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.dgvdata.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.dgvdata.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.dgvdata.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdata.RowTemplate.Height = 35;
            this.dgvdata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvdata.Size = new System.Drawing.Size(902, 152);
            this.dgvdata.TabIndex = 5;
            this.dgvdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellContentClick);
            // 
            // CIDproducto
            // 
            this.CIDproducto.HeaderText = "ID";
            this.CIDproducto.Name = "CIDproducto";
            this.CIDproducto.ReadOnly = true;
            this.CIDproducto.Visible = false;
            // 
            // CProducto
            // 
            this.CProducto.FillWeight = 130F;
            this.CProducto.HeaderText = "Producto";
            this.CProducto.Name = "CProducto";
            this.CProducto.ReadOnly = true;
            // 
            // CPrecioVenta
            // 
            this.CPrecioVenta.FillWeight = 90F;
            this.CPrecioVenta.HeaderText = "P. Venta";
            this.CPrecioVenta.Name = "CPrecioVenta";
            this.CPrecioVenta.ReadOnly = true;
            // 
            // CCantidad
            // 
            this.CCantidad.FillWeight = 70F;
            this.CCantidad.HeaderText = "Cant.";
            this.CCantidad.Name = "CCantidad";
            this.CCantidad.ReadOnly = true;
            // 
            // CSubTotal
            // 
            this.CSubTotal.FillWeight = 90F;
            this.CSubTotal.HeaderText = "SubTotal";
            this.CSubTotal.Name = "CSubTotal";
            this.CSubTotal.ReadOnly = true;
            // 
            // CIdDetalleCompra (NUEVO — oculta, guarda qué lote se vendió en esta línea del carrito)
            // 
            this.CIdDetalleCompra.HeaderText = "IdDetalleCompra";
            this.CIdDetalleCompra.Name = "CIdDetalleCompra";
            this.CIdDetalleCompra.ReadOnly = true;
            this.CIdDetalleCompra.Visible = false;
            // 
            // btneliminae
            // 
            this.btneliminae.FillWeight = 30F;
            this.btneliminae.HeaderText = "";
            this.btneliminae.Name = "btneliminae";
            this.btneliminae.ReadOnly = true;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label12.Location = new System.Drawing.Point(945, 328);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 17);
            this.label12.TabIndex = 76;
            this.label12.Text = "Paga con :";
            // 
            // txtpagarcon
            // 
            this.txtpagarcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtpagarcon.BorderRadius = 5;
            this.txtpagarcon.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpagarcon.DefaultText = "0";
            this.txtpagarcon.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtpagarcon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtpagarcon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpagarcon.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpagarcon.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtpagarcon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtpagarcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txtpagarcon.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtpagarcon.Location = new System.Drawing.Point(948, 348);
            this.txtpagarcon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtpagarcon.Name = "txtpagarcon";
            this.txtpagarcon.PlaceholderText = "";
            this.txtpagarcon.SelectedText = "";
            this.txtpagarcon.Size = new System.Drawing.Size(160, 32);
            this.txtpagarcon.TabIndex = 75;
            this.txtpagarcon.TextChanged += new System.EventHandler(this.txtpagarcon_TextChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label10.Location = new System.Drawing.Point(945, 388);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 17);
            this.label10.TabIndex = 74;
            this.label10.Text = "Cambio :";
            // 
            // txtcambio
            // 
            this.txtcambio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcambio.BorderRadius = 5;
            this.txtcambio.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcambio.DefaultText = "0";
            this.txtcambio.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtcambio.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtcambio.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtcambio.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtcambio.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtcambio.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtcambio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txtcambio.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtcambio.Location = new System.Drawing.Point(948, 408);
            this.txtcambio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtcambio.Name = "txtcambio";
            this.txtcambio.PlaceholderText = "";
            this.txtcambio.SelectedText = "";
            this.txtcambio.Size = new System.Drawing.Size(160, 32);
            this.txtcambio.TabIndex = 73;
            this.txtcambio.TextChanged += new System.EventHandler(this.txtcambio_TextChanged);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label13.Location = new System.Drawing.Point(945, 456);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 17);
            this.label13.TabIndex = 72;
            this.label13.Text = "Total a Pagar:";
            // 
            // txttotalpagar
            // 
            this.txttotalpagar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txttotalpagar.BorderRadius = 5;
            this.txttotalpagar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txttotalpagar.DefaultText = "0";
            this.txttotalpagar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txttotalpagar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txttotalpagar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttotalpagar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttotalpagar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txttotalpagar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txttotalpagar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txttotalpagar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txttotalpagar.Location = new System.Drawing.Point(946, 477);
            this.txttotalpagar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txttotalpagar.Name = "txttotalpagar";
            this.txttotalpagar.PlaceholderText = "";
            this.txttotalpagar.SelectedText = "";
            this.txttotalpagar.Size = new System.Drawing.Size(160, 32);
            this.txttotalpagar.TabIndex = 71;
            this.txttotalpagar.TextChanged += new System.EventHandler(this.txttotalpagar_TextChanged);
            // 
            // chkGenerarTicket
            // 
            this.chkGenerarTicket.AutoSize = true;
            this.chkGenerarTicket.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.chkGenerarTicket.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.chkGenerarTicket.Location = new System.Drawing.Point(28, 480);
            this.chkGenerarTicket.Name = "chkGenerarTicket";
            this.chkGenerarTicket.Size = new System.Drawing.Size(197, 23);
            this.chkGenerarTicket.TabIndex = 79;
            this.chkGenerarTicket.Text = "¿Generar e imprimir ticket?";
            this.chkGenerarTicket.UseVisualStyleBackColor = true;
            this.chkGenerarTicket.CheckedChanged += new System.EventHandler(this.chkGenerarTicket_CheckedChanged);
            // 
            // btnImprimirTicket
            // 
            this.btnImprimirTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimirTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnImprimirTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimirTicket.FlatAppearance.BorderSize = 0;
            this.btnImprimirTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirTicket.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnImprimirTicket.ForeColor = System.Drawing.Color.White;
            this.btnImprimirTicket.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnImprimirTicket.IconColor = System.Drawing.Color.White;
            this.btnImprimirTicket.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnImprimirTicket.IconSize = 22;
            this.btnImprimirTicket.Location = new System.Drawing.Point(948, 265);
            this.btnImprimirTicket.Name = "btnImprimirTicket";
            this.btnImprimirTicket.Size = new System.Drawing.Size(160, 40);
            this.btnImprimirTicket.TabIndex = 80;
            this.btnImprimirTicket.Text = "  Imprimir Ticket";
            this.btnImprimirTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimirTicket.UseVisualStyleBackColor = false;
            this.btnImprimirTicket.Click += new System.EventHandler(this.btnImprimirTicket_Click);
            // 
            // textregistra
            // 
            this.textregistra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textregistra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.textregistra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textregistra.FlatAppearance.BorderSize = 0;
            this.textregistra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textregistra.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.textregistra.ForeColor = System.Drawing.Color.White;
            this.textregistra.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.textregistra.IconColor = System.Drawing.Color.White;
            this.textregistra.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.textregistra.IconSize = 22;
            this.textregistra.Location = new System.Drawing.Point(948, 215);
            this.textregistra.Name = "textregistra";
            this.textregistra.Size = new System.Drawing.Size(160, 40);
            this.textregistra.TabIndex = 78;
            this.textregistra.Text = "  Registrar Venta";
            this.textregistra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.textregistra.UseVisualStyleBackColor = false;
            this.textregistra.Click += new System.EventHandler(this.txtagregar_Click_1);
            // 
            // txtagregar
            // 
            this.txtagregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtagregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtagregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtagregar.FlatAppearance.BorderSize = 0;
            this.txtagregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtagregar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtagregar.ForeColor = System.Drawing.Color.White;
            this.txtagregar.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.txtagregar.IconColor = System.Drawing.Color.White;
            this.txtagregar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.txtagregar.IconSize = 22;
            this.txtagregar.Location = new System.Drawing.Point(946, 163);
            this.txtagregar.Name = "txtagregar";
            this.txtagregar.Size = new System.Drawing.Size(160, 40);
            this.txtagregar.TabIndex = 81;
            this.txtagregar.Text = "  Agregar Ventas";
            this.txtagregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.txtagregar.UseVisualStyleBackColor = false;
            this.txtagregar.Click += new System.EventHandler(this.txtagregar_Click);
            // 
            // Form_Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1125, 522);
            this.Controls.Add(this.txtagregar);
            this.Controls.Add(this.btnImprimirTicket);
            this.Controls.Add(this.chkGenerarTicket);
            this.Controls.Add(this.textregistra);
            this.Controls.Add(this.txtpagarcon);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtcambio);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txttotalpagar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.gr);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_Ventas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registro de Ventas";
            this.Load += new System.EventHandler(this.Form_Ventas_Load);
            this.gr.ResumeLayout(false);
            this.gr.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtcantida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIDproducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIdDetalleCompra;
        private System.Windows.Forms.DataGridViewButtonColumn btneliminae;
        private System.Windows.Forms.GroupBox groupBox2;
        private FontAwesome.Sharp.IconButton btnbusquedaproducto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txtProductos;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtcodigoproducto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown txtcantida;
        private System.Windows.Forms.GroupBox gr;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.Label lblMetodoPago;
        private Guna.UI2.WinForms.Guna2TextBox txtfecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnBusqueda;
        private Guna.UI2.WinForms.Guna2TextBox txtNumerodocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtpreciostock;
        private Guna.UI2.WinForms.Guna2TextBox txtprecioventa;
        private Guna.UI2.WinForms.Guna2TextBox txtracliente;
        private Guna.UI2.WinForms.Guna2TextBox txttotalpagar;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2TextBox txtcambio;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2TextBox txtpagarcon;
        private System.Windows.Forms.Label label12;
        private FontAwesome.Sharp.IconButton textregistra;
        private System.Windows.Forms.CheckBox chkGenerarTicket;
        private FontAwesome.Sharp.IconButton btnImprimirTicket;
        private System.Windows.Forms.TextBox txidproducto;
        private FontAwesome.Sharp.IconButton txtagregar;
        private System.Windows.Forms.TextBox txtIdcliente;
    }
}