using ClinicaFrba.FormulariosBase;
using ClinicaFrba.Helpers;
using ClinicaFrba.Pedir_Turno;
using ClinicaFrba.UI._04___Abm_Afiliado;
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

namespace ClinicaFrba.UI._11___Registro_Llegada
{
    public partial class RegistroLlegada : FormularioListadoBase
    {
        private AbmAfiliadoListar abmAfiliado;
        private PedirTurno pedidorTurnos;
        public RegistroLlegada()
        {
            InitializeComponent();
            EsconderBotones();
            Show();
            groupBoxPacienteSeleccionado.Visible = false;
        }

        private void EsconderBotones()
        {
            btnAgregar.Visible = btnEliminar.Visible =  false;
            btnLimpiar.Visible = btnBuscar.Visible =  false;
            btnModificar.Enabled = false;
            btnSeleccionar.Enabled = false;
        }


        /// <summary>
        /// Este metodo es llamado por un AbmListarAfiliados quien envia la fila que representa a un afi.
        /// </summary>
        /// <param name="dr"></param>
        public void ElTurnoEsPara(DataGridViewRow dr)
        {
            var cells = dr.Cells;
            pacienteNombreLabel.Text = cells[1].Value.ToString();
            pacienteApellidoLabel.Text = cells[2].Value.ToString();
            idPacienteLabel.Text = cells[0].Value.ToString();
            btnModificar.Enabled = true;
            btnSeleccionar.Enabled = true;
            btnSeleccionar.Visible = true;
            groupBoxPacienteSeleccionado.Visible = true;

            MostrarTurnosDeHoy();
            Show();
        }

        private void MostrarTurnosDeHoy()
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_turnosActivosPaciente");
            cmd.Parameters.Add("@paci_usuario", SqlDbType.VarChar).Value = idPacienteLabel.Text;
            DataTable dt = con.ExecConsulta(cmd);
            dgListado.DataSource = dt;
        }

        public void TurnoSeleccionado(string nombreMedico, string hora)
        {
            MessageBox.Show("El turno para el paciente con" + nombreMedico + "a las" + hora + "fue programado correctamente"
                , "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
        private void btnMedicoHora_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(StaticUtils.getDate());
            pedidorTurnos = new PedirTurno(this,idPacienteLabel.Text,date);
            Hide();
            Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbmAfiliadoListar afilistar = new AbmAfiliadoListar(this);
            Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            BorrarBono();
        }

        private void BorrarBono()
        {
            string q = @" UPDATE GRUPOSA.Bonos
                            SET bono_expirado = 1
                            WHERE Bono_Consulta_Numero IN (SELECT TOP 1 Bono_Consulta_Numero FROM GRUPOSA.Bonos B JOIN GRUPOSA.Paciente P ON B.Bono_Paci_Id = P.Paci_Matricula
								                            AND P.Paci_Usuario = '@id'
								                            AND bono_fecha_compra_usado IS NULL)";
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoQuery(q);
            cmd.Parameters.Add(new SqlParameter("@id", idPacienteLabel.Text));
            con.ExecConsulta(cmd);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}


//UPDATE GRUPOSA.Bonos
//SET bono_expirado = 1
//WHERE Bono_Consulta_Numero IN (SELECT TOP 1 Bono_Consulta_Numero FROM GRUPOSA.Bonos B JOIN GRUPOSA.Paciente P ON B.Bono_Paci_Id = P.Paci_Matricula

//                                AND P.Paci_Usuario = 'aaron_sánchez_00000101'

//                                AND bono_fecha_compra_usado IS NULL)