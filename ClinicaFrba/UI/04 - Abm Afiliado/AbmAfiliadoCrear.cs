using ClinicaFrba.FormulariosBase;
using ClinicaFrba.Helpers;
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

namespace ClinicaFrba.UI._05___Abm_Profesional
{
    public partial class AbmAfiliadoCrear : FormBase
    {

        public List<int> Especialidades { get; set; }
        public bool estaModificando { get; set; }
        public string IDAfiliado { get; set; }
        public string IDfamiliar { get;  set; } //para mandarle a la base que familiar quiero
        public string HijoConcubino { get; private set; }

        #region constructores
        /// <summary>
        /// para crear un afiliado
        /// </summary>
        public AbmAfiliadoCrear()
        {
            Inicializar();
            IDAfiliado = "0";
            estaModificando = false;
            Text = "Crear Afiliado";
            numeroHijo = 2;
            radioButtonFemenino.Checked = true;
        }

        #region trash2
        /// <summary>
        /// para cuando le quiero agregar un familiar a un afi
        /// </summary>
        /// <param name="esPariente"></param>
        /// <param name="planMedico"></param>
        /// <param name="IDfamiliarr"></param>
        //public AbmAfiliadoCrear(bool esPariente, object planMedico, string IDfamiliarr,string hijoConcubino)
        //{
        //    estaModificando = false;
        //    if (esPariente)
        //    {
        //        HijoConcubino = hijoConcubino;
        //        estoyAgregandoUnFamiliar = true;
        //        IDfamiliar = IDfamiliarr;
        //        Text = "Modificar Afiliado";
        //        comboBoxPlanMedico.SelectedValue = planMedico;
        //        comboBoxPlanMedico.Enabled = false;
        //        groupBoxCrear.Text = "Agregar pariente";
        //        buttonCrearAfiliado.Hide();
        //        buttonCrearFamiliar.Show();
        //    }
        //}
        #endregion


