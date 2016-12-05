using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;
using ClinicaFrba.Helpers;
using ClinicaFrba.Logica.Entidades;
using ClinicaFrba.FormulariosBase;

namespace ClinicaFrba.UI._13___Cancelar_Atencion
{
    class BajaAtencion
    {
        public DateTime[] obtenerFechas(string medico, DateTime diaSeleccionado){
            List<string> list = new List<string>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_obtenerDiasDeAtencion");
            cmd.Parameters.Add("@id_medico", SqlDbType.VarChar).Value = medico;
            DataTable dias = con.ExecConsulta(cmd);
            foreach (DataRow item in dias.Rows){
                list.Add(Convert.ToString(item[0]));
            }
            int cantDias = DateTime.DaysInMonth(diaSeleccionado.Year, diaSeleccionado.Month) - diaSeleccionado.Day;
            DateTime[] fechas = new DateTime[cantDias + 1];
            foreach (string day in list){
                for (int i = 0; i <= cantDias; i++){
                    string dia = diaSeleccionado.AddDays(i).ToString("dddd", new CultureInfo("es-ES"));
                    if (String.Equals(dia, day, StringComparison.CurrentCultureIgnoreCase)){
                        fechas[i] = diaSeleccionado.AddDays(i);
                    }
                }
            }
            return fechas;
        }

        public DateTime[] obtenerFechas(string medico, string especialidad, DateTime diaSeleccionado)
        {
            List<string> list = new List<string>();
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_obtenerDiasDeAtencion2");
            cmd.Parameters.Add("@id_medico", SqlDbType.VarChar).Value = medico;
            cmd.Parameters.Add("@especialidad", SqlDbType.VarChar).Value = especialidad;
            DataTable dias = con.ExecConsulta(cmd);
            foreach (DataRow item in dias.Rows){
                list.Add(Convert.ToString(item[0]));
            }
            int cantDias = DateTime.DaysInMonth(diaSeleccionado.Year, diaSeleccionado.Month) - diaSeleccionado.Day;
            DateTime[] fechas = new DateTime[cantDias + 1];
            foreach (string day in list){
                for (int i = 0; i <= cantDias; i++){
                    string dia = diaSeleccionado.AddDays(i).ToString("dddd", new CultureInfo("es-ES"));
                    if (String.Equals(dia, day, StringComparison.CurrentCultureIgnoreCase)){
                        fechas[i] = diaSeleccionado.AddDays(i);
                    }
                }
            }
            return fechas;
        }
        

        public DataTable bajaTurnosMedico(string dia, string dia2,string medico, string descripcion){
            DataTable dt = null;
            try{
                Conexion con = new Conexion();
                List<DateTime> list = new List<DateTime>();
                List<string> list2 = new List<string>();
                SqlCommand cmd = con.CrearComandoStoreProcedure("sp_obtenerDiasDeAtencion");
                cmd.Parameters.Add("@id_medico", SqlDbType.VarChar).Value = medico;
                DataTable days = con.ExecConsulta(cmd);
                foreach (DataRow day in days.Rows){
                    list2.Add(Convert.ToString(day[0]).ToUpper());
                }
              
                cmd = con.CrearComandoStoreProcedure("sp_bajaTurnosMedico");
                cmd.Parameters.Add("@fechaDesde", SqlDbType.VarChar).Value = dia.ToString();
                cmd.Parameters.Add("@fechaHasta", SqlDbType.VarChar).Value = dia2.ToString();
                cmd.Parameters.Add("@idMedico", SqlDbType.VarChar).Value = medico;
                cmd.Parameters.Add("@motivo", SqlDbType.VarChar).Value = descripcion;
                cmd.Parameters.Add("@fechaHoy", SqlDbType.DateTime).Value = StaticUtils.getDateTime();
                dt = con.ExecConsulta(cmd);
            }
             
            catch (Exception ex){
                Console.WriteLine(ex.ToString());
            }
            return dt;

        }
    }
}
