namespace JuiceStockProject.Presentacion
{
    partial class frmReportes
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
            dgvMovimientos = new DataGridView();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            dateFin = new DateTimePicker();
            dateInicio = new DateTimePicker();
            panel3 = new Panel();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(78, 141, 164);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 533);
            panel2.Name = "panel2";
            panel2.Size = new Size(1052, 70);
            panel2.TabIndex = 7;
            // 
            // dgvMovimientos
            // 
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToDeleteRows = false;
            dgvMovimientos.AllowUserToResizeColumns = false;
            dgvMovimientos.AllowUserToResizeRows = false;
            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovimientos.BackgroundColor = Color.FromArgb(222, 220, 220);
            dgvMovimientos.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(142, 184, 194);
            dataGridViewCellStyle1.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = Color.Transparent;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMovimientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMovimientos.ColumnHeadersHeight = 30;
            dgvMovimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(222, 220, 220);
            dataGridViewCellStyle2.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMovimientos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMovimientos.Dock = DockStyle.Fill;
            dgvMovimientos.EnableHeadersVisualStyles = false;
            dgvMovimientos.GridColor = Color.FromArgb(222, 220, 220);
            dgvMovimientos.Location = new Point(0, 133);
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.RowHeadersVisible = false;
            dgvMovimientos.RowHeadersWidth = 51;
            dgvMovimientos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvMovimientos.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvMovimientos.Size = new Size(1052, 470);
            dgvMovimientos.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(78, 141, 164);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(dateFin);
            panel1.Controls.Add(dateInicio);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1052, 133);
            panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(255, 158, 49);
            pictureBox1.Image = Properties.Resources.buscar1;
            pictureBox1.Location = new Point(485, 86);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 35);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // dateFin
            // 
            dateFin.Format = DateTimePickerFormat.Short;
            dateFin.Location = new Point(371, 90);
            dateFin.Name = "dateFin";
            dateFin.Size = new Size(101, 27);
            dateFin.TabIndex = 7;
            // 
            // dateInicio
            // 
            dateInicio.Format = DateTimePickerFormat.Short;
            dateInicio.Location = new Point(156, 90);
            dateInicio.Name = "dateInicio";
            dateInicio.Size = new Size(101, 27);
            dateInicio.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(142, 184, 194);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(12, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(1028, 67);
            panel3.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiCondensed", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(15, 13);
            label1.Name = "label1";
            label1.Size = new Size(306, 36);
            label1.TabIndex = 0;
            label1.Text = "REPORTE DE PRODUCTOS";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bahnschrift SemiCondensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(285, 90);
            label3.Name = "label3";
            label3.Size = new Size(84, 24);
            label3.TabIndex = 4;
            label3.Text = "Fecha Fin";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift SemiCondensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(30, 90);
            label2.Name = "label2";
            label2.Size = new Size(125, 24);
            label2.TabIndex = 3;
            label2.Text = "Fecha de Inicio";
            // 
            // frmReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1052, 603);
            Controls.Add(panel2);
            Controls.Add(dgvMovimientos);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmReportes";
            Text = "frmReportes";
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private DataGridView dgvMovimientos;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private Label label3;
        private Panel panel3;
        private DateTimePicker dateInicio;
        private DateTimePicker dateFin;
        private PictureBox pictureBox1;
    }
}