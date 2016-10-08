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
    class Rol
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public List<Funcionalidad> Funcionalidades{get;set; }
        public char Estado { get; set; }
        public char EsAdmin { get; set; }
        public string EstadoString { get; set; }
        private Conexion coneccion;

        public Rol()
        {
            //El listado total de funcionalidades del sistema es fijo y no varía
            this.Funcionalidades = new List<Funcionalidad>();
        }


        //public List<Rol> ObtenerRoles(Dictionary<string, object> filtros)
        //{
        //    try
        //    {
        //        //DataTable dtRoles = new DataTable();
        //        ////Conexion = new Conexion();
        //        ////XDocument filtrosXml = UtilDatos.ArmarFiltrosXml(filtros);
        //        //dtRoles = coneccion.EjecutarProcedure("Sp_ObtenerRoles", filtrosXml, "@filtrosXml");
        //        //List<Rol> lstRoles = MapearDataTableLista(dtRoles);


        //        return lstRoles;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}






    }
}
