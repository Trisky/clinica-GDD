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
using ClinicaFrba.Helpers;
using ClinicaFrba.Logica.Entidades;
using ClinicaFrba.FormulariosBase;

namespace ClinicaFrba.UI._13___Cancelar_Atencion
{
    public partial class CancelarAtencionAfiliado : Form
    {   
        public CancelarAtencionAfiliado(UsuarioLogeado user)
        {
            InitializeComponent();
            usuario = user;
            Show();
        }

        private void CancelarAtencionAfiliado_Load(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_turnosActivosPaciente");
            cmd.Parameters.Add("@paci_usuario", SqlDbType.VarChar).Value = usuario.UserName;
            DataTable dt = con.ExecConsulta(cmd);
            turnosActivos.DataSource = dt;
            turnosActivos.Columns[0].Visible = false;
            txtSelectedTurn.Enabled = false;
        }
        
        private void turnosActivos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private decimal turno;
        private List<decimal> listaTurnos = new List<decimal>();
        private UsuarioLogeado usuario;
        private DateTime fechaConsultada;
        private TimeSpan ts;

        private void turnosActivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fechaConsultada = Convert.ToDateTime(turnosActivos.Rows[e.RowIndex].Cells[3].Value);
            ts=fechaConsultada-DateTime.Now;
            if (ts.Days < 1)
            {
                txtSelectedTurn.Text = "Se necesitan 24 hs de anticipacion para cancelar";
            }
            else
            {
                txtSelectedTurn.Text = "Se cancelara el turno del dia "+fechaConsultada.ToShortDateString()+" a las "+fechaConsultada.ToShortTimeString()+" hs.";   
                turno = Convert.ToDecimal(turnosActivos.Rows[e.RowIndex].Cells[0].Value);
            }

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            //@tipo NUMERIC(18, 0),
            //@id_turno NUMERIC(18, 0),
            //@descripcion VARCHAR(255),
            //@fechaHoy DATETIME
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_bajaTurnoPaciente");
            cmd.Parameters.Add("@id_turno", SqlDbType.Decimal).Value = turno;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = txtReason.Text;
            cmd.Parameters.Add("@tipo", SqlDbType.NVarChar).Value = usuario.UserName;
            cmd.Parameters.Add("@fechaHoy", SqlDbType.DateTime).Value = StaticUtils.getDateTime();

            DataTable dt = con.ExecConsulta(cmd);
            if (dt != null) { MessageBox.Show("Cancelacion exitosa"); }
            cmd = con.CrearComandoStoreProcedure("sp_turnosActivosPaciente");
            
            dt = con.ExecConsulta(cmd);
            turnosActivos.DataSource = dt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
