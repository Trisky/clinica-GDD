using ClinicaFrba.Helpers;
using ClinicaFrba.Logica.Entidades;
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

namespace ClinicaFrba.Compra_Bono
{
    public partial class CompraBono : Form
    {
        public Decimal PrecioBono { get; set; }
        public UsuarioLogeado usuarioLogeado { get; set; }
        public CompraBono(UsuarioLogeado user)
        {
            usuarioLogeado = user;   
            InitializeComponent();
            textBoxPrecio.ReadOnly = true; // para que el precio sea solo lectura
            labelGrupoFamiliar.Text = user.GrupoFamiliar.ToString();
            idPlanMedicoLabel.Text = user.planMedico;
            getPreciosPlanMedico(user.planMedico);
            radioButtonAtencion.Checked = true;
            Show();

        }

        private void getPreciosPlanMedico(string planMedico)
        {

            //llamar a la base y traer los precios
            string s = @"SELECT
                              [Plan_Precio_Bono_Consulta]
                              ,[Plan_Precio_Bono_Farmacia]
                          FROM [GD2C2016].[GRUPOSA].[PlanesMedicos]
                          where Plan_Codigo = @planmed";

            Conexion con = new Conexion();
            
            SqlCommand cmd = con.CrearComandoQuery(s);
            if(usuarioLogeado.planMedico == null)
            {
                MessageBox.Show("el usuario no tiene un plan medico asignado" , "Afiliado ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Hide();
                return;
            }
            cmd.Parameters.Add(new SqlParameter("@planmed", usuarioLogeado.planMedico));
            DataTable dt = con.ExecConsulta(cmd);
            
            
            //DataGridView dgListado = new DataGridView();
            
            //dgListado.DataSource = dt;
            //var rows = dgListado.ro
            //var cells = dgListado.Cells;
            //DataGridViewRow dr = dgListado.Rows[0];
            precioFarmaciaLabel.Text = dt.Rows[0].ItemArray[0].ToString();
            precioAtencionLabel.Text = dt.Rows[0].ItemArray[1].ToString();
            //precioFarmaciaLabel.Text = dr.Cells[0].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Actualizo el valor del textbox precio cada 
        /// vez que el usuario cambia la cantidad de bonos que quiere
        /// </summary>
        private void numericUpDownCantidad_ValueChanged(object sender, EventArgs e)
        {
            actualizarPrecio();
        }

        private string actualizarPrecio()
        {
            string a = "0" ;
            if (radioButtonFarmacia.Checked)
                a = precioFarmaciaLabel.Text;
            if (radioButtonAtencion.Checked)
                a = precioAtencionLabel.Text;
            textBoxPrecio.Text = (numericUpDownCantidad.Value * Convert.ToInt32(a)).ToString();
            return textBoxPrecio.Text;
        }

        private void buttonComprar_Click(object sender, EventArgs e)
        {
            //1- creo la conexion
            Conexion con = new Conexion();

            //2- creo el comando de tipo storeProcedure con el nombre del SP.
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_comprarBono");

            //3- agrego los parametros del SP.
            cmd.Parameters.Add("@matricula",SqlDbType.Decimal).Value = usuarioLogeado.PacienteMatricula;
            cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = usuarioLogeado.UserName;
            //TODO cmd.Parameters.Add("fechaHoy", SqlDbType.VarChar).Value = StaticUtils.getDate();
            //4- ejecuto el storeprocedure
            DataTable respuesta = con.ExecConsulta(cmd);

            //5- informo resultado
            string precio = actualizarPrecio();
            MessageBox.Show("Debe pagar"+precio, "Afiliado ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

       

        private void idPlanMedicoLabel_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonFarmacia_CheckedChanged(object sender, EventArgs e)
        {
            actualizarPrecio();
        }

        private void radioButtonAtencion_CheckedChanged(object sender, EventArgs e)
        {
            actualizarPrecio();
        }
    }
}
