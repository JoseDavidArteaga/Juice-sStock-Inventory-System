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
            lblSeleccionarProd.Visible = false;

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
            lblSeleccionarProd.Visible = false;
            string productoSeleccionado = "";

            // Verificar si hay un producto seleccionado
            if (cmbProductos.SelectedIndex != -1)
            {
                pnlModificar.Visible = true;
                productoSeleccionado = cmbProductos.SelectedItem.ToString();
                txbNombre.Text = productoSeleccionado;

                try
                {
                    using (OracleConnection conexion = Conexion.getInstancia().CrearConexion())
                    {
                        using (OracleCommand comando = new OracleCommand("obtener_detalles_producto", conexion))
                        {
                            comando.CommandType = CommandType.StoredProcedure;

                            // Parámetro de entrada
                            comando.Parameters.Add("p_nombre_producto", OracleDbType.Varchar2).Value = productoSeleccionado;

                            // Parámetros de salida
                            // Precio - asignar tamaño específico
                            OracleParameter precioParam = new OracleParameter("p_precio", OracleDbType.Int32, 32);
                            precioParam.Direction = ParameterDirection.Output;
                            comando.Parameters.Add(precioParam);

                            // Proveedor - asignar tamaño específico
                            OracleParameter proveedorParam = new OracleParameter("p_nombre_proveedor", OracleDbType.Varchar2, 100);
                            proveedorParam.Direction = ParameterDirection.Output;
                            comando.Parameters.Add(proveedorParam);

                            // Categoría - asignar tamaño específico
                            OracleParameter categoriaParam = new OracleParameter("p_nombre_categoria", OracleDbType.Varchar2, 100);
                            categoriaParam.Direction = ParameterDirection.Output;
                            comando.Parameters.Add(categoriaParam);

                            // Ejecutar el procedimiento
                            conexion.Open();
                            comando.ExecuteNonQuery();

                            // Obtener los valores de salida de manera segura
                            if (precioParam.Value != DBNull.Value)
                            {
                                txbPrecio.Text = precioParam.Value.ToString();
                            }

                            if (proveedorParam.Value != DBNull.Value)
                            {
                                cmbProveedor.Text = proveedorParam.Value.ToString();
                            }

                            if (categoriaParam.Value != DBNull.Value)
                            {
                                cmbCategoria.Text = categoriaParam.Value.ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener los detalles del producto: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                pnlModificar.Visible = false;
                // Limpiar los campos cuando no hay selección
                txbNombre.Clear();
                txbPrecio.Clear();
                cmbProveedor.Text = "";
                cmbCategoria.Text = "";
            }
        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedIndex == -1)
            {
                lblSeleccionarProd.Visible = true;
                return; // Salir del método si no hay un producto seleccionado
            }

            // Verificar si se ha ingresado un nombre, un precio, se ha seleccionado un proveedor o una categoría
            if (cmbProveedor.SelectedIndex == -1 || cmbCategoria.SelectedIndex == -1 || txbNombre.Text == "" || txbPrecio.Text == "")
            {
                lblIncompleto.Visible = true;
                return; // Salir del método si no hay un producto seleccionado
            }

            string productoSeleccionado = "";

            productoSeleccionado = cmbProductos.SelectedItem.ToString();

            

            // Enviar nuevos valores a procedimiento para modificar productos
            int bandera = 0;
            int nuevoPrecio = Convert.ToInt32(txbPrecio.Text);
            string p_nuevoNombre = txbNombre.Text;
            string p_nuevoProveedor = cmbProveedor.SelectedItem.ToString();
            string p_nuevaCategoria = cmbCategoria.SelectedItem.ToString();

            using (OracleConnection conexion = Conexion.getInstancia().CrearConexion())
            {
                using (OracleCommand comando = new OracleCommand("modificar_producto_proc", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Parámetro de entrada
                    comando.Parameters.Add("nombre_actual", OracleDbType.Varchar2).Value = productoSeleccionado;
                    comando.Parameters.Add("nuevo_nombre", OracleDbType.Varchar2).Value = p_nuevoNombre;
                    comando.Parameters.Add("nueva_categoria", OracleDbType.Varchar2).Value = p_nuevaCategoria;
                    comando.Parameters.Add("nueva_proveedor", OracleDbType.Varchar2).Value = p_nuevoProveedor;
                    comando.Parameters.Add("nuevo_precio", OracleDbType.Int32).Value = nuevoPrecio;

                    // Parámetro de salida
                    OracleParameter banderaParam = new OracleParameter("p_bandera", OracleDbType.Int32, 32);
                    banderaParam.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(banderaParam);

                    // Ejecutar el procedimiento
                    conexion.Open();
                    comando.ExecuteNonQuery();

                    // Retornar valor de parámetro de salida
                    if (banderaParam.Value != DBNull.Value)
                    {
                        bandera = Convert.ToInt32(banderaParam.Value.ToString());

                    }

                    // Casos de error según resultado de bandera
                    if (bandera == 0)
                    {
                        // Mensaje de éxito
                        MessageBox.Show("El producto se ha modificado correctamente.");
                    }

                    // Cerrar el formulario de agregar inventario
                    this.Close();

                    // Actualizar el formulario de productos
                    var frmProductos = (frmProductos)Owner; // Obtener el formulario padre (frmInventario)
                    frmProductos.ActualizarTabla(); // Llamar al método para actualizar la tabla
                }
            }
        }

        private void txbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Inhabilitar lblIncompleto porque ya no está vacío
            lblIncompleto.Visible = false;
        }

        private void txbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Inhabilitar lblIncompleto porque ya no está vacío
            lblIncompleto.Visible = false;

            // Validar si el carácter es un número o si es la tecla de retroceso (para borrar)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Rechazar el carácter si no es un número
            }
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Inhabilitar lblIncompleto porque ya no está vacío
            lblIncompleto.Visible = false;
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Inhabilitar lblIncompleto porque ya no está vacío
            lblIncompleto.Visible = false;
        }

        private void txbPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            // Verificar si la combinación de teclas es Ctrl + V
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Bloquea el evento de pegar
            }
        }

        private void txbNombre_TextChanged(object sender, EventArgs e)
        {
            // Verificar si el texto ingresado tiene al menos 3 caracteres
            if (txbNombre.Text.Length >= 3)
            {
                btnModificarProducto.Enabled = true;
            }
            else
            {
                btnModificarProducto.Enabled = false;
            }
        }

        private void txbPrecio_TextChanged(object sender, EventArgs e)
        {
            // Verificar si el texto es exactamente "0"
            if (txbPrecio.Text == "0")
            {
                lblPrecio0.Visible = true;   // Mostrar el mensaje de advertencia si es "0"
                btnModificarProducto.Enabled = false; // Inhabilitar botón de agregar producto hasta que el precio sea diferente de 0
            }
            else
            {
                lblPrecio0.Visible = false;  // Ocultar el mensaje si el texto es diferente a "0"
                btnModificarProducto.Enabled = true; // Habilitar botón de agregar producto ya que el precio no es 0
            }
        }
    }
}
