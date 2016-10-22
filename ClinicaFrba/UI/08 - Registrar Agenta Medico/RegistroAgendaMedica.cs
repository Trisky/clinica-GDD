using ClinicaFrba.FormulariosBase;
using ClinicaFrba.Helpers;
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

namespace ClinicaFrba.Registrar_Agenta_Medico
{
    public partial class RegistroAgendaMedica : FormBase
    {
        public string medicoActualUsername { get; set; }
        public List<Tuple<int,int>> lstHorariosDelDia  { get; set; }

        public RegistroAgendaMedica(string usernameMedicoActual)
        {
            InitializeComponent();
            ComboBoxManager cm = new ComboBoxManager();
            comboBoxDia = cm.CrearDias(comboBoxDia);


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string diaSeleccionado = comboBoxDia.SelectedValue.ToString();
            DataTable dt = GetAgendaDeldia(diaSeleccionado);
            comboBoxDia.Enabled = false; // por las dudas.
            buttonNuevoHorario.Enabled = true;

        }

        private DataTable GetAgendaDeldia(string diaSeleccionado)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoQuery(@"SELECT [Hora_Inicio] ,[Hora_Fin]
                                                    FROM[GD2C2016].[GRUPOSA].[HorariosAtencion]
                                                    where Hora_dia = '@dia' and
                                                    Horario_FK_Medico_Usuario = '@medico'");
            cmd.Parameters.Add("@dia", SqlDbType.NVarChar).Value = diaSeleccionado;
            cmd.Parameters.Add("@medico", SqlDbType.VarChar).Value = medicoActualUsername;
            DataTable dt = con.ExecConsulta(cmd);
            return dt;


        }

        private void buttonNuevoHorario_Click(object sender, EventArgs e)
        {
            groupBoxNuevoHorario.Enabled = true;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        
        }

        private void numHoraFin_ValueChanged(object sender, EventArgs e)
        {
            if (numHoraFin.Value == 20)
                numMinutoFin.Value = 0;
        }

        private void numMinutoFin_ValueChanged(object sender, EventArgs e)
        {
            if (numHoraFin.Value == 20)
                numMinutoFin.Value = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int horaMilitarInicio = Convert.ToInt32(numHoraInicio.ToString() + numMinutoInicio.ToString());
            int horaMilitarFin = Convert.ToInt32(numHoraFin.ToString() + numMinutoFin.ToString());
            if(horaMilitarInicio> horaMilitarFin)
            {
                MessageBox.Show("¡error, hora de inicio debe ser anterio a la de fin!", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(estaDentroDeEsteHorario(horaMilitarInicio) || estaDentroDeEsteHorario(horaMilitarFin))
            {
                MessageBox.Show("¡error, Este horario ya esta tomado!", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //ahora que ya se que es valido, lo mando a la base --> TODO

        }

        private bool estaDentroDeEsteHorario(int hora)
        {
            foreach (Tuple<int,int> element in lstHorariosDelDia)
            {
                if (element.Item1 < hora && element.Item2 < hora)
                    return true;

            }
            return false;
        }
    }
}
