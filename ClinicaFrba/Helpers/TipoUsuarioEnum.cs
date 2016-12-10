using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Helpers
{
    public static class TipoUsuarioEnum
    {
        public enum TipoUsuario { PACIENTE = 0, MEDICO = 1, ADMIN = 2 };
        public enum DiaSemana
        {
            LUNES = 7,
            MARTES = 8,
            MIERCOLES = 9,
            JUEVES = 3,
            VIERNES = 4,
            SABADO = 5
        }
        public enum TipoDni
        {
            PASAPORTE = 1,
            DNI = 2,
            LC = 3
        }
    }
}
