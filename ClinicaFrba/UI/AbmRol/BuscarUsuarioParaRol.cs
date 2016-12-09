using ClinicaFrba.AbmRol;
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
    public partial class BuscarUsuarioParaRol : FormularioListadoBase
    {
        private ListaDeRoles vlr;
        
        public BuscarUsuarioParaRol(ListaDeRoles vistaListaRoles)
        {
            vlr = vistaListaRoles;
            InitializeComponent();
            btnModificar.Visible = false;
            btnAgregar.Visible = false;
            btnSeleccionar.Visible = true;
            btnEliminar.Visible = false;
            Show();
        }

        private void BuscarUsuarioParaRol_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt;
            Conexion con = new Conexion();
            string s = @"   select Usuario_Username
                from     [GD2C2016].[GRUPOSA].[Usuario] ";

            if (textBoxNombre.Text == "")
                dt = con.SimpleQuery(s);
            else
            {
                string q = @"  select Usuario_Username
                from     [GD2C2016].[GRUPOSA].[Usuario]  where Usuario_Username like @user_nom";
                SqlCommand cmd = con.CrearComandoQuery(q);

                cmd.Parameters.Add(new SqlParameter("@user_nom", con.ConWildCard(textBoxNombre.Text)));
                dt = con.ExecConsulta(cmd);
            }
            dgListado.DataSource = dt;

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgListado.DataSource = null;
            textBoxNombre.Text = string.Empty;
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {

            var a = dgListado.SelectedRows[0];
            if (a != null)
            {
                var cells = a.Cells;
                UsuarioLogeado ua = new UsuarioLogeado();
                ua.UserName = cells[0].Value.ToString();
                vlr.modificarRolUsuario(ua);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario", "Usuario no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Hide();
            Dispose();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}
