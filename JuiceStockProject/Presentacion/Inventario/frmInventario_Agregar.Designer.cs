namespace JuiceStockProject.Presentacion
{
    partial class frmInventario_Agregar
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
            panel1 = new Panel();
            btnAgregar = new Button();
            label3 = new Label();
            cmbProducto = new ComboBox();
            numCantidad = new NumericUpDown();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAgregar);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cmbProducto);
            panel1.Controls.Add(numCantidad);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(582, 353);
            panel1.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(255, 183, 3);
            btnAgregar.Cursor = Cursors.Hand;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Bahnschrift SemiCondensed", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregar.Location = new Point(236, 269);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(113, 38);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9F);
            label3.Location = new Point(209, 108);
            label3.Name = "label3";
            label3.Size = new Size(165, 18);
            label3.TabIndex = 4;
            label3.Text = "Seleccione el Producto:";
            // 
            // cmbProducto
            // 
            cmbProducto.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbProducto.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(123, 129);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(341, 28);
            cmbProducto.TabIndex = 3;
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(383, 193);
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(69, 27);
            numCantidad.TabIndex = 2;
            numCantidad.KeyDown += numCantidad_KeyDown;
            numCantidad.KeyPress += numCantidad_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F);
            label2.Location = new Point(136, 196);
            label2.Name = "label2";
            label2.Size = new Size(220, 18);
            label2.TabIndex = 1;
            label2.Text = "Cantidad de unidades a Agregar:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiCondensed", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(111, 43);
            label1.Name = "label1";
            label1.Size = new Size(351, 34);
            label1.TabIndex = 0;
            label1.Text = "Agregar Unidades al Inventario";
            // 
            // frmInventario_Agregar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 353);
            Controls.Add(panel1);
            Name = "frmInventario_Agregar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Unidades";
            Load += frmInventario_Agregar_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnAgregar;
        private Label label3;
        private ComboBox cmbProducto;
        private NumericUpDown numCantidad;
        private Label label2;
        private Label label1;
    }
}