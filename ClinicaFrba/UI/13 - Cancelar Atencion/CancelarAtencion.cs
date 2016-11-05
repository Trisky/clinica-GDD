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
        }

        private void BuscarTurnosDelUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
