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
        public List<string> diasDeAtencion(string idMedico)
        {
            List<string> list = new List<string>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoQuery("select * from horarios");
            cmd.Parameters.Add("@id_medico", SqlDbType.NVarChar).Value = idMedico;
            DataTable dias = con.ExecConsulta(cmd);

            for (int i = 0; i < dias.Rows.Count; i++ )
            {
                //
            }
                
            return list;
        }

    }


}
