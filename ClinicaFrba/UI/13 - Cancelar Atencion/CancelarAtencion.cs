using ClinicaFrba.FormulariosBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.UI._12___Registro_Resultado
{
    public partial class CancelarAtencion : FormularioListadoBase
    {
        private string usuarioMatricula;

        public CancelarAtencion(string usuarioMatriculaa)
        {
            InitializeComponent();
            usuarioMatricula = usuarioMatriculaa;
            BuscarTurnosDelUsuario();
            Text = "Cancelacion de atencion - Medico";
        }

        private void BuscarTurnosDelUsuario()
        {
            throw new NotImplementedException();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }
    }
}
