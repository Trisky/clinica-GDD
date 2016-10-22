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
    public partial class FormularioListadoBase : FormBase
    {
        public FormularioListadoBase()
        {
            InitializeComponent();
        }

        private void dgListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //selecciona toda la fila al tocar cualquier col.
            if (e.RowIndex > -1)
            {
                dgListado.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgListado_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            bool tieneFilas = (dgListado.Rows.Count > 0);
            btnEliminar.Enabled = tieneFilas;
            btnModificar.Enabled = tieneFilas;
            btnSeleccionar.Enabled = tieneFilas;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        public void btnSeleccionar_Click(object sender, EventArgs e)
        {

        }

        private void dgListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
