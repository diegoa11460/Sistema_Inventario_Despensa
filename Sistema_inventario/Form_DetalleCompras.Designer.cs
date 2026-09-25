namespace Sistema_inventario
{
    partial class Form_DetalleCompras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtnumerocompra = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtusuario = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txttipodocumento = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtfecha = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnbuscar = new FontAwesome.Sharp.IconButton();
            this.btnlimpiar = new FontAwesome.Sharp.IconButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtrazonsocial = new Guna.UI2.WinForms.Guna2TextBox();
            this.Idproveedor = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtdocumento = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txttabladetallecompra = new System.Windows.Forms.DataGridView();
            this.CIDproducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNroLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btneliminae = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtbuscarnumerodocumento = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txmontototal = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnExplorapdf = new FontAwesome.Sharp.IconButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txttabladetallecompra)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(30, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detalle de Compra";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtnumerocompra);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtusuario);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txttipodocumento);
            this.groupBox1.Controls.Add(this.txtfecha);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.groupBox1.Location = new System.Drawing.Point(30, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(740, 75);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Información de Compra ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label9.Location = new System.Drawing.Point(355, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 15);
            this.label9.TabIndex = 42;
            this.label9.Text = "Nro. Documento";
            // 
            // txtnumerocompra
            // 
            this.txtnumerocompra.BorderRadius = 5;
            this.txtnumerocompra.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtnumerocompra.DefaultText = "";
            this.txtnumerocompra.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtnumerocompra.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtnumerocompra.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtnumerocompra.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtnumerocompra.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtnumerocompra.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtnumerocompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txtnumerocompra.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtnumerocompra.Location = new System.Drawing.Point(355, 41);
            this.txtnumerocompra.Name = "txtnumerocompra";
            this.txtnumerocompra.PlaceholderText = "";
            this.txtnumerocompra.SelectedText = "";
            this.txtnumerocompra.Size = new System.Drawing.Size(125, 26);
            this.txtnumerocompra.TabIndex = 41;
            this.txtnumerocompra.TextChanged += new System.EventHandler(this.txtnumerocompra_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label5.Location = new System.Drawing.Point(495, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 40;
            this.label5.Text = "Usuario";
            // 
            // txtusuario
            // 
            this.txtusuario.BorderRadius = 5;
            this.txtusuario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtusuario.DefaultText = "";
            this.txtusuario.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtusuario.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtusuario.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtusuario.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtusuario.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtusuario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtusuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txtusuario.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtusuario.Location = new System.Drawing.Point(495, 41);
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.PlaceholderText = "";
            this.txtusuario.SelectedText = "";
            this.txtusuario.Size = new System.Drawing.Size(225, 26);
            this.txtusuario.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label4.Location = new System.Drawing.Point(180, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 39;
            this.label4.Text = "Tipo Documento";
            // 
            // txttipodocumento
            // 
            this.txttipodocumento.BorderRadius = 5;
            this.txttipodocumento.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txttipodocumento.DefaultText = "";
            this.txttipodocumento.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txttipodocumento.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txttipodocumento.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttipodocumento.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttipodocumento.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txttipodocumento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txttipodocumento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txttipodocumento.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txttipodocumento.Location = new System.Drawing.Point(180, 41);
            this.txttipodocumento.Name = "txttipodocumento";
            this.txttipodocumento.PlaceholderText = "";
            this.txttipodocumento.SelectedText = "";
            this.txttipodocumento.Size = new System.Drawing.Size(160, 26);
            this.txttipodocumento.TabIndex = 39;
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
            this.txtfecha.Location = new System.Drawing.Point(20, 41);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.PlaceholderText = "";
            this.txtfecha.SelectedText = "";
            this.txtfecha.Size = new System.Drawing.Size(145, 26);
            this.txtfecha.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label3.Location = new System.Drawing.Point(20, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 38;
            this.label3.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label2.Location = new System.Drawing.Point(260, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nro. de Documento:";
            // 
            // btnbuscar
            // 
            this.btnbuscar.BackColor = System.Drawing.Color.White;
            this.btnbuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.btnbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnbuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.btnbuscar.IconChar = FontAwesome.Sharp.IconChar.Sistrix;
            this.btnbuscar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.btnbuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscar.IconSize = 16;
            this.btnbuscar.Location = new System.Drawing.Point(535, 71);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(100, 28);
            this.btnbuscar.TabIndex = 36;
            this.btnbuscar.Text = " Buscar";
            this.btnbuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbuscar.UseVisualStyleBackColor = false;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.BackColor = System.Drawing.Color.White;
            this.btnlimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnlimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.btnlimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.btnlimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiar.IconSize = 16;
            this.btnlimpiar.Location = new System.Drawing.Point(645, 71);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(100, 28);
            this.btnlimpiar.TabIndex = 37;
            this.btnlimpiar.Text = " Limpiar";
            this.btnlimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnlimpiar.UseVisualStyleBackColor = false;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtrazonsocial);
            this.groupBox2.Controls.Add(this.Idproveedor);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtdocumento);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.groupBox2.Location = new System.Drawing.Point(30, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(740, 75);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Información de Proveedor ";
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
            this.txtrazonsocial.Location = new System.Drawing.Point(235, 41);
            this.txtrazonsocial.Name = "txtrazonsocial";
            this.txtrazonsocial.PlaceholderText = "";
            this.txtrazonsocial.SelectedText = "";
            this.txtrazonsocial.Size = new System.Drawing.Size(300, 26);
            this.txtrazonsocial.TabIndex = 40;
            // 
            // Idproveedor
            // 
            this.Idproveedor.BorderRadius = 5;
            this.Idproveedor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Idproveedor.DefaultText = "";
            this.Idproveedor.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Idproveedor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Idproveedor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Idproveedor.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Idproveedor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.Idproveedor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Idproveedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.Idproveedor.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.Idproveedor.Location = new System.Drawing.Point(565, 41);
            this.Idproveedor.Name = "Idproveedor";
            this.Idproveedor.PlaceholderText = "";
            this.Idproveedor.SelectedText = "";
            this.Idproveedor.Size = new System.Drawing.Size(60, 26);
            this.Idproveedor.TabIndex = 38;
            this.Idproveedor.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label7.Location = new System.Drawing.Point(235, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 15);
            this.label7.TabIndex = 39;
            this.label7.Text = "Razón Social";
            // 
            // txtdocumento
            // 
            this.txtdocumento.BorderRadius = 5;
            this.txtdocumento.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtdocumento.DefaultText = "";
            this.txtdocumento.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtdocumento.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtdocumento.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtdocumento.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtdocumento.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtdocumento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtdocumento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txtdocumento.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtdocumento.Location = new System.Drawing.Point(20, 41);
            this.txtdocumento.Name = "txtdocumento";
            this.txtdocumento.PlaceholderText = "";
            this.txtdocumento.SelectedText = "";
            this.txtdocumento.Size = new System.Drawing.Size(190, 26);
            this.txtdocumento.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label8.Location = new System.Drawing.Point(20, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 15);
            this.label8.TabIndex = 38;
            this.label8.Text = "Número de documento";
            // 
            // txttabladetallecompra
            // 
            this.txttabladetallecompra.AllowUserToAddRows = false;
            this.txttabladetallecompra.AllowUserToDeleteRows = false;
            this.txttabladetallecompra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txttabladetallecompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.txttabladetallecompra.BackgroundColor = System.Drawing.Color.White;
            this.txttabladetallecompra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txttabladetallecompra.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.txttabladetallecompra.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.txttabladetallecompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.txttabladetallecompra.ColumnHeadersHeight = 35;
            this.txttabladetallecompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CIDproducto,
            this.CProducto,
            this.CPrecioCompra,
            this.CPrecioVenta,
            this.CCantidad,
            this.CNroLote,
            this.CFechaVencimiento,
            this.CSubTotal,
            this.btneliminae});
            this.txttabladetallecompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txttabladetallecompra.EnableHeadersVisualStyles = false;
            this.txttabladetallecompra.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txttabladetallecompra.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.txttabladetallecompra.Location = new System.Drawing.Point(30, 290);
            this.txttabladetallecompra.Name = "txttabladetallecompra";
            this.txttabladetallecompra.ReadOnly = true;
            this.txttabladetallecompra.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.txttabladetallecompra.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.txttabladetallecompra.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.txttabladetallecompra.RowTemplate.Height = 32;
            this.txttabladetallecompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.txttabladetallecompra.Size = new System.Drawing.Size(740, 160);
            this.txttabladetallecompra.TabIndex = 43;
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
            this.CProducto.HeaderText = "Producto";
            this.CProducto.Name = "CProducto";
            this.CProducto.ReadOnly = true;
            // 
            // CPrecioCompra
            // 
            this.CPrecioCompra.HeaderText = "Precio Compra";
            this.CPrecioCompra.Name = "CPrecioCompra";
            this.CPrecioCompra.ReadOnly = true;
            // 
            // CPrecioVenta
            // 
            this.CPrecioVenta.HeaderText = "Precio Venta";
            this.CPrecioVenta.Name = "CPrecioVenta";
            this.CPrecioVenta.ReadOnly = true;
            // 
            // CCantidad
            // 
            this.CCantidad.HeaderText = "Cantidad";
            this.CCantidad.Name = "CCantidad";
            this.CCantidad.ReadOnly = true;
            // 
            // CNroLote
            // 
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
            this.CSubTotal.HeaderText = "Sub Total";
            this.CSubTotal.Name = "CSubTotal";
            this.CSubTotal.ReadOnly = true;
            // 
            // btneliminae
            // 
            this.btneliminae.HeaderText = "";
            this.btneliminae.Name = "btneliminae";
            this.btneliminae.ReadOnly = true;
            this.btneliminae.Visible = false;
            // 
            // txtbuscarnumerodocumento
            // 
            this.txtbuscarnumerodocumento.BorderRadius = 5;
            this.txtbuscarnumerodocumento.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbuscarnumerodocumento.DefaultText = "";
            this.txtbuscarnumerodocumento.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtbuscarnumerodocumento.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtbuscarnumerodocumento.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbuscarnumerodocumento.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbuscarnumerodocumento.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtbuscarnumerodocumento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtbuscarnumerodocumento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txtbuscarnumerodocumento.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtbuscarnumerodocumento.Location = new System.Drawing.Point(400, 71);
            this.txtbuscarnumerodocumento.Name = "txtbuscarnumerodocumento";
            this.txtbuscarnumerodocumento.PlaceholderText = "";
            this.txtbuscarnumerodocumento.SelectedText = "";
            this.txtbuscarnumerodocumento.Size = new System.Drawing.Size(125, 28);
            this.txtbuscarnumerodocumento.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.label6.Location = new System.Drawing.Point(30, 465);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 19);
            this.label6.TabIndex = 45;
            this.label6.Text = "Monto Total:";
            // 
            // txmontototal
            // 
            this.txmontototal.BorderRadius = 5;
            this.txmontototal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txmontototal.DefaultText = "0";
            this.txmontototal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txmontototal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txmontototal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txmontototal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txmontototal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txmontototal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txmontototal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txmontototal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txmontototal.Location = new System.Drawing.Point(120, 461);
            this.txmontototal.Name = "txmontototal";
            this.txmontototal.PlaceholderText = "";
            this.txmontototal.SelectedText = "";
            this.txmontototal.Size = new System.Drawing.Size(140, 28);
            this.txmontototal.TabIndex = 41;
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
            this.btnExplorapdf.Location = new System.Drawing.Point(620, 460);
            this.btnExplorapdf.Name = "btnExplorapdf";
            this.btnExplorapdf.Size = new System.Drawing.Size(150, 32);
            this.btnExplorapdf.TabIndex = 47;
            this.btnExplorapdf.Text = " Descargar PDF";
            this.btnExplorapdf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExplorapdf.UseVisualStyleBackColor = false;
            this.btnExplorapdf.Click += new System.EventHandler(this.btnExplorapdf_Click);
            // 
            // Form_DetalleCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(800, 510);
            this.Controls.Add(this.btnExplorapdf);
            this.Controls.Add(this.txmontototal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtbuscarnumerodocumento);
            this.Controls.Add(this.txttabladetallecompra);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_DetalleCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle de Compras";
            this.Load += new System.EventHandler(this.Form_DetalleCompras_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txttabladetallecompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnbuscar;
        private FontAwesome.Sharp.IconButton btnlimpiar;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtusuario;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txttipodocumento;
        private Guna.UI2.WinForms.Guna2TextBox txtfecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txtnumerocompra;
        private System.Windows.Forms.GroupBox groupBox2;
        private Guna.UI2.WinForms.Guna2TextBox Idproveedor;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txtdocumento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView txttabladetallecompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIDproducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNroLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFechaVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSubTotal;
        private System.Windows.Forms.DataGridViewButtonColumn btneliminae;
        private Guna.UI2.WinForms.Guna2TextBox txtrazonsocial;
        private Guna.UI2.WinForms.Guna2TextBox txtbuscarnumerodocumento;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txmontototal;
        private FontAwesome.Sharp.IconButton btnExplorapdf;
    }
}