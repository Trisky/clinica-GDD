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

            ComboBoxManager cm = new ComboBoxManager();
            comboBoxDia = cm.CrearDias(comboBoxDia);

        }

        private void comboBoxDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = comboBoxDia.SelectedValue.ToString();
            DataTable dt = GetAgendaDeldia(s);

            dgListado.DataSource = dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CrearNuevoHorario nuevoHorario = new CrearNuevoHorario(usuarioLogeado.UserName);
            nuevoHorario.Show();
        }

        private DataTable GetAgendaDeldia(string diaSeleccionado)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoQuery(@"SELECT [Hora_Inicio] ,[Hora_Fin]
                                                    FROM[GD2C2016].[GRUPOSA].[HorariosAtencion]
                                                    where Hora_dia = @dia and
                                                    Horario_FK_Medico_Usuario = @medico");
            cmd.Parameters.Add("@dia", SqlDbType.NVarChar).Value = diaSeleccionado;
            cmd.Parameters.Add("@medico", SqlDbType.VarChar).Value = usuarioLogeado.UserName;
            DataTable dt = con.ExecConsulta(cmd);
            return dt;


        }
    }
}
