using JuiceStockProject.Datos;
using JuiceStockProject.Presentacion.Inventario;
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
        string cadena = "SELECT ID_PROD \"Identificador\", NOMBRE_PROD \"Nombre\", NOMBRE_CATEGORIA \"Categoría\", CANTIDAD_PROD \"Cantidad\" FROM VISTA_PRODUCTOS";

        private void Listado_pro()
        {
            D_Productos Datos = new D_Productos();
            dgvListadoInventario.DataSource = Datos.listado_pro(cadena);
        }



        private void btnAgregarInventario_Click(object sender, EventArgs e)
        {

            // Cargar los productos del inventario desde la base de datos
            D_Productos Datos = new D_Productos();
            DataTable tablaProductos = Datos.ObtenerNombres("SELECT nombre_prod  FROM producto WHERE estado_prod = 'ACTIVO'");

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
        //PRUEBA
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

        private void btnEliminarInventario_Click(object sender, EventArgs e)
        {
            // Cargar los productos del inventario desde la base de datos
            D_Productos Datos = new D_Productos();
            DataTable tablaProductos = Datos.ObtenerNombres("SELECT nombre_prod  FROM producto WHERE estado_prod = 'ACTIVO'");

            // Verificar si hay productos activos
            if (tablaProductos.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos activos para agregar en el inventario");
                return; // No abrir el formulario si no hay productos
            }

            // Crear una instancia del formulario de Eliminar inventario
            frmInventario_Eliminar eliminarInventario = new frmInventario_Eliminar();

            // Establecer frmInventario como el formulario propietario
            eliminarInventario.Owner = this;

            // Mostrar frmAgregarInventario como un cuadro de diálogo modal
            eliminarInventario.ShowDialog();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Capturar el texto ingresado en el TextBox
            string textoBusqueda = txtBuscar.Text;

            // Crear una consulta que cargue todos los productos si no hay texto en el TextBox
            string consultaFiltrada;

            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                // Si el TextBox está vacío, mostrar todos los productos
                consultaFiltrada = "SELECT ID_PROD \"Identificador\", NOMBRE_PROD \"Nombre\", NOMBRE_CATEGORIA \"Categoría\", CANTIDAD_PROD \"Cantidad\" " +
                                   "FROM VISTA_PRODUCTOS";
            }
            else
            {
                // Si hay texto, buscar los productos que contengan la cadena ingresada
                consultaFiltrada = "SELECT ID_PROD \"Identificador\", NOMBRE_PROD \"Nombre\", NOMBRE_CATEGORIA \"Categoría\", CANTIDAD_PROD \"Cantidad\" " +
                                   "FROM VISTA_PRODUCTOS " +
                                   "WHERE upper(NOMBRE_PROD) LIKE '%" + textoBusqueda.ToUpper() + "%' " +
                                   "ORDER BY CASE " +
                                   "WHEN upper(NOMBRE_PROD) LIKE '" + textoBusqueda.ToUpper() + "%' THEN 1 " +  // Prefiere los que empiezan con el texto
                                   "WHEN upper(NOMBRE_PROD) LIKE '%" + textoBusqueda.ToUpper() + "%' THEN 2 " +  // Luego los que contienen el texto
                                   "ELSE 3 END, NOMBRE_PROD ASC"; // Si no es una coincidencia, ponerlo al final

            }

            // Llamar al método que actualiza el DataGridView con los productos filtrados
            D_Productos Datos = new D_Productos();
            dgvListadoInventario.DataSource = Datos.listado_pro(consultaFiltrada);
        }



    }
}
