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
using ClinicaFrba.UI._08___Registrar_Agenta_Medico;


namespace ClinicaFrba.Pedir_Turno
{

    public partial class PedirTurno : FormBase
    {
        public UsuarioLogeado usuarioLogeado { get; set; }

        public PedirTurno()
        {
            InitializeComponent();
            Show();
            ComboBoxManager listaEspecialidades = new ComboBoxManager();
            cmbBoxListadoEspecialidades = listaEspecialidades.CrearEspecialidades(cmbBoxListadoEspecialidades);
            monthCalendar1.MaxSelectionCount = 1;

        }

        private void cmbBoxListadoEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            string especialidad;
            especialidad = cmbBoxListadoEspecialidades.SelectedValue.ToString();
            ComboBoxManager comboMed = new ComboBoxManager();
            cmbMedicos = comboMed.ListarMedicos(especialidad, cmbMedicos);

        }

        private void btnPedirTurno(object sender, EventArgs e)
        {
            String especialidadSeleccionada = cmbBoxListadoEspecialidades.SelectedValue.ToString();
            String idMedico = cmbMedicos.SelectedValue.ToString();
            String diaSeleccionado = monthCalendar1.SelectionRange.Start.ToString();

            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_turnosMedicosDisponibles");
            cmd.Parameters.Add("@especialidad", SqlDbType.NVarChar).Value = especialidadSeleccionada;
            cmd.Parameters.Add("@diaConsultado", SqlDbType.NVarChar).Value = diaSeleccionado;
            cmd.Parameters.Add("@id_medico", SqlDbType.NVarChar).Value = idMedico;
            DataTable dTurnos = con.ExecConsulta(cmd);
            dataGridView1.DataSource = dTurnos;

        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        private void PedirTurno_Load(object sender, EventArgs e)
        {

        }

        private void tbAfiliado_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
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

        private void cmbMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }
       
    }
       
}


