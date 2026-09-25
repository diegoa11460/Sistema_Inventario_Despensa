namespace Sistema_inventario
{
    partial class Form_Ver_detalle
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
            this.lblTituloPrincipal = new System.Windows.Forms.Label();
            this.panelCompra = new System.Windows.Forms.Panel();
            this.btnVerCompra = new FontAwesome.Sharp.IconButton();
            this.lblDescCompra = new System.Windows.Forms.Label();
            this.iconTituloCompra = new FontAwesome.Sharp.IconPictureBox();
            this.lblTituloCompra = new System.Windows.Forms.Label();
            this.panelVenta = new System.Windows.Forms.Panel();
            this.btnVerVenta = new FontAwesome.Sharp.IconButton();
            this.lblDescVenta = new System.Windows.Forms.Label();
            this.iconTituloVenta = new FontAwesome.Sharp.IconPictureBox();
            this.lblTituloVenta = new System.Windows.Forms.Label();
            this.panelCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconTituloCompra)).BeginInit();
            this.panelVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconTituloVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.AutoSize = true;
            this.lblTituloPrincipal.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.lblTituloPrincipal.Location = new System.Drawing.Point(30, 25);
            this.lblTituloPrincipal.Name = "lblTituloPrincipal";
            this.lblTituloPrincipal.Size = new System.Drawing.Size(475, 30);
            this.lblTituloPrincipal.TabIndex = 0;
            this.lblTituloPrincipal.Text = "Módulo de Ver Detalles de compra y ventas";
            // 
            // panelCompra
            // 
            this.panelCompra.BackColor = System.Drawing.Color.White;
            this.panelCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCompra.Controls.Add(this.btnVerCompra);
            this.panelCompra.Controls.Add(this.lblDescCompra);
            this.panelCompra.Controls.Add(this.iconTituloCompra);
            this.panelCompra.Controls.Add(this.lblTituloCompra);
            this.panelCompra.Location = new System.Drawing.Point(35, 80);
            this.panelCompra.Name = "panelCompra";
            this.panelCompra.Size = new System.Drawing.Size(385, 262);
            this.panelCompra.TabIndex = 1;
            // 
            // btnVerCompra
            // 
            this.btnVerCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.btnVerCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerCompra.FlatAppearance.BorderSize = 0;
            this.btnVerCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerCompra.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnVerCompra.ForeColor = System.Drawing.Color.White;
            this.btnVerCompra.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnVerCompra.IconColor = System.Drawing.Color.White;
            this.btnVerCompra.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnVerCompra.IconSize = 20;
            this.btnVerCompra.Location = new System.Drawing.Point(30, 190);
            this.btnVerCompra.Name = "btnVerCompra";
            this.btnVerCompra.Size = new System.Drawing.Size(320, 50);
            this.btnVerCompra.TabIndex = 2;
            this.btnVerCompra.Text = "  Consultar Compras";
            this.btnVerCompra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerCompra.UseVisualStyleBackColor = false;
            this.btnVerCompra.Click += new System.EventHandler(this.btnVerCompra_Click);
            // 
            // lblDescCompra
            // 
            this.lblDescCompra.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDescCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.lblDescCompra.Location = new System.Drawing.Point(30, 88);
            this.lblDescCompra.Name = "lblDescCompra";
            this.lblDescCompra.Size = new System.Drawing.Size(320, 65);
            this.lblDescCompra.TabIndex = 1;
            this.lblDescCompra.Text = "Busca el historial de compras por número de factura, revisa lotes, fechas de venc" +
    "imiento, proveedores y montos.";
            // 
            // iconTituloCompra
            // 
            this.iconTituloCompra.BackColor = System.Drawing.Color.Transparent;
            this.iconTituloCompra.IconChar = FontAwesome.Sharp.IconChar.Boxes;
            this.iconTituloCompra.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.iconTituloCompra.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconTituloCompra.IconSize = 26;
            this.iconTituloCompra.Location = new System.Drawing.Point(30, 28);
            this.iconTituloCompra.Name = "iconTituloCompra";
            this.iconTituloCompra.Size = new System.Drawing.Size(30, 30);
            this.iconTituloCompra.TabIndex = 3;
            this.iconTituloCompra.TabStop = false;
            // 
            // lblTituloCompra
            // 
            this.lblTituloCompra.AutoSize = true;
            this.lblTituloCompra.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.lblTituloCompra.Location = new System.Drawing.Point(68, 32);
            this.lblTituloCompra.Name = "lblTituloCompra";
            this.lblTituloCompra.Size = new System.Drawing.Size(190, 25);
            this.lblTituloCompra.TabIndex = 0;
            this.lblTituloCompra.Text = "Detalle de Compras";
            // 
            // panelVenta
            // 
            this.panelVenta.BackColor = System.Drawing.Color.White;
            this.panelVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVenta.Controls.Add(this.btnVerVenta);
            this.panelVenta.Controls.Add(this.lblDescVenta);
            this.panelVenta.Controls.Add(this.iconTituloVenta);
            this.panelVenta.Controls.Add(this.lblTituloVenta);
            this.panelVenta.Location = new System.Drawing.Point(440, 80);
            this.panelVenta.Name = "panelVenta";
            this.panelVenta.Size = new System.Drawing.Size(385, 262);
            this.panelVenta.TabIndex = 2;
            // 
            // btnVerVenta
            // 
            this.btnVerVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnVerVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerVenta.FlatAppearance.BorderSize = 0;
            this.btnVerVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnVerVenta.ForeColor = System.Drawing.Color.White;
            this.btnVerVenta.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnVerVenta.IconColor = System.Drawing.Color.White;
            this.btnVerVenta.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnVerVenta.IconSize = 20;
            this.btnVerVenta.Location = new System.Drawing.Point(30, 190);
            this.btnVerVenta.Name = "btnVerVenta";
            this.btnVerVenta.Size = new System.Drawing.Size(320, 50);
            this.btnVerVenta.TabIndex = 2;
            this.btnVerVenta.Text = "  Consultar Ventas";
            this.btnVerVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerVenta.UseVisualStyleBackColor = false;
            this.btnVerVenta.Click += new System.EventHandler(this.btnVerVenta_Click);
            // 
            // lblDescVenta
            // 
            this.lblDescVenta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDescVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.lblDescVenta.Location = new System.Drawing.Point(30, 88);
            this.lblDescVenta.Name = "lblDescVenta";
            this.lblDescVenta.Size = new System.Drawing.Size(320, 65);
            this.lblDescVenta.TabIndex = 1;
            this.lblDescVenta.Text = "Consulta el detalle de las ventas realizadas, productos entregados, cajero respon" +
    "sable y totales registrados.";
            // 
            // iconTituloVenta
            // 
            this.iconTituloVenta.BackColor = System.Drawing.Color.Transparent;
            this.iconTituloVenta.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            this.iconTituloVenta.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.iconTituloVenta.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconTituloVenta.IconSize = 26;
            this.iconTituloVenta.Location = new System.Drawing.Point(30, 28);
            this.iconTituloVenta.Name = "iconTituloVenta";
            this.iconTituloVenta.Size = new System.Drawing.Size(30, 30);
            this.iconTituloVenta.TabIndex = 3;
            this.iconTituloVenta.TabStop = false;
            // 
            // lblTituloVenta
            // 
            this.lblTituloVenta.AutoSize = true;
            this.lblTituloVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.lblTituloVenta.Location = new System.Drawing.Point(68, 32);
            this.lblTituloVenta.Name = "lblTituloVenta";
            this.lblTituloVenta.Size = new System.Drawing.Size(170, 25);
            this.lblTituloVenta.TabIndex = 0;
            this.lblTituloVenta.Text = "Detalle de Ventas";
            // 
            // Form_Ver_detalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(860, 420);
            this.Controls.Add(this.panelVenta);
            this.Controls.Add(this.panelCompra);
            this.Controls.Add(this.lblTituloPrincipal);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Ver_detalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Módulo de Consultas";
            this.panelCompra.ResumeLayout(false);
            this.panelCompra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconTituloCompra)).EndInit();
            this.panelVenta.ResumeLayout(false);
            this.panelVenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconTituloVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloPrincipal;
        private System.Windows.Forms.Panel panelCompra;
        private FontAwesome.Sharp.IconButton btnVerCompra;
        private System.Windows.Forms.Label lblDescCompra;
        private FontAwesome.Sharp.IconPictureBox iconTituloCompra;
        private System.Windows.Forms.Label lblTituloCompra;
        private System.Windows.Forms.Panel panelVenta;
        private FontAwesome.Sharp.IconButton btnVerVenta;
        private System.Windows.Forms.Label lblDescVenta;
        private FontAwesome.Sharp.IconPictureBox iconTituloVenta;
        private System.Windows.Forms.Label lblTituloVenta;
    }
}