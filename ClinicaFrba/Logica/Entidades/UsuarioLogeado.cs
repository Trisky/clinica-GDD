using ClinicaFrba.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ClinicaFrba.Logica.Entidades
{
    public class UsuarioLogeado
    {




        public string UserName { get; set; }
        public string password { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string PreguntaSecreta { get; private set; }
        public string RespuestaSecreta { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime FechaUltimaModificacion { get; private set; }
        public int CantidadIntentosFallidos { get; private set; }
        public bool Inhabilitado { get; private set; }

        public UsuarioLogeado GetUsuario(string usuarioIngresado, string passwordIngresado)
        {
            Conexion con = new Conexion();
            string asd = "select * from GRUPOSA.Usuario where Usuario_Username=" + usuarioIngresado + "and Usuario_Password=" + passwordIngresado;
            DataTable usuarios = con.EjecutarConsultaSql(asd);
            if (usuarios.Rows.Count > 1)
                throw new Exception("mas de un usuario encontrado");
            DataRow usuario = usuarios.Rows[0];
            return MapearDataTableLista(usuarios);

        }
        public UsuarioLogeado() { }

        private UsuarioLogeado MapearDataTableLista(DataTable dtUsuarios)
        {
            List<UsuarioLogeado> lstUsuarios = new List<UsuarioLogeado>();
            try
            {



                lstUsuarios = (from x in dtUsuarios.AsEnumerable()
                               select new UsuarioLogeado
                               {
                                   UserName = Convert.ToString(x["Usuario_Username"] ?? string.Empty),
                                   password = Convert.ToString(x["Usuario_Password"] ?? string.Empty),
                                   PreguntaSecreta = Convert.ToString(x["Usuario_Pregunta_Secreta"] ?? string.Empty),
                                   RespuestaSecreta = Convert.ToString(x["Usuario_Respuesta_Secreta"] ?? string.Empty),
                                   FechaCreacion = Convert.ToDateTime(Convert.ToString(x["Usuario_Fecha_Creacion"] ?? string.Empty)),
                                   FechaUltimaModificacion = (x["Usuario_Fecha_Ultima_Modificacion"] == DBNull.Value || Convert.ToDateTime(x["Usuario_Fecha_Ultima_Modificacion"]) == SqlDateTime.MinValue.Value) ? DateTime.MinValue : Convert.ToDateTime(Convert.ToString(x["Usuario_Fecha_Ultima_Modificacion"])),
                                   CantidadIntentosFallidos = Convert.ToInt32(Convert.ToString(x["Usuario_Intentos_Fallidos"])),
                                   Inhabilitado = Convert.ToBoolean(x["Usuario_Inhabilitado"])
                               }).ToList();

                lstUsuarios = lstUsuarios.GroupBy(a => a.UserName).Select(g => g.First()).ToList();


            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al intentar realizar el logueo. Por favor, intente nuevamente.", "Error Login", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return lstUsuarios.First();
        }
    }
}
