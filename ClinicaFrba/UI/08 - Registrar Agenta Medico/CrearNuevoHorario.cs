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
            comboBoxEspecialidad = cm.CrearEspecialidades(comboBoxEspecialidad,user);
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
            int horaInicio =( Convert.ToInt32(numHoraInicio.Value.ToString())) * 100;
            int horaFin = (Convert.ToInt32(numHoraFin.Value.ToString())) * 100;
            int minutosInicio =Convert.ToInt32(numMinutoInicio.Value.ToString());
            int minutosFin = Convert.ToInt32(numMinutoFin.Value.ToString());

            int horaMilitarInicio = horaInicio + minutosInicio;
            int horaMilitarFin = horaFin + minutosFin;




            if (horaMilitarInicio > horaMilitarFin)
            {
                MessageBox.Show("¡error, hora de inicio debe ser anterio a la de fin!", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Convert.ToInt32(comboBoxDia.SelectedValue) == 5 && horaMilitarFin > 150)
            {
                MessageBox.Show("¡Los SABADOS solo esta abierto hasta las 15, su horario fin fue mayor!", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            Conexion con = new Conexion();
            SqlCommand cmd1 = con.CrearComandoQuery(@"select isnull(sum(DATEDIFF(MINUTE,h.Hora_Inicio, h.Hora_Fin)),0) as horas 
            from gruposa.HorariosAtencion h join gruposa.Medico m on h.Hora_Medico_Id_FK = m.Medi_Id
            where m.Medi_Id =@medico ");
            cmd1.Parameters.Add("@medico", SqlDbType.VarChar).Value = UsuarioLogueado.MedicoMatricula;
            DataTable dt = con.ExecConsulta(cmd1);

            int minutos = (Convert.ToInt32(numMinutoInicio.Value.ToString())) - Convert.ToInt32(numMinutoFin.Value.ToString());
         
            if(minutos < 0){
            minutos = minutos * (-1);
            }

            int horarioAMinutos=(Convert.ToInt32(numHoraFin.Value.ToString()) - Convert.ToInt32(numHoraInicio.Value.ToString()))*(60);

            int horarioDB = (int.Parse(dt.Rows[0][0].ToString()));

            if (minutos+ horarioAMinutos+horarioDB > 2880)
            {
                MessageBox.Show("¡error, supera las 48hs semanales!", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
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
            MessageBox.Show("¡Horario nuevo creado con exito!", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void numHoraFin_ValueChanged_1(object sender, EventArgs e)
        {

        }
    }
}
