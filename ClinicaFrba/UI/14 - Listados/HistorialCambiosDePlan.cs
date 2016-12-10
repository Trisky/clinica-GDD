using ClinicaFrba.FormulariosBase;
using ClinicaFrba.Helpers;
using ClinicaFrba.Logica.Entidades;
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
    public partial class HistorialCambiosDePlan : FormularioListadoBase
    {
        public HistorialCambiosDePlan( )
        {

            InitializeComponent();
            btnEliminar.Visible = false;
            PopularTabla();
            Show();
        }

        private void PopularTabla()
        {
            string q = @"select * from GRUPOSA.Auditoria_Plan";
            if (textBoxUsername.Text != "")
            {
                 q = @"select * from GRUPOSA.Auditoria_Plan
                        where Auditoria_Usuario like '@usuario' ";
            }
            

            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoQuery(q);
            cmd.Parameters.Add("@paci_usuario", SqlDbType.VarChar).Value = textBoxUsername.Text;
            DataTable dt = con.ExecConsulta(cmd);
            dgListado.DataSource = dt;
        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            PopularTabla();
        }
    }
}
