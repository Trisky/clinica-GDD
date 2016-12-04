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

namespace ClinicaFrba.UI._13___Cancelar_Atencion
{
    public partial class CancelarAtencionAfiliado2 : FormularioListadoBase
    {
        private string motivoRound;

        public CancelarAtencionAfiliado2(UsuarioLogeado user)
        {
            InitializeComponent();
            btnAgregar.Visible = btnEliminar.Visible = btnModificar.Visible = false;
            btnLimpiar.Visible = btnBuscar.Visible = false;
            UsuarioLogueado = user;
            PopularTabla();
            radioButton1.Checked = true;
            btnSeleccionar.Text = "cancelar este turno";
            btnSeleccionar.Visible = true;
            Show();
        }

        private void PopularTabla()
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_turnosActivosPaciente");
            cmd.Parameters.Add("@paci_usuario", SqlDbType.VarChar).Value = UsuarioLogueado.UserName;
            DataTable dt = con.ExecConsulta(cmd);
            dgListado.DataSource = dt;
        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgListado.SelectedRows[0];
            var fechaConsultada = Convert.ToDateTime(dr.Cells[3].Value);
            var ts = (fechaConsultada - StaticUtils.getDateTime()).TotalHours;
            if (ts < 24)
            {
                MessageBox.Show("Debe hacerlo por lo menos con 24 horas de antelacion" , "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //ahora cancelo el turno

            int turno = Convert.ToInt32(dr.Cells[0].Value.ToString());

            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_bajaTurnoPaciente");
            cmd.Parameters.Add("@id_turno", SqlDbType.Decimal).Value = turno;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = textBoxMotivo.Text;
            cmd.Parameters.Add("@tipo", SqlDbType.NVarChar).Value = 1;//TODO cambiar por un string
            //cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = motivoRound;
            cmd.Parameters.Add("@fechaHoy", SqlDbType.DateTime).Value = StaticUtils.getDateTime();

            DataTable dt = con.ExecConsulta(cmd);
            if (dt != null) { MessageBox.Show("Cancelacion exitosa"); }
            cmd = con.CrearComandoStoreProcedure("sp_turnosActivosPaciente");


        }

        

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            motivoRound = "Motivo personal"; 
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            motivoRound = "Motivo laboral";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            motivoRound = "Motivo medico";
        }
    }
}
