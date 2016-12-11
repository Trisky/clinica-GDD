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
            string q2 = 
                @"SELECT Turn_Numero AS 'Turno Nro', Turn_Paciente_Id AS 'Id Paciente',
	            (SELECT (Paci_Nombre + ' ' + upper(Paci_Apellido)) FROM GRUPOSA.Paciente WHERE Paci_Matricula = Turn_Paciente_Id) AS 'Paciente',
                CAST(Turn_fecha AS DATE) AS 'Fecha del Turno',
	             C.Cons_Realizada
                FROM [GRUPOSA].[Turnos] JOIN GRUPOSA.Consultas C ON Turn_Numero = C.Cons_Id_Turno
                WHERE Turn_medico_id = @id
                AND CAST(Turn_fecha AS DATE) = CAST(@fecha AS DATE)
                AND Turn_Numero = C.Cons_Id_Turno 
                AND cons_Llegada_Registrada = 1
                AND Cons_realizada <> 1";
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
