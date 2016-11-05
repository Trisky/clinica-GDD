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
    public partial class RegistroResultado : FormBase
    {
        public RegistroResultado(UsuarioLogeado usuarioLogeado)
        {
            InitializeComponent();
            buttonCerrarConsulta.Enabled = false;
            UsuarioLogueado = usuarioLogeado;
            MostrarTurnosDelMedicoDeHoy();
            radioButtonAtendidoNo.Checked = true;

        }

        private void MostrarTurnosDelMedicoDeHoy()
        {
            string q = @"SELECT
                           [Turn_Paciente_Id]
                          ,[Turn_Medico_Id]
                          ,cast([Turn_fecha] as date)
                      FROM [GD2C2016].[GRUPOSA].[Turnos]
                      where Turn_medico_id = @id and
                            cast(turn_fecha as date) between @fecha  and @fecha";//00000101 '2015-02-02'

            Conexion con =new Conexion();
            SqlCommand cmd = con.CrearComandoQuery(q);
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = UsuarioLogueado.MedicoMatricula;
            cmd.Parameters.Add("@fecha", SqlDbType.VarChar).Value = StaticUtils.getDate();
            DataTable dt = con.ExecConsulta(cmd);
            dgTable.DataSource = dt;
            if(dgTable.Rows.Count == 0)
            {
                MessageBox.Show("Usted no tiene pacientes hoy :)", "sin pacientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //selecciona toda la fila al tocar cualquier col.
            if (e.RowIndex > -1)
            {
                dgTable.Rows[e.RowIndex].Selected = true;
            }
        }

        private void buttonCerrarConsulta_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_cerrarConsulta");
            cmd.Parameters.Add("@sintomas", SqlDbType.VarChar).Value = textBoxSintomas.Text;
            cmd.Parameters.Add("@diagnostico", SqlDbType.VarChar).Value = textBoxDiagnostico.Text;

            if (radioButtonAtendidoSi.Checked) cmd.Parameters.Add("@asistio", SqlDbType.NVarChar).Value = 1;
            else  cmd.Parameters.Add("@asistio", SqlDbType.NVarChar).Value = 0;

        }

        private void buttonSeleccionarAfiliado_Click(object sender, EventArgs e)
        {
            var dr = dgTable.SelectedCells;
            //var cells = dr.Cells;
            dgTable.Enabled = false;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBoxPasoDos.Enabled = true;
        }

       
    }
}
