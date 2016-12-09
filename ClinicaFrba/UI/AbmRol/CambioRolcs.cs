using ClinicaFrba.FormulariosBase;
using ClinicaFrba.Helpers;
using ClinicaFrba.Logica.Entidades;
using ClinicaFrba.Logica.Roles;
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

namespace ClinicaFrba.UI.AbmRol
{
    public partial class CambioRol : FormBase
    {
        UsuarioLogeado usuario;
        public CambioRol(UsuarioLogeado user)
        {

            usuario = user;
            InitializeComponent();
            ComboBoxManager cm = new ComboBoxManager();
            comboBox1 = cm.cargarRoles(comboBox1);
            textBox1.Text = user.UserName;
            Show();

        }


        private void button1Aceptar_Click(object sender, EventArgs e)
        {
            Rol rol = new Rol();
            rol = usuario.Roles.Find(s => s.Codigo != -1);
            DataTable dt;
            Conexion con = new Conexion();
            string q = @"   UPDATE [GD2C2016].[GRUPOSA].[RolesUsuario]
                            SET RolUsu_Rol_Codigo = @user_rolNuevo
                            WHERE RolUsu_Usuario_Username =@user_nom and
                            RolUsu_Rol_Codigo = @user_rolAnterior";
            SqlCommand cmd = con.CrearComandoQuery(q);
            cmd.Parameters.Add(new SqlParameter("@user_rolAnterior", rol.Codigo));
            cmd.Parameters.Add(new SqlParameter("@user_nom", usuario.UserName));
            cmd.Parameters.Add(new SqlParameter("@user_rolNuevo", comboBox1.SelectedValue));
            dt = con.ExecConsulta(cmd);

            Dispose();

        }


        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CambioRol_Load(object sender, EventArgs e)
        {

        }




    }
}
