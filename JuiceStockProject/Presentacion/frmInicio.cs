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
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();

            // Mostrar la hora y fecha inmediatamente al cargar el formulario
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lblDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");

            timerTime.Start();
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            // Actualizar el Label con la hora y fecha actuales
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lblDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
        }
    }
}
