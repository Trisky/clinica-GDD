using ClinicaFrba.FormulariosBase;
using ClinicaFrba.Helpers;
using ClinicaFrba.Logica.Entidades;
using ClinicaFrba.Logica.Roles;
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
    public partial class ElegirRol : FormBase
    {
        public UsuarioLogeado usuario { get; set; }

        public ElegirRol(UsuarioLogeado user)
        {
            usuario = user;
            InitializeComponent();
            ComboBoxManager cm = new ComboBoxManager();
            comboBoxRol = cm.cargarRoles(user,comboBoxRol);
            Show();
        }



        private void Elegir_rol_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void aceptarRolBoton_Click(object sender, EventArgs e)
        {
          
        }

        private void aceptarRolBoton_Click_1(object sender, EventArgs e)
        {
            Rol rol = new Rol();
            String codigo;
            codigo = Convert.ToString(comboBoxRol.SelectedValue);
            rol.Codigo = Convert.ToInt32(codigo);
            usuario.Roles.Clear();
            usuario.Roles.Add(rol);
            Dispose();
            PantallaPrincipal pp = new PantallaPrincipal(usuario);
        }
    }
}
