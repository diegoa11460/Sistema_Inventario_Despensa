namespace Sistema_inventario
{
    partial class Form_DetalleVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExplorapdf = new FontAwesome.Sharp.IconButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbuscarnumerodocumento = new Guna.UI2.WinForms.Guna2TextBox();
            this.btneliminae = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIDproducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txmontototal = new Guna.UI2.WinForms.Guna2TextBox();
            this.txttabladetalleventa = new System.Windows.Forms.DataGridView();
            this.txtnombrecliente = new Guna.UI2.WinForms.Guna2TextBox();
            this.Idcliente = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtdocumentocliente = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnlimpiar = new FontAwesome.Sharp.IconButton();
            this.btnbuscar = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtticketventa = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtusuario = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txttipodocumento = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtfecha = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPagoCon = new System.Windows.Forms.Label();
            this.txtpagocon = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelCambio = new System.Windows.Forms.Label();
            this.txtcambio = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txttabladetalleventa)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.btnExplorapdf.Location = new System.Drawing.Point(691, 439);
            this.btnExplorapdf.Name = "btnExplorapdf";
            this.btnExplorapdf.Size = new System.Drawing.Size(150, 32);
            this.btnExplorapdf.TabIndex = 58;
            this.btnExplorapdf.Text = " Descargar PDF";
            this.btnExplorapdf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExplorapdf.UseVisualStyleBackColor = false;
            this.btnExplorapdf.Click += new System.EventHandler(this.btnExplorapdf_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.label6.Location = new System.Drawing.Point(101, 444);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 19);
            this.label6.TabIndex = 57;
            this.label6.Text = "Monto Total:";
            // 
            // txtbuscarnumerodocumento
            // 
            this.txtbuscarnumerodocumento.BorderRadius = 5;
            this.txtbuscarnumerodocumento.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbuscarnumerodocumento.DefaultText = "";
            this.txtbuscarnumerodocumento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtbuscarnumerodocumento.Location = new System.Drawing.Point(471, 50);
            this.txtbuscarnumerodocumento.Name = "txtbuscarnumerodocumento";
            this.txtbuscarnumerodocumento.PlaceholderText = "";
            this.txtbuscarnumerodocumento.SelectedText = "";
            this.txtbuscarnumerodocumento.Size = new System.Drawing.Size(125, 28);
            this.txtbuscarnumerodocumento.TabIndex = 56;
            this.txtbuscarnumerodocumento.TextChanged += new System.EventHandler(this.txtbuscarnumerodocumento_TextChanged);
            // 
            // btneliminae
            // 
            this.btneliminae.HeaderText = "";
            this.btneliminae.Name = "btneliminae";
            this.btneliminae.ReadOnly = true;
            this.btneliminae.Visible = false;
            // 
            // CSubTotal
            // 
            this.CSubTotal.HeaderText = "Sub Total";
            this.CSubTotal.Name = "CSubTotal";
            this.CSubTotal.ReadOnly = true;
            // 
            // CCantidad
            // 
            this.CCantidad.HeaderText = "Cantidad";
            this.CCantidad.Name = "CCantidad";
            this.CCantidad.ReadOnly = true;
            // 
            // CPrecioVenta
            // 
            this.CPrecioVenta.HeaderText = "Precio";
            this.CPrecioVenta.Name = "CPrecioVenta";
            this.CPrecioVenta.ReadOnly = true;
            // 
            // CProducto
            // 
            this.CProducto.HeaderText = "Producto";
            this.CProducto.Name = "CProducto";
            this.CProducto.ReadOnly = true;
            // 
            // CIDproducto
            // 
            this.CIDproducto.HeaderText = "ID";
            this.CIDproducto.Name = "CIDproducto";
            this.CIDproducto.ReadOnly = true;
            this.CIDproducto.Visible = false;
            // 
            // txmontototal
            // 
            this.txmontototal.BorderRadius = 5;
            this.txmontototal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txmontototal.DefaultText = "0";
            this.txmontototal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txmontototal.Location = new System.Drawing.Point(191, 440);
            this.txmontototal.Name = "txmontototal";
            this.txmontototal.PlaceholderText = "";
            this.txmontototal.ReadOnly = true;
            this.txmontototal.SelectedText = "";
            this.txmontototal.Size = new System.Drawing.Size(100, 28);
            this.txmontototal.TabIndex = 53;
            this.txmontototal.TextChanged += new System.EventHandler(this.txmontototal_TextChanged);
            // 
            // txttabladetalleventa
            // 
            this.txttabladetalleventa.AllowUserToAddRows = false;
            this.txttabladetalleventa.AllowUserToDeleteRows = false;
            this.txttabladetalleventa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txttabladetalleventa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.txttabladetalleventa.BackgroundColor = System.Drawing.Color.White;
            this.txttabladetalleventa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txttabladetalleventa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.txttabladetalleventa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.txttabladetalleventa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.txttabladetalleventa.ColumnHeadersHeight = 35;
            this.txttabladetalleventa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CIDproducto,
            this.CProducto,
            this.CPrecioVenta,
            this.CCantidad,
            this.CSubTotal,
            this.btneliminae});
            this.txttabladetalleventa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txttabladetalleventa.EnableHeadersVisualStyles = false;
            this.txttabladetalleventa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txttabladetalleventa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.txttabladetalleventa.Location = new System.Drawing.Point(101, 269);
            this.txttabladetalleventa.Name = "txttabladetalleventa";
            this.txttabladetalleventa.ReadOnly = true;
            this.txttabladetalleventa.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.txttabladetalleventa.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.txttabladetalleventa.RowTemplate.Height = 32;
            this.txttabladetalleventa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.txttabladetalleventa.Size = new System.Drawing.Size(740, 160);
            this.txttabladetalleventa.TabIndex = 55;
            this.txttabladetalleventa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.txttabladetalleventa_CellContentClick);
            // 
            // txtnombrecliente
            // 
            this.txtnombrecliente.BorderRadius = 5;
            this.txtnombrecliente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtnombrecliente.DefaultText = "";
            this.txtnombrecliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtnombrecliente.Location = new System.Drawing.Point(235, 41);
            this.txtnombrecliente.Name = "txtnombrecliente";
            this.txtnombrecliente.PlaceholderText = "";
            this.txtnombrecliente.ReadOnly = true;
            this.txtnombrecliente.SelectedText = "";
            this.txtnombrecliente.Size = new System.Drawing.Size(300, 26);
            this.txtnombrecliente.TabIndex = 40;
            this.txtnombrecliente.TextChanged += new System.EventHandler(this.txtnombrecliente_TextChanged);
            // 
            // Idcliente
            // 
            this.Idcliente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Idcliente.DefaultText = "";
            this.Idcliente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Idcliente.Location = new System.Drawing.Point(565, 41);
            this.Idcliente.Name = "Idcliente";
            this.Idcliente.PlaceholderText = "";
            this.Idcliente.SelectedText = "";
            this.Idcliente.Size = new System.Drawing.Size(60, 26);
            this.Idcliente.TabIndex = 38;
            this.Idcliente.Visible = false;
            this.Idcliente.TextChanged += new System.EventHandler(this.Idcliente_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label7.Location = new System.Drawing.Point(235, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 15);
            this.label7.TabIndex = 41;
            this.label7.Text = "Nombre Cliente";
            // 
            // txtdocumentocliente
            // 
            this.txtdocumentocliente.BorderRadius = 5;
            this.txtdocumentocliente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtdocumentocliente.DefaultText = "";
            this.txtdocumentocliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtdocumentocliente.Location = new System.Drawing.Point(20, 41);
            this.txtdocumentocliente.Name = "txtdocumentocliente";
            this.txtdocumentocliente.PlaceholderText = "";
            this.txtdocumentocliente.ReadOnly = true;
            this.txtdocumentocliente.SelectedText = "";
            this.txtdocumentocliente.Size = new System.Drawing.Size(190, 26);
            this.txtdocumentocliente.TabIndex = 38;
            this.txtdocumentocliente.TextChanged += new System.EventHandler(this.txtdocumentocliente_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label8.Location = new System.Drawing.Point(20, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 15);
            this.label8.TabIndex = 42;
            this.label8.Text = "Documento Cliente";
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.BackColor = System.Drawing.Color.White;
            this.btnlimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnlimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiar.IconColor = System.Drawing.Color.Black;
            this.btnlimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiar.IconSize = 16;
            this.btnlimpiar.Location = new System.Drawing.Point(716, 50);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(100, 28);
            this.btnlimpiar.TabIndex = 52;
            this.btnlimpiar.Text = " Limpiar";
            this.btnlimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnlimpiar.UseVisualStyleBackColor = false;
            // 
            // btnbuscar
            // 
            this.btnbuscar.BackColor = System.Drawing.Color.White;
            this.btnbuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnbuscar.IconChar = FontAwesome.Sharp.IconChar.Sistrix;
            this.btnbuscar.IconColor = System.Drawing.Color.Black;
            this.btnbuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscar.IconSize = 16;
            this.btnbuscar.Location = new System.Drawing.Point(606, 50);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(100, 28);
            this.btnbuscar.TabIndex = 51;
            this.btnbuscar.Text = " Buscar";
            this.btnbuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbuscar.UseVisualStyleBackColor = false;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label2.Location = new System.Drawing.Point(344, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 59;
            this.label2.Text = "Buscar por Ticket:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.Location = new System.Drawing.Point(355, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Ticket";
            // 
            // txtticketventa
            // 
            this.txtticketventa.BorderRadius = 5;
            this.txtticketventa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtticketventa.DefaultText = "";
            this.txtticketventa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtticketventa.Location = new System.Drawing.Point(355, 41);
            this.txtticketventa.Name = "txtticketventa";
            this.txtticketventa.PlaceholderText = "";
            this.txtticketventa.ReadOnly = true;
            this.txtticketventa.SelectedText = "";
            this.txtticketventa.Size = new System.Drawing.Size(125, 26);
            this.txtticketventa.TabIndex = 41;
            this.txtticketventa.TextChanged += new System.EventHandler(this.txtticketventa_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(495, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 42;
            this.label5.Text = "Usuario";
            // 
            // txtusuario
            // 
            this.txtusuario.BorderRadius = 5;
            this.txtusuario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtusuario.DefaultText = "";
            this.txtusuario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtusuario.Location = new System.Drawing.Point(495, 41);
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.PlaceholderText = "";
            this.txtusuario.ReadOnly = true;
            this.txtusuario.SelectedText = "";
            this.txtusuario.Size = new System.Drawing.Size(225, 26);
            this.txtusuario.TabIndex = 38;
            this.txtusuario.TextChanged += new System.EventHandler(this.txtusuario_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(180, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 43;
            this.label4.Text = "Método de Pago";
            // 
            // txttipodocumento
            // 
            this.txttipodocumento.BorderRadius = 5;
            this.txttipodocumento.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txttipodocumento.DefaultText = "";
            this.txttipodocumento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txttipodocumento.Location = new System.Drawing.Point(180, 41);
            this.txttipodocumento.Name = "txttipodocumento";
            this.txttipodocumento.PlaceholderText = "";
            this.txttipodocumento.ReadOnly = true;
            this.txttipodocumento.SelectedText = "";
            this.txttipodocumento.Size = new System.Drawing.Size(160, 26);
            this.txttipodocumento.TabIndex = 39;
            this.txttipodocumento.TextChanged += new System.EventHandler(this.txttipodocumento_TextChanged);
            // 
            // txtfecha
            // 
            this.txtfecha.BorderRadius = 5;
            this.txtfecha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtfecha.DefaultText = "";
            this.txtfecha.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtfecha.Location = new System.Drawing.Point(20, 41);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.PlaceholderText = "";
            this.txtfecha.ReadOnly = true;
            this.txtfecha.SelectedText = "";
            this.txtfecha.Size = new System.Drawing.Size(145, 26);
            this.txtfecha.TabIndex = 38;
            this.txtfecha.TextChanged += new System.EventHandler(this.txtfecha_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(20, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 44;
            this.label3.Text = "Fecha";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtnombrecliente);
            this.groupBox2.Controls.Add(this.Idcliente);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtdocumentocliente);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(101, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(740, 75);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Información de Cliente ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtticketventa);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtusuario);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txttipodocumento);
            this.groupBox1.Controls.Add(this.txtfecha);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(101, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(740, 75);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Información de Venta ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(101, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 30);
            this.label1.TabIndex = 60;
            this.label1.Text = "Detalle de Venta";
            // 
            // labelPagoCon
            // 
            this.labelPagoCon.AutoSize = true;
            this.labelPagoCon.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelPagoCon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.labelPagoCon.Location = new System.Drawing.Point(300, 444);
            this.labelPagoCon.Name = "labelPagoCon";
            this.labelPagoCon.Size = new System.Drawing.Size(72, 19);
            this.labelPagoCon.TabIndex = 3;
            this.labelPagoCon.Text = "Pagó Con:";
            // 
            // txtpagocon
            // 
            this.txtpagocon.BorderRadius = 5;
            this.txtpagocon.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpagocon.DefaultText = "0";
            this.txtpagocon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtpagocon.Location = new System.Drawing.Point(375, 440);
            this.txtpagocon.Name = "txtpagocon";
            this.txtpagocon.PlaceholderText = "";
            this.txtpagocon.ReadOnly = true;
            this.txtpagocon.SelectedText = "";
            this.txtpagocon.Size = new System.Drawing.Size(100, 28);
            this.txtpagocon.TabIndex = 2;
            this.txtpagocon.TextChanged += new System.EventHandler(this.txtpagocon_TextChanged);
            // 
            // labelCambio
            // 
            this.labelCambio.AutoSize = true;
            this.labelCambio.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelCambio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.labelCambio.Location = new System.Drawing.Point(485, 444);
            this.labelCambio.Name = "labelCambio";
            this.labelCambio.Size = new System.Drawing.Size(60, 19);
            this.labelCambio.TabIndex = 1;
            this.labelCambio.Text = "Cambio:";
            // 
            // txtcambio
            // 
            this.txtcambio.BorderRadius = 5;
            this.txtcambio.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcambio.DefaultText = "0";
            this.txtcambio.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtcambio.Location = new System.Drawing.Point(545, 440);
            this.txtcambio.Name = "txtcambio";
            this.txtcambio.PlaceholderText = "";
            this.txtcambio.ReadOnly = true;
            this.txtcambio.SelectedText = "";
            this.txtcambio.Size = new System.Drawing.Size(100, 28);
            this.txtcambio.TabIndex = 0;
            this.txtcambio.TextChanged += new System.EventHandler(this.txtcambio_TextChanged);
            // 
            // Form_DetalleVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 475);
            this.Controls.Add(this.txtcambio);
            this.Controls.Add(this.labelCambio);
            this.Controls.Add(this.txtpagocon);
            this.Controls.Add(this.labelPagoCon);
            this.Controls.Add(this.btnExplorapdf);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtbuscarnumerodocumento);
            this.Controls.Add(this.txmontototal);
            this.Controls.Add(this.txttabladetalleventa);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form_DetalleVentas";
            this.Text = "Form_Detalle_Ventas";
            this.Load += new System.EventHandler(this.Form_DetalleVentas_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.txttabladetalleventa)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnExplorapdf;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtbuscarnumerodocumento;
        private System.Windows.Forms.DataGridViewButtonColumn btneliminae;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIDproducto;
        private Guna.UI2.WinForms.Guna2TextBox txmontototal;
        private System.Windows.Forms.DataGridView txttabladetalleventa;
        private Guna.UI2.WinForms.Guna2TextBox txtnombrecliente;
        private Guna.UI2.WinForms.Guna2TextBox Idcliente;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txtdocumentocliente;
        private System.Windows.Forms.Label label8;
        private FontAwesome.Sharp.IconButton btnlimpiar;
        private FontAwesome.Sharp.IconButton btnbuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txtticketventa;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtusuario;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txttipodocumento;
        private Guna.UI2.WinForms.Guna2TextBox txtfecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPagoCon;
        private Guna.UI2.WinForms.Guna2TextBox txtpagocon;
        private System.Windows.Forms.Label labelCambio;
        private Guna.UI2.WinForms.Guna2TextBox txtcambio;
    }
}