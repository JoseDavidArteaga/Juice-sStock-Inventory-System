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
            string productoSeleccionado = "";

            // Mostrar el panel solo si hay un ítem seleccionado
            if (cmbProductos.SelectedIndex != -1)
            {
                pnlModificar.Visible = true;
                productoSeleccionado = cmbProductos.SelectedItem.ToString();
                txbNombre.Text = productoSeleccionado;

            }
            else
            {
                pnlModificar.Visible = false;
            }

            // Variables para almacenar los parámetros de salida del procedimiento
            int precio = 0;
            string nombreProv = "", nombreCat = "";

            try
            {
                using (OracleConnection conexion = Conexion.getInstancia().CrearConexion())
                {
                    using (OracleCommand comando = new OracleCommand("obtener_detalles_producto", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        // Parámetro de entrada: nombre del producto
                        comando.Parameters.Add("p_nombre_producto", OracleDbType.Varchar2).Value = productoSeleccionado;

                        // Parámetros de salida

                        /* Precio */
                        OracleParameter precioParam = new OracleParameter("p_precio", OracleDbType.Int32)
                        {
                            Direction = ParameterDirection.Output,
                        };
                        comando.Parameters.Add(precioParam);

                        /* Nombre Proveedor */
                        OracleParameter proveedorParam = new OracleParameter("p_nombre_proveedor", OracleDbType.Varchar2);
                        proveedorParam.Direction = ParameterDirection.Output;
                        comando.Parameters.Add(proveedorParam);

                        /* Nombre Categoría */
                        OracleParameter categoriaParam = new OracleParameter("p_nombre_categoria", OracleDbType.Varchar2);
                        categoriaParam.Direction = ParameterDirection.Output;
                        comando.Parameters.Add(categoriaParam);

                        // Abrir conexión y ejecutar el procedimiento
                        conexion.Open();
                        comando.ExecuteNonQuery();

                        // Recuperar el valor del parámetro de salida

                        /* Precio */
                        /*if (precioParam.Value != DBNull.Value)
                        {
                            Oracle.ManagedDataAccess.Types.OracleDecimal oracleDecimal = (Oracle.ManagedDataAccess.Types.OracleDecimal)precioParam.Value;
                            precio = oracleDecimal.ToInt32();
                        }*/

                        /* Nombre Proveedor */
                        if (proveedorParam.Value != DBNull.Value)
                        {
                            Oracle.ManagedDataAccess.Types.OracleString oracleString = (Oracle.ManagedDataAccess.Types.OracleString)proveedorParam.Value;
                            nombreProv = oracleString.ToString();
                        }

                        /* Nombre Categoría */
                    }
                }

                // Llenar los txb con los datos traídos del procedimiento

                txbPrecio.Text = precio.ToString();
                cmbProveedor.Text = nombreProv;
                cmbCategoria.Text = nombreCat;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los detalles del producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
