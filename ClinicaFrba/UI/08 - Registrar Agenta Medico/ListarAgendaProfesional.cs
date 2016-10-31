using ClinicaFrba.FormulariosBase;
using ClinicaFrba.Helpers;
using ClinicaFrba.Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static ClinicaFrba.Helpers.TipoUsuarioEnum;

namespace ClinicaFrba.UI._08___Registrar_Agenta_Medico
{
    public partial class ListarAgendaProfesional : FormularioListadoBase
    {
        public UsuarioLogeado usuarioLogeado { get; set; }
        public List<Tuple<int, int>> lstHorariosDelDia { get; set; }


        public ListarAgendaProfesional(UsuarioLogeado user)
        {
            InitializeComponent();
            btnModificar.Enabled = false;
            btnBuscar.Enabled = btnEliminar.Enabled = btnLimpiar.Enabled = false;
            usuarioLogeado = user;
            labelIdMedico.Text = usuarioLogeado.MedicoMatricula;

            ComboBoxManager cm = new ComboBoxManager();
            comboBoxDia = cm.CrearDias(comboBoxDia);

        }

        private void comboBoxDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CrearNuevoHorario nuevoHorario = new CrearNuevoHorario(usuarioLogeado.UserName);
            nuevoHorario.Show();
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
            DiaSemana s = (DiaSemana)comboBoxDia.SelectedValue;
            int dia = (int)s;

            DataTable dt = GetAgendaDeldia(dia);
            dgListado.DataSource = dt;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
