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
        }

        private void CancelarAtencionMedico_Load(object sender, EventArgs e)
        {
            fechas=baja.obtenerFechas(usuario.MedicoMatricula,DateTime.Today);
            diaryDoctor.BoldedDates = fechas;
            diaryDoctor.UpdateBoldedDates();
        }

        BajaAtencion baja = new BajaAtencion();
        private int mes = DateTime.Today.Month;
        private UsuarioLogeado usuario;
        private DateTime[] fechas;

        private void diaryDoctor_DateSelected(object sender, DateRangeEventArgs e)
        {
            //falta agregar excepciones
            if (e.Start < DateTime.Today)
            {
                MessageBox.Show("Periodo no valido");
            }
            else
            {
                txtInitDate.Text = e.Start.ToString();
                txtLastDate.Text = e.End.ToString();
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

        
    }

}
