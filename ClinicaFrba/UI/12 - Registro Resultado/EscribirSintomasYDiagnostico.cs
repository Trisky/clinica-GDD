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
using ClinicaFrba.UI._12___Registro_Resultado;

namespace ClinicaFrba.Registro_Resultado
{
    public partial class EscribirSintomasYDiagnostico : FormBase
    {
        private string IdTurno;
        private string idPaciente;
        private RegistrarResultadoPaciente registrarResultadoPaciente;

        private RegistrarResultadoPaciente FormRegistroResultados { get;  set; }

        public EscribirSintomasYDiagnostico(string turnoID, string pacienteID, RegistrarResultadoPaciente registrarResultadoPaciente)
        {
            FormRegistroResultados = registrarResultadoPaciente;
            idPaciente = pacienteID;
            InitializeComponent();
            IdTurno = turnoID;

            groupBoxSintomaDiagnostico.Visible = true;
            Show();
        }

       

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxSintomaDiagnostico.Visible = true;
        }


        private void buttonCerrarConsulta_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_cerrarConsulta");
            cmd.Parameters.Add("@turnoId", SqlDbType.VarChar).Value = IdTurno;//1
            cmd.Parameters.Add("@diagnostico", SqlDbType.VarChar).Value = textBoxDiagnostico.Text;//2
            cmd.Parameters.Add("@enfermedad", SqlDbType.VarChar).Value = "Enfermedad"; //y bueno q se yo, ale me dijo que le mande siempre esto
            cmd.Parameters.Add("@sintomas", SqlDbType.VarChar).Value = textBoxSintomas.Text;
            cmd.Parameters.Add("@idPaciente", SqlDbType.VarChar).Value = idPaciente;
            cmd.Parameters.Add("@fechaHoy", SqlDbType.VarChar).Value = StaticUtils.getDate();

            con.ExecConsulta(cmd);
            FormRegistroResultados.MostrarTurnosDeHoy();
            FormRegistroResultados.Show();
            Dispose();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            groupBoxPasoDos.Enabled = true;
        }

        private void radioButtonAtendidoNo_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxSintomaDiagnostico.Visible = false;
        }
    }
}
