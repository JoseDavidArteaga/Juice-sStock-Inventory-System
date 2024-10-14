using JuiceStockProject.Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuiceStockProject.Datos
{
    public class D_Productos
    {
        public DataTable listado_pro(string cadena)
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand(cadena, SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public DataTable ObtenerNombres(string cadena)
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand(cadena, SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
    }
}
