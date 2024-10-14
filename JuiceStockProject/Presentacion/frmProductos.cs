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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }
        string cadena = "SELECT ID_PROD \"      Identificador\", NOMBRE_PROD \"       Nombre\", NOMBRE_CATEGORIA \"     Categoría\", PRECIO_PROD \"     Precio\" FROM VISTA_PRODUCTOS";

        private void Listado_pro()
        {
            D_Productos Datos = new D_Productos();
            dgvListadoProducto.DataSource = Datos.listado_pro(cadena);
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            this.Listado_pro();
        }
    }
}
