using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClinicaFrba.FormulariosBase
{
    public partial class FormularioEdicionBase : FormBase
    {

        public FormularioEdicionBase()
        {
            InitializeComponent();


            this.FindForm().AcceptButton = this.btnGuardar;
            this.FindForm().CancelButton = this.btnCancelar;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Cierra el formulario.
            this.Dispose();
        }

    }
}
