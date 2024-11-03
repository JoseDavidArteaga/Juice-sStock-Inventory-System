using NUnit.Framework;
using System;
using System.Windows.Forms;
using Moq;
using JuiceStockProject.Presentacion.Productos;
using JuiceStockProject.Datos;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace JuiceStockProject.Tests
{
    [TestFixture]
    public class ProductosAgregarTests
    {
        private frmProductos_Agregar formulario;
        private Mock<D_Productos> mockDatos;

        [SetUp]
        public void Setup()
        {
            // Inicializar el formulario antes de cada prueba
            formulario = new frmProductos_Agregar();
            mockDatos = new Mock<D_Productos>();
        }

        [TearDown]
        public void TearDown()
        {
            // Limpiar recursos después de cada prueba
            formulario.Dispose();
        }

        [Test]
        public void CargarComboBoxProveedores_DeberiaCargarProveedoresActivos()
        {
            // Preparar datos de prueba
            DataTable tablaProveedores = new DataTable();
            tablaProveedores.Columns.Add("nombre_prov");
            tablaProveedores.Rows.Add("Proveedor 1");
            tablaProveedores.Rows.Add("Proveedor 2");

            // Configurar el mock para devolver la tabla de prueba
            mockDatos.Setup(x => x.ObtenerNombres("SELECT nombre_prov FROM Proveedor WHERE estado_prov = 'ACTIVO'"))
                     .Returns(tablaProveedores);

            // Usar reflection para invocar el método privado
            var method = typeof(frmProductos_Agregar).GetMethod("CargarComboBoxProveedores",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            // Preparar los campos necesarios
            var cmbProveedorField = typeof(frmProductos_Agregar).GetField("cmbProveedor",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cmbProveedor = new ComboBox();
            cmbProveedorField.SetValue(formulario, cmbProveedor);

            // Invocar el método
            method.Invoke(formulario, null);

            // Verificar resultados
            Assert.AreEqual(2, cmbProveedor.Items.Count);
            Assert.AreEqual("Proveedor 1", cmbProveedor.Items[0]);
            Assert.AreEqual("Proveedor 2", cmbProveedor.Items[1]);
        }

        [Test]
        public void AgregarProducto_DatosValidos_DeberiaAgregarProductoCorrectamente()
        {
            // Configurar datos del formulario
            formulario.txbNombre.Text = "Producto Prueba";
            formulario.txbPrecio.Text = "100";

            // Configurar ComboBox
            formulario.cmbProveedor.Items.Add("Proveedor Test");
            formulario.cmbProveedor.SelectedIndex = 0;
            formulario.cmbCategoria.Items.Add("Categoria Test");
            formulario.cmbCategoria.SelectedIndex = 0;

            // Simular click en botón de agregar
            formulario.btnAgregarProducto_Click(null, EventArgs.Empty);

            // Verificaciones
            // Puedes agregar asserts para verificar que el producto se agregó correctamente
            // Esto puede implicar verificar en la base de datos o usar mocks
        }

        [Test]
        public void AgregarProducto_DatosIncompletos_DeberiaMostrarError()
        {
            // Dejar campos vacíos
            formulario.txbNombre.Text = "";
            formulario.txbPrecio.Text = "";

            // Simular click en botón de agregar
            formulario.btnAgregarProducto_Click(null, EventArgs.Empty);

            // Verificar que el label de incompleto se hace visible
            Assert.IsTrue(formulario.lblIncompleto.Visible);
        }

        [Test]
        public void ValidarPrecio_PrecioCero_DeberiaDeshabilitarBoton()
        {
            // Establecer precio a cero
            formulario.txbPrecio.Text = "0";

            // Verificar que el botón de agregar está deshabilitado
            Assert.IsFalse(formulario.btnAgregarProducto.Enabled);
            // Verificar que el label de precio cero está visible
            Assert.IsTrue(formulario.lblPrecio0.Visible);
        }

        [Test]
        public void ValidarNombre_NombreCorto_DeberiaDeshabilitarBoton()
        {
            // Establecer nombre corto
            formulario.txbNombre.Text = "AB";

            // Verificar que el botón de agregar está deshabilitado
            Assert.IsFalse(formulario.btnAgregarProducto.Enabled);
        }

        [Test]
        public void ValidarNombre_NombreLargo_DeberiaHabilitarBoton()
        {
            // Establecer nombre largo
            formulario.txbNombre.Text = "Producto de Prueba";

            // Verificar que el botón de agregar está habilitado
            Assert.IsTrue(formulario.btnAgregarProducto.Enabled);
        }
    }
}