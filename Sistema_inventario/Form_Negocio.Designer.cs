namespace Sistema_inventario
{
    partial class Form_Negocio
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtguardar = new FontAwesome.Sharp.IconButton();
            this.textdireccion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textRuc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnsubirimagen = new FontAwesome.Sharp.IconButton();
            this.logo = new System.Windows.Forms.Label();
            this.picturelogo = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturelogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(30, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detalle de Negocio";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtguardar);
            this.groupBox1.Controls.Add(this.textdireccion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textRuc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnsubirimagen);
            this.groupBox1.Controls.Add(this.logo);
            this.groupBox1.Controls.Add(this.picturelogo);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.groupBox1.Location = new System.Drawing.Point(30, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(20);
            this.groupBox1.Size = new System.Drawing.Size(710, 325);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Datos de la Empresa ";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtguardar
            // 
            this.txtguardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.txtguardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtguardar.FlatAppearance.BorderSize = 0;
            this.txtguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtguardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtguardar.ForeColor = System.Drawing.Color.White;
            this.txtguardar.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            this.txtguardar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.txtguardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.txtguardar.IconSize = 20;
            this.txtguardar.Location = new System.Drawing.Point(240, 255);
            this.txtguardar.Name = "txtguardar";
            this.txtguardar.Size = new System.Drawing.Size(170, 38);
            this.txtguardar.TabIndex = 9;
            this.txtguardar.Text = " Guardar Cambios";
            this.txtguardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.txtguardar.UseVisualStyleBackColor = false;
            this.txtguardar.Click += new System.EventHandler(this.txtguardar_Click);
            // 
            // textdireccion
            // 
            this.textdireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textdireccion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.textdireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.textdireccion.Location = new System.Drawing.Point(240, 202);
            this.textdireccion.Name = "textdireccion";
            this.textdireccion.Size = new System.Drawing.Size(430, 24);
            this.textdireccion.TabIndex = 8;
            this.textdireccion.TextChanged += new System.EventHandler(this.textdireccion_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label4.Location = new System.Drawing.Point(240, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Dirección";
            // 
            // textRuc
            // 
            this.textRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRuc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.textRuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.textRuc.Location = new System.Drawing.Point(240, 134);
            this.textRuc.Name = "textRuc";
            this.textRuc.Size = new System.Drawing.Size(430, 24);
            this.textRuc.TabIndex = 6;
            this.textRuc.TextChanged += new System.EventHandler(this.textRuc_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label3.Location = new System.Drawing.Point(240, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "RUC";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.textBox1.Location = new System.Drawing.Point(240, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(430, 24);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.label2.Location = new System.Drawing.Point(240, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre de Negocio";
            // 
            // btnsubirimagen
            // 
            this.btnsubirimagen.BackColor = System.Drawing.Color.White;
            this.btnsubirimagen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsubirimagen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.btnsubirimagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsubirimagen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnsubirimagen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.btnsubirimagen.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.btnsubirimagen.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(68)))));
            this.btnsubirimagen.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnsubirimagen.IconSize = 18;
            this.btnsubirimagen.Location = new System.Drawing.Point(30, 255);
            this.btnsubirimagen.Name = "btnsubirimagen";
            this.btnsubirimagen.Size = new System.Drawing.Size(160, 36);
            this.btnsubirimagen.TabIndex = 2;
            this.btnsubirimagen.Text = " Subir Imagen";
            this.btnsubirimagen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnsubirimagen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsubirimagen.UseVisualStyleBackColor = false;
            this.btnsubirimagen.Click += new System.EventHandler(this.btnsubirimagen_Click);
            // 
            // logo
            // 
            this.logo.AutoSize = true;
            this.logo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.logo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.logo.Location = new System.Drawing.Point(30, 46);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(99, 15);
            this.logo.TabIndex = 1;
            this.logo.Text = "Logo del Negocio";
            // 
            // picturelogo
            // 
            this.picturelogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.picturelogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picturelogo.Location = new System.Drawing.Point(30, 66);
            this.picturelogo.Name = "picturelogo";
            this.picturelogo.Size = new System.Drawing.Size(160, 165);
            this.picturelogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturelogo.TabIndex = 0;
            this.picturelogo.TabStop = false;
            this.picturelogo.Click += new System.EventHandler(this.picturelogo_Click);
            // 
            // Form_Negocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(770, 435);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_Negocio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle de Negocio";
            this.Load += new System.EventHandler(this.Form_Negocio_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturelogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label logo;
        private System.Windows.Forms.PictureBox picturelogo;
        private FontAwesome.Sharp.IconButton btnsubirimagen;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton txtguardar;
        private System.Windows.Forms.TextBox textdireccion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textRuc;
        private System.Windows.Forms.Label label3;
    }
}