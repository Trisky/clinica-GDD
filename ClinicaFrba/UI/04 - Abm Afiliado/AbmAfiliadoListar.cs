using ClinicaFrba.Helpers;
using ClinicaFrba.UI._05___Abm_Profesional;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.UI._11___Registro_Llegada;

namespace ClinicaFrba.UI._04___Abm_Afiliado
{
    public partial class AbmAfiliadoListar : FormulariosBase.FormularioListadoBase
    {
        private RegistroLlegada registroLlegada;

        public AbmAfiliadoListar()
        {
            InitializeComponent();
            groupBoxLlegada.Dispose();
            Show();
        }

        /// <summary>
        /// Se utiliza para cuando esta ventana es una sub funcionalidad del registro de llegadas
        /// </summary>
        /// <param name="registroLlegada"></param>
        public AbmAfiliadoListar(RegistroLlegada registroLlegada)
        {
            this.registroLlegada = registroLlegada;
            InitializeComponent();
            groupBoxLlegada.Enabled = true;

            Show();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt;
            Conexion con = new Conexion();
            if(textBoxApellido.Text == ""  && textBoxNombre.Text == "")
                dt = con.SimpleQuery("SELECT * FROM [GD2C2016].[GRUPOSA].[Paciente]");
            else
            {
                string q = @"SELECT * FROM [GD2C2016].[GRUPOSA].[Paciente]
                             where paci_nombre like @paci_nom and
                                   paci_apellido like @paci_ape";
                SqlCommand cmd = con.CrearComandoQuery(q);
                cmd.Parameters.Add(new SqlParameter("@paci_nom", con.ConWildCard(textBoxNombre.Text)));
                cmd.Parameters.Add(new SqlParameter("@paci_ape", con.ConWildCard(textBoxApellido.Text)));

                dt = con.ExecConsulta(cmd);
            }

            textBoxCantidadEncontrada.Text = dt.Rows.Count.ToString();
            
            //dgListado.DataSource = null;
            //dgListado.ColumnCount = 4;
            //dgListado.AutoGenerateColumns = false;
            //dgListado.Columns[0].Name = "Username";
            //dgListado.Columns[0].DataPropertyName = "Username";
            //dgListado.Columns[0].Width = 200;
            //dgListado.Columns[1].Name = "Fecha creación";
            //dgListado.Columns[1].DataPropertyName = "FechaCreacion";
            //dgListado.Columns[1].Width = 200;
            //dgListado.Columns[2].Name = "Fecha última modificacion";
            //dgListado.Columns[2].DataPropertyName = "FechaUltimaModificacion";
            //dgListado.Columns[2].Width = 200;
            //dgListado.Columns[3].Name = "Inhabilitado";
            //dgListado.Columns[3].DataPropertyName = "InhabilitadoString";
            //dgListado.Columns[3].Width = 157;
            dgListado.DataSource = dt;
            dgListado.Columns[4].Name = "tipo DNI";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var a = dgListado.SelectedRows[0];
            AbmAfiliadoCrear afi = new AbmAfiliadoCrear(a);
            afi.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbmAfiliadoCrear abm = new AbmAfiliadoCrear();
            abm.Show();
        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            var dr = dgListado.SelectedRows[0];
            var cells = dr.Cells;
            string usuario = cells[13].Value.ToString();
            ExecBajaLogica(usuario);

        }

        private void ExecBajaLogica(string usuario)
        {
            Conexion con = new Conexion();
            try
            {
                SqlCommand cmd = con.CrearComandoStoreProcedure("sp_bajaAfiliado");
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                con.ExecConsulta(cmd);
                MessageBox.Show("Afiliado eliminado", "Afiliado ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error al eliminar eliminado", "Afiliado ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            


        }

        private void buttonSeleccionParaTurno_Click(object sender, EventArgs e)
        {
            var a = dgListado.SelectedRows[0];
            if (a!= null)
            {
                registroLlegada.ElTurnoEsPara(a);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un afiliado", "Afiliado ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            
        }
    }
}
