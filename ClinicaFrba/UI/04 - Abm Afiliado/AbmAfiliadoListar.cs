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
using ClinicaFrba.UI.MenuPrincipal;
using ClinicaFrba.Logica.Entidades;

namespace ClinicaFrba.UI._04___Abm_Afiliado
{
    public partial class AbmAfiliadoListar : FormulariosBase.FormularioListadoBase
    {
        private RegistroLlegada registroLlegada;
        private PantallaPrincipal pantallaPP;
        public int numeroAccionAdmin { get; set; }
        public AbmAfiliadoListar()
        {
            InitializeComponent();
            groupBoxLlegada.Dispose();
            btnLimpiar.Dispose();
            Show();

        }

        /// <summary>
        /// Se utiliza para cuando esta ventana es una sub funcionalidad del registro de llegadas
        /// </summary>
        /// <param name="registroLlegada"></param>
        /// 





        public AbmAfiliadoListar(PantallaPrincipal pp,int numero)
        {
            InitializeComponent();
            btnModificar.Visible = false;
            pantallaPP = pp;
            groupBoxAccion.Visible = true;
            numeroAccionAdmin = numero;
            buttonParaAccion.Enabled = false;
            btnBajaAfiliado.Visible = false;
            Text = "Buscar Afiliado para realizar esta accion";
            btnAgregar.Visible = false;
            btnEliminar.Visible = false;
            btnSeleccionar.Visible = false;
            groupBoxLlegada.Visible = false;
            btnLimpiar.Visible = false;
            Show();

        }
        private void BorrarBotones()
        {

        }
        public AbmAfiliadoListar(RegistroLlegada registroLlegada)
        {
            InitializeComponent();
            BorrarBotones();
            Text = "Buscar Afiliado que acaba de llegar";

            this.registroLlegada = registroLlegada;
            InitializeComponent();

            groupBoxLlegada.Visible = true;
            groupBoxLlegada.Enabled = true;
            btnAgregar.Visible = false;
            btnEliminar.Visible = false;
            btnModificar.Visible = false;
            btnSeleccionar.Visible = false;
            BuscarEnDB();
            Show();

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarEnDB();
            buttonParaAccion.Enabled = true;

        }
        private void BuscarEnDB()
        {
            DataTable dt;
            Conexion con = new Conexion();
            string s = @"SELECT Paci_Matricula as MATRICULA, 
                                paci_nombre as NOMBRE, 
                                paci_apellido as APELLIDO,
                                Paci_TipoDocumento as TIPO_DNI,
                                paci_Dni as DNI,
	                            Paci_Direccion as DIRECCION,
                                Paci_Telefono as TELEFONO,
                                Paci_Mail as Mail,
                                Paci_Usuario as USUARIO,
                                Paci_Fecha_Nac as F_NACIMIENTO,
                                Paci_plan_Med_Cod_FK as PLAN_MEDICO,
                                Paci_sexo as SEXO,
                                Paci_Estado_civil as ESTADO_CIVIL
                               
                            FROM [GD2C2016].[GRUPOSA].[Paciente]
                            WHERE Paci_estado = 0 ";
            if (textBoxApellido.Text == "" && textBoxNombre.Text == "")
                dt = con.SimpleQuery(s);
            else
            {
                string q = s +
                             @"and paci_nombre like @paci_nom or
                                   paci_apellido like @paci_ape";
                SqlCommand cmd = con.CrearComandoQuery(q);
                cmd.Parameters.Add(new SqlParameter("@paci_nom", con.ConWildCard(textBoxNombre.Text)));
                cmd.Parameters.Add(new SqlParameter("@paci_ape", con.ConWildCard(textBoxApellido.Text)));

                dt = con.ExecConsulta(cmd);
            }

            textBoxCantidadEncontrada.Text = dt.Rows.Count.ToString();

            dgListado.DataSource = dt;
            //dgListado.DataSource = null;
            //dgListado.ColumnCount = 4;
            //dgListado.AutoGenerateColumns = false;
            dgListado.Columns[0].Visible = false; //escondo matricula
            dgListado.Columns[9].Visible = false; //escondo plan FK
                                                  //dgListado.Columns[0].DataPropertyName = "Username";
                                                  //dgListado.Columns[0].Width = 200;
                                                  //dgListado.Columns[1].Name = "Fecha creación";
                                                  //dgListado.Columns[1].DataPropertyName = "FechaCreacion";
                                                  //dgListado.Columns[1].Width = 200;
                                                  //dgListado.Columns[2].Name = "ultima modificacion";
                                                  //dgListado.Columns[2].DataPropertyName = "FechaUltimaModificacion";
                                                  //dgListado.Columns[2].Width = 200;
                                                  //dgListado.Columns[3].Name = "Inhabilitado";
                                                  //dgListado.Columns[3].DataPropertyName = "InhabilitadoString";
                                                  //dgListado.Columns[3].Width = 157;

            //dgListado.Columns[4]. = "tipo DNI";
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            var a = dgListado.SelectedRows[0];
            AbmAfiliadoCrear afi = new AbmAfiliadoCrear(a);
            Close();
            afi.Show();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //traducirTiposDniDeLaTabla();
            AbmAfiliadoCrear abm = new AbmAfiliadoCrear();
            abm.Show();
        }
        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            LlamadaBotonElimiarAfiliado();
        }
        private void dgListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //selecciona toda la fila al tocar cualquier col.
            if (e.RowIndex > -1)
            {
                dgListado.Rows[e.RowIndex].Selected = true;
                btnBajaAfiliado.Enabled = true;
            }
            else
            {
                btnBajaAfiliado.Enabled = false;
            }
        }

        private void LlamadaBotonElimiarAfiliado()
        {
            if (dgListado.SelectedRows[0] == null)
            {
                MessageBox.Show("Primero debe seleccionar un afiliado", "Afiliado ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var dr = dgListado.SelectedRows[0];
            var cells = dr.Cells;
            string usuario = cells[8].Value.ToString();
            ExecBajaLogica(usuario);
            //MessageBox.Show("afiliado dado de baja", "Afiliado ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void ExecBajaLogica(string usuario)
        {
            Conexion con = new Conexion();
            try
            {
                SqlCommand cmd = con.CrearComandoStoreProcedure("sp_bajaAfiliado");
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                cmd.Parameters.Add("@fechaHoy", SqlDbType.DateTime).Value = StaticUtils.getDateTime();
                con.ExecConsulta(cmd);

                //SqlCommand bajaTurnos = con.CrearComandoStoreProcedure("sp_turnosUsuarioBaja");
                //bajaTurnos.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                //con.ExecConsulta(bajaTurnos);
                
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
            MessageBox.Show("este boton no deberias verlo", "Afiliado ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void buttonTurnoHoy_Click(object sender, EventArgs e)
        {
            var a = dgListado.SelectedRows[0];
            if (a != null)
            {
                registroLlegada.ElTurnoEsPara(a);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un afiliado", "Afiliado no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Hide();
            Dispose();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgListado.DataSource = null;

        }
        private void buttonParaAccion_Click(object sender, EventArgs e)
        {
            var a = dgListado.SelectedRows[0];
            if (a != null)
            {
                var cells = a.Cells;
                UsuarioLogeado ua = new UsuarioLogeado();
                ua.PacienteMatricula = cells[0].Value.ToString();
                ua.UserName = cells[8].Value.ToString();
                LogInHelper helper = new LogInHelper();
                ua = helper.GetUsuario(ua.UserName);
                pantallaPP.afiliadoSeleccionado(ua,numeroAccionAdmin);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un afiliado", "Afiliado no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Hide();
            Dispose();
        }

        private void textBoxCantidadEncontrada_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnBajaAfiliado_Click(object sender, EventArgs e)
        {
            LlamadaBotonElimiarAfiliado();
        }
    }
}
