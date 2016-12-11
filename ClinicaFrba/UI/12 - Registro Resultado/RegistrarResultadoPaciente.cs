using ClinicaFrba.FormulariosBase;
using ClinicaFrba.Helpers;
using ClinicaFrba.Logica.Entidades;
using ClinicaFrba.Registro_Resultado;
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

namespace ClinicaFrba.UI._12___Registro_Resultado
{
    public partial class RegistrarResultadoPaciente : FormularioListadoBase
    {
        public RegistrarResultadoPaciente(UsuarioLogeado u)
        {
            UsuarioLogueado = u;
            InitializeComponent();
            btnAgregar.Visible = false;
            btnEliminar.Visible = false;
            btnSeleccionar.Visible = false;
            MostrarTurnosDeHoy();
            if (dgListado.Rows.Count == 0)
            {
                MessageBox.Show("Usted no tiene pacientes hoy :)", "sin pacientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();

            }
            else
            {
                Show();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dr = dgListado.SelectedRows[0];
            var cells = dr.Cells;
            string turnoID = cells[0].Value.ToString();
            string pacienteID = cells[3].Value.ToString();
            EscribirSintomasYDiagnostico escribir = new EscribirSintomasYDiagnostico(turnoID, pacienteID);

        }

        private void MostrarTurnosDeHoy()
        {
            string q2 = @"SELECT
	                        [turn_numero] as IDTurno,
	                        (select concat([Paci_Nombre]
		                          ,' ',[Paci_Apellido]) as paciente
		                        from [GD2C2016].[GRUPOSA].[Paciente]
	                         where [Paci_Matricula] = [turn_Paciente_Id]
	                         ) as 'nombre del paciente'
	                        ,cast([Turn_fecha] as date) as 'fecha del turno'
							,Turn_Paciente_Id as idPaciente
                        

                        FROM [GD2C2016].[GRUPOSA].[Turnos]
                         where Turn_medico_id = @id and
	                           cast(turn_fecha as date) between @fecha  and @fecha";
           //00000101 '2015-02-02'

            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoQuery(q2);
            cmd.Parameters.Add("@id", SqlDbType.VarChar);
            cmd.Parameters["@id"].Value = UsuarioLogueado.MedicoMatricula;
            cmd.Parameters.Add("@fecha", SqlDbType.VarChar);
            cmd.Parameters["@fecha"].Value = StaticUtils.getDate();
            DataTable dt = con.ExecConsulta(cmd);
            dgListado.DataSource = dt;

        }
    }
}
