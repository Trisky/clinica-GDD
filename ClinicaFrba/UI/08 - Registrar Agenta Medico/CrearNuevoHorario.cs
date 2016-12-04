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

namespace ClinicaFrba.UI._08___Registrar_Agenta_Medico
{
    public partial class CrearNuevoHorario : FormBase
    {
        private List<Tuple<int, int>> lstHorariosDelDia;

        public string Username { get; set; }
        public CrearNuevoHorario(string username)
        {
            InitializeComponent();
            ComboBoxManager cm = new ComboBoxManager();
            buttonNuevoHorario.Visible = true;
            comboBoxDia = cm.CrearDias(comboBoxDia);
            comboBoxEspecialidad = cm.CrearEspecialidades(comboBoxEspecialidad);



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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonNuevoHorario_Click(object sender, EventArgs e)
        {
            int horaMilitarInicio = Convert.ToInt32(numHoraInicio.ToString() + numMinutoInicio.ToString());
            int horaMilitarFin = Convert.ToInt32(numHoraFin.ToString() + numMinutoFin.ToString());
            if (horaMilitarInicio > horaMilitarFin)
            {
                MessageBox.Show("¡error, hora de inicio debe ser anterio a la de fin!", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //ahora que ya se que es valido, lo mando a la base --> TODO
            //armo la hora con los dos puntitos
            string inicio = numHoraInicio.ToString() + ":" + numMinutoInicio.ToString();
            string fin = numHoraFin.ToString() + ":" + numMinutoFin.ToString();

            try
            {
                Conexion con = new Conexion();
                SqlCommand cmd = con.CrearComandoQuery(@"INSERT INTO HorariosAtencion (Hora_Inicio, Hora_fin, Hora_Dia,Hora_Medico_Id_FK,Hora_Especialidad)
                                                                           VALUES     (@inicio,     @fin,     @dia,    @id,               @especialiadad)");
                cmd.Parameters.Add("@id", SqlDbType.VarChar);
                cmd.Parameters["@id"].Value = UsuarioLogueado.MedicoMatricula;
                cmd.Parameters.Add("@inicio", SqlDbType.VarChar);
                cmd.Parameters["@inicio"].Value = inicio;
                cmd.Parameters.Add("@fin", SqlDbType.VarChar);
                cmd.Parameters["@fin"].Value = fin;
                cmd.Parameters.Add("@dia", SqlDbType.VarChar);
                cmd.Parameters["@dia"].Value = comboBoxDia.SelectedValue.ToString();
                cmd.Parameters.Add("@especialidad", SqlDbType.VarChar);
                cmd.Parameters["@especialidad"].Value = comboBoxEspecialidad.SelectedValue.ToString();
                con.ExecConsulta(cmd);
            }
            catch
            {
                MessageBox.Show("¡Error al intentar crear el horario pedido!", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //por ultimo, escondo el grupo de crear horario y muestro el inicial
            Close();
            Dispose();
        }
        private bool estaDentroDeEsteHorario(int hora)
        {
            foreach (Tuple<int, int> element in lstHorariosDelDia)
            {
                if (element.Item1 < hora && element.Item2 < hora)
                    return true;

            }
            return false;
        }

        private void comboBoxEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
