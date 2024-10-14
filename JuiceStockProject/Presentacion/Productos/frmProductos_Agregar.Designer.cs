namespace JuiceStockProject.Presentacion.Productos
{
    partial class frmProductos_Agregar
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txbNombre = new TextBox();
            txbPrecio = new TextBox();
            cmbProveedor = new ComboBox();
            cmbCategoria = new ComboBox();
            btnAgregarProducto = new Button();
            lblInvalido = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiCondensed", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(189, 41);
            label1.Name = "label1";
            label1.Size = new Size(217, 34);
            label1.TabIndex = 1;
            label1.Text = "Agregar Productos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(135, 91);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 2;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(332, 91);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 3;
            label3.Text = "Precio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(135, 175);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 4;
            label4.Text = "Proveedor";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(332, 175);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 5;
            label5.Text = "Categoria";
            // 
            // txbNombre
            // 
            txbNombre.Location = new Point(135, 114);
            txbNombre.Name = "txbNombre";
            txbNombre.Size = new Size(164, 27);
            txbNombre.TabIndex = 6;
            // 
            // txbPrecio
            // 
            txbPrecio.Location = new Point(332, 114);
            txbPrecio.Name = "txbPrecio";
            txbPrecio.Size = new Size(127, 27);
            txbPrecio.TabIndex = 7;
            // 
            // cmbProveedor
            // 
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(135, 198);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(151, 28);
            cmbProveedor.TabIndex = 8;
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(332, 198);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(151, 28);
            cmbCategoria.TabIndex = 9;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.BackColor = Color.FromArgb(255, 183, 3);
            btnAgregarProducto.Cursor = Cursors.Hand;
            btnAgregarProducto.FlatAppearance.BorderSize = 0;
            btnAgregarProducto.FlatStyle = FlatStyle.Flat;
            btnAgregarProducto.Font = new Font("Bahnschrift SemiCondensed", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarProducto.Location = new Point(240, 286);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(113, 38);
            btnAgregarProducto.TabIndex = 10;
            btnAgregarProducto.Text = "Agregar";
            btnAgregarProducto.UseVisualStyleBackColor = false;
            // 
            // lblInvalido
            // 
            lblInvalido.AutoSize = true;
            lblInvalido.ForeColor = Color.FromArgb(192, 0, 0);
            lblInvalido.Location = new Point(132, 254);
            lblInvalido.Name = "lblInvalido";
            lblInvalido.Size = new Size(167, 20);
            lblInvalido.TabIndex = 11;
            lblInvalido.Text = "Ingrese todos los datos!";
            lblInvalido.Visible = false;
            // 
            // frmProductos_Agregar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 353);
            Controls.Add(lblInvalido);
            Controls.Add(btnAgregarProducto);
            Controls.Add(cmbCategoria);
            Controls.Add(cmbProveedor);
            Controls.Add(txbPrecio);
            Controls.Add(txbNombre);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmProductos_Agregar";
            Text = "frmProductos_Agregar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txbNombre;
        private TextBox txbPrecio;
        private ComboBox cmbProveedor;
        private ComboBox cmbCategoria;
        private Button btnAgregarProducto;
        private Label lblInvalido;
    }
}