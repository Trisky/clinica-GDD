using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Helpers
{
    public static class StaticUtils
    {
        public static bool esNumerico(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private static DateTime ObtenerFechaSistema()
        {
            try
            {
                DateTime fecha = DateTime.Now;
                string fechaString = Convert.ToString(ConfigurationManager.AppSettings["FechaSistema"]);
                fecha = Convert.ToDateTime(fechaString);

                return fecha;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// recibe un string y devuelve el string encriptado con SHA256
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static string Encriptar(string cadena)
        {

            var proveedor = new SHA256Managed();

            byte[] inputBytes = Encoding.UTF8.GetBytes(cadena);
            byte[] hashedBytes = proveedor.ComputeHash(inputBytes);

            StringBuilder salida = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                salida.Append(hashedBytes[i].ToString("x2").ToLower());

            return salida.ToString(); 
        }
        public static bool EsSoloNumerico(string s)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(s, "^[0-9]*$");
        }
        /// <summary>
        /// obtener la fecha del dia en formato string
        /// </summary>
        /// <returns></returns>
        public static string getDate()
        {
            return Convert.ToString(ConfigurationManager.AppSettings["FechaSistema"]);
        }
        /// <summary>
        /// obtener la fecha del dia en formato datetime
        /// </summary>
        /// <returns></returns>
        public static DateTime getDateTime()
        {
            return Convert.ToDateTime(getDate());
        }

        public static object TraducirTipoDNI(object entrada)
        {
            //PASAPORTE = 1,
            //DNI = 2,
            //LC = 3
            string ent = entrada.ToString();
            switch (ent)
            {
                case "1":
                    return "pasaporte";
                case "2":
                    return "DNI";
                case "3":
                    return "LC";
                case "pasaporte":
                    return 1;
                case "DNI":
                    return 2;
                case "LC":
                    return 3;
                default:
                    return "WTF";
            }
        }
        /// <summary>
        /// le das un datatable y devuelve el valor 0 de la col 0
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string getUniqueValueFrom(DataTable d)
        {
            string field = d.Rows[0].Field<string>(0);
            if (field == null)
            {
                return "0";
            }
            return field;
        }

        //<summary>
        //se fija si el usuario selecciono algo en el combobox, si no lo seleccionó, avisa.
        public static bool CheckSelectedValueCB(ComboBox cb)
        {
            string s = "--SELECCIONE--";
            if (cb.SelectedValue == s){
                
                return false;
            }
                
            else
                return true;
        }

        


        public static bool checkControls(Control.ControlCollection controles)
        {

            foreach (Control control in controles)
            {
                if (string.IsNullOrWhiteSpace(control.Text))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
