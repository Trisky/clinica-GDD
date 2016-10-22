using ClinicaFrba.Helpers;
using ClinicaFrba.UI._05___Abm_Profesional;
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

namespace ClinicaFrba.UI._04___Abm_Afiliado
{
    public partial class AbmAfiliadoListar : FormulariosBase.FormularioListadoBase
    {
        public AbmAfiliadoListar()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            SqlCommand cmd =  con.CrearComandoQuery("SELECT * FROM [GD2C2016].[GRUPOSA].[Pacientes]");

            DataTable dt = con.ExecConsulta(cmd);
            //dgListado.DataSource = null;
            //dgListado.ColumnCount = 4;
            //dgListado.AutoGenerateColumns = false;
            //dgListado.Columns[0].Name = "Username";
            //dgListado.Columns[0].DataPropertyName = "Username";
            //dgListado.Columns[0].Width = 200;
            //dgListado.Columns[1].Name = "Fecha creación";
            //dgListado.Columns[1].DataPropertyName = "FechaCreacion";
            //dgListado.Columns[1].Width = 200;
            //dgListado.Columns[2].Name = "Fecha última modificacion";
            //dgListado.Columns[2].DataPropertyName = "FechaUltimaModificacion";
            //dgListado.Columns[2].Width = 200;
            //dgListado.Columns[3].Name = "Inhabilitado";
            //dgListado.Columns[3].DataPropertyName = "InhabilitadoString";
            //dgListado.Columns[3].Width = 157;
            dgListado.DataSource = dt;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var a = dgListado.SelectedRows[0];
            AbmAfiliadoCrear afi = new AbmAfiliadoCrear(a);
        }
    }
}
