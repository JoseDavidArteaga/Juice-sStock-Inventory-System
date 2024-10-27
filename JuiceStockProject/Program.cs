using JuiceStockProject.Presentacion;

namespace JuiceStockProject
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {       // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // Crear una instancia del formulario de login
            frmLogin loginForm = new frmLogin();
                
                // Mostrar el formulario de login y verificar el resultado
                if (loginForm.ShowDialog() == DialogResult.OK)
                {

                
                // Si las credenciales son correctas, abrir el formulario principal
                Application.Run(new frmPrincipal());
                }
                else
                {
                    // Si el login falla o se cierra, la aplicación se termina
                    Application.Exit();
                }
            
        }
    }
}