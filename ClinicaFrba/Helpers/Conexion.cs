using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ClinicaFrba.Helpers
{
    class Conexion
    {
        public string cadenaConexion { get; set; }

        public Conexion()
        {
            cadenaConexion = "ConexionClinica";
        }
        public DataTable EjecutarConsultaSql(string consultaSql)
        {
            
        DataTable miDataTable = new DataTable();
            try
            {
                
                SqlConnection conexionSql = new SqlConnection(cadenaConexion);
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = consultaSql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexionSql;

                conexionSql.Open();

                miDataTable.Load(cmd.ExecuteReader());
                conexionSql.Close();

                return miDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
