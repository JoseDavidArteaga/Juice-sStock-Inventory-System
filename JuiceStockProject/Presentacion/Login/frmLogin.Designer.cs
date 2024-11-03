namespace JuiceStockProject.Presentacion
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            panel1 = new Panel();
            lblDatosIncompletos = new Label();
            label2 = new Label();
            label1 = new Label();
            txtContraseña = new TextBox();
            txtUsuario = new TextBox();
            pictureBox1 = new PictureBox();
            btnLogin = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblDatosIncompletos);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtContraseña);
            panel1.Controls.Add(txtUsuario);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnLogin);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(432, 553);
            panel1.TabIndex = 0;
            // 
            // lblDatosIncompletos
            // 
            lblDatosIncompletos.AutoSize = true;
            lblDatosIncompletos.ForeColor = Color.Red;
            lblDatosIncompletos.Location = new Point(112, 361);
            lblDatosIncompletos.Name = "lblDatosIncompletos";
            lblDatosIncompletos.Size = new Size(163, 20);
            lblDatosIncompletos.TabIndex = 6;
            lblDatosIncompletos.Text = "Ingrese todos los datos";
            lblDatosIncompletos.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(112, 299);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 5;
            label2.Text = "Contraseña";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(112, 208);
            label1.Name = "label1";
            label1.Size = new Size(59, 20);
            label1.TabIndex = 4;
            label1.Text = "Usuario";
            // 
            // txtContraseña
            // 
            txtContraseña.BorderStyle = BorderStyle.FixedSingle;
            txtContraseña.Cursor = Cursors.IBeam;
            txtContraseña.Location = new Point(112, 322);
            txtContraseña.MaxLength = 50;
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(207, 27);
            txtContraseña.TabIndex = 3;
            txtContraseña.KeyPress += txtContraseña_KeyPress;
            // 
            // txtUsuario
            // 
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Cursor = Cursors.IBeam;
            txtUsuario.Location = new Point(112, 231);
            txtUsuario.MaxLength = 50;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(207, 27);
            txtUsuario.TabIndex = 2;
            txtUsuario.KeyPress += txtUsuario_KeyPress;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.JuiceStockIcon;
            pictureBox1.Location = new Point(117, 48);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(202, 99);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(142, 184, 194);
            btnLogin.FlatAppearance.BorderColor = Color.FromArgb(142, 184, 194);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Bahnschrift SemiCondensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(149, 419);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(130, 40);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // frmLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 553);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio de Sesión";
            Load += frmLogin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnLogin;
        private TextBox txtContraseña;
        private TextBox txtUsuario;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private Label lblDatosIncompletos;
    }
}