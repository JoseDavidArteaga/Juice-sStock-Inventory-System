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
    public partial class frmProveedores_Modificar : Form
    {
        public frmProveedores_Modificar()
        {
            InitializeComponent();
        }

        D_Productos Datos = new D_Productos();

        private void CargarComboBoxProveedores()
        {
            string cadena = "SELECT nombre_prov FROM proveedor where estado_prov = 'ACTIVO' ";
            DataTable tablaProveedores = Datos.ObtenerNombres(cadena);

            //Limpiar el combobox antes de cargar los datos
            cmbProveedores.Items.Clear();

            //Verificar si se obtuvieron datos
            if (tablaProveedores.Rows.Count > 0)
            {
                //Recorrer cada fila en la tabla y añadir el nombre al combobox
                foreach (DataRow row in tablaProveedores.Rows)
                {
                    cmbProveedores.Items.Add(row["nombre_prov"].ToString());
                }
            }
            else
            {
                MessageBox.Show("No se encontraron proveedores activos.");
                return;
            }
        }

        private void frmProveedores_Modificar_Load(object sender, EventArgs e)
        {
            this.CargarComboBoxProveedores();
            if (cmbProveedores.Items.Count > 0)
            {
                // Establecer el índice si hay al menos un producto
                cmbProveedores.SelectedIndex = -1; // Selecciona el primer elemento
            }
        }

        private void cmbProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSeleccionarProv.Visible = false;
            string proveedorSeleccionado = "";
            if (cmbProveedores.SelectedIndex != -1)
            {
                pnlModificar.Visible = true;
                proveedorSeleccionado = cmbProveedores.SelectedItem.ToString();
                txbNombre.Text = proveedorSeleccionado;

                try
                {
                    using (OracleConnection conexion = Conexion.getInstancia().CrearConexion())
                    {
                        using (OracleCommand comando = new OracleCommand("obtener_detalles_proveedor", conexion))
                        {
                            comando.CommandType = CommandType.StoredProcedure;

                            // Parámetro de entrada
                            comando.Parameters.Add("p_nombre_proveedor", OracleDbType.Varchar2).Value = proveedorSeleccionado;

                            // Parámetros de salida
                            OracleParameter telParam = new OracleParameter("p_telefono", OracleDbType.Varchar2, 100);
                            telParam.Direction = ParameterDirection.Output;
                            comando.Parameters.Add(telParam);

                            // correo - asignar tamaño específico
                            OracleParameter correoParam = new OracleParameter("p_correo", OracleDbType.Varchar2, 100);
                            correoParam.Direction = ParameterDirection.Output;
                            comando.Parameters.Add(correoParam);

                            // direccion - asignar tamaño específico
                            OracleParameter dirParam = new OracleParameter("p_direccion", OracleDbType.Varchar2, 100);
                            dirParam.Direction = ParameterDirection.Output;
                            comando.Parameters.Add(dirParam);

                            // Ejecutar el procedimiento
                            conexion.Open();
                            comando.ExecuteNonQuery();

                            // Obtener los valores de salida de manera segura
                            if (telParam.Value != DBNull.Value)
                            {
                                txbTelefono.Text = telParam.Value.ToString();
                            }

                            if (correoParam.Value != DBNull.Value)
                            {
                                txbCorreo.Text = correoParam.Value.ToString();
                            }

                            if (dirParam.Value != DBNull.Value)
                            {
                                txbDirección.Text = dirParam.Value.ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener los detalles del proveedor: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                pnlModificar.Visible = false;
                txbNombre.Clear();
                txbTelefono.Clear();
                txbCorreo.Clear();
                txbDirección.Clear();
            }
        }

        private void btnModificarProveedor_Click(object sender, EventArgs e)
        {
            if (cmbProveedores.SelectedIndex == -1)
            {
                lblSeleccionarProv.Visible = true;
                return; // Salir del método si no hay un producto seleccionado
            }

            //Verificar si se han ingresado todos los datos
            if (txbNombre.Text == "" || txbTelefono.Text == "" || txbCorreo.Text == "" || txbDirección.Text == "")
            {
                lblIncompleto.Visible = true;
                return;
            }

            string proveedorSeleccionado = "";
            proveedorSeleccionado = cmbProveedores.SelectedItem.ToString();

            //Enviar valores al procedimiento para modificar proveedores
            int bandera = 0;
            string p_nuevoNombre = txbNombre.Text;
            string p_nuevoTelefono = txbTelefono.Text;
            string p_nuevoCorreo = txbCorreo.Text;
            string p_nuevaDireccion = txbDirección.Text;

            using (OracleConnection conexion = Conexion.getInstancia().CrearConexion())
            {
                using (OracleCommand comando = new OracleCommand("modificar_proveedor_proc", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Parámetro de entrada
                    comando.Parameters.Add("p_nombre_actual", OracleDbType.Varchar2).Value = proveedorSeleccionado;
                    comando.Parameters.Add("p_nuevo_nombre", OracleDbType.Varchar2).Value = p_nuevoNombre;
                    comando.Parameters.Add("p_nuevo_telefono", OracleDbType.Varchar2).Value = p_nuevoTelefono;
                    comando.Parameters.Add("p_nuevo_correo", OracleDbType.Varchar2).Value = p_nuevoCorreo;
                    comando.Parameters.Add("p_nueva_direccion", OracleDbType.Varchar2).Value = p_nuevaDireccion;

                    // Parámetro de salida
                    OracleParameter banderaParam = new OracleParameter("p_resultado", OracleDbType.Int32, 32);
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
                        MessageBox.Show("El proveedor se ha modificado correctamente.");
                    }

                    // Cerrar el formulario de agregar inventario
                    this.Close();

                    // Actualizar el formulario de productos
                    var frmProveedor = (frmProveedores)Owner; // Obtener el formulario padre (frmInventario)
                    frmProveedor.ActualizarTabla(); // Llamar al método para actualizar la tabla
                }
            }
        }
    }
}
