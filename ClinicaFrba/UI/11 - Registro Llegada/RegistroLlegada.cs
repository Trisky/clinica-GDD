using ClinicaFrba.FormulariosBase;
using ClinicaFrba.Helpers;
using ClinicaFrba.Pedir_Turno;
using ClinicaFrba.UI._04___Abm_Afiliado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.UI._11___Registro_Llegada
{
    public partial class RegistroLlegada : FormBase
    {
        private AbmAfiliadoListar abmAfiliado;
        private PedirTurno pedidorTurnos;
        public RegistroLlegada()
        {
            InitializeComponent();
            btnMedicoHora.Enabled = false;
            Show();
        }

        /// <summary>
        /// Este metodo es llamado por un AbmListarAfiliados quien envia la fila que representa a un afi.
        /// </summary>
        /// <param name="dr"></param>
        public void ElTurnoEsPara(DataGridViewRow dr)
        {
            var cells = dr.Cells;
            pacienteNombreLabel.Text = cells[1].Value.ToString();
            pacienteApellidoLabel.Text = cells[2].Value.ToString();
            idPacienteLabel.Text = cells[0].Value.ToString();
            btnMedicoHora.Enabled = true;
            Show();
        }

        public void TurnoSeleccionado(string nombreMedico, string hora)
        {
            MessageBox.Show("El turno para el paciente con" + nombreMedico + "a las" + hora + "fue programado correctamente"
                , "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// muestro la ventana de seleccion de medico y hora y cierro esta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMedicoHora_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(StaticUtils.getDate());
            pedidorTurnos = new PedirTurno(this,idPacienteLabel.Text,date);
            Hide();
            Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbmAfiliadoListar afilistar = new AbmAfiliadoListar(this);
            Hide();
        }
    }
}
