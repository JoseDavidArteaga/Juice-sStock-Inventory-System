using System;
using JuiceStockProject.Datos;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace JuiceStockProject.Presentacion.Inventario
{
    public partial class frmInventario_Eliminar : Form
    {
        public frmInventario_Eliminar()
        {
            InitializeComponent();
        }
        D_Productos Datos = new D_Productos();
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

        private int ObtenerCantidadProducto(string nombreProducto)
        {
            int cantidadProd = 0;

            using (OracleConnection conexion = Conexion.getInstancia().CrearConexion())
            {
                using (OracleCommand comando = new OracleCommand("obtener_cantidad_producto", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Parámetro de entrada: nombre del producto
                    comando.Parameters.Add("p_nombre_producto", OracleDbType.Varchar2).Value = nombreProducto;

                    // Parámetro de salida: cantidad del producto
                    OracleParameter cantidadParam = new OracleParameter("p_cantidad", OracleDbType.Int32);
                    cantidadParam.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(cantidadParam);

                    // Abrir conexión y ejecutar el procedimiento
                    conexion.Open();
                    comando.ExecuteNonQuery();

                    // Recuperar el valor del parámetro de salida
                    if (cantidadParam.Value != DBNull.Value)
                    {
                        Oracle.ManagedDataAccess.Types.OracleDecimal oracleDecimal = (Oracle.ManagedDataAccess.Types.OracleDecimal)cantidadParam.Value;
                        cantidadProd = oracleDecimal.ToInt32();
                    }
                }
            }

            return cantidadProd;
        }

        private void frmInventario_Eliminar_Load(object sender, EventArgs e)
        {
            this.CargarComboBoxProductos();
            cmbProductos.SelectedIndex = -1;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {

            try
            {
                if (cmbProductos.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, seleccione un producto.");
                    return; // Salir del método si no hay un producto seleccionado
                }
                // Obtener el nombre del producto seleccionado
                string nombreProductoSeleccionado = cmbProductos.SelectedItem.ToString();
                int cantidadARestar = Convert.ToInt32(numCantidad.Value);

                // Verificar que la cantidad a restar sea mayor que cero
                if (cantidadARestar <= 0)
                {
                    MessageBox.Show("La cantidad a restar debe ser mayor que cero.");
                    return; // Salir del método si la cantidad es cero o negativa
                }

                //Obtener la cantidad actual del producto
                int cantidadActual = ObtenerCantidadProducto(nombreProductoSeleccionado);

                //Verificar si la cantidad a eliminar es mayor que la cantidad actual 
                if (cantidadARestar > cantidadActual)
                {
                    MessageBox.Show("No se puede eliminar una cantidad mayor a la existente.");
                    return; //Salir del método si la cantidad a eliminar es mayor que la cantidad actual
                }

                // Crear la conexión
                using (OracleConnection conexion = Conexion.getInstancia().CrearConexion())
                {
                    // Crear el comando para llamar al procedimiento almacenado
                    using (OracleCommand comando = new OracleCommand("eliminar_cantidad_procedimiento", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        // Añadir los parámetros al comando
                        comando.Parameters.Add(new OracleParameter("p_nombre_prod", nombreProductoSeleccionado));
                        comando.Parameters.Add(new OracleParameter("p_cantidad_eliminar", cantidadARestar));


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
