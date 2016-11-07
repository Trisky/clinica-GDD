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

namespace ClinicaFrba.Registro_Resultado
{
    public partial class EscribirSintomasYDiagnostico : FormBase
    {
        private string IdTurno;

        public EscribirSintomasYDiagnostico(string turnoID)
        {
            InitializeComponent();
            IdTurno = turnoID;
            radioButtonAtendidoNo.Checked = true;
            Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }


        private void buttonCerrarConsulta_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_cerrarConsulta");
            cmd.Parameters.Add("@sintomas", SqlDbType.VarChar).Value = textBoxSintomas.Text;
            cmd.Parameters.Add("@diagnostico", SqlDbType.VarChar).Value = textBoxDiagnostico.Text;
            cmd.Parameters.Add("@idTurno", SqlDbType.VarChar).Value = IdTurno;
            cmd.Parameters.Add("@fechaHora", SqlDbType.VarChar).Value = StaticUtils.getDate();

            if (radioButtonAtendidoSi.Checked) cmd.Parameters.Add("@asistio", SqlDbType.NVarChar).Value = 1;
            else  cmd.Parameters.Add("@asistio", SqlDbType.NVarChar).Value = 0;

            con.ExecConsulta(cmd);
            Dispose();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            groupBoxPasoDos.Enabled = true;
        }

       
    }
}
