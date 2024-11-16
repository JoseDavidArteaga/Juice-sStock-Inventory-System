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
    public partial class frmProductos_Eliminar : Form
    {
        public frmProductos_Eliminar()
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

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbProductos.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, seleccione un producto.");
                    return; // Salir del método si no hay un producto seleccionado
                }
                string nombreProductoSeleccionado = cmbProductos.SelectedItem.ToString();
                int banderaEliminar = 0;
                //Crear la conexión
                using (OracleConnection conexion = Conexion.getInstancia().CrearConexion())
                {
                    //Crear el comando para llamar el procedimineto almacenado
                    using (OracleCommand comando = new OracleCommand("eliminar_producto_proc", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        // Añadir los parámetros al comando
                        comando.Parameters.Add(new OracleParameter("p_nombre_prod", nombreProductoSeleccionado));

                        // Recibir parámetro de salida
                        OracleParameter banderaEliminarParam = new OracleParameter("p_bandera", OracleDbType.Int32);
                        banderaEliminarParam.Direction = ParameterDirection.Output;
                        comando.Parameters.Add(banderaEliminarParam);

                        // Abrir la conexión y ejecutar el comando
                        conexion.Open();
                        comando.ExecuteNonQuery();

                        // Recuperar el valor del parámetro de salida
                        if (banderaEliminarParam.Value != DBNull.Value)
                        {
                            Oracle.ManagedDataAccess.Types.OracleDecimal oracleDecimal = (Oracle.ManagedDataAccess.Types.OracleDecimal)banderaEliminarParam.Value;
                            banderaEliminar = oracleDecimal.ToInt32();
                        }
                    }
                }


                if (banderaEliminar == 0)
                {
                    // Mensaje de éxito
                    MessageBox.Show("El producto se ha eliminado correctamente.");
                }
                else if (banderaEliminar == 1)
                {
                    // Mensaje de error producto tiene cantidad en inventario
                    MessageBox.Show("El producto tiene cantidad mayor que 0");
                }
                else
                {
                    // Mensaje de error diferente
                    MessageBox.Show("Ocurrió un error al intentar eliminar el producto");
                }
                // Cerrar el formulario de agregar inventario
                this.Close();

                // Actualizar el formulario de inventario
                var frmProducto = (frmProductos)Owner; // Obtener el formulario padre (frmInventario)
                frmProducto.ActualizarTabla(); // Llamar al método para actualizar la tabla
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar producto: " + ex.Message);
            }
        }

        private void frmProductos_Eliminar_Load(object sender, EventArgs e)
        {
            this.CargarComboBoxProductos();
            cmbProductos.SelectedIndex = -1;
        }
    }
}
