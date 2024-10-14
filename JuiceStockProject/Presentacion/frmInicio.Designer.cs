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
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiCondensed", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(391, 266);
            label1.Name = "label1";
            label1.Size = new Size(274, 36);
            label1.TabIndex = 0;
            label1.Text = "BIENVENIDO (PRUEBA)";
            // 
            // frmInicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1052, 603);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmInicio";
            Text = "frmInicio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    }
}