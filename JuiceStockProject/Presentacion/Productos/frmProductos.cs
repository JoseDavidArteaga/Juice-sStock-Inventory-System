﻿using JuiceStockProject.Datos;
using JuiceStockProject.Presentacion.Productos;
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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }
        string cadena = "SELECT ID_PROD \"Identificador\", NOMBRE_PROD \"Nombre\", NOMBRE_CATEGORIA \"Categoría\", PRECIO_PROD \"Precio\" FROM VISTA_PRODUCTOS";

        private void Listado_pro()
        {
            D_Productos Datos = new D_Productos();
            dgvListadoProducto.DataSource = Datos.listado_pro(cadena);
        }

        public void ActualizarTabla()
        {
            // Llamar al método que carga los datos en el DataGridView
            D_Productos Datos = new D_Productos();
            dgvListadoProducto.DataSource = Datos.listado_pro(cadena);
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            this.Listado_pro();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            // Si hay productos, abrir el formulario de agregar producto
            frmProductos_Agregar agregarProducto = new frmProductos_Agregar();

            // Establecer frmProductos como el formulario propietario
            agregarProducto.Owner = this;

            // Mostrar frmProductos_Agregar como un cuadro de diálogo modal
            agregarProducto.ShowDialog();
        }

        private void btnEliminarProductos_Click(object sender, EventArgs e)
        {
            // Si hay productos, abrir el formulario de agregar producto
            frmProductos_Eliminar eliminarProducto = new frmProductos_Eliminar();

            // Establecer frmProductos como el formulario propietario
            eliminarProducto.Owner = this;

            // Mostrar frmProductos_Agregar como un cuadro de diálogo modal
            eliminarProducto.ShowDialog();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
{
    // Capturar el texto ingresado en el TextBox
    string textoBusqueda = txtBuscar.Text;

    // Crear una consulta que cargue todos los productos si no hay texto en el TextBox
    string consultaFiltrada;

    if (string.IsNullOrWhiteSpace(textoBusqueda))
    {
        // Si el TextBox está vacío, mostrar todos los productos
        consultaFiltrada = "SELECT ID_PROD \"Identificador\", NOMBRE_PROD \"Nombre\", NOMBRE_CATEGORIA \"Categoría\", PRECIO_PROD \"Precio\" " +
                           "FROM VISTA_PRODUCTOS";
    }
    else
    {
        // Si hay texto, buscar los productos que contengan la cadena ingresada
        consultaFiltrada = "SELECT ID_PROD \"Identificador\", NOMBRE_PROD \"Nombre\", NOMBRE_CATEGORIA \"Categoría\", PRECIO_PROD \"Precio\" " +
                           "FROM VISTA_PRODUCTOS " +
                           "WHERE upper(NOMBRE_PROD) LIKE '%" + textoBusqueda.ToUpper() + "%' " +
                           "ORDER BY CASE " +
                           "WHEN upper(NOMBRE_PROD) LIKE '" + textoBusqueda.ToUpper() + "%' THEN 1 " +  // Prefiere los que empiezan con el texto
                           "WHEN upper(NOMBRE_PROD) LIKE '%" + textoBusqueda.ToUpper() + "%' THEN 2 " +  // Luego los que contienen el texto
                           "ELSE 3 END, NOMBRE_PROD ASC"; // Si no es una coincidencia, ponerlo al final

    }

    // Llamar al método que actualiza el DataGridView con los productos filtrados
    D_Productos Datos = new D_Productos();
    dgvListadoProducto.DataSource = Datos.listado_pro(consultaFiltrada);
}

    }
}
