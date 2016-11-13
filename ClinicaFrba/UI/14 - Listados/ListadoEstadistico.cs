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

namespace ClinicaFrba.Listados
{
    public partial class ListadoEstadistico : FormularioListadoBase
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
            DesactivarBotonesQueNoSeUsan();
        }

        private void buttonMostrar1_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_listado1");
            DataTable dt = con.ExecConsulta(cmd);
            MostrarEstaTabla(dt);
        }

        #region auxiliares
        private void DesactivarBotonesQueNoSeUsan()
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnSeleccionar.Enabled = false;
        }

        private void MostrarEstaTabla(DataTable dt)
        {
            dgListado.DataSource = dt;
        }
        #endregion
    }
}
