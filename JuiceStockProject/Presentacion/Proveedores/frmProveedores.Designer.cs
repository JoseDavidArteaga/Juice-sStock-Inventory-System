namespace JuiceStockProject.Presentacion
{
    partial class frmProveedores
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel2 = new Panel();
            btnModificarProveedores = new Button();
            btnEliminarProveedores = new Button();
            btnAgregarProveedores = new Button();
            panel1 = new Panel();
            panel3 = new Panel();
            label1 = new Label();
            dgvListadoProveedores = new DataGridView();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListadoProveedores).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(78, 141, 164);
            panel2.Controls.Add(btnModificarProveedores);
            panel2.Controls.Add(btnEliminarProveedores);
            panel2.Controls.Add(btnAgregarProveedores);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 533);
            panel2.Name = "panel2";
            panel2.Size = new Size(1052, 70);
            panel2.TabIndex = 5;
            // 
            // btnModificarProveedores
            // 
            btnModificarProveedores.BackColor = Color.FromArgb(255, 158, 49);
            btnModificarProveedores.Cursor = Cursors.Hand;
            btnModificarProveedores.FlatAppearance.BorderSize = 0;
            btnModificarProveedores.FlatStyle = FlatStyle.Flat;
            btnModificarProveedores.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnModificarProveedores.ForeColor = Color.Transparent;
            btnModificarProveedores.Location = new Point(439, 10);
            btnModificarProveedores.Name = "btnModificarProveedores";
            btnModificarProveedores.Size = new Size(144, 47);
            btnModificarProveedores.TabIndex = 2;
            btnModificarProveedores.Text = "Modificar";
            btnModificarProveedores.UseVisualStyleBackColor = false;
            btnModificarProveedores.Click += btnModificarProveedores_Click;
            // 
            // btnEliminarProveedores
            // 
            btnEliminarProveedores.BackColor = Color.FromArgb(255, 158, 49);
            btnEliminarProveedores.Cursor = Cursors.Hand;
            btnEliminarProveedores.FlatAppearance.BorderSize = 0;
            btnEliminarProveedores.FlatStyle = FlatStyle.Flat;
            btnEliminarProveedores.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminarProveedores.ForeColor = Color.Transparent;
            btnEliminarProveedores.Location = new Point(268, 10);
            btnEliminarProveedores.Name = "btnEliminarProveedores";
            btnEliminarProveedores.Size = new Size(144, 47);
            btnEliminarProveedores.TabIndex = 1;
            btnEliminarProveedores.Text = "Eliminar";
            btnEliminarProveedores.UseVisualStyleBackColor = false;
            btnEliminarProveedores.Click += btnEliminarProveedores_Click;
            // 
            // btnAgregarProveedores
            // 
            btnAgregarProveedores.BackColor = Color.FromArgb(255, 158, 49);
            btnAgregarProveedores.Cursor = Cursors.Hand;
            btnAgregarProveedores.FlatAppearance.BorderSize = 0;
            btnAgregarProveedores.FlatStyle = FlatStyle.Flat;
            btnAgregarProveedores.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarProveedores.ForeColor = Color.Transparent;
            btnAgregarProveedores.Location = new Point(94, 10);
            btnAgregarProveedores.Name = "btnAgregarProveedores";
            btnAgregarProveedores.Size = new Size(144, 47);
            btnAgregarProveedores.TabIndex = 0;
            btnAgregarProveedores.Text = "Agregar";
            btnAgregarProveedores.UseVisualStyleBackColor = false;
            btnAgregarProveedores.Click += btnAgregarProveedores_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(78, 141, 164);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1052, 89);
            panel1.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(142, 184, 194);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(12, 11);
            panel3.Name = "panel3";
            panel3.Size = new Size(1028, 67);
            panel3.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiCondensed", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(15, 13);
            label1.Name = "label1";
            label1.Size = new Size(187, 36);
            label1.TabIndex = 0;
            label1.Text = "PROVEEDORES";
            // 
            // dgvListadoProveedores
            // 
            dgvListadoProveedores.AllowUserToAddRows = false;
            dgvListadoProveedores.AllowUserToDeleteRows = false;
            dgvListadoProveedores.AllowUserToResizeColumns = false;
            dgvListadoProveedores.AllowUserToResizeRows = false;
            dgvListadoProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListadoProveedores.BackgroundColor = Color.FromArgb(222, 220, 220);
            dgvListadoProveedores.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(142, 184, 194);
            dataGridViewCellStyle1.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = Color.Transparent;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvListadoProveedores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvListadoProveedores.ColumnHeadersHeight = 30;
            dgvListadoProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(222, 220, 220);
            dataGridViewCellStyle2.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvListadoProveedores.DefaultCellStyle = dataGridViewCellStyle2;
            dgvListadoProveedores.Dock = DockStyle.Fill;
            dgvListadoProveedores.EnableHeadersVisualStyles = false;
            dgvListadoProveedores.GridColor = SystemColors.ControlDark;
            dgvListadoProveedores.Location = new Point(0, 89);
            dgvListadoProveedores.Name = "dgvListadoProveedores";
            dgvListadoProveedores.ReadOnly = true;
            dgvListadoProveedores.RowHeadersVisible = false;
            dgvListadoProveedores.RowHeadersWidth = 51;
            dgvListadoProveedores.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvListadoProveedores.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvListadoProveedores.Size = new Size(1052, 444);
            dgvListadoProveedores.TabIndex = 7;
            // 
            // frmProveedores
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1052, 603);
            Controls.Add(dgvListadoProveedores);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProveedores";
            Text = "frmProveedores";
            Load += frmProveedores_Load;
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListadoProveedores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Button btnModificarProveedores;
        private Button btnEliminarProveedores;
        private Button btnAgregarProveedores;
        private Panel panel1;
        private DataGridView dgvListadoProveedores;
        private Panel panel3;
        private Label label1;
    }
}