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

namespace ClinicaFrba.UI._08___Registrar_Agenta_Medico
{
    public partial class CrearNuevoHorario : FormBase
    {
        private List<Tuple<int, int>> lstHorariosDelDia;

        public string Username { get; set; }
        public CrearNuevoHorario(UsuarioLogeado user)
        {
            InitializeComponent();
            UsuarioLogueado = user;
            Username = UsuarioLogueado.UserName;
            
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
            int horaMilitarInicio = Convert.ToInt32(numHoraInicio.Value.ToString() + numMinutoInicio.Value.ToString());
            int horaMilitarFin = Convert.ToInt32(numHoraFin.Value.ToString() + numMinutoFin.Value.ToString());
            if (horaMilitarInicio > horaMilitarFin)
            {
                MessageBox.Show("¡error, hora de inicio debe ser anterio a la de fin!", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //ahora que ya se que es valido, lo mando a la base --> TODO
            //armo la hora con los dos puntitos

            
            string inicio = checkEntre0y9(numHoraInicio.Value.ToString()) + ":" + checkEntre0y9( numMinutoInicio.Value.ToString());
            string fin = checkEntre0y9(numHoraFin.Value.ToString()) + ":" + checkEntre0y9(numMinutoFin.Value.ToString());

            TipoUsuarioEnum.DiaSemana s = (TipoUsuarioEnum.DiaSemana)comboBoxDia.SelectedValue;
            int dia = (int)s;

            try
            {
                Conexion con = new Conexion();
                SqlCommand cmd = con.CrearComandoQuery(@"INSERT INTO GRUPOSA.HorariosAtencion (Hora_Inicio, Hora_fin, Hora_Dia,Hora_Medico_Id_FK,Hora_Especialidad)
                                                                           VALUES     (@inicio,     @fin,  datename(weekday,@dia),    @id,        CAST(@especialidad AS INT))");
                cmd.Parameters.Add(new SqlParameter("@id",      UsuarioLogueado.MedicoMatricula));
                cmd.Parameters.Add(new SqlParameter("@inicio",  inicio));
                cmd.Parameters.Add(new SqlParameter("@fin", fin));
                cmd.Parameters.Add(new SqlParameter("@dia", dia));
                cmd.Parameters.Add(new SqlParameter("@especialidad", comboBoxEspecialidad.SelectedValue.ToString()));
                //cmd.Parameters.Add(new SqlParameter("@especialidad", comboBoxEspecialidad.SelectedValue));
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

        private string checkEntre0y9(string v)
        {
            if (v.Length == 1)
                return "0" + v;
            else
                return v;
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
            buttonNuevoHorario.Enabled = true;
        }

        private void comboBoxDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBoxNuevoHorario.Visible = true;
        }
    }
}
