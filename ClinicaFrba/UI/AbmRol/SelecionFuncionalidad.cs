using ClinicaFrba.Logica.Entidades;
using ClinicaFrba.Pedir_Turno;
using ClinicaFrba.UI._04___Abm_Afiliado;
using ClinicaFrba.UI._05___Abm_Profesional;
using ClinicaFrba.UI._13___Cancelar_Atencion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.UI.MenuPrincipal
{
    public partial class SelecionFuncionalidad : Form
    {
        public UsuarioLogeado usuario { get; set; }
        public SelecionFuncionalidad(UsuarioLogeado user)
        {
            InitializeComponent();
            usuario = user;
            Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void AutoSeleccionarFuncionalidad()
        {
            if (comboBoxRol.Items.Count == 1)
            {
                comboBoxRol.SelectedIndex = 0;
                comboBoxRol.Enabled = false;
            }
               
        }

        
        public void AutoSeleccionarRol()
        {
            if (comboBoxFuncionalidad.Items.Count == 1)
            {
                comboBoxFuncionalidad.SelectedIndex = 0;
                comboBoxFuncionalidad.Enabled = false;
                buttonGo.Enabled = true;

            }
                
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AbmAfiliadoListar afi = new AbmAfiliadoListar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PedirTurno turnos = new PedirTurno(usuario); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CancelarAtencionAfiliado canc = new CancelarAtencionAfiliado(usuario);
            canc.ShowDialog();
        }
    }
}
