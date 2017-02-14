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
            MotivotextBox1.Visible = false;
            Motivolabel13.Visible = false;
            
            Text = "Crear Afiliado";
            numeroHijo = 3; //es el tail number en el ID
            radioButtonFemenino.Checked = true;
            HijoConcubino = "01";
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
            estaModificando = true;
            buttonCrearAfiliado.Visible = false;
            buttonGuardarModificacion.Visible = true;
            label12.Visible = false;
            textBoxNombre.Enabled = false;
            textBoxApellido.Enabled = false;
            textBoxDNI.Enabled = false;
            dateTimePickerFechaNacimiento.Enabled = false;



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
            dateTimePickerFechaNacimiento.Value = Convert.ToDateTime(cells[9].Value.ToString()) ;
            comboBoxPlanMedico.SelectedValue = cells[10].Value.ToString();
            string sexoDb = cells[11].Value.ToString();
            if (sexoDb == "Masculino")
                radioButtonMasculino.Checked = true;
            else radioButtonFemenino.Checked = true;
            comboBoxEstadoCivil.SelectedValue = cells[12].Value.ToString();
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
                    CrearHijo c = new CrearHijo(2,numeroDePlanMedico,this,textBoxDNI.Text); //le mando 1 porque es el trailing number del esposo
                    Hide();
                }
            }
            else
            consultarPorMasHijos();
        }



        public void consultarPorMasHijos()
        {
            int cantidadHijos = Convert.ToInt32(UpDownCantidadHijos.Value);
            int cantFaltante = cantidadHijos + 3 - numeroHijo; //la cantidad de forms que le falta completar
            
            if (cantidadHijos + 3 > numeroHijo)
            {
                DialogResult dialogResult = MessageBox.Show("¡Te quedan " + cantFaltante + " personas a cargo por crear!", "...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CrearHijo c = new CrearHijo(numeroHijo,numeroDePlanMedico, this,textBoxDNI.Text);
                numeroHijo++;
            }
            else
            {
                MessageBox.Show("Proceso finalizado", "...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
        }
        public int numeroHijo;//representa el tailNumber del proximoHijo
        private string numeroDePlanMedico;
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
                cmd.Parameters.Add("@paci_sexo", SqlDbType.VarChar).Value = "Masculino";//9
            else
                cmd.Parameters.Add("@paci_sexo", SqlDbType.VarChar).Value = "Femenino";//9
            // fin sexo, sigo con el resto
            string a = comboBoxTipoDni.SelectedValue.ToString();
            cmd.Parameters.Add("@paci_nom", SqlDbType.VarChar).Value = textBoxNombre.Text;//1
            cmd.Parameters.Add("@paci_apell", SqlDbType.VarChar).Value = textBoxApellido.Text;//2
            cmd.Parameters.Add("@paci_tipodni", SqlDbType.VarChar).Value =  a;//3
            cmd.Parameters.Add("@paci_dni", SqlDbType.VarChar).Value = textBoxDNI.Text;//4
            cmd.Parameters.Add("@paci_direccion", SqlDbType.VarChar).Value =  textBoxDireccion.Text;//5

            if (textBoxTelefono.Text.Equals("")){textBoxTelefono.Text = "0";}
            cmd.Parameters.Add("@paci_tel", SqlDbType.VarChar).Value = textBoxTelefono.Text; // Convert.ToInt32(textBoxTelefono.Text);//6
            cmd.Parameters.Add("@paci_mail", SqlDbType.VarChar).Value =  textBoxMail.Text;//7
            cmd.Parameters.Add("@paci_fecha_nac", SqlDbType.VarChar).Value =  dateTimePickerFechaNacimiento.Value;//8
            cmd.Parameters.Add("@paci_estado_civil", SqlDbType.VarChar).Value = comboBoxEstadoCivil.SelectedValue;//10
            cmd.Parameters.Add("@paci_plan_medi", SqlDbType.VarChar).Value =  comboBoxPlanMedico.SelectedValue;//11 numeric?
            numeroDePlanMedico = comboBoxPlanMedico.SelectedValue.ToString() ; //para usar en el hijo
            cmd.Parameters.Add("@fechaHoy", SqlDbType.VarChar).Value = StaticUtils.getDate();
            //cmd.Parameters.Add("@paci_cant_fam", SqlDbType.NVarChar).Value = 0; // 12 pedo
            cmd.Parameters.Add("@paci_tipoFamiliar", SqlDbType.VarChar).Value = HijoConcubino;//13
            //cmd.Parameters.Add("@idFamiliar", SqlDbType.VarChar).Value = IDfamiliar; //13 FALTA??
            con.ExecConsulta(cmd);

            //@paci_nom VARCHAR(250),
            //@paci_apell VARCHAR(250),
            //@paci_tipodni VARCHAR(255),
            //@paci_dni NUMERIC(18, 0),
            //@paci_direccion VARCHAR(250),
            //@paci_tel NUMERIC(18, 0),
            //@paci_mail VARCHAR(250),
            //@paci_fecha_nac DATE,
            //@paci_sexo VARCHAR(250),
            //@paci_estado_civil VARCHAR(250),
            //@paci_plan_medi NUMERIC(18, 0),
            //@fechaHoy DATETIME,
            //@paci_tipoFamiliar VARCHAR(250)
        }

        private bool Validar()
        {
            if (comboBoxPlanMedico.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("¡Debe seleccionar un plan medico", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (!StaticUtils.esNumerico(textBoxDNI.Text) ||
                !StaticUtils.esNumerico(textBoxTelefono.Text))
            {
                MessageBox.Show("¡Telefono y dni deben ser numericos", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            CheckearTextBoxesNoVacios();
            if (
                !StaticUtils.CheckSelectedValueCB(comboBoxEstadoCivil) ||
                !StaticUtils.CheckSelectedValueCB(comboBoxPlanMedico) ||
                !StaticUtils.CheckSelectedValueCB(comboBoxTipoDni) ||
                !StaticUtils.checkControls(groupBoxCrear.Controls)
              )
            {
                MessageBox.Show("¡Debe seleccionar todas las opciones y completar todos los campos", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (!estaModificando) //para que no aparezca en la pantalla de modificacion
            {
                if (!DniEsUnico()) return false;
            }
            
            return true;

        }

        /// <summary>
        /// chequea si el dni esta repetido en la DB
        /// 
        /// </summary>
        /// <returns></returns>
        private bool DniEsUnico()
        {
            DataTable dt;
            Conexion con1 = new Conexion();
            string q = @" select 1 FROM [GD2C2016].[GRUPOSA].[Paciente] where
                             @dni_user= [Paci_Dni] and [Paci_estado] <> 1 and @tipo_dni = [Paci_TipoDocumento] ";
            SqlCommand cmd1 = con1.CrearComandoQuery(q);
            cmd1.Parameters.Add(new SqlParameter("@dni_user", textBoxDNI.Text));
            cmd1.Parameters.Add(new SqlParameter("@tipo_dni", comboBoxTipoDni.Text));
            dt = con1.ExecConsulta(cmd1);

            if (dt.Rows.Count >= 1)
            {
                MessageBox.Show("¡El DNI no puede repetirse!", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
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


            Conexion con = new Conexion();
            SqlCommand cmd;
            cmd = con.CrearComandoStoreProcedure("sp_modificarAfiliado");
            string a = comboBoxTipoDni.SelectedValue.ToString();

            cmd.Parameters.Add("@motivo", SqlDbType.VarChar).Value = MotivotextBox1.Text;
            cmd.Parameters.Add("@afiliadoId", SqlDbType.VarChar).Value = IDAfiliado;//5
            cmd.Parameters.Add("@paci_tipodni", SqlDbType.VarChar).Value = a;//3
            cmd.Parameters.Add("@paci_direccion", SqlDbType.VarChar).Value = textBoxDireccion.Text;//5
            if (textBoxTelefono.Text.Equals("")) { textBoxTelefono.Text = "0"; };
            cmd.Parameters.Add("@paci_tel", SqlDbType.VarChar).Value = textBoxTelefono.Text; // Convert.ToInt32(textBoxTelefono.Text);//6
            cmd.Parameters.Add("@paci_mail", SqlDbType.VarChar).Value = textBoxMail.Text;//7
            cmd.Parameters.Add("@fechaHoy", SqlDbType.VarChar).Value = StaticUtils.getDate();
            //sexo
            if (radioButtonMasculino.Checked)
                cmd.Parameters.Add("@paci_sexo", SqlDbType.VarChar).Value = "Masculino";//9
            else
                cmd.Parameters.Add("@paci_sexo", SqlDbType.VarChar).Value = "Femenino";//9
            // fin sexo, sigo con el resto
           cmd.Parameters.Add("@paci_estado_civil", SqlDbType.VarChar).Value = comboBoxEstadoCivil.SelectedValue;//10
           cmd.Parameters.Add("@paci_plan_medi", SqlDbType.VarChar).Value = comboBoxPlanMedico.SelectedValue;//11 numeric?

            con.ExecConsulta(cmd);
            MessageBox.Show("Se modifico correctamente", "Operacion correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);


            Close();
            AbmAfiliadoListar abmAfil = new AbmAfiliadoListar();
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

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    #endregion
}
