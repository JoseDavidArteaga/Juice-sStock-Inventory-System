namespace JuiceStockProject.Presentacion.Productos
{
    partial class frmProductos_Eliminar
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
            cmbProductos = new ComboBox();
            label2 = new Label();
            btnEliminarProducto = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiCondensed", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(176, 56);
            label1.Name = "label1";
            label1.Size = new Size(221, 34);
            label1.TabIndex = 2;
            label1.Text = "Eliminar Productos";
            // 
            // cmbProductos
            // 
            cmbProductos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductos.FormattingEnabled = true;
            cmbProductos.Location = new Point(157, 161);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(260, 28);
            cmbProductos.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(172, 136);
            label2.Name = "label2";
            label2.Size = new Size(230, 20);
            label2.TabIndex = 10;
            label2.Text = "Seleccione el Producto a Eliminar";
            // 
            // btnEliminarProducto
            // 
            btnEliminarProducto.BackColor = Color.FromArgb(255, 183, 3);
            btnEliminarProducto.Cursor = Cursors.Hand;
            btnEliminarProducto.FlatAppearance.BorderSize = 0;
            btnEliminarProducto.FlatStyle = FlatStyle.Flat;
            btnEliminarProducto.Font = new Font("Bahnschrift SemiCondensed", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminarProducto.Location = new Point(241, 241);
            btnEliminarProducto.Name = "btnEliminarProducto";
            btnEliminarProducto.Size = new Size(113, 38);
            btnEliminarProducto.TabIndex = 11;
            btnEliminarProducto.Text = "Eliminar";
            btnEliminarProducto.UseVisualStyleBackColor = false;
            btnEliminarProducto.Click += btnEliminarProducto_Click;
            // 
            // frmProductos_Eliminar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 353);
            Controls.Add(btnEliminarProducto);
            Controls.Add(label2);
            Controls.Add(cmbProductos);
            Controls.Add(label1);
            Name = "frmProductos_Eliminar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Eliminar Productos";
            Load += frmProductos_Eliminar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbProductos;
        private Label label2;
        private Button btnEliminarProducto;
    }
}