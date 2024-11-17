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
            // Traer datos de los campos ingresables
            string fecha_ini = dateInicio.Value.ToString("dd/MM/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
            string fecha_fin = dateFin.Value.ToString("dd/MM/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);

            string consultaReportes = "SELECT * FROM VISTA_MOVIMIENTOS_GENERAL WHERE trunc(fecha) BETWEEN TRUNC(TO_DATE('" + fecha_ini + "', 'dd/mm/yyyy hh:mi:ss AM')) AND TRUNC(TO_DATE('" + fecha_fin + "', 'dd/mm/yyyy hh:mi:ss AM'));";

            // Llamar al método que carga los datos en el DataGridView
            D_Productos Datos = new D_Productos();
            dgvMovimientos.DataSource = Datos.listado_pro(consultaReportes);
        }
    }
}
