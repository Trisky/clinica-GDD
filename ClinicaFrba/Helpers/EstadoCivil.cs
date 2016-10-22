using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Helpers
{
    public class EstadoCivil
    {
        public string nombre { get; set; }
        public int valor { get; set; }

        public EstadoCivil(string nom, int val)
        {
            nombre = nom;
            valor = val;
        }
    }
}
