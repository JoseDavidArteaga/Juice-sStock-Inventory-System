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

namespace JuiceStockProject.Presentacion.Proveedores
{
    public partial class frmProveedores_Eliminar : Form
    {
        public frmProveedores_Eliminar()
        {
            InitializeComponent();
        }

        D_Productos Datos = new D_Productos();

        private void CargarComboBoxProveedores()
        {
            DataTable tablaProductos = Datos.ObtenerNombres("SELECT nombre_prov  FROM Proveedor WHERE estado_prov = 'ACTIVO'");

            // Limpiar el ComboBox antes de cargar los datos
            cmbProveedores.Items.Clear();

            // Verificar si se obtuvieron datos
            if (tablaProductos.Rows.Count > 0)
            {
                // Recorrer cada fila en la tabla y añadir el nombre al ComboBox
                foreach (DataRow row in tablaProductos.Rows)
                {
                    cmbProveedores.Items.Add(row["nombre_prov"].ToString());
                }
            }
            else
            {
                MessageBox.Show("No se encontraron proveedores activos.");
            }
        }
        private void frmProveedores_Eliminar_Load(object sender, EventArgs e)
        {
            this.CargarComboBoxProveedores();
            cmbProveedores.SelectedIndex = -1;
        }

        private void btnEliminarProveedores_Click(object sender, EventArgs e)
        {
            try
            {
                if(cmbProveedores.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, seleccione un proveedor");
                    return;
                }
                string nombreProveedorSeleccionado = cmbProveedores.SelectedItem.ToString();
                int bandera = 0;
                //Crear la conexión
                using (OracleConnection conexion = Conexion.getInstancia().CrearConexion())
                {
                    //Crear el comando para llamar el procedimineto almacenado
                    using (OracleCommand comando = new OracleCommand("eliminar_proveedor", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        // Añadir los parámetros al comando
                        comando.Parameters.Add(new OracleParameter("p_nombre_proveedor", nombreProveedorSeleccionado));

                        // Recibir parámetro de salida
                        OracleParameter banderaEliminarParam = new OracleParameter("p_resultado", OracleDbType.Int32);
                        banderaEliminarParam.Direction = ParameterDirection.Output;
                        comando.Parameters.Add(banderaEliminarParam);

                        // Abrir la conexión y ejecutar el comando
                        conexion.Open();
                        comando.ExecuteNonQuery();

                        // Recuperar el valor del parámetro de salida
                        if (banderaEliminarParam.Value != DBNull.Value)
                        {
                            Oracle.ManagedDataAccess.Types.OracleDecimal oracleDecimal = (Oracle.ManagedDataAccess.Types.OracleDecimal)banderaEliminarParam.Value;
                            bandera = oracleDecimal.ToInt32();
                        }
                    }
                }
                if (bandera == 0)
                {
                    // Mensaje de éxito
                    MessageBox.Show("El proveedor se ha eliminado correctamente.");
                }
                else if (bandera == 1)
                {
                    // Mensaje de error producto tiene cantidad en inventario
                    MessageBox.Show("El proveedor tiene productos asociados");
                }
                else
                {
                    // Mensaje de error diferente
                    MessageBox.Show("OCurrió un error al intentar eliminar el proveedor");
                }
                // Cerrar el formulario de agregar inventario
                this.Close();

                // Actualizar el formulario de inventario
                var frmProveedor = (frmProveedores)Owner; // Obtener el formulario padre (frmInventario)
                frmProveedor.ActualizarTabla(); // Llamar al método para actualizar la tabla
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al eliminar el proveedor: " + ex.Message);
            }
        }
    }
}
