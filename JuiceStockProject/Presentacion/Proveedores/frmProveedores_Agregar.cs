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
    public partial class frmProveedores_Agregar : Form
    {
        public frmProveedores_Agregar()
        {
            InitializeComponent();
            // Invisibilizar etiquetas que no son necesarias al iniciar el formulario
            lblTelefono.Visible = false;
        }

        D_Productos Datos = new D_Productos();

        private void btnAgregarProveedores_Click(object sender, EventArgs e)
        {

            try
            {
                // Verificar si se ha ingresado un nombre, un telefono, un correo o una direccion
                if (txbNombre.Text.Length == 0 || txbTelefono.Text.Length == 0 || txbCorreo.Text.Length == 0 || txbDirección.Text.Length == 0)
                {
                    lblIncompleto.Visible = true;
                    btnAgregarProveedores.Enabled = false;
                    return; // Salir del método si no hay un producto seleccionado
                }

                //Obtener el nombre del proveedor nuevo
                string nombreProv = txbNombre.Text;

                // Obtener el telefono del proveedor nuevo
                string telefono = txbTelefono.Text;

                // Obtener el correo
                string correo = txbCorreo.Text;

                // Obtener el nombre de la categoria seleccionada
                string direccion = txbDirección.Text;

                // Bandera traída desde la BD
                int banderaAgregar = 0;

                // Crear la conexión
                using (OracleConnection conexion = Conexion.getInstancia().CrearConexion())
                {
                    //Pendiente desde aquí
                    // Crear el comando para llamar al procedimiento almacenado
                    using (OracleCommand comando = new OracleCommand("agregar_proveedor", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        // Añadir los parámetros al comando
                        comando.Parameters.Add(new OracleParameter("p_nombre", nombreProv));
                        comando.Parameters.Add(new OracleParameter("p_telefono", telefono));
                        comando.Parameters.Add(new OracleParameter("p_correo", correo));
                        comando.Parameters.Add(new OracleParameter("p_direccion", direccion));

                        // Recibir parámetro de salida
                        OracleParameter banderaAgregarParam = new OracleParameter("p_resultado", OracleDbType.Int32);
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
                    MessageBox.Show("El proveedor se ha agregado correctamente.");
                }
                else if (banderaAgregar == 1)
                {
                    // Mensaje de error producto ya existente
                    MessageBox.Show("El proveedor ya existe");
                    return;
                }
                else
                {
                    // Mensaje de error diferente
                    MessageBox.Show("Ocurrió un error al intentar agregar el proveedor");
                }
                // Cerrar el formulario de agregar inventario
                this.Close();

                // Actualizar el formulario de inventario
                var frmProveedores = (frmProveedores)Owner; // Obtener el formulario padre (frmPrincipal)
                frmProveedores.ActualizarTabla(); // Llamar al método para actualizar la tabla
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la cantidad: " + ex.Message);
            }
        }

        private void txbTelefono_TextChanged(object sender, EventArgs e)
        {
            lblIncompleto.Visible = false;
            btnAgregarProveedores.Enabled = true;

            // Verificar si el texto es exactamente "0"
            if (!txbTelefono.Text.StartsWith("3"))
            {
                lblTelefono.Visible = true;   // Mostrar el mensaje de advertencia si es "0"
                btnAgregarProveedores.Enabled = false; // Inhabilitar botón de agregar producto hasta que el precio sea diferente de 0
            }
            else
            {
                lblTelefono.Visible = false;  // Ocultar el mensaje si el texto es diferente a "0"
                btnAgregarProveedores.Enabled = true; // Habilitar botón de agregar producto ya que el precio no es 0
            }
        }

        private void txbNombre_TextChanged(object sender, EventArgs e)
        {
            lblIncompleto.Visible = false;
            btnAgregarProveedores.Enabled = true;
        }

        private void txbCorreo_TextChanged(object sender, EventArgs e)
        {
            lblIncompleto.Visible = false;
            btnAgregarProveedores.Enabled = true;
        }

        private void txbDirección_TextChanged(object sender, EventArgs e)
        {
            lblIncompleto.Visible = false;
            btnAgregarProveedores.Enabled = true;
        }

        private void txbTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            // Verificar si la combinación de teclas es Ctrl + V
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Bloquea el evento de pegar
            }
        }

        private void txbTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Inhabilitar lblIncompleto porque ya no está vacío
            lblIncompleto.Visible = false;

            // Validar si el carácter es un número o si es la tecla de retroceso (para borrar)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Rechazar el carácter si no es un número
            }
        }
    }
}
