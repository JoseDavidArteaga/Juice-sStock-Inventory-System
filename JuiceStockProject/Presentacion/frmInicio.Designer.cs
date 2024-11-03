namespace JuiceStockProject.Presentacion
{
    partial class frmInicio
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
            components = new System.ComponentModel.Container();
            lblTime = new Label();
            timerTime = new System.Windows.Forms.Timer(components);
            lblDate = new Label();
            lblNombreUsuario = new Label();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Bahnschrift SemiCondensed", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTime.ForeColor = Color.FromArgb(142, 184, 194);
            lblTime.Location = new Point(80, 192);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(223, 72);
            lblTime.TabIndex = 1;
            lblTime.Text = "06:43:00";
            // 
            // timerTime
            // 
            timerTime.Interval = 1000;
            timerTime.Tick += timerTime_Tick;
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDate.AutoSize = true;
            lblDate.BackColor = SystemColors.Control;
            lblDate.Font = new Font("Bahnschrift SemiCondensed", 24F);
            lblDate.ForeColor = Color.FromArgb(142, 184, 194);
            lblDate.Location = new Point(80, 281);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(505, 48);
            lblDate.TabIndex = 2;
            lblDate.Text = "domingo 24 de octubre de 2024";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Bahnschrift SemiCondensed", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreUsuario.Location = new Point(80, 97);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(353, 48);
            lblNombreUsuario.TabIndex = 3;
            lblNombreUsuario.Text = "BIENVENIDO USUARIO";
            lblNombreUsuario.TextAlign = ContentAlignment.TopCenter;
            // 
            // frmInicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1052, 603);
            Controls.Add(lblNombreUsuario);
            Controls.Add(lblDate);
            Controls.Add(lblTime);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmInicio";
            Text = "frmInicio";
            Load += frmInicio_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTime;
        private System.Windows.Forms.Timer timerTime;
        private Label lblDate;
        private Label lblNombreUsuario;
    }
}