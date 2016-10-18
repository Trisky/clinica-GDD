using ClinicaFrba.Logica.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Compra_Bono
{
    public partial class CompraBono : Form
    {
        public CompraBono(UsuarioLogeado user)
        {
            InitializeComponent();
            textBoxPrecio.ReadOnly = true; // para que el precio sea solo lectura
            labelGrupoFamiliar.Text = user.GrupoFamiliar.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
