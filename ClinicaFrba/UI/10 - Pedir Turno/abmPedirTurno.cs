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

            ComboBoxManager cb = new ComboBoxManager();

            cmbBoxListadoEspecialidades = cb.CrearEspecialidades(cmbBoxListadoEspecialidades);

 
     
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

        private void tbAfiliado_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnBuscarTurnos.Text = "Buscar Turnos";
            using (ListarAgendaProfesional agenda = new ListarAgendaProfesional(usuarioLogeado))
            {

            }
        }

        private void cmbBoxListadoEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            string especialidad;
            especialidad = cmbBoxListadoEspecialidades.SelectedValue.ToString();
            ComboBoxManager combomed = new ComboBoxManager();

            cmbMedicos = combomed.ListarMedicos(especialidad, cmbMedicos);

        }

                
        /*
        private void btnBuscarTurno_Click(object sender, EventArgs e)
        {
            using (FrmAgendaConsultar frm = new FrmAgendaConsultar(2))
            {
                frm.ShowDialog(this);

                if (frm.TurnoSeleccionado != null)
                {
                    this._turno = frm.TurnoSeleccionado;
                    this.textBox1.Text = _turno.ToString();
                    this.btnAceptar.Enabled = true;
                }

            */
        }
       
    }


