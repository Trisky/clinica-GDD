using ClinicaFrba.FormulariosBase;
using ClinicaFrba.Helpers;
using ClinicaFrba.Pedir_Turno;
using ClinicaFrba.UI._04___Abm_Afiliado;
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
            idPacienteLabel.Text = cells[7].Value.ToString(); //es el usuario en el sistema
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

            

            //ahora filtro los que no son de hoy
            DateTime hoy = StaticUtils.getDateTime().Date;
            foreach (DataRow row in dt.Rows)
            {
                DateTime fechaTurno= row.Field<DateTime>("Fecha").Date; ;
                //DateTime fechaTurno = (Convert.ToDateTime(cells[3].Value.ToString())).Date;
                if (fechaTurno != hoy)
                {
                    row.Delete(); //escondo la datarow si no es de hoy.
                }
            }
        }

        public void TurnoSeleccionado(string nombreMedico, string hora)
        {
            MessageBox.Show("El turno para el paciente con" + nombreMedico + "a las" + hora + "fue programado correctamente"
                , "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
        private void btnMedicoHora_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbmAfiliadoListar afilistar = new AbmAfiliadoListar(this);
            Hide();
        }

        internal void MostrarTurnosProfesional(string matriculaProfesional)
        {
            throw new NotImplementedException();


            Show();
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            VerificarSiTieneBonos(idPacienteLabel.Text);
        }

        
        private void VerificarSiTieneBonos(string idPaciente)
        {
            Conexion con = new Conexion();
            string s = @" SELECT count( [Bono_Id])
                          FROM [GD2C2016].[GRUPOSA].[Bonos]
                          where SUBSTRING(@id,1,6)=SUBSTRING(Bono_Paci_Id,1,6) and
                          Bono_expirado = 0";
            SqlCommand cmd = con.CrearComandoQuery(s);
            cmd.Parameters.Add(new SqlParameter("@id", idPaciente));
            DataTable dt = con.ExecConsulta(cmd);
            if (dt.Rows.Count == 0)
                UstedNoTieneBonos();
            int c = dt.Rows[0].Field<int>(0);

            if (c < 1)
            {
                UstedNoTieneBonos();
                return;
            }

            else
            {
                MessageBox.Show("A este paciente ahora le queda una cantidad de bonos de: " + (c-1).ToString()
                    , "Tiene bonos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            BorrarBono();

        }

        private static void UstedNoTieneBonos()
        {
            MessageBox.Show("Este paciente no tiene bonos, debe comprar antes de realizar esta accion"
                                , "Sin bonos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
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
            MessageBox.Show("Atencion borrada correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Dispose();
        }

        private void buttonBuscarTurnosMedico_Click(object sender, EventArgs e)
        {
            AbmProfesionalListado prof = new AbmProfesionalListado(this);
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pedidorTurnos = new PedirTurno(this);
            Hide();
            //Dispose();
        }

        internal void elMedicoEs(string idMedico)
        {

            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_turnosOcupadosDelDia");
            cmd.Parameters.Add("@idMedico", SqlDbType.VarChar).Value = idMedico;
            cmd.Parameters.Add("@fecha", SqlDbType.VarChar).Value = StaticUtils.getDate();
            DataTable dt = con.ExecConsulta(cmd);
            dgListado.DataSource = dt;
            
        }
    }
}


//UPDATE GRUPOSA.Bonos
//SET bono_expirado = 1
//WHERE Bono_Consulta_Numero IN (SELECT TOP 1 Bono_Consulta_Numero FROM GRUPOSA.Bonos B JOIN GRUPOSA.Paciente P ON B.Bono_Paci_Id = P.Paci_Matricula

//                                AND P.Paci_Usuario = 'aaron_sánchez_00000101'

//                                AND bono_fecha_compra_usado IS NULL)