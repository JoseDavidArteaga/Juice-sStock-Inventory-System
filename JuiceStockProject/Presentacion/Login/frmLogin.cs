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

namespace JuiceStockProject.Presentacion
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtContraseña.Text == "")
            {
                lblDatosIncompletos.Visible = true;
                return;
            }
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;
            int resultado = 0;

            // Crear la conexión
            using (OracleConnection conexion = Conexion.getInstancia().CrearConexion())
            {
                //Pendiente desde aquí
                // Crear el comando para llamar al procedimiento almacenado
                using (OracleCommand comando = new OracleCommand("verificar_credenciales", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Añadir los parámetros al comando
                    comando.Parameters.Add(new OracleParameter("p_usuario", usuario));
                    comando.Parameters.Add(new OracleParameter("p_contrasena", contraseña));

                    // Recibir parámetro de salida
                    OracleParameter resultadoParam = new OracleParameter("p_resultado", OracleDbType.Int32);
                    resultadoParam.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(resultadoParam);

                    // Abrir la conexión y ejecutar el comando
                    conexion.Open();
                    comando.ExecuteNonQuery();

                    // Recuperar el valor del parámetro de salida
                    if (resultadoParam.Value != DBNull.Value)
                    {
                        Oracle.ManagedDataAccess.Types.OracleDecimal oracleDecimal = (Oracle.ManagedDataAccess.Types.OracleDecimal)resultadoParam.Value;
                        resultado = oracleDecimal.ToInt32(); // Almacenar el valor convertido en una nueva variable
                    }
                }
            }
            switch (resultado)
            {
                case 0:
                    // Usuario y contraseña correctos
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case 1:
                    MessageBox.Show("Contraseña incorrecta");
                    break;
                case 2:
                    MessageBox.Show("Usuario inexistente");
                    break;
                case 3:
                    MessageBox.Show("Otro error");
                    break;
                default:
                    MessageBox.Show("Error desconocido");
                    break;
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblDatosIncompletos.Visible = false;
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblDatosIncompletos.Visible = false;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

       
    }
}
