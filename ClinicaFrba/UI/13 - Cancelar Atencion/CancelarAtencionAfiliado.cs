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
        }

        private void CancelarAtencionAfiliado_Load(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_turnosActivosPaciente");
            cmd.Parameters.Add("@paci_usuario", SqlDbType.VarChar).Value = usuario.UserName;
            DataTable dt = con.ExecConsulta(cmd);
            
            turnosActivos.DataSource = dt;
            turnosActivos.Columns[0].Visible = false;
            textBox1.Enabled = false;
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fechaConsultada = Convert.ToDateTime(turnosActivos.Rows[e.RowIndex].Cells[3].Value);
            ts=fechaConsultada-DateTime.Now;
            if (ts.Days < 1)
            {
                textBox1.Text = "Se necesitan 24 hs de anticipacion para cancelar";
            }
            else
            {
                textBox1.Text = "Se cancelara el turno del dia "+fechaConsultada.ToShortDateString()+" a las "+fechaConsultada.ToShortTimeString()+" hs.";   
                turno = Convert.ToDecimal(turnosActivos.Rows[e.RowIndex].Cells[0].Value);
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_bajaTurnoPaciente");
            cmd.Parameters.Add("@id_turno", SqlDbType.Decimal).Value = turno;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = textBox2.Text;
            DataTable dt = con.ExecConsulta(cmd);
            if (dt != null) { MessageBox.Show("Cancelacion exitosa"); }
            cmd = con.CrearComandoStoreProcedure("sp_turnosActivosPaciente");
            cmd.Parameters.Add("@paci_usuario", SqlDbType.VarChar).Value = usuario.UserName;
            dt = con.ExecConsulta(cmd);
            turnosActivos.DataSource = dt;
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
    }
}
