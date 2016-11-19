using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Logica;
using System.Data;
using ClinicaFrba.Helpers;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ClinicaFrba.Logica.Roles
{
    public class Rol
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public List<Funcionalidad> Funcionalidades{get;set; }
        public string Estado { get; set; }
        public string EsAdmin { get; set; }
        public string EstadoString { get; set; }

        


        public static List<Rol> MapearDataTableRol(DataTable dtRoles)
        {
            List<Rol> lstRoles = dtRoles.AsEnumerable().Select(row =>
            new Rol
            {
                Codigo = Convert.ToInt32(Convert.ToString(row["Rol_Codigo"])),
                Nombre = Convert.ToString(row["Rol_Nombre"]),
                Estado = Convert.ToString(row["Rol_Estado"]),
                EsAdmin = Convert.ToString(row["Rol_Es_Administrador"])

            }).ToList();






            return lstRoles;
        }

        public static Rol buscarRol(List<Rol> lstRoles, string nombreDeRol)
        {
            Rol rol = new Rol();
            foreach (Rol rolAEncontrar in lstRoles)
            {

                if (rolAEncontrar.Nombre == nombreDeRol)
                {
                    return rolAEncontrar;
                }
            }
            return rol;
        }

        public static DataTable llenarDataTable()
        {
            DataTable dt;
            Conexion con = new Conexion();
            dt = con.SimpleQuery("SELECT * FROM [GD2C2016].[GRUPOSA].[Rol]");


            return dt;

        }


        public static List<Rol> MapearDataTableRolyFunc(DataTable dtRoles)
        {
            List<Rol> lstRoles = dtRoles.AsEnumerable().Select(row =>
            new Rol
            {
                Codigo = Convert.ToInt32(Convert.ToString(row["Rol_Codigo"])),
                Nombre = Convert.ToString(row["Rol_Nombre"]),
                Estado = Convert.ToString(row["Rol_Estado"]),
                EsAdmin = Convert.ToString(row["Rol_Es_Administrador"])

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



        public static Rol rolConSusFuncionalidades(string nomRol)
        {
            //try
            //{
                DataTable dt;
                Conexion con = new Conexion();
                dt = con.SimpleQuery(@"SELECT R.Rol_Codigo,R.Rol_Nombre,R.Rol_Estado,R.Rol_Es_Administrador,FR.FuncRol_Rol_Codigo,F.Func_Codigo,F.Func_Desc
	                                
                                    FROM [GRUPOSA].[Rol] R
	                                LEFT JOIN [GRUPOSA].[FuncionalidadesRol] FR ON FR.[FuncRol_Rol_Codigo] = R.[Rol_Codigo]
	                                LEFT JOIN [GRUPOSA].[Funcionalidad] F ON FR.[FuncRol_Func_Codigo] = F.Func_Codigo");

                List<Rol> lstRoles = MapearDataTableRolyFunc(dt);
 
foreach (Rol r in lstRoles)
                {
                    if (r.Nombre == nomRol)
                    {
                        return r;
                    }
                }
                Rol rol = new Rol();
                return rol;
            //}
            //catch {
            //    MessageBox.Show("No se agrego el rol correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        
        }







        //public Rol()
        //{
        //    //El listado total de funcionalidades del sistema es fijo y no varía
        //    this.Funcionalidades = new List<Funcionalidad>();
        //}


        //private List<Rol> MapearDataTableLista(DataTable dtRoles)
        //{
        //    List<Rol> lstRoles = new List<Rol>();

        //    try
        //    {
        //        lstRoles = (from x in dtRoles.AsEnumerable()
        //                    select new Rol
        //                    {
        //                        Codigo = Convert.ToInt32(Convert.ToString(x["Rol_Codigo"])),
        //                        Nombre = Convert.ToString(x["Rol_Nombre"]),
        //                        EsAdmin = Convert.ToBoolean(x["Rol_Es_Administrador"]),
        //                        Estado = Convert.ToBoolean(x["Rol_Estado"])
        //                    }).ToList();

        //        lstRoles = lstRoles.GroupBy(a => a.Codigo).Select(g => g.First()).ToList();

        //        //Cargo las funcionalidades de cada Rol
        //        foreach (Rol r in lstRoles)
        //        {
        //            List<Funcionalidad> lstFuncionalidades = new List<Funcionalidad>();

        //            lstFuncionalidades = (from x in dtRoles.AsEnumerable()
        //                                  where Convert.ToInt32(Convert.ToString(x["Rol_Codigo"])) == r.Codigo
        //                                       && x["Func_Codigo"] != DBNull.Value
        //                                  select new Funcionalidad
        //                                  {
        //                                      Codigo = Convert.ToInt32(Convert.ToString(x["Func_Codigo"])),
        //                                      Descripcion = Convert.ToString(x["Func_Desc"])
        //                                  }).ToList();

        //            r.Funcionalidades = lstFuncionalidades;
        //        }
        //        return lstRoles;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }


        //}


    }
}
