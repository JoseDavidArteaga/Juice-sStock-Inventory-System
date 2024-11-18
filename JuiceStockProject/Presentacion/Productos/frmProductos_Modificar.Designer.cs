namespace JuiceStockProject.Presentacion.Productos
{
    partial class frmProductos_Modificar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductos_Modificar));
            btnModificarProducto = new Button();
            label2 = new Label();
            label1 = new Label();
            pnlModificar = new Panel();
            lblPrecio0 = new Label();
            lblIncompleto = new Label();
            cmbCategoria = new ComboBox();
            cmbProveedor = new ComboBox();
            txbPrecio = new TextBox();
            txbNombre = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label6 = new Label();
            cmbProductos = new ComboBox();
            lblSeleccionarProd = new Label();
            pnlModificar.SuspendLayout();
            SuspendLayout();
            // 
            // btnModificarProducto
            // 
            btnModificarProducto.BackColor = Color.FromArgb(255, 183, 3);
            btnModificarProducto.Cursor = Cursors.Hand;
            btnModificarProducto.FlatAppearance.BorderSize = 0;
            btnModificarProducto.FlatStyle = FlatStyle.Flat;
            btnModificarProducto.Font = new Font("Bahnschrift SemiCondensed", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnModificarProducto.Location = new Point(228, 185);
            btnModificarProducto.Name = "btnModificarProducto";
            btnModificarProducto.Size = new Size(113, 38);
            btnModificarProducto.TabIndex = 15;
            btnModificarProducto.Text = "Modificar";
            btnModificarProducto.UseVisualStyleBackColor = false;
            btnModificarProducto.Click += btnModificarProducto_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(179, 55);
            label2.Name = "label2";
            label2.Size = new Size(240, 20);
            label2.TabIndex = 14;
            label2.Text = "Seleccione el Producto a Modificar";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiCondensed", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(185, 9);
            label1.Name = "label1";
            label1.Size = new Size(230, 34);
            label1.TabIndex = 12;
            label1.Text = "Modificar Productos";
            // 
            // pnlModificar
            // 
            pnlModificar.BackColor = SystemColors.ScrollBar;
            pnlModificar.Controls.Add(lblSeleccionarProd);
            pnlModificar.Controls.Add(lblPrecio0);
            pnlModificar.Controls.Add(btnModificarProducto);
            pnlModificar.Controls.Add(lblIncompleto);
            pnlModificar.Controls.Add(cmbCategoria);
            pnlModificar.Controls.Add(cmbProveedor);
            pnlModificar.Controls.Add(txbPrecio);
            pnlModificar.Controls.Add(txbNombre);
            pnlModificar.Controls.Add(label5);
            pnlModificar.Controls.Add(label4);
            pnlModificar.Controls.Add(label3);
            pnlModificar.Controls.Add(label6);
            pnlModificar.Location = new Point(12, 115);
            pnlModificar.Name = "pnlModificar";
            pnlModificar.Size = new Size(558, 226);
            pnlModificar.TabIndex = 16;
            pnlModificar.Visible = false;
            // 
            // lblPrecio0
            // 
            lblPrecio0.AutoSize = true;
            lblPrecio0.ForeColor = Color.FromArgb(192, 0, 0);
            lblPrecio0.Location = new Point(352, 74);
            lblPrecio0.Name = "lblPrecio0";
            lblPrecio0.Size = new Size(169, 20);
            lblPrecio0.TabIndex = 36;
            lblPrecio0.Text = "El precio no puede ser 0";
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
            // cmbCategoria
            // 
            cmbCategoria.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(357, 128);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(151, 28);
            cmbCategoria.TabIndex = 34;
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;
            // 
            // cmbProveedor
            // 
            cmbProveedor.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbProveedor.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(75, 126);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(187, 28);
            cmbProveedor.TabIndex = 33;
            cmbProveedor.SelectedIndexChanged += cmbProveedor_SelectedIndexChanged;
            // 
            // txbPrecio
            // 
            txbPrecio.Location = new Point(360, 44);
            txbPrecio.MaxLength = 10;
            txbPrecio.Name = "txbPrecio";
            txbPrecio.Size = new Size(127, 27);
            txbPrecio.TabIndex = 32;
            txbPrecio.TextChanged += txbPrecio_TextChanged;
            txbPrecio.KeyDown += txbPrecio_KeyDown;
            txbPrecio.KeyPress += txbPrecio_KeyPress;
            // 
            // txbNombre
            // 
            txbNombre.Location = new Point(75, 42);
            txbNombre.MaxLength = 50;
            txbNombre.Name = "txbNombre";
            txbNombre.Size = new Size(187, 27);
            txbNombre.TabIndex = 31;
            txbNombre.TextChanged += txbNombre_TextChanged;
            txbNombre.KeyPress += txbNombre_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(352, 105);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 30;
            label5.Text = "Categoria";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(75, 103);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 29;
            label4.Text = "Proveedor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(354, 21);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 28;
            label3.Text = "Precio";
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
            // cmbProductos
            // 
            cmbProductos.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbProductos.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbProductos.FormattingEnabled = true;
            cmbProductos.Location = new Point(166, 76);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(260, 28);
            cmbProductos.TabIndex = 26;
            cmbProductos.SelectedIndexChanged += cmbProductos_SelectedIndexChanged;
            // 
            // lblSeleccionarProd
            // 
            lblSeleccionarProd.AutoSize = true;
            lblSeleccionarProd.ForeColor = Color.FromArgb(192, 0, 0);
            lblSeleccionarProd.Location = new Point(352, 195);
            lblSeleccionarProd.Name = "lblSeleccionarProd";
            lblSeleccionarProd.Size = new Size(165, 20);
            lblSeleccionarProd.TabIndex = 37;
            lblSeleccionarProd.Text = "Seleccione un producto";
            // 
            // frmProductos_Modificar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 353);
            Controls.Add(pnlModificar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbProductos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmProductos_Modificar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modificar Productos";
            Load += frmProductos_Modificar_Load;
            pnlModificar.ResumeLayout(false);
            pnlModificar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnModificarProducto;
        private Label label2;
        private Label label1;
        private Panel pnlModificar;
        internal Label lblPrecio0;
        internal Label lblIncompleto;
        internal ComboBox cmbCategoria;
        internal ComboBox cmbProveedor;
        internal TextBox txbPrecio;
        internal TextBox txbNombre;
        internal Label label5;
        internal Label label4;
        internal Label label3;
        internal Label label6;
        private ComboBox cmbProductos;
        internal Label lblSeleccionarProd;
    }
}