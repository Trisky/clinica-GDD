using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace ClinicaFrba.Helpers
{
    public class Conexion
    {
        public SqlConnection Connector { get; set; }
        public SqlCommand Command { get; set; }

        public Conexion()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["clinica"].ConnectionString;
            Connector = new SqlConnection(connectionString);
             
        }

        /// <summary>
        /// ideal para cuando queres mandar una query q es solo un string sin parametros.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable SimpleQuery(string query)
        {
            SqlCommand cmd = CrearComandoQuery(query);
            return ExecConsulta(cmd);
        }

        /// <summary>
        /// Recibe un comando sql, lo ejecuta en el servidorSQL y devuelve la tabla que devuelve este. 
        /// Si el server no devuelve nada, devuelve tabla vacia.
        /// Sirve para select, update, delete y
        /// 
        /// Para store procedures  hay que usar el CrearComandoStoreProcedure antes!
        /// Ver ejemplo en la clase LogInHelper para ver como usarlo y panra SP en comprarBono
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public DataTable ExecConsulta(SqlCommand cmd)
        {
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    Connector.Open();

                    DataTable dataTable = new DataTable();
                    da.Fill(dataTable);
                    Connector.Close();
                    return dataTable;
                }
            }
            catch
            {
                throw new Exception("query error");
                MessageBox.Show("Error al ejecutar la query", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Crea un SqlCommand para storeProcedure, despues para ejecutarlo llamo a ExecConsulta(comando);
        /// </summary>
        /// <param name="nombreStoreProcedure"></param>
        /// <returns></returns>
        public SqlCommand CrearComandoStoreProcedure(string nombreStoreProcedure)
        {
            string nombre = "GRUPOSA." + nombreStoreProcedure;
            SqlCommand cmd = new SqlCommand(nombre, Connector);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;

        }
        public SqlCommand CrearComandoQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query, Connector);
            return cmd;
        }
        public string ConWildCard(string original)
        {
            return "%" + original + "%";
        }


        [Obsolete]
        public DataTable EjecutarConsultaSql(string consultaSql)
        {

            DataTable miDataTable = new DataTable();
            try
            {
                SqlConnection conexionSql = Connector;
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
