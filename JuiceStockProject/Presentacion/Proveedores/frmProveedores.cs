﻿using JuiceStockProject.Datos;
using JuiceStockProject.Presentacion.Proveedores;
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
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
        }
        string cadena = "SELECT * FROM VISTA_PROVEEDORES";
        D_Productos Datos = new D_Productos();

        private void Listado_pro()
        {
            D_Productos Datos = new D_Productos();
            dgvListadoProveedores.DataSource = Datos.listado_pro(cadena);
        }

        public void ActualizarTabla()
        {
            // Llamar al método que carga los datos en el DataGridView
            D_Productos Datos = new D_Productos();
            dgvListadoProveedores.DataSource = Datos.listado_pro(cadena);
        }
        private void frmProveedores_Load(object sender, EventArgs e)
        {
            this.Listado_pro();
        }

        private void btnAgregarProveedores_Click(object sender, EventArgs e)
        {
            // Si hay productos, abrir el formulario de agregar proveedores
            frmProveedores_Agregar agregarProveedores = new frmProveedores_Agregar();

            // Establecer frmProductos como el formulario propietario
            agregarProveedores.Owner = this;

            // Mostrar frmProductos_Agregar como un cuadro de diálogo modal
            agregarProveedores.ShowDialog();
        }

        private void btnEliminarProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores_Eliminar eliminarProveedores = new frmProveedores_Eliminar();
            eliminarProveedores.Owner = this;
            eliminarProveedores.ShowDialog();
        }
    }
}