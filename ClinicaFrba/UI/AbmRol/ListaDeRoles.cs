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
using ClinicaFrba.UI._04___Abm_Afiliado;
using ClinicaFrba.Logica.Entidades;



namespace ClinicaFrba.AbmRol
{
    public partial class ListaDeRoles : Form
    {

        private List<Rol> lstRoles;
        UsuarioLogeado usuario;
        public ListaDeRoles(UsuarioLogeado user)
        {

            InitializeComponent();
            usuario = user;
            buttonLimpiar.Enabled = false;
            buttonEliminar.Enabled = false;
            buttonModificar.Enabled = false;
            Show();
        }


//Si no se selecciona una fila el boton de modificar agrega un rol nuevo
        private void button_Modificar(object sender, EventArgs e)
        {
            if (dataGridViewRoles.SelectedRows.Count != 0)
            {
                Rol miRol = new Rol();
                DataGridViewRow miFilaSeleccionada = dataGridViewRoles.SelectedRows[0];
                string nomRol = Convert.ToString(miFilaSeleccionada.Cells[1].Value);
                Rol rol = Rol.rolConSusFuncionalidades(nomRol);
                RolEditar rolEditar = new RolEditar(rol,usuario);
            }
            else {
                MessageBox.Show("No se selecciono ningun Rol se dara de alta uno nuevo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RolEditar rolNuevo = new RolEditar();
            }
        }          
        private void button_Agregar(object sender, EventArgs e)
        {
            RolEditar rolNuevo = new RolEditar();
        }
        private void button_Eliminar(object sender, EventArgs e)
        {
            try{
            DataTable dt;
            Conexion con = new Conexion();

            DataGridViewRow miFilaSeleccionada = dataGridViewRoles.SelectedRows[0];
            int codigoRol = Convert.ToInt32(miFilaSeleccionada.Cells[0].Value);

            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_inhabilitarRol");
            cmd.Parameters.Add("@rolCodigo", SqlDbType.Decimal).Value = codigoRol;
            dt = con.ExecConsulta(cmd);

                MessageBox.Show("Se realizo baja logica correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch
            {
                MessageBox.Show("No se realizo baja logica correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridViewRoles.DataSource = null;
            nombreRol.Text = string.Empty;
        }
        private void button_Busqueda(object sender, EventArgs e)
        {

            buttonLimpiar.Enabled = true;
            buttonEliminar.Enabled = true;
            buttonModificar.Enabled = true;
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


            dataGridViewRoles.DataSource = dt;
         }


        // ListaDeRoles A = new ListaDeRoles();

//        using ClinicaFrba.Logica.Entidades;
//﻿using ClinicaFrba.AbmRol;
//using ClinicaFrba.FormulariosBase;
//using ClinicaFrba.Logica.Entidades;

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

        private void button2_Click(object sender, EventArgs e)
        {
            BuscarUsuarioParaRol pedirTurno = new BuscarUsuarioParaRol(this);
            Dispose();
        }


        public void modificarRolUsuario(UsuarioLogeado user) {


            CambioRol cambiarRol = new CambioRol(user);
        
        
        
        }


 
    }
}
