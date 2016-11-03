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

        private List<Rol> lstRoles;
        public ListaDeRoles()
        {
            InitializeComponent();
            Show();
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



        private void button_Modificar(object sender, EventArgs e)
        {

        }
        private void button_Agregar(object sender, EventArgs e)
        {
            RolEditar rolNuevo = new RolEditar();
        }





        private void button_Eliminar(object sender, EventArgs e)
        {
            DataTable dt;
            Conexion con = new Conexion();

            Rol miRol = new Rol();

            DataGridViewRow miFilaSeleccionada = dataGridView1.SelectedRows[0];
            int codigoRol = Convert.ToInt32(miFilaSeleccionada.Cells[0].Value);

            string q = @"UPDATE [GD2C2016].[GRUPOSA].[Rol]
                         SET Rol_Estado = 1
                         WHERE Rol_Codigo = @codigoRol";

            SqlCommand cmd = con.CrearComandoQuery(q);
            cmd.Parameters.Add(new SqlParameter("@codigoRol", codigoRol));
            dt = con.ExecConsulta(cmd);

        }
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            nombreRol.Text = string.Empty;
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
            //lstRoles = MapearDataTableLista(dt);

        }






        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
 
    }
}
