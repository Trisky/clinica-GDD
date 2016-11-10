using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClinicaFrba.Helpers;
using System.Data.SqlClient;

namespace ClinicaFrba.UI._10___Pedir_Turno
{
    class ConfirmarTurno
    {
        public List<string> diasDeAtencion(string userName)
        {
            List<string> list = new List<string>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_obtenerDiasDeAtencion");
            cmd.Parameters.Add("@usr_medico", SqlDbType.NVarChar).Value = userName;
            DataTable dias = con.ExecConsulta(cmd);

            foreach (DataRow item in dias.Rows)
            {
                list.Add(Convert.ToString(item[0]));
            }
                
            return list;
        }

    }


}
