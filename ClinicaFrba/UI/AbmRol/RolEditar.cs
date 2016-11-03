using ClinicaFrba.FormulariosBase;
using ClinicaFrba.Helpers;
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

namespace ClinicaFrba.UI.AbmRol
{
    public partial class RolEditar : FormularioEdicionBase
    {
        private Rol rol;
        public RolEditar()
        {
            InitializeComponent();
            CargarCheckListFuncionalidades(ref checkedListFuncionalidades);
            Show();
        }

        private Rol ObtenerRolDelFormulario()
        {
            try
            {
                //Si es un Alta
                if (rol == null)
                {
                    rol = new Rol();
                }
                rol.Nombre = textBoxNombre.Text;
                rol.Estado = checkBoxInhabilitar.Checked;
                rol.EsAdmin = checkBoxAdmin.Checked;
                rol.Funcionalidades = new List<Funcionalidad>();
                foreach (Funcionalidad item in checkedListFuncionalidades.CheckedItems)
                {
                    rol.Funcionalidades.Add(item);
                }

                return rol;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public static void CargarCheckListFuncionalidades(ref CheckedListBox chk)
        {

            DataTable dtFuncionalidades = new DataTable();
            Conexion con = new Conexion();
            dtFuncionalidades = con.SimpleQuery("SELECT Func_Codigo, Func_Desc FROM [GD2C2016].[GRUPOSA].[Funcionalidad]");

            List<Funcionalidad> lstFuncionalidades = dtFuncionalidades.AsEnumerable().Select(x => new Funcionalidad
            {
                Codigo = Convert.ToInt32(Convert.ToString(x["Func_Codigo"])),
                Descripcion = Convert.ToString(x["Func_Desc"] ?? string.Empty)
            }).ToList();
            
            ((ListBox)chk).DataSource = lstFuncionalidades;
            ((ListBox)chk).DisplayMember = "Descripcion";
            ((ListBox)chk).ValueMember = "Codigo";
        }

        private void gcAccion_Enter(object sender, EventArgs e)
        {

        }

        private void checkBoxAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxInhabilitar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
