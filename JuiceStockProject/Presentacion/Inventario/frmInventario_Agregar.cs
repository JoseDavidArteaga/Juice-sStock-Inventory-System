using JuiceStockProject.Datos;
using JuiceStockProject.Entidades;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JuiceStockProject.Presentacion
{
    public partial class frmInventario_Agregar : Form
    {
        public frmInventario_Agregar()
        {
            InitializeComponent();
        }

        D_Productos Datos = new D_Productos();

        private void CargarComboBoxProductos()
        {
            DataTable tablaProductos = Datos.ObtenerNombres("SELECT nombre_prod  FROM Producto WHERE estado_prod = 'ACTIVO'");

            // Limpiar el ComboBox antes de cargar los datos
            cmbProducto.Items.Clear();

            // Verificar si se obtuvieron datos
            if (tablaProductos.Rows.Count > 0)
            {
                // Recorrer cada fila en la tabla y añadir el nombre al ComboBox
                foreach (DataRow row in tablaProductos.Rows)
                {
                    cmbProducto.Items.Add(row["nombre_prod"].ToString());
                }
            }
            else
            {
                MessageBox.Show("No se encontraron productos activos.");
            }
        }



        private void frmInventario_Agregar_Load(object sender, EventArgs e)
        {
            this.CargarComboBoxProductos();

            // Verificar si hay suficientes elementos en el ComboBox antes de establecer SelectedIndex
            if (cmbProducto.Items.Count > 0)
            {
                // Establecer el índice si hay al menos un producto
                cmbProducto.SelectedIndex = -1; // Selecciona el primer elemento
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                // Verificar si se ha seleccionado un producto
                if (cmbProducto.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, seleccione un producto.");
                    return; // Salir del método si no hay un producto seleccionado
                }

                // Obtener el nombre del producto seleccionado
                string nombreProductoSeleccionado = cmbProducto.SelectedItem.ToString();
                int cantidadASumar = Convert.ToInt32(numCantidad.Value);

                // Verificar que la cantidad a sumar sea mayor que cero
                if (cantidadASumar <= 0)
                {
                    MessageBox.Show("La cantidad a agregar debe ser mayor que cero.");
                    return; // Salir del método si la cantidad es cero o negativa
                }

                // Crear la conexión
                using (OracleConnection conexion = Conexion.getInstancia().CrearConexion())
                {
                    // Crear el comando para llamar al procedimiento almacenado
                    using (OracleCommand comando = new OracleCommand("agregar_cantidad_procedimiento", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        // Añadir los parámetros al comando
                        comando.Parameters.Add(new OracleParameter("p_nombre_prod", nombreProductoSeleccionado));
                        comando.Parameters.Add(new OracleParameter("p_cantidad_agregar", cantidadASumar));

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

        private void numCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Rechazar el carácter si no es un número
            }
        }

        private void numCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            // Verificar si la combinación de teclas es Ctrl + V
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Bloquea el evento de pegar
            }
        }
    }
}
