using JuiceStockProject.Presentacion;

namespace JuiceStockProject
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            bool iniciarSesion = true;

            while (iniciarSesion)
            {
                // Crear una instancia del formulario de login
                using (frmLogin loginForm = new frmLogin())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        // Si las credenciales son correctas, abrir el formulario principal
                        using (frmPrincipal principalForm = new frmPrincipal())
                        {
                            if (principalForm.ShowDialog() == DialogResult.Abort)
                            {
                                // Si se cierra sesión, reiniciar el flujo de login
                                iniciarSesion = true;
                            }
                            else
                            {
                                // Cerrar la aplicación si el formulario principal se cierra de otra forma
                                iniciarSesion = false;
                            }
                        }
                    }
                    else
                    {
                        // Si el login falla o se cierra, terminar la aplicación
                        iniciarSesion = false;
                    }
                }
            }
        }
    }
}
