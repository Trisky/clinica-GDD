using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Logica;
using System.Data;
using ClinicaFrba.Helpers;

namespace ClinicaFrba.Logica.Roles
{
    public class Rol
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public List<Funcionalidad> Funcionalidades{get;set; }
        public char Estado { get; set; }
        public char EsAdmin { get; set; }
        public string EstadoString { get; set; }

        public Rol()
        {
            //El listado total de funcionalidades del sistema es fijo y no varía
            this.Funcionalidades = new List<Funcionalidad>();
        }
    }
}
