namespace JuiceStockProject.Presentacion.Proveedores
{
    partial class frmProveedores_Modificar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProveedores_Modificar));
            pnlModificar = new Panel();
            txbDirección = new TextBox();
            txbCorreo = new TextBox();
            lblTelefono = new Label();
            txbTelefono = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            lblSeleccionarProv = new Label();
            btnModificarProveedor = new Button();
            lblIncompleto = new Label();
            txbNombre = new TextBox();
            label6 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbProveedores = new ComboBox();
            pnlModificar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlModificar
            // 
            pnlModificar.BackColor = SystemColors.ScrollBar;
            pnlModificar.Controls.Add(txbDirección);
            pnlModificar.Controls.Add(txbCorreo);
            pnlModificar.Controls.Add(lblTelefono);
            pnlModificar.Controls.Add(txbTelefono);
            pnlModificar.Controls.Add(label5);
            pnlModificar.Controls.Add(label4);
            pnlModificar.Controls.Add(label3);
            pnlModificar.Controls.Add(lblSeleccionarProv);
            pnlModificar.Controls.Add(btnModificarProveedor);
            pnlModificar.Controls.Add(lblIncompleto);
            pnlModificar.Controls.Add(txbNombre);
            pnlModificar.Controls.Add(label6);
            pnlModificar.Location = new Point(12, 116);
            pnlModificar.Name = "pnlModificar";
            pnlModificar.Size = new Size(558, 226);
            pnlModificar.TabIndex = 29;
            pnlModificar.Visible = false;
            // 
            // txbDirección
            // 
            txbDirección.Location = new Point(313, 126);
            txbDirección.MaxLength = 50;
            txbDirección.Name = "txbDirección";
            txbDirección.Size = new Size(190, 27);
            txbDirección.TabIndex = 44;
            // 
            // txbCorreo
            // 
            txbCorreo.Location = new Point(73, 126);
            txbCorreo.MaxLength = 50;
            txbCorreo.Name = "txbCorreo";
            txbCorreo.Size = new Size(191, 27);
            txbCorreo.TabIndex = 43;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.ForeColor = Color.FromArgb(192, 0, 0);
            lblTelefono.Location = new Point(316, 72);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(224, 20);
            lblTelefono.TabIndex = 42;
            lblTelefono.Text = "El telefono debe empezar por 3 ";
            lblTelefono.Visible = false;
            // 
            // txbTelefono
            // 
            txbTelefono.Location = new Point(316, 42);
            txbTelefono.MaxLength = 10;
            txbTelefono.Name = "txbTelefono";
            txbTelefono.Size = new Size(143, 27);
            txbTelefono.TabIndex = 41;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(316, 103);
            label5.Name = "label5";
            label5.Size = new Size(72, 20);
            label5.TabIndex = 40;
            label5.Text = "Dirección";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(76, 103);
            label4.Name = "label4";
            label4.Size = new Size(132, 20);
            label4.TabIndex = 39;
            label4.Text = "Correo Electronico";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(316, 19);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 38;
            label3.Text = "Telefono";
            // 
            // lblSeleccionarProv
            // 
            lblSeleccionarProv.AutoSize = true;
            lblSeleccionarProv.ForeColor = Color.FromArgb(192, 0, 0);
            lblSeleccionarProv.Location = new Point(352, 195);
            lblSeleccionarProv.Name = "lblSeleccionarProv";
            lblSeleccionarProv.Size = new Size(173, 20);
            lblSeleccionarProv.TabIndex = 37;
            lblSeleccionarProv.Text = "Seleccione un proveedor";
            // 
            // btnModificarProveedor
            // 
            btnModificarProveedor.BackColor = Color.FromArgb(255, 183, 3);
            btnModificarProveedor.Cursor = Cursors.Hand;
            btnModificarProveedor.FlatAppearance.BorderSize = 0;
            btnModificarProveedor.FlatStyle = FlatStyle.Flat;
            btnModificarProveedor.Font = new Font("Bahnschrift SemiCondensed", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnModificarProveedor.Location = new Point(227, 185);
            btnModificarProveedor.Name = "btnModificarProveedor";
            btnModificarProveedor.Size = new Size(113, 38);
            btnModificarProveedor.TabIndex = 15;
            btnModificarProveedor.Text = "Modificar";
            btnModificarProveedor.UseVisualStyleBackColor = false;
            btnModificarProveedor.Click += btnModificarProveedor_Click;
            // 
            // lblIncompleto
            // 
            lblIncompleto.AutoSize = true;
            lblIncompleto.ForeColor = Color.FromArgb(192, 0, 0);
            lblIncompleto.Location = new Point(77, 159);
            lblIncompleto.Name = "lblIncompleto";
            lblIncompleto.Size = new Size(167, 20);
            lblIncompleto.TabIndex = 35;
            lblIncompleto.Text = "Ingrese todos los datos!";
            lblIncompleto.Visible = false;
            // 
            // txbNombre
            // 
            txbNombre.Location = new Point(75, 42);
            txbNombre.MaxLength = 50;
            txbNombre.Name = "txbNombre";
            txbNombre.Size = new Size(187, 27);
            txbNombre.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(75, 19);
            label6.Name = "label6";
            label6.Size = new Size(64, 20);
            label6.TabIndex = 27;
            label6.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(172, 56);
            label2.Name = "label2";
            label2.Size = new Size(248, 20);
            label2.TabIndex = 28;
            label2.Text = "Seleccione el Proveedor a Modificar";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiCondensed", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(171, 11);
            label1.Name = "label1";
            label1.Size = new Size(257, 34);
            label1.TabIndex = 27;
            label1.Text = "Modificar Proveedores";
            // 
            // cmbProveedores
            // 
            cmbProveedores.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbProveedores.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbProveedores.FormattingEnabled = true;
            cmbProveedores.Location = new Point(167, 77);
            cmbProveedores.Name = "cmbProveedores";
            cmbProveedores.Size = new Size(260, 28);
            cmbProveedores.TabIndex = 30;
            cmbProveedores.SelectedIndexChanged += cmbProveedores_SelectedIndexChanged;
            // 
            // frmProveedores_Modificar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 353);
            Controls.Add(pnlModificar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbProveedores);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmProveedores_Modificar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modificar Proveedores";
            Load += frmProveedores_Modificar_Load;
            pnlModificar.ResumeLayout(false);
            pnlModificar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlModificar;
        internal Label lblSeleccionarProv;
        private Button btnModificarProveedor;
        internal Label lblIncompleto;
        internal TextBox txbNombre;
        internal Label label6;
        private Label label2;
        private Label label1;
        private ComboBox cmbProveedores;
        internal TextBox txbDirección;
        internal TextBox txbCorreo;
        internal Label lblTelefono;
        internal TextBox txbTelefono;
        internal Label label5;
        internal Label label4;
        internal Label label3;
    }
}