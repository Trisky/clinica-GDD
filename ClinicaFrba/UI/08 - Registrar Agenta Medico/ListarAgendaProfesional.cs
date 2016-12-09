using ClinicaFrba.FormulariosBase;
using ClinicaFrba.Helpers;
using ClinicaFrba.Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ClinicaFrba.UI._08___Registrar_Agenta_Medico
{
    public partial class ListarAgendaProfesional : FormularioListadoBase
    {
        public UsuarioLogeado usuarioLogeado { get; set; }
        public List<Tuple<int, int>> lstHorariosDelDia { get; set; }


        public ListarAgendaProfesional(UsuarioLogeado user)
        {
            InitializeComponent();
            usuarioLogeado = user;
            labelIdMedico.Text = usuarioLogeado.MedicoMatricula;
            btnBuscar.Visible = btnEliminar.Visible = btnLimpiar.Visible = btnModificar.Visible = false;
            ComboBoxManager cm = new ComboBoxManager();
            comboBoxDia = cm.CrearDias(comboBoxDia);
            Show();

        }

        private void comboBoxDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoQuery(@"select isnull(sum(DATEDIFF(MINUTE,h.Hora_Inicio, h.Hora_Fin)),0) as horas 
            from gruposa.HorariosAtencion h join gruposa.Medico m on h.Hora_Medico_Id_FK = m.Medi_Id
            where m.Medi_Id =@medico ");
            cmd.Parameters.Add("@medico", SqlDbType.VarChar).Value = usuarioLogeado.MedicoMatricula;
            DataTable dt = con.ExecConsulta(cmd);

            if (int.Parse(dt.Rows[0][0].ToString()) > 2880)
            {
                MessageBox.Show("¡error, supera las 48hs semanales!", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                CrearNuevoHorario nuevoHorario = new CrearNuevoHorario(usuarioLogeado);
                nuevoHorario.Show();
            }
        }

        private DataTable GetAgendaDeldia(int diaSeleccionado)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoQuery(@"SELECT *
                                                         FROM [GD2C2016].[GRUPOSA].[HorariosAtencion]
                                                            where Hora_dia = datename(weekday,@dia)
                                                            and Hora_Medico_Id_FK = @medico");
            cmd.Parameters.Add("@dia", SqlDbType.Int).Value = diaSeleccionado;
            cmd.Parameters.Add("@medico", SqlDbType.VarChar).Value = usuarioLogeado.MedicoMatricula;
            DataTable dt = con.ExecConsulta(cmd);
            return dt;
        }

        private void buttonVerDia_Click(object sender, EventArgs e)
        {
            TipoUsuarioEnum.DiaSemana s = (TipoUsuarioEnum.DiaSemana)comboBoxDia.SelectedValue;
            int dia = (int)s;

            DataTable dt = GetAgendaDeldia(dia);
            dgListado.DataSource = dt;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
