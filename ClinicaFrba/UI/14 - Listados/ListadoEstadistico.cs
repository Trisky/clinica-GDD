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
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnSeleccionar.Enabled = false;
            toggleBotones(false);
        }
        public void toggleBotones(bool valor)
        {
            button1.Enabled = valor;
            button2.Enabled = valor;
            button3.Enabled = valor;
        }

        private void MostrarEsteSP(string SP)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure(SP);
            cmd.Parameters.Add("@desde", SqlDbType.VarChar).Value = dateDesde.Value.Date.ToString();
            cmd.Parameters.Add("@hasta", SqlDbType.VarChar).Value = dateHasta.Value.Date.ToString();
            DataTable dt = con.ExecConsulta(cmd);
            dgListado.DataSource = dt;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarEsteSP("sp_top5EspecialidadesMasCanceladas");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MostrarEsteSP("sp_top5ProfConMenosHsTrabPorEsp");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MostrarEsteSP("sp_top5ProfMasConsultadasPorPlan");
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
    }
}
