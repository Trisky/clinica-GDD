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
            comboBox1 = cm.cargarRoles(comboBox1,user);
            textBox1.Text = user.UserName;
            Show();

        }


        private void button1Aceptar_Click(object sender, EventArgs e)
        {

            DataTable dt;
            Conexion con = new Conexion();
            string q = @"   Insert Into [GD2C2016].[GRUPOSA].[RolesUsuario]
                            values (@user_rolNuevo,@user_nom) ";
            SqlCommand cmd = con.CrearComandoQuery(q);
            cmd.Parameters.Add(new SqlParameter("@user_nom", usuario.UserName));
            cmd.Parameters.Add(new SqlParameter("@user_rolNuevo", comboBox1.SelectedValue));
            dt = con.ExecConsulta(cmd);



            MessageBox.Show("Se agrego el rol al usuario correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
