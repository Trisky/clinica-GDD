using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Logica.Roles
{
    public class Funcionalidad
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }




        public static Funcionalidades? obtenerPorNombre(Funcionalidad fun)
        {
            if (fun.Descripcion == "ABM de Rol") return Funcionalidades.ABM_Rol;
            if (fun.Descripcion == "ABM de Afiliado") return Funcionalidades.ABM_Afiliado;
            if (fun.Descripcion == "Registro Llegada") return Funcionalidades.RegistroLlegada;
            if (fun.Descripcion == "Pedir Turno") return Funcionalidades.PedirTurno;
            if (fun.Descripcion == "Compra Bono") return Funcionalidades.CompraBono;
            if (fun.Descripcion == "Cancelar Atencion") return Funcionalidades.CancelarAtencion;
            if (fun.Descripcion == "Registro Agenda") return Funcionalidades.RegistrarAgenda;
            if (fun.Descripcion == "Registro Resultado") return Funcionalidades.RegistroResultado;
            if (fun.Descripcion == "Cancelar Turno") return Funcionalidades.CancerlarTurno;
            if (fun.Descripcion == "Listados") return Funcionalidades.Listados;
            if (fun.Descripcion == "Historial Cambio de planes") return Funcionalidades.HistorialCambioDePlanes;
            return null;
        }

    }

    public enum Funcionalidades   //afuera de la clase
    {
        ABM_Rol,
        ABM_Afiliado,
        RegistroLlegada,

        PedirTurno,
        CompraBono,
        CancerlarTurno,
       
        RegistrarAgenda,
        RegistroResultado,
        CancelarAtencion,

        HistorialCambioDePlanes,
        Listados,
    }
    }
