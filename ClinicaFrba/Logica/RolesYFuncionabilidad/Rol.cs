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
        public bool Estado { get; set; }
        public bool EsAdmin { get; set; }
        public string EstadoString { get; set; }

        public Rol()
        {
            //El listado total de funcionalidades del sistema es fijo y no varía
            this.Funcionalidades = new List<Funcionalidad>();
        }


        private List<Rol> MapearDataTableLista(DataTable dtRoles)
        {
            List<Rol> lstRoles = new List<Rol>();

            try
            {
                lstRoles = (from x in dtRoles.AsEnumerable()
                            select new Rol
                            {
                                Codigo = Convert.ToInt32(Convert.ToString(x["Rol_Codigo"])),
                                Nombre = Convert.ToString(x["Rol_Nombre"]),
                                EsAdmin = Convert.ToBoolean(x["Rol_Es_Administrador"]),
                                Estado = Convert.ToBoolean(x["Rol_Estado"])
                            }).ToList();

                lstRoles = lstRoles.GroupBy(a => a.Codigo).Select(g => g.First()).ToList();

                //Cargo las funcionalidades de cada Rol
                foreach (Rol r in lstRoles)
                {
                    List<Funcionalidad> lstFuncionalidades = new List<Funcionalidad>();

                    lstFuncionalidades = (from x in dtRoles.AsEnumerable()
                                          where Convert.ToInt32(Convert.ToString(x["Rol_Codigo"])) == r.Codigo
                                               && x["Func_Codigo"] != DBNull.Value
                                          select new Funcionalidad
                                          {
                                              Codigo = Convert.ToInt32(Convert.ToString(x["Func_Codigo"])),
                                              Descripcion = Convert.ToString(x["Func_Desc"])
                                          }).ToList();

                    r.Funcionalidades = lstFuncionalidades;
                }
                return lstRoles;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


    }
}
