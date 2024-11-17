using JuiceStockProject.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuiceStockProject.Presentacion
{
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();
        }
        string cadena = "SELECT * FROM VISTA_MOVIMIENTOS_GENERAL";
        public void listado_pro()
        {
            // Llamar al método que carga los datos en el DataGridView
            D_Productos Datos = new D_Productos();
            dgvMovimientos.DataSource = Datos.listado_pro(cadena);
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            this.listado_pro();
        }

        private void btnFiltrarReportes_Click(object sender, EventArgs e)
        {
            try
            {
                // Formatear las fechas correctamente para Oracle
                string fecha_ini = dateInicio.Value.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                string fecha_fin = dateFin.Value.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                // Construir la consulta SQL
                string consultaReportes = $@"
            SELECT * 
            FROM VISTA_MOVIMIENTOS_GENERAL 
            WHERE TRUNC(fecha) BETWEEN 
                TRUNC(TO_DATE('{fecha_ini}', 'DD/MM/YYYY')) AND 
                TRUNC(TO_DATE('{fecha_fin}', 'DD/MM/YYYY'))";

                // Llamar al método que carga los datos en el DataGridView
                D_Productos Datos = new D_Productos();
                dgvMovimientos.DataSource = Datos.listado_pro(consultaReportes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar reportes: " + ex.Message);
            }
        }
    }
}
