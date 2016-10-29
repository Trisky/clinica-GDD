﻿using System;
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
            LUNES = 1,
            MARTES = 2,
            MIERCOLES = 3,
            JUEVES = 4,
            VIERNES = 5,
            SABADO = 6
        }
    }
}
