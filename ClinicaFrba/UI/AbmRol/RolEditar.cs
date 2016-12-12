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
    public partial class RolEditar : FormularioEdicionBase
    {

        private Rol rol;
        public List<Funcionalidad> lstFuncionalidades;
        public List<Rol> lstRoles;
        public UsuarioLogeado usuario;

        public RolEditar()
        {
            InitializeComponent();
            CargarCheckListFuncionalidades(ref checkedListFuncionalidades);
            Show();
        }

        public RolEditar(Rol rol, UsuarioLogeado userr)
        {
            usuario = userr;
            InitializeComponent();
            CargarFormulario(rol);
            Show();

        }

        private void CargarFormulario(Rol rol)
        {
            try
            {
                textBoxNombre.Text = rol.Nombre;
                checkBoxInhabilitar.Checked = Convert.ToBoolean(rol.Estado);
                checkBoxAdmin.Checked = Convert.ToBoolean(rol.EsAdmin);

                DataTable dtFuncionalidades = new DataTable();
                Conexion con = new Conexion();
                dtFuncionalidades = con.SimpleQuery("SELECT Func_Codigo, Func_Desc FROM [GD2C2016].[GRUPOSA].[Funcionalidad]");

                checkedListFuncionalidades.DataSource = dtFuncionalidades;
                checkedListFuncionalidades.DisplayMember = "Func_Desc";
                checkedListFuncionalidades.ValueMember = "Func_Codigo";



                for (int i = 0; i < dtFuncionalidades.Rows.Count; i++)
                {
                    DataRow funcion = dtFuncionalidades.Rows[i]; //todas las funciones
                    Funcionalidad unaFuncion = new Funcionalidad();
                    unaFuncion.Codigo = int.Parse(funcion["Func_Codigo"].ToString());

                    bool estaEnLaColeccion = rol.Funcionalidades.Exists(x => x.Codigo == unaFuncion.Codigo);
                    checkedListFuncionalidades.SetItemChecked(i, estaEnLaColeccion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CargarCheckListFuncionalidades(ref CheckedListBox chk)
        {

            DataTable dtFuncionalidades = new DataTable();
            Conexion con = new Conexion();
            dtFuncionalidades = con.SimpleQuery("SELECT Func_Codigo, Func_Desc FROM [GD2C2016].[GRUPOSA].[Funcionalidad]");

            checkedListFuncionalidades.DataSource = dtFuncionalidades;
            checkedListFuncionalidades.DisplayMember = "Func_Desc";
            checkedListFuncionalidades.ValueMember = "Func_Codigo";

        }
        public void guardarFuncionalidadesRol(int codigo){
          Conexion con = new Conexion();
          foreach (DataRowView item in checkedListFuncionalidades.CheckedItems)
                    {
                        string q = @"INSERT INTO [GRUPOSA].[FuncionalidadesRol]
                                         ([FuncRol_Rol_Codigo],[FuncRol_Func_Codigo])
                                        VALUES (@funcRol_Rol_Codigo,@funcRol_Func_Codigo)";
                        SqlCommand cmd3 = con.CrearComandoQuery(q);
                        cmd3.Parameters.Add("@funcRol_Rol_Codigo", SqlDbType.NVarChar).Value = codigo;
                        cmd3.Parameters.Add("@funcRol_Func_Codigo", SqlDbType.NVarChar).Value = int.Parse(item["Func_Codigo"].ToString());
                        con.ExecConsulta(cmd3);
                    }

        }



        void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion con = new Conexion();
                string q = @"	SELECT R.Rol_Nombre  FROM GRUPOSA.Rol R WHERE R.Rol_Nombre = @nombreRol ";
                SqlCommand cmd1 = con.CrearComandoQuery(q);
                cmd1.Parameters.Add("@nombreRol", SqlDbType.VarChar).Value = textBoxNombre.Text;
                DataTable dt = con.ExecConsulta(cmd1);

                if (dt.Rows.Count > 0)
                {
                    DataTable dtLlena = Rol.llenarDataTable();
                    lstRoles = Rol.MapearDataTableRol(dtLlena);
                    Rol rol = Rol.buscarRol(lstRoles, textBoxNombre.Text);

                    string q2 = @"DELETE FROM [GRUPOSA].[FuncionalidadesRol]
                                    WHERE funcRol_Rol_Codigo=@funcRol_Rol_Codigo";
                    SqlCommand cmd2= con.CrearComandoQuery(q2);
                    cmd2.Parameters.Add("@funcRol_Rol_Codigo", SqlDbType.NVarChar).Value = rol.Codigo;
                    con.ExecConsulta(cmd2);

                    guardarFuncionalidadesRol(rol.Codigo);


                    if ((checkBoxInhabilitar.Checked ? true : false))
                    {
                        SqlCommand cmd3 = con.CrearComandoStoreProcedure("sp_inhabilitarRol");
                        cmd3.Parameters.Add("@rolCodigo", SqlDbType.Decimal).Value = rol.Codigo;
                        con.ExecConsulta(cmd3);


                    }
                    else {
                        SqlCommand cmd4= con.CrearComandoStoreProcedure("sp_habilitarRol");
                        cmd4.Parameters.Add("@rolCodigo", SqlDbType.Int).Value = rol.Codigo;
                        con.ExecConsulta(cmd4);

                    }
                    string q3 = @"UPDATE GRUPOSA.Rol
                                    SET Rol_Es_Administrador = @esAdministrador
                                    WHERE Rol_Nombre = @nombre";
                    SqlCommand cmd5 = con.CrearComandoQuery(q3);
                    cmd5.Parameters.Add("@nombre", SqlDbType.VarChar).Value = textBoxNombre.Text;
                    cmd5.Parameters.Add("@esAdministrador", SqlDbType.Bit).Value = (checkBoxAdmin.Checked ? 1 : 0);
                    con.ExecConsulta(cmd5);
                    if (usuario.Roles.Exists(x => x.Codigo == rol.Codigo))
                    {
                     MessageBox.Show(@"Modifico el Rol que posee el usuario con el que se logueo actualmente, debe cerrar secion y logearse nuevamente para notar los cambios
                        ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                    }


                }
                    else{
                        if (textBoxNombre.Text == "") {
                            MessageBox.Show("Debe ingresar un nombre de rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }


                        SqlCommand cmd6 = con.CrearComandoStoreProcedure("sp_AltaRol");
                        cmd6.Parameters.Add("@nombre", SqlDbType.VarChar).Value = textBoxNombre.Text;
                        cmd6.Parameters.Add("@estado", SqlDbType.Bit).Value = (checkBoxInhabilitar.Checked ? 1 : 0);
                        cmd6.Parameters.Add("@esAdministrador", SqlDbType.Bit).Value = (checkBoxAdmin.Checked ? 1 : 0);
                        con.ExecConsulta(cmd6);

                        DataTable dtLlena = Rol.llenarDataTable();
                        lstRoles = Rol.MapearDataTableRol(dtLlena);
                        Rol rol = Rol.buscarRol(lstRoles, textBoxNombre.Text);

                        guardarFuncionalidadesRol(rol.Codigo);
                        }

                

                MessageBox.Show("Se guardo el rol correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch
            {
                MessageBox.Show("No se guardo el rol correctamente, ya existe un rol con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
















        private void gcAccion_Enter(object sender, EventArgs e)
        {
            
        }
        private void checkBoxAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void checkBoxInhabilitar_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
