using ClinicaFrba.Logica.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Helpers;
using ClinicaFrba;
using System.Data.SqlClient;
using ClinicaFrba.UI.AbmRol;



namespace ClinicaFrba.AbmRol
{
    public partial class ListaDeRoles : Form
    {

        public ListaDeRoles()
        {
            InitializeComponent();
            Show();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Agregar(object sender, EventArgs e)
        {
            RolEditar rolNuevo = new RolEditar();
        }

        private void button_Eliminar(object sender, EventArgs e)
        {
            
                
        }

        private void button_Modificar(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_Busqueda(object sender, EventArgs e)
        {
            DataTable dt;
            Conexion con = new Conexion();
            if (nombreRol.Text == "")
                dt = con.SimpleQuery("SELECT Rol_Codigo,Rol_Nombre FROM [GD2C2016].[GRUPOSA].[Rol]");
            else
            {
                string q = @"SELECT Rol_Codigo,Rol_Nombre FROM [GD2C2016].[GRUPOSA].[Rol]
                             where Rol_nombre like @rolBusqueda ";
                SqlCommand cmd = con.CrearComandoQuery(q);
                cmd.Parameters.Add(new SqlParameter("@rolBusqueda", con.ConWildCard(nombreRol.Text)));

                dt = con.ExecConsulta(cmd);
            }


            dataGridView1.DataSource = dt;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
