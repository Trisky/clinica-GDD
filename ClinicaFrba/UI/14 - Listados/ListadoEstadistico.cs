using ClinicaFrba.FormulariosBase;
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

namespace ClinicaFrba.UI._14___Listados
{
    public partial class ListadoEstadistico : FormularioListadoBase
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
            DesactivarBotonesQueNoSeUsan();
            Show();
        }


        #region auxiliares
        private void DesactivarBotonesQueNoSeUsan()
        {
            btnAgregar.Visible = false;
            btnEliminar.Visible = false;
            btnModificar.Visible = false;
            btnSeleccionar.Visible = false;
            btnBuscar.Visible = false;
            btnLimpiar.Visible = false;
            toggleBotones(false);
        }
        public void toggleBotones(bool valor)
        {
            button1.Enabled = valor;
            button2.Enabled = valor;
            button3.Enabled = valor;
            button4.Enabled = valor;
            button5.Enabled = valor;
        }

        private bool MostrarEsteSP(string SP)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure(SP);
            cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = dateDesde.Value.Date.ToString();
            cmd.Parameters.Add("@fechaFinal", SqlDbType.VarChar).Value =  dateHasta.Value.Date.ToString();
            DataTable dt = con.ExecConsulta(cmd);
            if(dt.Rows.Count<1)
            {
                MessageBox.Show("No hay datos" , "No hay datos ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
                
            dgListado.DataSource = dt;
            return true;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (MostrarEsteSP("sp_top5EspecialidadesMasCanceladas"))
            {
                dgListado.Columns[0].Width = 500;
                dgListado.Columns[1].Width = 500;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MostrarEsteSP("sp_top5ProfConMenosHsTrabPorEsp"))
            {
                dgListado.Columns[0].Width = 500;
                dgListado.Columns[1].Width = 500;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MostrarEsteSP("sp_top5ProfMasConsultadasPorPlan"))
            {
                dgListado.Columns[0].Width = 200;
                dgListado.Columns[1].Width = 200;
                dgListado.Columns[2].Width = 300;
                dgListado.Columns[3].Width = 300;
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {

            if (MostrarEsteSP("sp_top5AfiliadosConMasBonos"))
            {
                dgListado.Columns[0].Width = 200;
                dgListado.Columns[1].Width = 300;
                dgListado.Columns[2].Width = 500;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MostrarEsteSP("sp_top5ProfConMenosHsTrabPorEsp"))
            {
                dgListado.Columns[0].Width = 500;
                dgListado.Columns[1].Width = 500;
            }
        }

        private void dateDesde_ValueChanged(object sender, EventArgs e)
        {
            if (dateDesde.Value < dateHasta.Value)
                toggleBotones(true);
            else
                toggleBotones(false);
        }

        private void dateHasta_ValueChanged(object sender, EventArgs e)
        {
            if (dateDesde.Value < dateHasta.Value)
                toggleBotones(true);
            else
                toggleBotones(false);
        }

        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {

        }

    }
}
