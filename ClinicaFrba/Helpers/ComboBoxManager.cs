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

        internal ComboBox CrearEspecialidades(ComboBox comboBoxEspecialidad)
        {
            Conexion con = new Conexion();
            const string query = "SELECT * FROM [GD2C2016].[GRUPOSA].[Especialidades]";
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

    }
}
