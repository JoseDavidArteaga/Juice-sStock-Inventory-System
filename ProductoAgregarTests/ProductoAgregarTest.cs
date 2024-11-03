using Microsoft.VisualStudio.TestTools.UnitTesting;
using JuiceStockProject.Presentacion;
using JuiceStockProject.Datos;
using System.Windows.Forms;
using System;

[TestClass]
public class InventarioAgregarTests
{
    [TestMethod]
    public void CargarComboBoxProductos_DeberiaCargarProductosActivos()
    {
        // Arrange
        var formulario = new frmInventario_Agregar();

        // Act
        // Usar reflection para acceder al método privado
        var metodo = typeof(frmInventario_Agregar).GetMethod("CargarComboBoxProductos",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        metodo.Invoke(formulario, null);

        // Assert
        Assert.IsTrue(formulario.cmbProducto.Items.Count > 0,
            "El ComboBox debería contener productos activos");
    }

    [TestMethod]
    [ExpectedException(typeof(System.Exception))]
    public void AgregarInventario_SinProductoSeleccionado_DeberiaLanzarExcepcion()
    {
        // Arrange
        var formulario = new frmInventario_Agregar();

        // Act
        // Simular clic en agregar sin seleccionar producto
        formulario.btnAgregar.PerformClick();

        // Assert se maneja con ExpectedException
    }

    [TestMethod]
    public void NumCantidad_SoloPermiteNumerosPositivos()
    {
        // Arrange
        var formulario = new frmInventario_Agregar();
        var keyPressEvent = new KeyPressEventArgs('a');

        // Act
        formulario.numCantidad_KeyPress(formulario.numCantidad, keyPressEvent);

        // Assert
        Assert.IsTrue(keyPressEvent.Handled,
            "Solo deberían permitirse números");
    }

    [TestMethod]
    public void AgregarInventario_CantidadValida_DeberiaActualizarInventario()
    {
        // Arrange
        var formulario = new frmInventario_Agregar();

        // Configurar un producto y cantidad válidos
        formulario.cmbProducto.SelectedIndex = 0;
        formulario.numCantidad.Value = 10;

        // Act
        formulario.btnAgregar_Click(null, null);

        // Assert
        // Aquí necesitarías lógica específica para verificar la actualización
        // Puede implicar consultar la base de datos o un mock
    }
}