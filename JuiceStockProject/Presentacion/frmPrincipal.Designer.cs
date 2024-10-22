namespace JuiceStockProject
{
    partial class frmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnOpciones = new Panel();
            panel4 = new Panel();
            btnReportes = new Button();
            panel3 = new Panel();
            btnProveedores = new Button();
            panel2 = new Panel();
            btnProductos = new Button();
            panel1 = new Panel();
            btnInventario = new Button();
            pictureBox1 = new PictureBox();
            pnContenedor = new Panel();
            pnOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnOpciones
            // 
            pnOpciones.BackColor = Color.FromArgb(142, 184, 194);
            pnOpciones.Controls.Add(panel4);
            pnOpciones.Controls.Add(btnReportes);
            pnOpciones.Controls.Add(panel3);
            pnOpciones.Controls.Add(btnProveedores);
            pnOpciones.Controls.Add(panel2);
            pnOpciones.Controls.Add(btnProductos);
            pnOpciones.Controls.Add(panel1);
            pnOpciones.Controls.Add(btnInventario);
            pnOpciones.Controls.Add(pictureBox1);
            pnOpciones.Dock = DockStyle.Left;
            pnOpciones.Location = new Point(0, 0);
            pnOpciones.Name = "pnOpciones";
            pnOpciones.Size = new Size(230, 603);
            pnOpciones.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(255, 158, 49);
            panel4.Location = new Point(0, 409);
            panel4.Name = "panel4";
            panel4.Size = new Size(7, 70);
            panel4.TabIndex = 10;
            // 
            // btnReportes
            // 
            btnReportes.Cursor = Cursors.Hand;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 158, 49);
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReportes.ForeColor = Color.White;
            btnReportes.Location = new Point(3, 409);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(227, 70);
            btnReportes.TabIndex = 9;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnReportes_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(255, 158, 49);
            panel3.Location = new Point(0, 333);
            panel3.Name = "panel3";
            panel3.Size = new Size(7, 70);
            panel3.TabIndex = 8;
            // 
            // btnProveedores
            // 
            btnProveedores.Cursor = Cursors.Hand;
            btnProveedores.FlatAppearance.BorderSize = 0;
            btnProveedores.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 158, 49);
            btnProveedores.FlatStyle = FlatStyle.Flat;
            btnProveedores.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProveedores.ForeColor = Color.White;
            btnProveedores.Location = new Point(3, 333);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Size = new Size(227, 70);
            btnProveedores.TabIndex = 7;
            btnProveedores.Text = "Proveedores";
            btnProveedores.UseVisualStyleBackColor = true;
            btnProveedores.Click += btnProveedores_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 158, 49);
            panel2.Location = new Point(0, 257);
            panel2.Name = "panel2";
            panel2.Size = new Size(7, 70);
            panel2.TabIndex = 6;
            // 
            // btnProductos
            // 
            btnProductos.Cursor = Cursors.Hand;
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 158, 49);
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProductos.ForeColor = Color.White;
            btnProductos.Location = new Point(3, 257);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(227, 70);
            btnProductos.TabIndex = 5;
            btnProductos.Text = "Productos";
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 158, 49);
            panel1.Location = new Point(0, 177);
            panel1.Name = "panel1";
            panel1.Size = new Size(7, 70);
            panel1.TabIndex = 2;
            // 
            // btnInventario
            // 
            btnInventario.Cursor = Cursors.Hand;
            btnInventario.FlatAppearance.BorderSize = 0;
            btnInventario.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 158, 49);
            btnInventario.FlatStyle = FlatStyle.Flat;
            btnInventario.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInventario.ForeColor = Color.White;
            btnInventario.Location = new Point(3, 177);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(227, 70);
            btnInventario.TabIndex = 1;
            btnInventario.Text = "Inventario";
            btnInventario.UseVisualStyleBackColor = true;
            btnInventario.Click += btnInventario_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = Properties.Resources.JuiceStockIcon;
            pictureBox1.Location = new Point(0, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(230, 98);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pnContenedor
            // 
            pnContenedor.Dock = DockStyle.Fill;
            pnContenedor.Location = new Point(230, 0);
            pnContenedor.Name = "pnContenedor";
            pnContenedor.Size = new Size(1052, 603);
            pnContenedor.TabIndex = 1;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 603);
            Controls.Add(pnContenedor);
            Controls.Add(pnOpciones);
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JuiceStock";
            Load += frmPrincipal_Load;
            pnOpciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnOpciones;
        private PictureBox pictureBox1;
        private Button btnInventario;
        private Panel pnContenedor;
        private Panel panel1;
        private Panel panel4;
        private Button btnReportes;
        private Panel panel3;
        private Button btnProveedores;
        private Panel panel2;
        private Button btnProductos;
    }
}
