using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Helpers
{
    public static class StaticUtils
    {

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
        public static string getDate()
        {
            return "2016-01-01";
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

    }
}
