using ClinicaFrba.Helpers;
using ClinicaFrba.Logica.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Logica.Entidades
{
    public class UsuarioLogeado
    {
        public string UserName { get; set; }
        public string password { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string PreguntaSecreta { get;  set; }
        public string RespuestaSecreta { get;  set; }
        public DateTime FechaCreacion { get;  set; }
        public DateTime FechaUltimaModificacion { get;  set; }
        public int CantidadIntentosFallidos { get;  set; }
        public bool Inhabilitado { get;  set; }
        public int GrupoFamiliar { get; set; }

        public List<Rol> Roles { get; set; }
        public List<Funcionalidad> FuncionalidadesRolSeleccionado { get; set; }

        public UsuarioLogeado()
        {
            GrupoFamiliar = 0;
        }

        public List<Rol> GetRoles()
        {
            throw new NotImplementedException();
        }

        public  List<Funcionalidad> GetFuncionalidades(Rol rol)
        {
            throw new NotImplementedException();
        }
    }
}
