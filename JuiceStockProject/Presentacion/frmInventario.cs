using JuiceStockProject.Datos;
using Oracle.ManagedDataAccess.Client;
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
    public partial class frmInventario : Form
    {
        public frmInventario()
        {
            InitializeComponent();
        }
        string cadena = "SELECT ID_PROD \"      Identificador\", NOMBRE_PROD \"       Nombre\", NOMBRE_CATEGORIA \"     Categoría\", CANTIDAD_PROD \"      Cantidad\" FROM VISTA_PRODUCTOS";

        private void Listado_pro()
        {
            D_Productos Datos = new D_Productos();
            dgvListadoInventario.DataSource = Datos.listado_pro(cadena);
        }

        private void btnAgregarInventario_Click(object sender, EventArgs e)
        {

            // Cargar los productos del inventario desde la base de datos
            D_Productos Datos = new D_Productos();
            DataTable tablaProductos = Datos.ObtenerNombresProductos();

            // Verificar si hay productos activos
            if (tablaProductos.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos activos para agregar en el inventario");
                return; // No abrir el formulario si no hay productos
            }

            // Si hay productos, abrir el formulario de agregar inventario
            frmInventario_Agregar agregarInventario = new frmInventario_Agregar();

            // Establecer frmInventario como el formulario propietario
            agregarInventario.Owner = this;

            // Mostrar frmAgregarInventario como un cuadro de diálogo modal
            agregarInventario.ShowDialog();
        }

        //-----------Metodo Para Actualizar La DataGridView------------
        public void ActualizarTabla()
        {
            // Carga los datos en el dgv
            D_Productos Datos = new D_Productos();
            dgvListadoInventario.DataSource = Datos.listado_pro(cadena);
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            this.Listado_pro();
        }
    }
}
