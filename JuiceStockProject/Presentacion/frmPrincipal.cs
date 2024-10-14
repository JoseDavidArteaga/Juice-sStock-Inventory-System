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

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new frmInventario());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new frmInicio());

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            AbrirFormHija(new frmInicio());
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new frmProductos());
        }
    }
}
