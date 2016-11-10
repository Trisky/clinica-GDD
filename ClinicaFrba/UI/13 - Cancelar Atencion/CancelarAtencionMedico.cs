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
        private UsuarioLogeado usuario;
        private DateTime fechaInicio;
        private DateTime fechaFinal;
        DateTime[] fechas;
        public CancelarAtencionMedico(UsuarioLogeado user)
        {
            InitializeComponent();
            usuario = user;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            //falta agregar excepciones
            if (e.Start < DateTime.Today)
            {
                MessageBox.Show("La fecha de inicio no esta disponible");
            }
            else
            {
                fechaInicio = e.Start;
                fechaFinal = e.End;
                textBox1.Text = fechaInicio.ToString();
                textBox2.Text = fechaFinal.ToString();
            }
        }

        private void CancelarAtencionMedico_Load(object sender, EventArgs e)
        {
            fechas=baja.obtenerFechas(usuario.MedicoMatricula, DateTime.Today);
            monthCalendar1.BoldedDates = fechas;
            monthCalendar1.UpdateBoldedDates();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (e.Start.Month != mes)
            {
                fechas = baja.obtenerFechas(usuario.MedicoMatricula, e.Start);
                monthCalendar1.BoldedDates = fechas;
                monthCalendar1.UpdateBoldedDates();
                mes = e.Start.Month;
            }
            
        }

        BajaAtencion baja = new BajaAtencion();
        int mes = DateTime.Today.Month;
    }

}
