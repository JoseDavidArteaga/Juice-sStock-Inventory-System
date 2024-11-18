using JuiceStockProject.Datos;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace JuiceStockProject.Presentacion
{
    public partial class frmLogin : Form
    {
        #region Propiedades
        public static string NombreUsuario { get; set; }
        #endregion

        #region Constructor
        public frmLogin()
        {
            InitializeComponent();
        }
        #endregion

        #region Métodos Privados
        private int VerificarCredenciales(string usuario, string contraseña)
        {
            int resultado = 0;
            try
            {
                using (OracleConnection conexion = Conexion.getInstancia().CrearConexion())
                {
                    using (OracleCommand comando = new OracleCommand("verificar_credenciales", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        // Parámetros de entrada
                        comando.Parameters.Add(new OracleParameter("p_usuario", usuario));
                        comando.Parameters.Add(new OracleParameter("p_contrasena", contraseña));

                        // Parámetro de salida
                        OracleParameter resultadoParam = new OracleParameter("p_resultado", OracleDbType.Int32);
                        resultadoParam.Direction = ParameterDirection.Output;
                        comando.Parameters.Add(resultadoParam);

                        conexion.Open();
                        comando.ExecuteNonQuery();

                        if (resultadoParam.Value != DBNull.Value)
                        {
                            Oracle.ManagedDataAccess.Types.OracleDecimal oracleDecimal =
                                (Oracle.ManagedDataAccess.Types.OracleDecimal)resultadoParam.Value;
                            resultado = oracleDecimal.ToInt32();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar credenciales: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        private void ObtenerNombreUsuario(string usuario)
        {
            try
            {
                using (OracleConnection conexion = Conexion.getInstancia().CrearConexion())
                {
                    using (OracleCommand comando = new OracleCommand("obtener_nombre_usuario", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        // Parámetro de entrada
                        comando.Parameters.Add("p_usuario", OracleDbType.Varchar2).Value = usuario;

                        // Parámetro de salida
                        OracleParameter nombreParam = new OracleParameter("p_nom_usuario", OracleDbType.Varchar2, 100);
                        nombreParam.Direction = ParameterDirection.Output;
                        comando.Parameters.Add(nombreParam);

                        conexion.Open();
                        comando.ExecuteNonQuery();

                        if (nombreParam.Value != DBNull.Value)
                        {
                            NombreUsuario = nombreParam.Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener nombre de usuario: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManejarResultadoLogin(int resultado, string usuario)
        {
            switch (resultado)
            {
                case 0: // Usuario y contraseña correctos
                    ObtenerNombreUsuario(usuario);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case 1:
                    MessageBox.Show("Contraseña incorrecta", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 2:
                    MessageBox.Show("Usuario inexistente", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 3:
                    MessageBox.Show("Otro error", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    MessageBox.Show("Error desconocido", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        #endregion

        #region Eventos
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtContraseña.Text))
            {
                lblDatosIncompletos.Visible = true;
                return;
            }

            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            int resultado = VerificarCredenciales(usuario, contraseña);
            ManejarResultadoLogin(resultado, usuario);
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblDatosIncompletos.Visible = false;
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblDatosIncompletos.Visible = false;
        }
        #endregion
    }
}