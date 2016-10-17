using ClinicaFrba.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ClinicaFrba.Logica.Entidades;

namespace ClinicaFrba.Logica.Entidades
{
    public class LogInHelper
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

        public UsuarioLogeado GetUsuario(string usuarioIngresado, string passwordIngresada)
        {
            string passEncriptada = Encriptador.Encriptar(passwordIngresada);
            //1- defino la query con los @parametros
            const string query = "select * from GRUPOSA.Usuario where Usuario_Username= @username and Usuario_Password= @password";

            //2- creo la conexion con la db
            Conexion conexion = new Conexion();

            //3- creo el comando SQL y le asigno los parametros que hice con @
            SqlCommand comando = new SqlCommand(query, conexion.Connector);
            comando.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = usuarioIngresado;
            comando.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = passEncriptada;

            //4- hago la consulta a la db y me devuelve una tabla.
            DataTable usuarios = conexion.ExecConsulta(comando);

            //5- me fijo que haya traido uno solo por las dudas
            if (usuarios.Rows.Count > 1)
                throw new Exception("mas de un usuario encontrado");
            if (usuarios.Rows.Count == 0)
                return null;
            //6- mapeo la row a la clase  UsuarioLogeado
            return MapearDataTableLista(usuarios);

        }
        

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
