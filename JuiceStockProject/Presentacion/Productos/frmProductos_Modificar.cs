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

namespace JuiceStockProject.Presentacion.Productos
{
    public partial class frmProductos_Modificar : Form
    {
        public frmProductos_Modificar()
        {
            InitializeComponent();
        }

        D_Productos Datos = new D_Productos();
        private void CargarComboBoxProveedores()
        {
            string cadena = "SELECT nombre_prov FROM Proveedor WHERE estado_prov = 'ACTIVO'";
            DataTable tablaProveedores = Datos.ObtenerNombres(cadena);

            // Limpiar el ComboBox antes de cargar los datos
            cmbProveedor.Items.Clear();

            // Verificar si se obtuvieron datos
            if (tablaProveedores.Rows.Count > 0)
            {
                // Recorrer cada fila en la tabla y añadir el nombre al ComboBox
                foreach (DataRow row in tablaProveedores.Rows)
                {
                    cmbProveedor.Items.Add(row["nombre_prov"].ToString());
                }
            }
            else
            {
                MessageBox.Show("No se encontraron proveedores activos.");
                return;
            }
        }

        private void CargarComboBoxCategorias()
        {
            string cadena = "SELECT nombre_categoria FROM categoria_producto";
            DataTable tablaCategorias = Datos.ObtenerNombres(cadena);

            // Limpiar el ComboBox antes de cargar los datos
            cmbCategoria.Items.Clear();

            // Verificar si se obtuvieron datos
            if (tablaCategorias.Rows.Count > 0)
            {
                // Recorrer cada fila en la tabla y añadir el nombre al ComboBox
                foreach (DataRow row in tablaCategorias.Rows)
                {
                    cmbCategoria.Items.Add(row["nombre_categoria"].ToString());
                }
            }
            else
            {
                MessageBox.Show("No se encontraron categorias activas.");
            }
        }

        private void CargarComboBoxProductos()
        {
            DataTable tablaProductos = Datos.ObtenerNombres("SELECT nombre_prod  FROM Producto WHERE estado_prod = 'ACTIVO'");

            // Limpiar el ComboBox antes de cargar los datos
            cmbProductos.Items.Clear();

            // Verificar si se obtuvieron datos
            if (tablaProductos.Rows.Count > 0)
            {
                // Recorrer cada fila en la tabla y añadir el nombre al ComboBox
                foreach (DataRow row in tablaProductos.Rows)
                {
                    cmbProductos.Items.Add(row["nombre_prod"].ToString());
                }
            }
            else
            {
                MessageBox.Show("No se encontraron productos activos.");
            }
        }

        private void frmProductos_Modificar_Load(object sender, EventArgs e)
        {
            this.CargarComboBoxProductos();

            // Poner invisibles labels que no se necesitan
            lblPrecio0.Visible = false;

            // Llenar comboBox de proveedores
            this.CargarComboBoxProveedores();

            // Verificar si hay suficientes elementos en el ComboBox antes de establecer SelectedIndex
            if (cmbProveedor.Items.Count > 0)
            {
                // Establecer el índice si hay al menos un producto
                cmbProveedor.SelectedIndex = -1; // Selecciona el primer elemento
            }

            // Llenar comboBox de categorias
            this.CargarComboBoxCategorias();

            // Verificar si hay suficientes elementos en el ComboBox antes de establecer SelectedIndex
            if (cmbCategoria.Items.Count > 0)
            {
                // Establecer el índice si hay al menos un producto
                cmbCategoria.SelectedIndex = -1; // Selecciona el primer elemento
            }
            cmbProductos.SelectedIndex = -1;

        }

        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mostrar el panel solo si hay un ítem seleccionado
            if (cmbProductos.SelectedIndex != -1)
            {
                pnlModificar.Visible = true;
                string productoSeleccionado = cmbProductos.SelectedItem.ToString();
                txbNombre.Text = productoSeleccionado;

            }
            else
            {
                pnlModificar.Visible = false;
            }
        }
    }
}
