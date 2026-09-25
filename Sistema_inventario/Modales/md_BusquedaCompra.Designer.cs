namespace Sistema_inventario.Modales
{
    partial class md_BusquedaCompra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBusqueda = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBuscarNombre = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnlimpiar = new FontAwesome.Sharp.IconButton();
            this.tablabusquedacompra = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ColFechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNumeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMontoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tablabusquedacompra)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(84)))), ((int)(((byte)(230)))));
            this.label1.Location = new System.Drawing.Point(24, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(645, 38);
            this.label1.TabIndex = 37;
            this.label1.Text = "Búsqueda de Compras";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBusqueda.DefaultText = "";
            this.txtBusqueda.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBusqueda.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBusqueda.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBusqueda.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBusqueda.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            this.txtBusqueda.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBusqueda.Location = new System.Drawing.Point(460, 61);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.PlaceholderText = "Escriba para buscar...";
            this.txtBusqueda.SelectedText = "";
            this.txtBusqueda.Size = new System.Drawing.Size(108, 24);
            this.txtBusqueda.TabIndex = 45;
            // 
            // txtBuscarNombre
            // 
            this.txtBuscarNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscarNombre.FormattingEnabled = true;
            this.txtBuscarNombre.Location = new System.Drawing.Point(333, 61);
            this.txtBuscarNombre.Name = "txtBuscarNombre";
            this.txtBuscarNombre.Size = new System.Drawing.Size(121, 25);
            this.txtBuscarNombre.TabIndex = 44;
            this.txtBuscarNombre.SelectedIndexChanged += new System.EventHandler(this.txtBuscarNombre_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(65)))), ((int)(((byte)(110)))));
            this.label2.Location = new System.Drawing.Point(236, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 43;
            this.label2.Text = "Búsqueda por...";
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.BackColor = System.Drawing.Color.White;
            this.btnlimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(84)))), ((int)(((byte)(230)))));
            this.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnlimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(84)))), ((int)(((byte)(230)))));
            this.btnlimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(84)))), ((int)(((byte)(230)))));
            this.btnlimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiar.IconSize = 16;
            this.btnlimpiar.Location = new System.Drawing.Point(574, 60);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(56, 26);
            this.btnlimpiar.TabIndex = 46;
            this.btnlimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnlimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnlimpiar.UseVisualStyleBackColor = false;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // tablabusquedacompra
            // 
            this.tablabusquedacompra.AllowUserToOrderColumns = true;
            this.tablabusquedacompra.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.tablabusquedacompra.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tablabusquedacompra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(84)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(84)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablabusquedacompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tablabusquedacompra.ColumnHeadersHeight = 36;
            this.tablabusquedacompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColFechaRegistro,
            this.ColTipoDocumento,
            this.ColNumeroDocumento,
            this.ColRazonSocial,
            this.ColMontoTotal,
            this.UsuarioRegistro});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablabusquedacompra.DefaultCellStyle = dataGridViewCellStyle3;
            this.tablabusquedacompra.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(255)))));
            this.tablabusquedacompra.Location = new System.Drawing.Point(29, 96);
            this.tablabusquedacompra.Name = "tablabusquedacompra";
            this.tablabusquedacompra.RowHeadersVisible = false;
            this.tablabusquedacompra.RowTemplate.Height = 30;
            this.tablabusquedacompra.Size = new System.Drawing.Size(642, 284);
            this.tablabusquedacompra.TabIndex = 47;
            this.tablabusquedacompra.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.tablabusquedacompra.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(255)))));
            this.tablabusquedacompra.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(84)))), ((int)(((byte)(230)))));
            this.tablabusquedacompra.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tablabusquedacompra.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tablabusquedacompra.ThemeStyle.HeaderStyle.Height = 36;
            this.tablabusquedacompra.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tablabusquedacompra.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            this.tablabusquedacompra.ThemeStyle.RowsStyle.Height = 30;
            this.tablabusquedacompra.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.tablabusquedacompra.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            this.tablabusquedacompra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablabusquedacompra_CellContentClick);
            // 
            // ColFechaRegistro
            // 
            this.ColFechaRegistro.HeaderText = "Fecha Registro";
            this.ColFechaRegistro.Name = "ColFechaRegistro";
            // 
            // ColTipoDocumento
            // 
            this.ColTipoDocumento.HeaderText = "Tipo Documento";
            this.ColTipoDocumento.Name = "ColTipoDocumento";
            this.ColTipoDocumento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ColNumeroDocumento
            // 
            this.ColNumeroDocumento.HeaderText = "Número Documento";
            this.ColNumeroDocumento.Name = "ColNumeroDocumento";
            // 
            // ColRazonSocial
            // 
            this.ColRazonSocial.HeaderText = "Razón Social";
            this.ColRazonSocial.Name = "ColRazonSocial";
            // 
            // ColMontoTotal
            // 
            this.ColMontoTotal.HeaderText = "Monto Total";
            this.ColMontoTotal.Name = "ColMontoTotal";
            this.ColMontoTotal.Visible = false;
            // 
            // UsuarioRegistro
            // 
            this.UsuarioRegistro.HeaderText = "Usuario Registro";
            this.UsuarioRegistro.Name = "UsuarioRegistro";
            // 
            // md_BusquedaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.tablabusquedacompra);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.txtBuscarNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "md_BusquedaCompra";
            this.Text = "Búsqueda de Compras";
            this.Load += new System.EventHandler(this.md_BusquedaCompra_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.tablabusquedacompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnlimpiar;
        private Guna.UI2.WinForms.Guna2TextBox txtBusqueda;
        private System.Windows.Forms.ComboBox txtBuscarNombre;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView tablabusquedacompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNumeroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMontoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioRegistro;
    }
}