using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Helpers
{
    public class TipoUsuarioEnum
    {
        public enum TipoUsuario { PACIENTE = 0, MEDICO = 1, ADMIN = 2 };
        public enum DiaSemana
        {
            LUNES = 0,
            MARTES = 1,
            MIERCOLES = 2,
            JUEVES = 3,
            VIERNES = 4,
            SABADO = 5
        }
    }
}
