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
using ClinicaFrba.UI._13___Cancelar_Atencion;

namespace ClinicaFrba.Pedir_Turno
{

    public partial class PedirTurno : FormBase
    {
        //Constructor
        BajaAtencion aten = new BajaAtencion();
        private string userName;
        private string especialidadSeleccionada;
        private string idMedico;
        private DateTime diaSeleccionado;
        private string especialidad;
        private string horario;
        private DateTime[] datesDoctor;
        private int mes;

        public PedirTurno(UsuarioLogeado user)
        {
            UsuarioLogueado = user;
            Init();          
        }
        private void Init()
        {
            InitializeComponent();
            calendarDoctors.TodayDate = StaticUtils.getDateTime();
            mes = StaticUtils.getDateTime().Month;
            calendarDoctors.MaxSelectionCount = 1;
            ComboBoxManager listaEspecialidades = new ComboBoxManager();
            cmbBoxListadoEspecialidades = listaEspecialidades.CrearEspecialidades(cmbBoxListadoEspecialidades);
            VerificarSiTieneBonos();
            calendarDoctors.TodayDate = StaticUtils.getDateTime();
            calendarDoctors.MinDate = StaticUtils.getDateTime();
            Show();
        }


        }
        private void VerificarSiTieneBonos()
        {
            Conexion con = new Conexion();
            string s = @" SELECT count( [Bono_Id])
                          FROM [GD2C2016].[GRUPOSA].[Bonos]
                          where SUBSTRING(@id,1,6)=SUBSTRING(Bono_Paci_Id,1,6) and
                          Bono_expirado = 0";
            SqlCommand cmd = con.CrearComandoQuery(s);
            string matricula = UsuarioLogueado.PacienteMatricula;
            cmd.Parameters.Add(new SqlParameter("@id",matricula));
            DataTable dt = con.ExecConsulta(cmd);
            if (dt.Rows.Count == 0)
                UstedNoTieneBonos();
            //int  cant =Convert.ToInt32(StaticUtils.getUniqueValueFrom(dt));
            int c = dt.Rows[0].Field<int>(0);

            if (c <1)
                UstedNoTieneBonos();
            else
                Show();

        }
        private void UstedNoTieneBonos()
        {
            MessageBox.Show("usted no tiene bonos, debe comprar antes de realizar esta accion"
           , "Sin bonos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Dispose();
        }
        /// <summary>
        /// Para cuando tengo que registrar una llegada en el hospital no dejo que el usuario pueda elegir el dia.
        /// </summary>
        /// <param name="regLlegada"></param>
        /// <param name="username"></param>
        public PedirTurno(RegistroLlegada regLlegada, string username, DateTime dia)
        {
            Init();
            userName = username;
            UsuarioLogueado = new UsuarioLogeado(); 
            //como esto no lo hace el propio usuario, 
            //asigno el usuario al que se le va a asignar el turno al usuariologeado (la villa)
            UsuarioLogueado.UserName = username;
            calendarDoctors.SelectionStart = dia;
            calendarDoctors.SelectionEnd = dia;
            calendarDoctors.Enabled = false;
            diaSeleccionado = dia;
        }
        private void cmbBoxListadoEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            especialidadSeleccionada = cmbBoxListadoEspecialidades.SelectedValue.ToString();
            ComboBoxManager comboMed = new ComboBoxManager();
            cmbMedicos = comboMed.ListarMedicos(especialidadSeleccionada, cmbMedicos);
            horariosDisponibles.DataSource = null;
            horariosDisponibles.Refresh();
        }
        private void btnPedirTurno(object sender, EventArgs e)
        {
            bool todoOk = true;
            if (calendarDoctors.Enabled) //si esto no esta activado significa que no puedo elegir el dia y que se va a asignar un turno para el dia de la fecha
            {
                if (diaSeleccionado < StaticUtils.getDateTime() || diaSeleccionado.ToString("dddd") == "domingo")
                {
                    MessageBox.Show("Fecha no valida");
                    todoOk = false;
                }
            }
            if (!todoOk) return; //

            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_turnosMedicosDisponibles");
            cmd.Parameters.Add("@especialidad", SqlDbType.NVarChar).Value = especialidadSeleccionada;
            cmd.Parameters.Add("@diaConsultado", SqlDbType.NVarChar).Value = diaSeleccionado.ToString();
            cmd.Parameters.Add("@id_medico", SqlDbType.NVarChar).Value = idMedico;
            DataTable dTurnos = con.ExecConsulta(cmd);
            horariosDisponibles.DataSource = dTurnos;


            //si no hay medicos, le aviso al usuario.
            
            if (dTurnos.Rows.Count == null)
                MessageBox.Show("No hay turnos disponibles"
                , "Sin turnos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            diaSeleccionado = e.Start;
            if (e.Start.Month != mes)
            {
                calendarDoctors.RemoveAllBoldedDates();
                calendarDoctors.BoldedDates = aten.obtenerFechas(idMedico,especialidadSeleccionada,e.Start);
                calendarDoctors.UpdateBoldedDates();
                mes = e.Start.Month;
            }
            horariosDisponibles.DataSource = null;
            horariosDisponibles.Refresh();
        }
        private void cmbMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            idMedico = cmbMedicos.SelectedValue.ToString();
            datesDoctor = aten.obtenerFechas(idMedico, especialidadSeleccionada, StaticUtils.getDateTime());
            calendarDoctors.BoldedDates = datesDoctor;
            calendarDoctors.UpdateBoldedDates();
            horariosDisponibles.DataSource = null;
            horariosDisponibles.Refresh();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //selecciona toda la fila al tocar cualquier col.
            if (e.RowIndex > -1)
            {
                horariosDisponibles.Rows[e.RowIndex].Selected = true;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //@fecha VARCHAR (250),
            //@hora           VARCHAR(250),
            //@paciente       VARCHAR(250),
            //@medico         VARCHAR(250),
            //@especialidad   VARCHAR(250)

            if (horario == null)
            {
                MessageBox.Show("Debe seleccionar un horario", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
                return;
            }
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_confirmacionTurno");
            cmd.Parameters.Add("@fecha", SqlDbType.VarChar).Value = diaSeleccionado.ToString();
            cmd.Parameters.Add("@hora", SqlDbType.VarChar).Value = horario;
            cmd.Parameters.Add("@paciente", SqlDbType.VarChar).Value = UsuarioLogueado.UserName;
            cmd.Parameters.Add("@medico", SqlDbType.VarChar).Value = idMedico;
            cmd.Parameters.Add("@especialidad", SqlDbType.VarChar).Value = especialidadSeleccionada;
            DataTable ret = con.ExecConsulta(cmd);
            //Esta comprobacion es medio dudosa
            if (ret != null)
            {
                MessageBox.Show("Su turno se ha reservado con exito!", "Reserva existosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void horariosDisponibles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            horario = horariosDisponibles.SelectedCells[0].Value.ToString();
        }










        private void PedirTurno_Load(object sender, EventArgs e)
        {

        }
        private void tbAfiliado_TextChanged(object sender, EventArgs e)
        {

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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }





    }

}


