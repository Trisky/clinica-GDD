using ClinicaFrba.FormulariosBase;
using ClinicaFrba.Helpers;
using ClinicaFrba.Logica.Entidades;
using ClinicaFrba.UI.MenuPrincipal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.UI._05___Abm_Profesional
{
    public partial class AbmProfesionalListado : FormularioListadoBase
    {
        private PantallaPrincipal pantallaPP;
        public int numeroAccionAdmin { get; set; }

        public AbmProfesionalListado(PantallaPrincipal pp,int numero)
        {
            InitializeComponent();
            btnSeleccionar.Visible = true;
            numeroAccionAdmin = numero;
            pantallaPP = pp;
            Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt;
            Conexion con = new Conexion();
            string s = @"SELECT [Medi_Id] as matricula
                          ,[Medi_Nombre] as nombre
                          ,[Medi_Apellido] as apellido
                          ,[Medi_Dni] as DNI
                          ,[Medi_Sexo] as sexo
                          ,[Medi_Usuario] as usuario
                      FROM [GD2C2016].[GRUPOSA].[Medico]
                      ";
            if (textBoxApellido.Text == "" && textBoxNombre.Text == "")
                dt = con.SimpleQuery(s);
            else
            {
                string q = s +
                             @"where Medi_Nombre like @nombre or
                                     Medi_Apellido like @apellido";
                SqlCommand cmd = con.CrearComandoQuery(q);
                cmd.Parameters.Add(new SqlParameter("@nombre", con.ConWildCard(textBoxNombre.Text)));
                cmd.Parameters.Add(new SqlParameter("@apellido", con.ConWildCard(textBoxApellido.Text)));

                dt = con.ExecConsulta(cmd);
            }

            dgListado.DataSource = dt;
        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            var a = dgListado.SelectedRows[0];
            if (a != null)
            {
                var cells = a.Cells;

                UsuarioLogeado ua = new UsuarioLogeado();
                ua.MedicoMatricula = cells[0].Value.ToString();
                ua.UserName = cells[5].Value.ToString();
                LogInHelper helper = new LogInHelper();
                ua = helper.GetUsuario(ua.UserName);
                pantallaPP.afiliadoSeleccionado(ua,numeroAccionAdmin);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un afiliado", "Afiliado no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Hide();
            Dispose();
        }
    }
}
