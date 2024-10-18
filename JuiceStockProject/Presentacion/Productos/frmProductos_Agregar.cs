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
                // Verificar si se ha ingresado un nombre, un precio, se ha seleccionado un proveedor o una categoría
                if (cmbProveedor.SelectedIndex == -1 || cmbCategoria.SelectedIndex == -1 || txbNombre.Text == "" || txbPrecio.Text == "")
                {
                    lblIncompleto.Visible = true;
                    return; // Salir del método si no hay un producto seleccionado
                }

                // Obtener el nombre del producto nuevo
                string nombreProd = txbNombre.Text;

                // Obtener el precio del producto nuevo
                int precioProd = Convert.ToInt32(txbPrecio.Text);

                // Obtener el nombre del proveedor seleccionado
                string nombreProveedorSeleccionado = cmbProveedor.SelectedItem.ToString();

                // Obtener el nombre de la categoria seleccionada
                string nombreCategoriaSeleccionado = cmbCategoria.SelectedItem.ToString();

                // Bandera traída desde la BD
                int banderaAgregar = 0;

                // Crear la conexión
                using (OracleConnection conexion = Conexion.getInstancia().CrearConexion())
                {
                    //Pendiente desde aquí
                    // Crear el comando para llamar al procedimiento almacenado
                    using (OracleCommand comando = new OracleCommand("agregar_producto_proc", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        // Añadir los parámetros al comando
                        comando.Parameters.Add(new OracleParameter("nombre_producto", nombreProd));
                        comando.Parameters.Add(new OracleParameter("nombre_categoria", nombreCategoriaSeleccionado));
                        comando.Parameters.Add(new OracleParameter("precio_producto", precioProd));
                        comando.Parameters.Add(new OracleParameter("nombre_proveedor", nombreProveedorSeleccionado));

                        // Recibir parámetro de salida
                        OracleParameter banderaAgregarParam = new OracleParameter("p_bandera", OracleDbType.Int32);
                        banderaAgregarParam.Direction = ParameterDirection.Output;
                        comando.Parameters.Add(banderaAgregarParam);

                        // Abrir la conexión y ejecutar el comando
                        conexion.Open();
                        comando.ExecuteNonQuery();

                        // Recuperar el valor del parámetro de salida
                        if (banderaAgregarParam.Value != DBNull.Value)
                        {
                            Oracle.ManagedDataAccess.Types.OracleDecimal oracleDecimal = (Oracle.ManagedDataAccess.Types.OracleDecimal)banderaAgregarParam.Value;
                            banderaAgregar = oracleDecimal.ToInt32();
                        }
                    }
                }


                if (banderaAgregar == 0)
                {
                    // Mensaje de éxito
                    MessageBox.Show("El producto se ha agregado correctamente.");
                }
                else if (banderaAgregar == 1)
                {
                    // Mensaje de error producto ya existente
                    MessageBox.Show("El nombre de producto especificado ya existe");
                    return;
                }
                else
                {
                    // Mensaje de error diferente
                    MessageBox.Show("OCurrió un error al intentar agregar el producto");
                }
                // Cerrar el formulario de agregar inventario
                this.Close();

                // Actualizar el formulario de inventario
                var frmProductos = (frmProductos)Owner; // Obtener el formulario padre (frmPrincipal)
                frmProductos.ActualizarTabla(); // Llamar al método para actualizar la tabla
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la cantidad: " + ex.Message);
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
    }
}
