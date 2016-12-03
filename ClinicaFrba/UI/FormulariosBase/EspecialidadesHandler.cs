using ClinicaFrba.Helpers;
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

namespace ClinicaFrba.UI._05___Abm_Profesional
{
    public partial class EspecialidadesHandler : Form
    {
        private List<int> especialidades;

        public EspecialidadesHandler()
        {
            InitializeComponent();
        }

        public EspecialidadesHandler(List<int> especialidades)
        {
            button1.Enabled = false;
            this.especialidades = especialidades;
            Conexion con = new Conexion();
            const string query = "SELECT [Espe_Cod] ,[Espe_Desc],[Espe_Tipo_Cod],[Espe_Tipo_Desc] FROM[GD2C2016].[GRUPOSA].[Especialidades]";
            SqlCommand cmd =  con.CrearComandoQuery(query);

            DataTable dataTableEspecialidades = con.ExecConsulta(cmd);
            if(dataTableEspecialidades.Rows.Count < 1)
            {
                throw new Exception("especialidades no encontradas");
                Close();
            }
            
            
        }

        public void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //selecciona toda la fila al tocar cualquier col.
            if (e.RowIndex > -1)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
            // tenes que seleccionar por lo menos uno
            if (dataGridView1.Rows.Count < 1)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void EspecialidadesHandler_Load(object sender, EventArgs e)
        {

        }
    }
}
