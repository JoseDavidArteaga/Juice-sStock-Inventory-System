namespace JuiceStockProject.Presentacion.Inventario
{
    partial class frmInventario_Eliminar
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
            numCantidad = new NumericUpDown();
            label3 = new Label();
            btnAgregarProducto = new Button();
            cmbProductos = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiCondensed", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(110, 44);
            label1.Name = "label1";
            label1.Size = new Size(368, 34);
            label1.TabIndex = 3;
            label1.Text = "Eliminar Unidades del Inventario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(120, 197);
            label2.Name = "label2";
            label2.Size = new Size(350, 20);
            label2.TabIndex = 11;
            label2.Text = "Ingrese la cantidad de unidades que desea eliminar";
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(243, 220);
            numCantidad.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(99, 27);
            numCantidad.TabIndex = 12;
            numCantidad.KeyDown += numCantidad_KeyDown;
            numCantidad.KeyPress += numCantidad_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(211, 97);
            label3.Name = "label3";
            label3.Size = new Size(161, 20);
            label3.TabIndex = 13;
            label3.Text = "Seleccione el producto";
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.BackColor = Color.FromArgb(255, 183, 3);
            btnAgregarProducto.Cursor = Cursors.Hand;
            btnAgregarProducto.FlatAppearance.BorderSize = 0;
            btnAgregarProducto.FlatStyle = FlatStyle.Flat;
            btnAgregarProducto.Font = new Font("Bahnschrift SemiCondensed", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarProducto.Location = new Point(237, 270);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(113, 38);
            btnAgregarProducto.TabIndex = 14;
            btnAgregarProducto.Text = "Eliminar";
            btnAgregarProducto.UseVisualStyleBackColor = false;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // cmbProductos
            // 
            cmbProductos.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbProductos.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbProductos.FormattingEnabled = true;
            cmbProductos.Location = new Point(163, 130);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(260, 28);
            cmbProductos.TabIndex = 15;
            // 
            // frmInventario_Eliminar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 353);
            Controls.Add(cmbProductos);
            Controls.Add(btnAgregarProducto);
            Controls.Add(label3);
            Controls.Add(numCantidad);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmInventario_Eliminar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Eliminar Unidades";
            Load += frmInventario_Eliminar_Load;
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private NumericUpDown numCantidad;
        private Label label3;
        private Button btnAgregarProducto;
        private ComboBox cmbProductos;
    }
}