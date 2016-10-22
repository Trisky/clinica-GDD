using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using MercadoEnvios.Entidades.Clases;
using ClinicaFrba.Logica.Entidades;

namespace ClinicaFrba.FormulariosBase
{
    public partial class FormBase : Form
    {
        private UsuarioLogeado usuarioLogueado;
        public UsuarioLogeado UsuarioLogueado
        {
            get
            {
                return usuarioLogueado;
            }
            set
            {
                usuarioLogueado = value;
            }
        }

        public FormBase()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
