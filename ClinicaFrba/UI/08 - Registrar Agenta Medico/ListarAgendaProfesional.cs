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
            //ComboBoxManager cm = new ComboBoxManager();
            //comboBoxDia = cm.CrearDias(comboBoxDia);
            CheckIfMasDe48hs();
            Show();

        }

        private void comboBoxDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            CrearNuevoHorario nuevoHorario = new CrearNuevoHorario(usuarioLogeado,this);
            nuevoHorario.Show();
        }

        private void CheckIfMasDe48hs()
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoQuery(@"select isnull(sum(DATEDIFF(MINUTE,h.Hora_Inicio, h.Hora_Fin)),0) as horas 
            from gruposa.HorariosAtencion h join gruposa.Medico m on h.Hora_Medico_Id_FK = m.Medi_Id
            where m.Medi_Id =@medico ");
            cmd.Parameters.Add("@medico", SqlDbType.VarChar).Value = usuarioLogeado.MedicoMatricula;
            DataTable dt = con.ExecConsulta(cmd);

            if (int.Parse(dt.Rows[0][0].ToString()) > 2880)
            {
                MessageBox.Show("¡error, supera las 48hs semanales, no puede agregar mas!", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAgregar.Enabled = false;

            }
        }

        //        private DataTable GetAgendaDeldia(int diaSeleccionado)
        //        {
        //            Conexion con = new Conexion();
        //            SqlCommand cmd = con.CrearComandoQuery(@"SELECT *
        //                                                         FROM [GD2C2016].[GRUPOSA].[HorariosAtencion]
        //                                                            where Hora_dia = datename(weekday,@dia)
        //                                                            and Hora_Medico_Id_FK = @medico");
        //            cmd.Parameters.Add("@dia", SqlDbType.Int).Value = diaSeleccionado;
        //            cmd.Parameters.Add("@medico", SqlDbType.VarChar).Value = usuarioLogeado.MedicoMatricula;
        //            DataTable dt = con.ExecConsulta(cmd);
        //            return dt;
        //        }

        private void buttonVerDia_Click(object sender, EventArgs e)
        {
            RefrescarLista();
        }

        public void RefrescarLista()
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoQuery(@"SELECT h.hora_dia, h.Hora_Inicio, h.Hora_Fin, 
(SELECT e.Espe_Desc FROM GRUPOSA.Especialidades e WHERE e.Espe_Cod = h.Hora_Especialidad) AS Especialidad,  
(SELECT 'Dr. ' + UPPER(SUBSTRING(M.Medi_Apellido,1,1))+(SUBSTRING(M.Medi_Apellido,2,50))+' '+UPPER(SUBSTRING(M.Medi_Nombre,1,1))+LOWER(SUBSTRING(M.Medi_Nombre,2,50)) FROM GRUPOSA.Medico M WHERE M.Medi_Id = h.Hora_Medico_Id_FK) AS Profesional
 from GRUPOSA.HorariosAtencion h where h.Hora_Medico_Id_FK =@matricula");

            cmd.Parameters.Add("@matricula", SqlDbType.VarChar).Value = usuarioLogeado.MedicoMatricula;
            DataTable dt = con.ExecConsulta(cmd);
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
