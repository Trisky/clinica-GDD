using ClinicaFrba.Logica.Entidades;
using ClinicaFrba.Logica.Roles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Helpers
{
    public  class ComboBoxManager
    {


        //ComboBox CrearComboSexo(ComboBox combo)
        //{
        //    DataTable dataTable = new DataTable();
        //    DataRow row = dataTable.NewRow();
        //    row["sexo"] = SELECCIONE;
        //    dataTable.Rows.InsertAt(row, 0);
        //    return combo;
        //}
        public ComboBox CrearEstadoCivil(ComboBox cbEstadoCiv)
        {
            Conexion con = new Conexion();
            const string query = "SELECT * FROM [GD2C2016].[GRUPOSA].[EstadoCivil]";
            SqlCommand cmd = con.CrearComandoQuery(query);
            DataTable dt = con.ExecConsulta(cmd);
            DataRow row = dt.NewRow();
            row["EstadoCivil_Id"] = -1;
            row["EstadoCivil_Desc"] = "--SELECCIONE--";
            dt.Rows.InsertAt(row, 0);
            cbEstadoCiv.DisplayMember = "EstadoCivil_Desc";
            cbEstadoCiv.ValueMember = "EstadoCivil_Desc";
            cbEstadoCiv.DataSource = dt;

            return cbEstadoCiv;

        }

        internal ComboBox CrearEspecialidades(ComboBox comboBoxEspecialidad,UsuarioLogeado user)
        {
            Conexion con = new Conexion();
            const string query = @"
  select * from [GD2C2016].[GRUPOSA].[MedicoEspecialidad] inner join [GD2C2016].[GRUPOSA].[Especialidades] on MedEspe_Espe_Cod = Espe_Cod

  where MedEspe_Medi_Id = @idMedico";

            SqlCommand cmd = con.CrearComandoQuery(query);
            cmd.Parameters.Add("@idMedico", SqlDbType.NVarChar).Value = user.MedicoMatricula;
            DataTable dt = con.ExecConsulta(cmd);
            DataRow row = dt.NewRow();
            row["Espe_Cod"] = -1;
            row["Espe_Desc"] = "--SELECCIONE--";
            dt.Rows.InsertAt(row, 0);
            comboBoxEspecialidad.DisplayMember = "Espe_Desc";
            comboBoxEspecialidad.ValueMember = "Espe_Cod";
            comboBoxEspecialidad.DataSource = dt;

            return comboBoxEspecialidad; 
            throw new NotImplementedException();
        }


        internal ComboBox CrearEspecialidades(ComboBox comboBoxEspecialidad)
        {
            Conexion con = new Conexion();
            const string query = @"select * from [GD2C2016].[GRUPOSA].[Especialidades] ";
            SqlCommand cmd = con.CrearComandoQuery(query);
            DataTable dt = con.ExecConsulta(cmd);
            DataRow row = dt.NewRow();
            row["Espe_Cod"] = -1;
            row["Espe_Desc"] = "--SELECCIONE--";
            dt.Rows.InsertAt(row, 0);
            comboBoxEspecialidad.DisplayMember = "Espe_Desc";
            comboBoxEspecialidad.ValueMember = "Espe_Cod";
            comboBoxEspecialidad.DataSource = dt;

            return comboBoxEspecialidad;
            throw new NotImplementedException();
        }



        /// <summary>
        /// obtiene todos los planes medicos disponibles y los pone en el comboBox mediante un datatable
        /// </summary>
        /// <param name="combo"></param>
        /// <returns></returns>
        public ComboBox CrearPlanesMedicos(ComboBox combo)
        {
            Conexion con = new Conexion();
            const string query = "SELECT * FROM [GD2C2016].[GRUPOSA].[PlanesMedicos]";
            SqlCommand cmd =  con.CrearComandoQuery(query);
            DataTable  dt = con.ExecConsulta(cmd);
            DataRow row = dt.NewRow();
            row["Plan_Codigo"] = -1;
            row["Plan_Descripcion"] = "--SELECCIONE--";
            dt.Rows.InsertAt(row, 0);
            combo.DisplayMember = "Plan_Descripcion";
            combo.ValueMember = "Plan_Codigo";
            combo.DataSource = dt;

            return combo;
        }
        public ComboBox CrearTiposDni(ComboBox combo)
        {
            Conexion con = new Conexion();
            const string query = "SELECT * FROM [GD2C2016].[GRUPOSA].[TipoDocumento]";
            SqlCommand cmd = con.CrearComandoQuery(query);
            DataTable dt = con.ExecConsulta(cmd);
            DataRow row = dt.NewRow();
            row["Tipo_Doc_Cod"] = -1;
            row["Tipo_Doc_Desc"] = "--SELECCIONE--";
            dt.Rows.InsertAt(row, 0);
            combo.DisplayMember = "Tipo_Doc_Desc";
            combo.ValueMember = "Tipo_Doc_Desc";
            combo.DataSource = dt;
            return combo;
        }
        public ComboBox CrearDias(ComboBox combo)
        {
            combo.DataSource = Enum.GetValues(typeof(TipoUsuarioEnum.DiaSemana));
            return combo;
        }

        internal ComboBox ListarMedicos(string especialidad, ComboBox comboBoxEspecialidad)
        {

            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_medicosEspecialidad");
            cmd.Parameters.Add("@id_especialidad", SqlDbType.NVarChar).Value = especialidad;
            DataTable dt = con.ExecConsulta(cmd);
            DataRow row = dt.NewRow();
            row["MedEspe_Medi_Id"] = -1;
            row["medico"] = "--SELECCIONE--";
            dt.Rows.InsertAt(row, 0);
            comboBoxEspecialidad.DisplayMember = "medico";
            comboBoxEspecialidad.ValueMember = "MedEspe_Medi_Id";
            comboBoxEspecialidad.DataSource = dt; 
            
            return comboBoxEspecialidad;
            throw new NotImplementedException();
        }


        //Roles del usuario
        public ComboBox cargarRoles(UsuarioLogeado user, ComboBox combo)
        {
            DataTable dtRol;
            DataRow row;

                Conexion con = new Conexion();
                string q = @"  select Rol_Nombre,Rol_Codigo from [GD2C2016].[GRUPOSA].[RolesUsuario] inner join [GD2C2016].[GRUPOSA].[Rol] On 
                                RolUsu_Rol_Codigo = Rol.Rol_Codigo
                                where RolUsu_Usuario_Username = @nombre";
                SqlCommand cmd3 = con.CrearComandoQuery(q);
                cmd3.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = user.UserName;
                dtRol = con.ExecConsulta(cmd3);

                row = dtRol.NewRow();
                dtRol.Rows.InsertAt(row, 0);
                combo.DisplayMember = "Rol_Nombre";
                combo.ValueMember = "Rol_Codigo";
                combo.DataSource = dtRol;
            
            return combo;
        }

        //Todos los roles
        public ComboBox cargarRoles(ComboBox combo)
        {
            DataTable dtRol;
            DataRow row;

            Conexion con = new Conexion();
            string q = @"  select * from [GD2C2016].[GRUPOSA].[Rol] ";
            SqlCommand cmd3 = con.CrearComandoQuery(q);
            dtRol = con.ExecConsulta(cmd3);

            row = dtRol.NewRow();
            dtRol.Rows.InsertAt(row, 0);
            combo.DisplayMember = "Rol_Nombre";
            combo.ValueMember = "Rol_Codigo";
            combo.DataSource = dtRol;

            return combo;
        }

    }
}
