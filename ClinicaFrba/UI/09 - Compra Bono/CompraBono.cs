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
            InitializeComponent();
            textBoxPrecio.ReadOnly = true; // para que el precio sea solo lectura
            labelGrupoFamiliar.Text = user.GrupoFamiliar.ToString();
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
           textBoxPrecio.Text =  (numericUpDownCantidad.Value* PrecioBono).ToString();
        }

        private void buttonComprar_Click(object sender, EventArgs e)
        {
            //1- creo la conexion
            Conexion con = new Conexion();

            //2- creo el comando de tipo storeProcedure con el nombre del SP.
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_comprarBono");

            //3- agrego los parametros del SP.
            cmd.Parameters.Add("NumeroGrupoFamiliar",SqlDbType.Decimal).Value = usuarioLogeado.GrupoFamiliar;
            cmd.Parameters.Add("Username", SqlDbType.VarChar).Value = usuarioLogeado.UserName;

            //4- ejecuto el storeprocedure
            DataTable respuesta = con.ExecConsulta(cmd);
        }
    }
}
