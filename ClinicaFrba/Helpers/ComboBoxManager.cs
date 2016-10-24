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
        public ComboBox CrearEstadoCivil(ComboBox combo)
        {
            //HACER EL COMBO BOX DE ESTADO CIVIL
            List<EstadoCivil> lstEstadoCivil = new List<EstadoCivil>();
            lstEstadoCivil.Add(new EstadoCivil("Soltero", 0));
            lstEstadoCivil.Add(new EstadoCivil("Casado", 1));
            lstEstadoCivil.Add(new EstadoCivil("Divorciado", 2));
            lstEstadoCivil.Add(new EstadoCivil("Viudo", 3));
            lstEstadoCivil.Add(new EstadoCivil("Concubinato", 4));
            lstEstadoCivil.Add(new EstadoCivil("-SELECCIONE-", 5));

            combo.DataSource = lstEstadoCivil;
            combo.ValueMember = "valor";
            combo.DisplayMember = "nombre";
            combo.SelectedValue = 5;
    
            return combo;
        }

        internal ComboBox CrearEspecialidades(ComboBox comboBoxEspecialidad)
        {
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
            combo.ValueMember = "Tipo_Doc_Cod";
            combo.DataSource = dt;
            return combo;
        }
        public ComboBox CrearDias(ComboBox combo)
        {
            combo.DataSource = Enum.GetValues(typeof(Enums.DiaSemana));
            return combo;
        }

    }
}
