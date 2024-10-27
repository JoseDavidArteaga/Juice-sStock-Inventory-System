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
            label1 = new Label();
            lblTime = new Label();
            timerTime = new System.Windows.Forms.Timer(components);
            lblDate = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiCondensed", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(377, 120);
            label1.Name = "label1";
            label1.Size = new Size(264, 72);
            label1.TabIndex = 0;
            label1.Text = "BIENVENIDO USUARIO\r\n\r\n";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(499, 259);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(36, 20);
            lblTime.TabIndex = 1;
            lblTime.Text = "6:43";
            // 
            // timerTime
            // 
            timerTime.Interval = 1000;
            timerTime.Tick += timerTime_Tick;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(499, 297);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(43, 20);
            lblDate.TabIndex = 2;
            lblDate.Text = "lunes";
            // 
            // frmInicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1052, 603);
            Controls.Add(lblDate);
            Controls.Add(lblTime);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmInicio";
            Text = "frmInicio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblTime;
        private System.Windows.Forms.Timer timerTime;
        private Label lblDate;
    }
}