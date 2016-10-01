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


namespace ClinicaFrba.AbmRol
{
    public partial class ListaDeRoles : Form
    {

        private List<Rol> lstRoles;
        Dictionary<string, object> lstFiltros;

        public ListaDeRoles()
        {
            
            InitializeComponent();


        }



        //public void CargarGrilla()
        //{
        //    try
        //    {
        //        lstFiltros = ObtenerFiltros();

        //        dgListado.DataSource = null;
        //        miRolNegocio = new RolNegocio();
        //        lstRoles = miRolNegocio.ObtenerRoles(lstFiltros);
        //        dgListado.ColumnCount = 3;
        //        dgListado.AutoGenerateColumns = false;
        //        dgListado.Columns[0].Name = "Código";
        //        dgListado.Columns[0].DataPropertyName = "Codigo";
        //        //dgListado.Columns[0].Visible = false;
        //        dgListado.Columns[1].Name = "Nombre";
        //        dgListado.Columns[1].DataPropertyName = "Nombre";
        //        dgListado.Columns[1].Width = 200;
        //        dgListado.Columns[2].Name = "Estado";
        //        dgListado.Columns[2].DataPropertyName = "EstadoString";
        //        dgListado.Columns[2].Width = 129;

        //        //Agrego la colección a la grilla.
        //        dgListado.DataSource = lstRoles;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}









        private Dictionary<string, object> ObtenerFiltros(){

            Dictionary<string, object> lstFiltros = new Dictionary<string, object>();
            
            if (!string.IsNullOrEmpty(textBox1.Text)){
                lstFiltros.Add("Nombre", textBox1.Text);
            }
            return lstFiltros;
        }










        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Agregar(object sender, EventArgs e)
        {

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




        }
    }
}
