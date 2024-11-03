using JuiceStockProject.Presentacion;

namespace JuiceStockProject
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        private void AbrirFormHija(object formHija)
        {
            if (this.pnContenedor.Controls.Count > 0)
                this.pnContenedor.Controls.RemoveAt(0);
            Form fh = formHija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pnContenedor.Controls.Add(fh);
            this.pnContenedor.Tag = fh;
            fh.Show();
        }

        private void restablecerColor()
        {
            btnInventario.BackColor = Color.FromArgb(142, 184, 194);
            btnProductos.BackColor = Color.FromArgb(142, 184, 194);
            btnProveedores.BackColor = Color.FromArgb(142, 184, 194);
            btnReportes.BackColor = Color.FromArgb(142, 184, 194);
        }
        private void btnInventario_Click(object sender, EventArgs e)
        {

            restablecerColor();
            btnInventario.BackColor = Color.FromArgb(255, 158, 49);
            AbrirFormHija(new frmInventario());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            restablecerColor();
            AbrirFormHija(new frmInicio());

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            AbrirFormHija(new frmInicio());
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            restablecerColor();
            btnProductos.BackColor = Color.FromArgb(255, 158, 49);
            AbrirFormHija(new frmProductos());
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            restablecerColor();
            btnProveedores.BackColor = Color.FromArgb(255, 158, 49);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            restablecerColor();
            btnReportes.BackColor = Color.FromArgb(255, 158, 49);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Cierra el formulario principal, indicando que debe reiniciarse el flujo de login
            this.DialogResult = DialogResult.Abort; // O cualquier otro resultado específico que prefieras
            this.Close();
        }

    }
}
