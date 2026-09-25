namespace Sistema_inventario
{
    partial class Form_Compras
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
            this.txtTipodocumentos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtfecha = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIdProveedor = new System.Windows.Forms.TextBox();
            this.btnBusqueda = new FontAwesome.Sharp.IconButton();
            this.txtrazonsocial = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNumerodocumento = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNumeroFactura = new Guna.UI2.WinForms.Guna2TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnbuscarproducto = new FontAwesome.Sharp.IconButton();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpfechavencimiento = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtnrolote = new Guna.UI2.WinForms.Guna2TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtcantida = new System.Windows.Forms.NumericUpDown();
            this.txtprecioventas = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtpreciocompras = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textIdproducto = new System.Windows.Forms.TextBox();
            this.txtProductos = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtcodigoproducto = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.CIDproducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNroLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btneliminae = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.txttotalpagar = new Guna.UI2.WinForms.Guna2TextBox();
            this.textregistra = new FontAwesome.Sharp.IconButton();
            this.txtagregar = new FontAwesome.Sharp.IconButton();
            this.gr.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(53, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registrar Compras";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // gr
            // 
            this.gr.Controls.Add(this.txtTipodocumentos);
            this.gr.Controls.Add(this.label3);
            this.gr.Controls.Add(this.txtfecha);
            this.gr.Controls.Add(this.label2);
            this.gr.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.gr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.gr.Location = new System.Drawing.Point(56, 65);
            this.gr.Name = "gr";
            this.gr.Size = new System.Drawing.Size(320, 85);
            this.gr.TabIndex = 1;
            this.gr.TabStop = false;
            this.gr.Text = "Información de Compra";
            // 
            // txtTipodocumentos
            // 
            this.txtTipodocumentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtTipodocumentos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTipodocumentos.FormattingEnabled = true;
            this.txtTipodocumentos.Location = new System.Drawing.Point(135, 43);
            this.txtTipodocumentos.Name = "txtTipodocumentos";
            this.txtTipodocumentos.Size = new System.Drawing.Size(170, 25);
            this.txtTipodocumentos.TabIndex = 2;
            this.txtTipodocumentos.SelectedIndexChanged += new System.EventHandler(this.txtTipodocumentos_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label3.Location = new System.Drawing.Point(132, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de Documento";
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
            this.groupBox1.Controls.Add(this.txtIdProveedor);
            this.groupBox1.Controls.Add(this.btnBusqueda);
            this.groupBox1.Controls.Add(this.txtrazonsocial);
            this.groupBox1.Controls.Add(this.txtNumerodocumento);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.groupBox1.Location = new System.Drawing.Point(393, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 85);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información de Proveedor";
            // 
            // txtIdProveedor
            // 
            this.txtIdProveedor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIdProveedor.Location = new System.Drawing.Point(345, 14);
            this.txtIdProveedor.Name = "txtIdProveedor";
            this.txtIdProveedor.Size = new System.Drawing.Size(31, 23);
            this.txtIdProveedor.TabIndex = 38;
            this.txtIdProveedor.Visible = false;
            this.txtIdProveedor.TextChanged += new System.EventHandler(this.txtIdProveedor_TextChanged);
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
            // txtrazonsocial
            // 
            this.txtrazonsocial.BorderRadius = 5;
            this.txtrazonsocial.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtrazonsocial.DefaultText = "";
            this.txtrazonsocial.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtrazonsocial.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtrazonsocial.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtrazonsocial.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtrazonsocial.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtrazonsocial.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtrazonsocial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txtrazonsocial.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtrazonsocial.Location = new System.Drawing.Point(187, 43);
            this.txtrazonsocial.Name = "txtrazonsocial";
            this.txtrazonsocial.PlaceholderText = "";
            this.txtrazonsocial.SelectedText = "";
            this.txtrazonsocial.Size = new System.Drawing.Size(190, 27);
            this.txtrazonsocial.TabIndex = 35;
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
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Razón Social";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label5.Location = new System.Drawing.Point(12, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "RUC Proveedor";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtNumeroFactura);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.groupBox3.Location = new System.Drawing.Point(798, 65);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(160, 85);
            this.groupBox3.TabIndex = 71;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nro. Factura";
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.BorderRadius = 5;
            this.txtNumeroFactura.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNumeroFactura.DefaultText = "";
            this.txtNumeroFactura.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNumeroFactura.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNumeroFactura.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNumeroFactura.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNumeroFactura.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtNumeroFactura.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNumeroFactura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txtNumeroFactura.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtNumeroFactura.Location = new System.Drawing.Point(15, 43);
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.PlaceholderText = "";
            this.txtNumeroFactura.SelectedText = "";
            this.txtNumeroFactura.Size = new System.Drawing.Size(130, 27);
            this.txtNumeroFactura.TabIndex = 0;
            this.txtNumeroFactura.TextChanged += new System.EventHandler(this.txtNumeroFactura_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label14.Location = new System.Drawing.Point(12, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "Nro. Factura";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnbuscarproducto);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.dtpfechavencimiento);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtnrolote);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtcantida);
            this.groupBox2.Controls.Add(this.txtprecioventas);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtpreciocompras);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textIdproducto);
            this.groupBox2.Controls.Add(this.txtProductos);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtcodigoproducto);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.groupBox2.Location = new System.Drawing.Point(56, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(732, 125);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Información de Productos";
            // 
            // btnbuscarproducto
            // 
            this.btnbuscarproducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.btnbuscarproducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarproducto.FlatAppearance.BorderSize = 0;
            this.btnbuscarproducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarproducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnbuscarproducto.ForeColor = System.Drawing.Color.White;
            this.btnbuscarproducto.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbuscarproducto.IconColor = System.Drawing.Color.White;
            this.btnbuscarproducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscarproducto.IconSize = 16;
            this.btnbuscarproducto.Location = new System.Drawing.Point(128, 43);
            this.btnbuscarproducto.Name = "btnbuscarproducto";
            this.btnbuscarproducto.Size = new System.Drawing.Size(36, 27);
            this.btnbuscarproducto.TabIndex = 53;
            this.btnbuscarproducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbuscarproducto.UseVisualStyleBackColor = false;
            this.btnbuscarproducto.Click += new System.EventHandler(this.btnbuscarproducto_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label10.Location = new System.Drawing.Point(415, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 15);
            this.label10.TabIndex = 67;
            this.label10.Text = "Fecha Vencimiento";
            // 
            // dtpfechavencimiento
            // 
            this.dtpfechavencimiento.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.dtpfechavencimiento.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpfechavencimiento.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.dtpfechavencimiento.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpfechavencimiento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpfechavencimiento.Location = new System.Drawing.Point(418, 96);
            this.dtpfechavencimiento.Name = "dtpfechavencimiento";
            this.dtpfechavencimiento.Size = new System.Drawing.Size(253, 24);
            this.dtpfechavencimiento.TabIndex = 66;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label12.Location = new System.Drawing.Point(232, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 15);
            this.label12.TabIndex = 65;
            this.label12.Text = "Nro. Lote";
            // 
            // txtnrolote
            // 
            this.txtnrolote.BorderRadius = 5;
            this.txtnrolote.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtnrolote.DefaultText = "";
            this.txtnrolote.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtnrolote.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtnrolote.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtnrolote.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtnrolote.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtnrolote.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtnrolote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txtnrolote.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtnrolote.Location = new System.Drawing.Point(235, 96);
            this.txtnrolote.Name = "txtnrolote";
            this.txtnrolote.PlaceholderText = "";
            this.txtnrolote.SelectedText = "";
            this.txtnrolote.Size = new System.Drawing.Size(165, 27);
            this.txtnrolote.TabIndex = 64;
            this.txtnrolote.TextChanged += new System.EventHandler(this.txtnrolote_TextChanged);
            this.txtnrolote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnrolote_KeyPress);
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
            // txtprecioventas
            // 
            this.txtprecioventas.BorderRadius = 5;
            this.txtprecioventas.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtprecioventas.DefaultText = "";
            this.txtprecioventas.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtprecioventas.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtprecioventas.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtprecioventas.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtprecioventas.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtprecioventas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtprecioventas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txtprecioventas.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtprecioventas.Location = new System.Drawing.Point(588, 43);
            this.txtprecioventas.Name = "txtprecioventas";
            this.txtprecioventas.PlaceholderText = "";
            this.txtprecioventas.SelectedText = "";
            this.txtprecioventas.Size = new System.Drawing.Size(130, 27);
            this.txtprecioventas.TabIndex = 59;
            this.txtprecioventas.TextChanged += new System.EventHandler(this.txtprecioventas_TextChanged);
            this.txtprecioventas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtprecioventas_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label9.Location = new System.Drawing.Point(585, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 15);
            this.label9.TabIndex = 58;
            this.label9.Text = "Precio Venta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label8.Location = new System.Drawing.Point(448, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 15);
            this.label8.TabIndex = 57;
            this.label8.Text = "Precio Compra";
            // 
            // txtpreciocompras
            // 
            this.txtpreciocompras.BorderRadius = 5;
            this.txtpreciocompras.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpreciocompras.DefaultText = "";
            this.txtpreciocompras.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtpreciocompras.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtpreciocompras.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpreciocompras.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpreciocompras.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtpreciocompras.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtpreciocompras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txtpreciocompras.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtpreciocompras.Location = new System.Drawing.Point(451, 43);
            this.txtpreciocompras.Name = "txtpreciocompras";
            this.txtpreciocompras.PlaceholderText = "";
            this.txtpreciocompras.SelectedText = "";
            this.txtpreciocompras.Size = new System.Drawing.Size(130, 27);
            this.txtpreciocompras.TabIndex = 56;
            this.txtpreciocompras.TextChanged += new System.EventHandler(this.txtpreciocompras_TextChanged);
            this.txtpreciocompras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpreciocompras_KeyPress);
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
            // textIdproducto
            // 
            this.textIdproducto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textIdproducto.Location = new System.Drawing.Point(97, 14);
            this.textIdproducto.Name = "textIdproducto";
            this.textIdproducto.Size = new System.Drawing.Size(26, 23);
            this.textIdproducto.TabIndex = 53;
            this.textIdproducto.Visible = false;
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
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label6.Location = new System.Drawing.Point(12, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Cod. Barra";
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
            this.txtcodigoproducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcodigoproducto_KeyDown);
            // 
            // dgvdata
            // 
            this.dgvdata.AllowUserToAddRows = false;
            this.dgvdata.AllowUserToDeleteRows = false;
            this.dgvdata.AllowUserToResizeRows = false;
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
            this.CPrecioCompra,
            this.CPrecioVenta,
            this.CCantidad,
            this.CNroLote,
            this.CFechaVencimiento,
            this.CSubTotal,
            this.btneliminae});
            this.dgvdata.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvdata.EnableHeadersVisualStyles = false;
            this.dgvdata.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvdata.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.dgvdata.Location = new System.Drawing.Point(56, 295);
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
            this.dgvdata.Size = new System.Drawing.Size(732, 175);
            this.dgvdata.TabIndex = 4;
            this.dgvdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellContentClick);
            this.dgvdata.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvdata_CellPainting);
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
            // CPrecioCompra
            // 
            this.CPrecioCompra.FillWeight = 90F;
            this.CPrecioCompra.HeaderText = "P. Compra";
            this.CPrecioCompra.Name = "CPrecioCompra";
            this.CPrecioCompra.ReadOnly = true;
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
            // CNroLote
            // 
            this.CNroLote.FillWeight = 80F;
            this.CNroLote.HeaderText = "Nro. Lote";
            this.CNroLote.Name = "CNroLote";
            this.CNroLote.ReadOnly = true;
            // 
            // CFechaVencimiento
            // 
            this.CFechaVencimiento.HeaderText = "Vencimiento";
            this.CFechaVencimiento.Name = "CFechaVencimiento";
            this.CFechaVencimiento.ReadOnly = true;
            // 
            // CSubTotal
            // 
            this.CSubTotal.FillWeight = 90F;
            this.CSubTotal.HeaderText = "SubTotal";
            this.CSubTotal.Name = "CSubTotal";
            this.CSubTotal.ReadOnly = true;
            // 
            // btneliminae
            // 
            this.btneliminae.FillWeight = 30F;
            this.btneliminae.HeaderText = "";
            this.btneliminae.Name = "btneliminae";
            this.btneliminae.ReadOnly = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label13.Location = new System.Drawing.Point(803, 395);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 17);
            this.label13.TabIndex = 68;
            this.label13.Text = "Total a Pagar:";
            // 
            // txttotalpagar
            // 
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
            this.txttotalpagar.Location = new System.Drawing.Point(806, 415);
            this.txttotalpagar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txttotalpagar.Name = "txttotalpagar";
            this.txttotalpagar.PlaceholderText = "";
            this.txttotalpagar.SelectedText = "";
            this.txttotalpagar.Size = new System.Drawing.Size(160, 32);
            this.txttotalpagar.TabIndex = 3;
            // 
            // textregistra
            // 
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
            this.textregistra.Location = new System.Drawing.Point(806, 213);
            this.textregistra.Name = "textregistra";
            this.textregistra.Size = new System.Drawing.Size(160, 40);
            this.textregistra.TabIndex = 69;
            this.textregistra.Text = "  Registrar Compra";
            this.textregistra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.textregistra.UseVisualStyleBackColor = false;
            this.textregistra.Click += new System.EventHandler(this.textregistra_Click);
            // 
            // txtagregar
            // 
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
            this.txtagregar.Location = new System.Drawing.Point(806, 165);
            this.txtagregar.Name = "txtagregar";
            this.txtagregar.Size = new System.Drawing.Size(160, 40);
            this.txtagregar.TabIndex = 5;
            this.txtagregar.Text = "  Agregar Producto";
            this.txtagregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.txtagregar.UseVisualStyleBackColor = false;
            this.txtagregar.Click += new System.EventHandler(this.txtagregar_Click);
            // 
            // Form_Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(995, 495);
            this.Controls.Add(this.textregistra);
            this.Controls.Add(this.txttotalpagar);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtagregar);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gr);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_Compras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registro de Compras";
            this.Load += new System.EventHandler(this.Form_Compras_Load);
            this.gr.ResumeLayout(false);
            this.gr.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtcantida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gr;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtfecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txtTipodocumentos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtrazonsocial;
        private Guna.UI2.WinForms.Guna2TextBox txtNumerodocumento;
        private FontAwesome.Sharp.IconButton btnBusqueda;
        private System.Windows.Forms.GroupBox groupBox3;
        private Guna.UI2.WinForms.Guna2TextBox txtNumeroFactura;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtcodigoproducto;
        private System.Windows.Forms.TextBox txtIdProveedor;
        private Guna.UI2.WinForms.Guna2TextBox txtProductos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textIdproducto;
        private Guna.UI2.WinForms.Guna2TextBox txtpreciocompras;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox txtprecioventas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2TextBox txtnrolote;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown txtcantida;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpfechavencimiento;
        private System.Windows.Forms.DataGridView dgvdata;
        private FontAwesome.Sharp.IconButton txtagregar;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2TextBox txttotalpagar;
        private FontAwesome.Sharp.IconButton textregistra;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIDproducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNroLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFechaVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSubTotal;
        private System.Windows.Forms.DataGridViewButtonColumn btneliminae;
        private FontAwesome.Sharp.IconButton btnbuscarproducto;
    }
}