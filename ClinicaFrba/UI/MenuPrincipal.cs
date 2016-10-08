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

namespace ClinicaFrba.UI
{
    public partial class MenuPrincipal : Form
    {
        public UsuarioLogeado UsuarioLogeado { get; set; }
        public MenuPrincipal(Form loginForm,UsuarioLogeado user)
        {
            
            InitializeComponent();
            loginForm.Visible = false;
            UsuarioLogeado = user;
            label1.Text = UsuarioLogeado.UserName;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
