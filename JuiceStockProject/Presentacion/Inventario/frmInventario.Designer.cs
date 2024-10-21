namespace JuiceStockProject.Presentacion
{
    partial class frmInventario
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
            panel1 = new Panel();
            label2 = new Label();
            cmbCategoria = new ComboBox();
            txtBuscar = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            btnEliminarInventario = new Button();
            btnAgregarInventario = new Button();
            panel3 = new Panel();
            dgvListadoInventario = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListadoInventario).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(78, 141, 164);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cmbCategoria);
            panel1.Controls.Add(txtBuscar);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1052, 70);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(581, 21);
            label2.Name = "label2";
            label2.Size = new Size(114, 28);
            label2.TabIndex = 3;
            label2.Text = "CATEGORIA";
            // 
            // cmbCategoria
            // 
            cmbCategoria.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCategoria.BackColor = Color.FromArgb(142, 184, 194);
            cmbCategoria.Font = new Font("Bahnschrift SemiCondensed", 13.8F);
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Items.AddRange(new object[] { "TODAS" });
            cmbCategoria.Location = new Point(701, 18);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(270, 36);
            cmbCategoria.TabIndex = 2;
            cmbCategoria.TextChanged += cmbCategoria_TextChanged;
            // 
            // txtBuscar
            // 
            txtBuscar.BackColor = Color.FromArgb(142, 184, 194);
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(252, 20);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(270, 28);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(58, 21);
            label1.Name = "label1";
            label1.Size = new Size(188, 28);
            label1.TabIndex = 0;
            label1.Text = "BUSCAR PRODUCTO";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(78, 141, 164);
            panel2.Controls.Add(btnEliminarInventario);
            panel2.Controls.Add(btnAgregarInventario);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 533);
            panel2.Name = "panel2";
            panel2.Size = new Size(1052, 70);
            panel2.TabIndex = 1;
            // 
            // btnEliminarInventario
            // 
            btnEliminarInventario.BackColor = Color.FromArgb(255, 158, 49);
            btnEliminarInventario.Cursor = Cursors.Hand;
            btnEliminarInventario.FlatAppearance.BorderSize = 0;
            btnEliminarInventario.FlatStyle = FlatStyle.Flat;
            btnEliminarInventario.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminarInventario.ForeColor = Color.Transparent;
            btnEliminarInventario.Location = new Point(268, 10);
            btnEliminarInventario.Name = "btnEliminarInventario";
            btnEliminarInventario.Size = new Size(144, 47);
            btnEliminarInventario.TabIndex = 1;
            btnEliminarInventario.Text = "Eliminar";
            btnEliminarInventario.UseVisualStyleBackColor = false;
            btnEliminarInventario.Click += btnEliminarInventario_Click;
            // 
            // btnAgregarInventario
            // 
            btnAgregarInventario.BackColor = Color.FromArgb(255, 158, 49);
            btnAgregarInventario.Cursor = Cursors.Hand;
            btnAgregarInventario.FlatAppearance.BorderSize = 0;
            btnAgregarInventario.FlatStyle = FlatStyle.Flat;
            btnAgregarInventario.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarInventario.ForeColor = Color.Transparent;
            btnAgregarInventario.Location = new Point(94, 10);
            btnAgregarInventario.Name = "btnAgregarInventario";
            btnAgregarInventario.Size = new Size(144, 47);
            btnAgregarInventario.TabIndex = 0;
            btnAgregarInventario.Text = "Agregar";
            btnAgregarInventario.UseVisualStyleBackColor = false;
            btnAgregarInventario.Click += btnAgregarInventario_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvListadoInventario);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 70);
            panel3.Name = "panel3";
            panel3.Size = new Size(1052, 463);
            panel3.TabIndex = 2;
            // 
            // dgvListadoInventario
            // 
            dgvListadoInventario.AllowUserToAddRows = false;
            dgvListadoInventario.AllowUserToDeleteRows = false;
            dgvListadoInventario.AllowUserToResizeColumns = false;
            dgvListadoInventario.AllowUserToResizeRows = false;
            dgvListadoInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListadoInventario.BackgroundColor = Color.FromArgb(222, 220, 220);
            dgvListadoInventario.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(142, 184, 194);
            dataGridViewCellStyle1.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = Color.Transparent;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvListadoInventario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvListadoInventario.ColumnHeadersHeight = 30;
            dgvListadoInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(222, 220, 220);
            dataGridViewCellStyle2.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvListadoInventario.DefaultCellStyle = dataGridViewCellStyle2;
            dgvListadoInventario.Dock = DockStyle.Fill;
            dgvListadoInventario.EnableHeadersVisualStyles = false;
            dgvListadoInventario.GridColor = SystemColors.ControlDark;
            dgvListadoInventario.Location = new Point(0, 0);
            dgvListadoInventario.Name = "dgvListadoInventario";
            dgvListadoInventario.ReadOnly = true;
            dgvListadoInventario.RowHeadersVisible = false;
            dgvListadoInventario.RowHeadersWidth = 51;
            dgvListadoInventario.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvListadoInventario.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvListadoInventario.Size = new Size(1052, 463);
            dgvListadoInventario.TabIndex = 0;
            // 
            // frmInventario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1052, 603);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmInventario";
            Text = "frmInventario";
            Load += frmInventario_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvListadoInventario).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ComboBox cmbCategoria;
        private TextBox txtBuscar;
        private Label label1;
        private Label label2;
        private Panel panel2;
        private Panel panel3;
        private Button btnEliminarInventario;
        private Button btnAgregarInventario;
        private DataGridView dgvListadoInventario;
    }
}