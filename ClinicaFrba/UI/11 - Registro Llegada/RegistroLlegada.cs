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

namespace ClinicaFrba.Registro_Llegada
{
    public partial class RegistroLlegada : FormBase
    {
        private AbmAfiliadoListar abmAfiliado;
        private PedirTurno pedidorTurnos;
        public RegistroLlegada()
        {
            InitializeComponent();
            pedidorTurnos = new PedirTurno();
            abmAfiliado = new AbmAfiliadoListar(this);
        }

        internal void ElTurnoEsPara(DataGridViewRow dr)
        {
            var cells = dr.Cells;
            var nombre = cells[1].Value.ToString();
            var apellido = cells[2].Value.ToString();
            var IDAfiliado = cells[0].Value.ToString();
        }
    }
}
