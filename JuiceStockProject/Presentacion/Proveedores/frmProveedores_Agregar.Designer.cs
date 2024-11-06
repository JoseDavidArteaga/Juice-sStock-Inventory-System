namespace JuiceStockProject.Presentacion.Proveedores
{
    partial class frmProveedores_Agregar
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
            lblTelefono = new Label();
            lblIncompleto = new Label();
            btnAgregarProveedores = new Button();
            txbTelefono = new TextBox();
            txbNombre = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txbDirección = new TextBox();
            txbCorreo = new TextBox();
            SuspendLayout();
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.ForeColor = Color.FromArgb(192, 0, 0);
            lblTelefono.Location = new Point(327, 135);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(224, 20);
            lblTelefono.TabIndex = 25;
            lblTelefono.Text = "El telefono debe empezar por 3 ";
            // 
            // lblIncompleto
            // 
            lblIncompleto.AutoSize = true;
            lblIncompleto.ForeColor = Color.FromArgb(192, 0, 0);
            lblIncompleto.Location = new Point(127, 245);
            lblIncompleto.Name = "lblIncompleto";
            lblIncompleto.Size = new Size(167, 20);
            lblIncompleto.TabIndex = 24;
            lblIncompleto.Text = "Ingrese todos los datos!";
            lblIncompleto.Visible = false;
            // 
            // btnAgregarProveedores
            // 
            btnAgregarProveedores.BackColor = Color.FromArgb(255, 183, 3);
            btnAgregarProveedores.Cursor = Cursors.Hand;
            btnAgregarProveedores.FlatAppearance.BorderSize = 0;
            btnAgregarProveedores.FlatStyle = FlatStyle.Flat;
            btnAgregarProveedores.Font = new Font("Bahnschrift SemiCondensed", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarProveedores.Location = new Point(240, 277);
            btnAgregarProveedores.Name = "btnAgregarProveedores";
            btnAgregarProveedores.Size = new Size(113, 38);
            btnAgregarProveedores.TabIndex = 23;
            btnAgregarProveedores.Text = "Agregar";
            btnAgregarProveedores.UseVisualStyleBackColor = false;
            btnAgregarProveedores.Click += btnAgregarProveedores_Click;
            // 
            // txbTelefono
            // 
            txbTelefono.Location = new Point(327, 105);
            txbTelefono.MaxLength = 10;
            txbTelefono.Name = "txbTelefono";
            txbTelefono.Size = new Size(143, 27);
            txbTelefono.TabIndex = 20;
            // 
            // txbNombre
            // 
            txbNombre.Location = new Point(130, 105);
            txbNombre.MaxLength = 50;
            txbNombre.Name = "txbNombre";
            txbNombre.Size = new Size(164, 27);
            txbNombre.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(327, 166);
            label5.Name = "label5";
            label5.Size = new Size(72, 20);
            label5.TabIndex = 18;
            label5.Text = "Dirección";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(130, 166);
            label4.Name = "label4";
            label4.Size = new Size(132, 20);
            label4.TabIndex = 17;
            label4.Text = "Correo Electronico";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(327, 82);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 16;
            label3.Text = "Telefono";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(130, 82);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 15;
            label2.Text = "Nombre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiCondensed", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(168, 33);
            label1.Name = "label1";
            label1.Size = new Size(244, 34);
            label1.TabIndex = 14;
            label1.Text = "Agregar Proveedores";
            // 
            // txbDirección
            // 
            txbDirección.Location = new Point(324, 189);
            txbDirección.MaxLength = 50;
            txbDirección.Name = "txbDirección";
            txbDirección.Size = new Size(190, 27);
            txbDirección.TabIndex = 27;
            // 
            // txbCorreo
            // 
            txbCorreo.Location = new Point(127, 189);
            txbCorreo.MaxLength = 50;
            txbCorreo.Name = "txbCorreo";
            txbCorreo.Size = new Size(191, 27);
            txbCorreo.TabIndex = 26;
            // 
            // frmProveedores_Agregar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 353);
            Controls.Add(txbDirección);
            Controls.Add(txbCorreo);
            Controls.Add(lblTelefono);
            Controls.Add(lblIncompleto);
            Controls.Add(btnAgregarProveedores);
            Controls.Add(txbTelefono);
            Controls.Add(txbNombre);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmProveedores_Agregar";
            Text = "Agregar Proveedores";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal Label lblTelefono;
        internal Label lblIncompleto;
        internal Button btnAgregarProveedores;
        internal TextBox txbTelefono;
        internal TextBox txbNombre;
        internal Label label5;
        internal Label label4;
        internal Label label3;
        internal Label label2;
        internal Label label1;
        internal TextBox txbDirección;
        internal TextBox txbCorreo;
    }
}