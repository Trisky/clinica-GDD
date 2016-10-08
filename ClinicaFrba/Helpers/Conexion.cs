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


        /// <summary>
        /// Ejecuta un storeprocedure con una lista de parametros
        /// </summary>
        /// <param name="nombreStoreProcedure"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public DataTable EjecutarProcedureCompleto(string nombreStoreProcedure, Dictionary<string, string> parametros)
        {
            return EjecutarProcedureCompleto(nombreStoreProcedure, parametros,null, new DateTime());
        }

        /// <summary>
        /// Ejecuta un store procedure con una lista de parametros y parametro adicional de tipo datetime
        /// </summary>
        /// <param name="nombreStoreProcedure"></param>
        /// <param name="parametros"></param>
        /// <param name="nombreParametroFecha"></param>
        /// <param name="parametroDos"></param>
        /// <returns></returns>
        public DataTable EjecutarProcedureCompleto(string nombreStoreProcedure, Dictionary<string, string> parametros, string nombreParametroFecha, DateTime parametroDos)
        {
            try
            {
                SqlParameter sqlparam;
                DataTable miDataTable = new DataTable();
                
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand(ObjetoConEsquema(nombreStoreProcedure)))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (var item in parametros)
                        {
                            sqlparam = new SqlParameter();
                            sqlparam.ParameterName = item.Key;
                            sqlparam.SqlDbType = SqlDbType.Int;
                            sqlparam.Value = item.Value;
                            cmd.Parameters.Add(sqlparam);
                        }

                        if (parametroDos != null && nombreParametroFecha != "") //agrego la fecha si no es null
                        {
                            cmd.Parameters.Add(new SqlParameter()
                            {
                                ParameterName = nombreParametroFecha,
                                SqlDbType = SqlDbType.DateTime,
                                Value = parametroDos
                            });
                        }


                        con.Open();
                        miDataTable.Load(cmd.ExecuteReader());
                        con.Close();
                    }
                }
                return miDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        private string ObjetoConEsquema(string nombreObjetoDb)
        {
            string esquema = cadenaConexion;
            return string.Format("{0}.{1}", esquema, nombreObjetoDb);
        }
    }
}
