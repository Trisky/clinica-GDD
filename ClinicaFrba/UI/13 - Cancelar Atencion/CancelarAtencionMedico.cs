using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ClinicaFrba.Helpers;
using ClinicaFrba.Logica.Entidades;
using ClinicaFrba.FormulariosBase;

namespace ClinicaFrba.UI._13___Cancelar_Atencion
{
    public partial class CancelarAtencionMedico : Form
    {
        public CancelarAtencionMedico(UsuarioLogeado user)
        {
            InitializeComponent();
            usuario = user;
            fechaHoy = Convert.ToDateTime(StaticUtils.getDate());
            mes = fechaHoy.Month; 
            diaryDoctor.TodayDate= StaticUtils.getDateTime();
            Show();
        }

        private void CancelarAtencionMedico_Load(object sender, EventArgs e)
        {
            fechas=baja.obtenerFechas(usuario.MedicoMatricula,fechaHoy);
            diaryDoctor.BoldedDates = fechas;
            diaryDoctor.UpdateBoldedDates();
        }

        BajaAtencion baja = new BajaAtencion();
        
        private UsuarioLogeado usuario;
        private DateTime[] fechas;
        private DateTime fechaHoy;
        private int mes;

        private void diaryDoctor_DateSelected(object sender, DateRangeEventArgs e)
        {
            //falta agregar excepciones
            if (e.Start < fechaHoy)
            {
                MessageBox.Show("Periodo no válido");
            }
            else
            {
                txtInitDate.Text = e.Start.ToShortDateString();
                txtLastDate.Text = e.End.ToShortDateString();
            }
        }

        private void diaryDoctor_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (e.Start.Month != mes)
            {
                fechas = baja.obtenerFechas(usuario.MedicoMatricula, e.Start);
                diaryDoctor.BoldedDates = fechas;
                diaryDoctor.UpdateBoldedDates();
                mes = e.Start.Month;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            baja.bajaTurnosMedico(txtInitDate.Text,txtLastDate.Text,usuario.MedicoMatricula,txtReason.Text);
            int a =txtInitDate.Text.Count();
            if ( a > 0)
            MessageBox.Show("Se cancelaron los turnos entre: "+txtInitDate.Text+ " y " + txtLastDate.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void selectionDates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtReason_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        
    }

}