        /// <summary>
        /// Para modificar un afiliado
        /// </summary>
        /// <param name="dataGridViewRow"></param>
        public AbmAfiliadoCrear(DataGridViewRow dr)
        {
            Inicializar();
            buttonCrearAfiliado.Visible = false;
            buttonGuardarModificacion.Visible = true;
            UpDownCantidadHijos.Dispose(); //porque estoy modificando

            groupBoxCrear.Text = "modificar usuario";
            Text = "Modificar Afiliado";

            //ahora copio todo de la dataRow seleccionada
            var cells = dr.Cells;
            IDAfiliado = cells[0].Value.ToString();
            textBoxNombre.Text = cells[1].Value.ToString();
            textBoxApellido.Text = cells[2].Value.ToString();
            comboBoxTipoDni.SelectedValue = cells[3].Value.ToString();
            textBoxDNI.Text = cells[4].Value.ToString();
            textBoxDireccion.Text = cells[5].Value.ToString();
            textBoxTelefono.Text = cells[6].Value.ToString();
            textBoxMail.Text = cells[7].Value.ToString();
            dateTimePickerFechaNacimiento.Value = Convert.ToDateTime(cells[8].Value.ToString()) ;
            comboBoxPlanMedico.SelectedValue = cells[9].Value.ToString();
            string sexoDb = cells[10].Value.ToString();
            if (sexoDb == "Masculino")
                radioButtonMasculino.Checked = true;
            else radioButtonFemenino.Checked = true;
            comboBoxEstadoCivil.SelectedValue = cells[11].Value.ToString();
        }
#endregion
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;
            ExecSQL();
            MessageBox.Show("¡Se guardaron los datos correctamente!", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Hide();
            if (EstaCasadoOConcubino())
            {
                DialogResult dialogResult = MessageBox.Show("Afiliado creado, quiere agregar a su concibino/esposo?", "pariente", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    //tiene un concubino o lo q sea, entonces lo agrego:
                    CrearHijo c = new CrearHijo(1,this); //le mando 1 porque es el trailing number
                    Hide();
                }
                #region trash
                //else if (dialogResult == DialogResult.No)
                //{
                //    MessageBox.Show("Creacion de afiliado finalizada", "pariente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    this.Dispose();
                //}
                //DialogResult dialogResult2 = MessageBox.Show("Afiliado creado, quiere agregar hijos o personas a cargo?", "pariente", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //if (dialogResult == DialogResult.Yes)
                //{
                //    new AbmAfiliadoCrear(true, comboBoxPlanMedico.SelectedValue, IDAfiliado, "03");
                //}
                #endregion
            }
            else
            consultarPorMasHijos();
        }
        public void consultarPorMasHijos()
        {
            int cantidadHijos = Convert.ToInt32(UpDownCantidadHijos.Value);
            int cantFaltante = cantidadHijos + 2 - numeroHijo; //la cantidad de forms que le falta completar
            
            if (cantidadHijos + 2 > numeroHijo)
            {
                DialogResult dialogResult = MessageBox.Show("¡Te quedan " + cantFaltante + " personas a cargo por crear!", "...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CrearHijo c = new CrearHijo(numeroHijo,this);
                numeroHijo++;
            }
            else
            {
                MessageBox.Show("Proceso finalizado", "...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
        }
        public int numeroHijo;//representa el tailNumber del proximoHijo
        #region funciones Auxiliares
        private bool EstaCasadoOConcubino()
        {
            if (comboBoxEstadoCivil.SelectedValue.Equals("Casado") || comboBoxEstadoCivil.SelectedValue.Equals("")) //concubino?
                return true;
            else return false;
        }
        private void Inicializar()
        {
            InitializeComponent();
            ComboBoxManager cb = new ComboBoxManager();
            comboBoxEstadoCivil = cb.CrearEstadoCivil(comboBoxEstadoCivil);
            comboBoxPlanMedico = cb.CrearPlanesMedicos(comboBoxPlanMedico);
            comboBoxTipoDni = cb.CrearTiposDni(comboBoxTipoDni);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Especialidades = new List<int>();
            EspecialidadesHandler espHandler = new EspecialidadesHandler(Especialidades);
        }
        #endregion

        private void ExecSQL()
        {
            Conexion con = new Conexion();
            SqlCommand cmd;
            cmd = con.CrearComandoStoreProcedure("sp_crearAfiliado");

            //sexo
            if (radioButtonMasculino.Checked)
                cmd.Parameters.Add("@paci_sexo", SqlDbType.VarChar).Value = "Masculino";
            else
                cmd.Parameters.Add("@paci_sexo", SqlDbType.VarChar).Value = "Femenino";
            // fin sexo, sigo con el resto
            string a = comboBoxTipoDni.SelectedText.ToString();
            cmd.Parameters.Add("@paci_nom", SqlDbType.VarChar).Value = textBoxNombre.Text;
            cmd.Parameters.Add("@paci_apell", SqlDbType.VarChar).Value = textBoxApellido.Text;
            cmd.Parameters.Add("@paci_direccion", SqlDbType.VarChar).Value = textBoxDireccion.Text;
            cmd.Parameters.Add("@paci_tipodni", SqlDbType.VarChar).Value = a;
            cmd.Parameters.Add("@paci_dni", SqlDbType.VarChar).Value = textBoxDNI.Text;
            cmd.Parameters.Add("@paci_tel", SqlDbType.VarChar).Value = textBoxTelefono.Text;
            cmd.Parameters.Add("@paci_mail", SqlDbType.VarChar).Value = textBoxMail.Text;
            cmd.Parameters.Add("@paci_estado_civil", SqlDbType.VarChar).Value = comboBoxEstadoCivil.SelectedValue;
            cmd.Parameters.Add("@paci_plan_medi", SqlDbType.VarChar).Value = comboBoxPlanMedico.SelectedValue;
            cmd.Parameters.Add("@paci_fecha_nac", SqlDbType.DateTime).Value = dateTimePickerFechaNacimiento.Value;
            cmd.Parameters.Add("@paci_cant_fam", SqlDbType.NVarChar).Value = 0; //al pedo
            cmd.Parameters.Add("@paci_tipoFamiliar", SqlDbType.VarChar).Value = HijoConcubino;
            cmd.Parameters.Add("@idFamiliar", SqlDbType.VarChar).Value = IDfamiliar;
            con.ExecConsulta(cmd);
        }

        private bool Validar()
        {
            CheckearTextBoxesNoVacios();

            if (!ValidateChildren())
            {
                MessageBox.Show("¡error!", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (comboBoxEstadoCivil.SelectedValue.Equals(5))
            {
                MessageBox.Show("¡error, elija estado civil!", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (comboBoxPlanMedico.SelectedValue.Equals(-1))
            {
                MessageBox.Show("¡error, elija plan medico!", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            //if (StaticUtils.EsSoloNumerico(textBoxDNI.Text))
            //{
            //    MessageBox.Show("¡DNI debe ser numerico!", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            return true;

        }

        private void buttonCrearFamiliar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ERROR RE LOCO ?", "pariente", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //if (!Validar()) return;
            //ExecSQL();
            //comboBoxPlanMedico.Enabled = false;
            //if (!estoyAgregandoUnFamiliar)
            //{
            //    DialogResult dialogResult = MessageBox.Show("Pariente creado, quiere agregar otro mas?", "pariente", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        //new AbmAfiliadoCrear(true, comboBoxPlanMedico.SelectedValue, IDAfiliado);
            //        this.Dispose();
            //    }

            //    else if (dialogResult == DialogResult.No)
            //    {
            //        this.Dispose();
            //    }
            //}
            //this.Dispose();
        }
        #region cosasRaras
        /// <summary>
        /// devuelve false si encuentra un textbox vacio
        /// </summary>
        /// <returns></returns>
        private bool CheckearTextBoxesNoVacios()
        {
            bool a = true;
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    if (((TextBox)x).Text == String.Empty)
                    {
                        a = false;
                        MessageBox.Show("¡Ningun campo puede estar vacio!", "Operación fallida"
                            , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return a;
                    }
                }
            }
            return a;
        }

        private void comboBoxSexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxPlanMedico_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        

        private void buttonGuardarModificacion_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

        }

        private void comboBoxTipoDni_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxDNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void UpDownCantidadHijos_ValueChanged(object sender, EventArgs e)
        {

        }
    }
    #endregion
}
