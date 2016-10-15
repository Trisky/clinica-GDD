using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Helpers
{
    public static class Encriptador
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
    }
}
