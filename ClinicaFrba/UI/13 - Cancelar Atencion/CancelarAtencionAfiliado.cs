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
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fechaConsultada=Convert.ToDateTime(turnosActivos.CurrentCell.Value);
            ts=fechaConsultada-DateTime.Now;
            if (ts.Days < 1)
            {
                textBox1.Text = "Se necesitan 24 hs de anticipacion para cancelar";
            }
            else
            {
                textBox1.Text = fechaConsultada.ToString();
            }
        }

        private UsuarioLogeado usuario;
        private DateTime fechaConsultada;
        private TimeSpan ts;
        
    }
}
