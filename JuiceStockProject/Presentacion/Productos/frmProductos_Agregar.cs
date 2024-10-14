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

namespace JuiceStockProject.Presentacion.Productos
{
    public partial class frmProductos_Agregar : Form
    {
        public frmProductos_Agregar()
        {
            InitializeComponent();
        }

        D_Productos Datos = new D_Productos();

        private void CargarComboBoxProveedores()
        {
            DataTable tablaProveedores = Datos.ObtenerNombres("SELECT nombre_prov FROM Proveedor WHERE estado_prov = 'ACTIVO'");

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
            }
        }

        private void CargarComboBoxCategorias()
        {
            DataTable tablaCategorias = Datos.ObtenerNombres("SELECT nombre_categoria FROM categoria");

            // Limpiar el ComboBox antes de cargar los datos
            cmbCategoria.Items.Clear();

            // Verificar si se obtuvieron datos
            if (tablaCategorias.Rows.Count > 0)
            {
                // Recorrer cada fila en la tabla y añadir el nombre al ComboBox
                foreach (DataRow row in tablaCategorias.Rows)
                {
                    cmbProveedor.Items.Add(row["nombre_categoria"].ToString());
                }
            }
            else
            {
                MessageBox.Show("No se encontraron categorias activas.");
            }
        }

        private void frmProductos_Agregar_Load(object sender, EventArgs e)
        {
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
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si se ha seleccionado un producto
                if (cmbCategoria.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, seleccione una categoria.");
                    return; // Salir del método si no hay una categoria seleccionado
                }

                // Obtener el nombre del proveedor seleccionado
                string nombreProveedorSeleccionado = cmbProveedor.SelectedItem.ToString();

                // Obtener el nombre de la categoria seleccionada
                string nombreCategoriaSeleccionado = cmbCategoria.SelectedItem.ToString();

                // Crear la conexión
                using (OracleConnection conexion = Conexion.getInstancia().CrearConexion())
                {
                    //Pendiente desde aquí
                    // Crear el comando para llamar al procedimiento almacenado
                    using (OracleCommand comando = new OracleCommand("agregar_producto_procedimiento", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        // Añadir los parámetros al comando
                        comando.Parameters.Add(new OracleParameter("p_nombre_prod", nombreProductoSeleccionado));
                        comando.Parameters.Add(new OracleParameter("p_cantidad_agregar", cantidadASumar));

                        // Abrir la conexión y ejecutar el comando
                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                }

                // Mensaje de éxito
                MessageBox.Show("La cantidad se ha actualizado correctamente.");

                // Cerrar el formulario de agregar inventario
                this.Close();

                // Actualizar el formulario de inventario
                var frmInventario = (frmInventario)Owner; // Obtener el formulario padre (frmInventario)
                frmInventario.ActualizarTabla(); // Llamar al método para actualizar la tabla
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la cantidad: " + ex.Message);
            }
        }
    }
}
