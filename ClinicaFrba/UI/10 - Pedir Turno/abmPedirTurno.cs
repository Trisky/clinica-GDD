using ClinicaFrba.FormulariosBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ClinicaFrba.Helpers;
using ClinicaFrba.Logica.Entidades;
//using ClinicaFrba.UI._08___Registrar_Agenta_Medico;
using ClinicaFrba.UI._11___Registro_Llegada;

namespace ClinicaFrba.Pedir_Turno
{

    public partial class PedirTurno : FormBase
    {
        private string userName;
        private string especialidadSeleccionada;
        private string idMedico;
        private DateTime diaSeleccionado;
        private string especialidad;
        private string rangoHorario;

        public PedirTurno()
        {
            Init();
        }

        private void Init()
        {
            InitializeComponent();
            Show();
            ComboBoxManager listaEspecialidades = new ComboBoxManager();
            cmbBoxListadoEspecialidades = listaEspecialidades.CrearEspecialidades(cmbBoxListadoEspecialidades);
            calendarDoctors.MaxSelectionCount = 1;
        }

        /// <summary>
        /// Para cuando tengo que registrar una llegada en el hospital.
        /// </summary>
        /// <param name="regLlegada"></param>
        /// <param name="username"></param>
        public PedirTurno(RegistroLlegada regLlegada, string username,DateTime dia)
        {
            userName = username;
            calendarDoctors.SelectionStart = dia;
            calendarDoctors.SelectionEnd = dia;
            calendarDoctors.Enabled = false;
            //FALTA HACER ESTO, ale no toques este metodo.
            Init();
        }

        private void cmbBoxListadoEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            especialidadSeleccionada = cmbBoxListadoEspecialidades.SelectedValue.ToString();
            ComboBoxManager comboMed = new ComboBoxManager();
            cmbMedicos = comboMed.ListarMedicos(especialidadSeleccionada, cmbMedicos);
        }

        private void btnPedirTurno(object sender, EventArgs e)
        {
            if (diaSeleccionado < DateTime.Today || diaSeleccionado.ToString("dddd")=="domingo")
            {
                MessageBox.Show("Fecha no valida");
            }
            else
            {
                Conexion con = new Conexion();
                SqlCommand cmd = con.CrearComandoStoreProcedure("sp_turnosMedicosDisponibles");
                cmd.Parameters.Add("@especialidad", SqlDbType.NVarChar).Value = especialidadSeleccionada;
                cmd.Parameters.Add("@diaConsultado", SqlDbType.NVarChar).Value = diaSeleccionado.ToString();
                cmd.Parameters.Add("@id_medico", SqlDbType.NVarChar).Value = idMedico;
                DataTable dTurnos = con.ExecConsulta(cmd);
                dataGridView1.DataSource = dTurnos;


                //si no hay medicos, le aviso al usuario.
                if (dTurnos.Rows.Count == 0)
                    MessageBox.Show("No existen medicos de la especialidad elegida que atiendan en ese horario"
                    , "Sin medicos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        
        private void PedirTurno_Load(object sender, EventArgs e)
        {

        }

        private void tbAfiliado_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
            calendarDoctors.RemoveAllBoldedDates();
            diaSeleccionado = e.Start;
            calendarDoctors.AddBoldedDate(diaSeleccionado);
            calendarDoctors.UpdateBoldedDates();
        }




        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void cmbMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            idMedico = cmbMedicos.SelectedValue.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rangoHorario = dataGridView1.CurrentCell.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_cargarTurno");
            cmd.Parameters.Add("@especialidad", SqlDbType.NVarChar).Value = especialidadSeleccionada;
            cmd.Parameters.Add("@fecha", SqlDbType.NVarChar).Value = diaSeleccionado.ToString();
            cmd.Parameters.Add("@id_medico", SqlDbType.NVarChar).Value = idMedico;
            cmd.Parameters.Add("@horario", SqlDbType.NVarChar).Value = rangoHorario;
        }
       
    }
       
}


