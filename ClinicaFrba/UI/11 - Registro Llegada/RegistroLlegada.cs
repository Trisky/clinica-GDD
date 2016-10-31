using ClinicaFrba.FormulariosBase;
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
            
            abmAfiliado = new AbmAfiliadoListar(this);
        }

        public void ElTurnoEsPara(DataGridViewRow dr)
        {
            var cells = dr.Cells;
            pacienteNombreLabel.Text = cells[1].Value.ToString();
            pacienteApellidoLabel.Text = cells[2].Value.ToString();
            idPacienteLabel.Text = cells[0].Value.ToString();
        }

        public void TurnoSeleccionado(string nombreMedico, string hora)
        {
            MessageBox.Show("El turno para el paciente con" + nombreMedico + "a las" + hora + "fue programado correctamente"
                , "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMedicoHora_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            pedidorTurnos = new PedirTurno(this,idPacienteLabel.Text,date);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
