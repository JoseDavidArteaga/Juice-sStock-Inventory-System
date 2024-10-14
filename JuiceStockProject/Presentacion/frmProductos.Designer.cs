namespace JuiceStockProject.Presentacion
{
    partial class frmProductos
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
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            dgvListadoProducto = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListadoProducto).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(78, 141, 164);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1034, 70);
            panel1.TabIndex = 2;
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
            // comboBox1
            // 
            comboBox1.BackColor = Color.FromArgb(142, 184, 194);
            comboBox1.Font = new Font("Bahnschrift SemiCondensed", 13.8F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(701, 18);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(270, 36);
            comboBox1.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(142, 184, 194);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(252, 20);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(270, 28);
            textBox1.TabIndex = 1;
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
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 158, 49);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(94, 10);
            button1.Name = "button1";
            button1.Size = new Size(144, 47);
            button1.TabIndex = 0;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 158, 49);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Transparent;
            button2.Location = new Point(268, 10);
            button2.Name = "button2";
            button2.Size = new Size(144, 47);
            button2.TabIndex = 1;
            button2.Text = "Eliminar";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 158, 49);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.Transparent;
            button3.Location = new Point(439, 10);
            button3.Name = "button3";
            button3.Size = new Size(144, 47);
            button3.TabIndex = 2;
            button3.Text = "Modificar";
            button3.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(78, 141, 164);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 486);
            panel2.Name = "panel2";
            panel2.Size = new Size(1034, 70);
            panel2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvListadoProducto);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 70);
            panel3.Name = "panel3";
            panel3.Size = new Size(1034, 416);
            panel3.TabIndex = 5;
            // 
            // dgvListadoProducto
            // 
            dgvListadoProducto.AllowUserToAddRows = false;
            dgvListadoProducto.AllowUserToDeleteRows = false;
            dgvListadoProducto.AllowUserToResizeColumns = false;
            dgvListadoProducto.AllowUserToResizeRows = false;
            dgvListadoProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListadoProducto.BackgroundColor = Color.FromArgb(222, 220, 220);
            dgvListadoProducto.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(142, 184, 194);
            dataGridViewCellStyle1.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = Color.Transparent;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvListadoProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvListadoProducto.ColumnHeadersHeight = 30;
            dgvListadoProducto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(222, 220, 220);
            dataGridViewCellStyle2.Font = new Font("Bahnschrift SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvListadoProducto.DefaultCellStyle = dataGridViewCellStyle2;
            dgvListadoProducto.Dock = DockStyle.Fill;
            dgvListadoProducto.EnableHeadersVisualStyles = false;
            dgvListadoProducto.GridColor = SystemColors.ControlDark;
            dgvListadoProducto.Location = new Point(0, 0);
            dgvListadoProducto.Name = "dgvListadoProducto";
            dgvListadoProducto.ReadOnly = true;
            dgvListadoProducto.RowHeadersVisible = false;
            dgvListadoProducto.RowHeadersWidth = 51;
            dgvListadoProducto.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvListadoProducto.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvListadoProducto.Size = new Size(1034, 416);
            dgvListadoProducto.TabIndex = 1;
            // 
            // frmProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 556);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProductos";
            Text = "frmProductos";
            Load += frmProductos_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvListadoProducto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Panel panel2;
        private Panel panel3;
        private DataGridView dgvListadoProducto;
    }
}