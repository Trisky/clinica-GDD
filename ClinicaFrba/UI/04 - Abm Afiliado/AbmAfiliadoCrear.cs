using ClinicaFrba.FormulariosBase;
using ClinicaFrba.Helpers;
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
        public int IDAfiliado { get; set; }
        public AbmAfiliadoCrear()

        {
            Inicializar();
            IDAfiliado = 0;
            estaModificando = false;
            
        }

        public AbmAfiliadoCrear(bool esPariente, object planMedico)
        {
            estaModificando = false;
            if (esPariente)
            {
                comboBoxPlanMedico.SelectedValue = planMedico;
                comboBoxPlanMedico.Enabled = false;
                groupBoxCrear.Text = "Agregar pariente";
                buttonCrearAfiliado.Hide();
                buttonCrearFamiliar.Show();
            }
        }


        /// <summary>
        /// Para modificar un afiliado
        /// </summary>
        /// <param name="dt"></param>
        public AbmAfiliadoCrear(DataGridViewRow dr)
        {
            Inicializar();
            estaModificando = true;
            groupBoxCrear.Text = "modificar usuario";

            var cells = dr.Cells;
            IDAfiliado = Convert.ToInt32(cells[0].Value.ToString());
            textBoxNombre.Text = cells[1].Value.ToString();
            textBoxApellido.Text = cells[2].Value.ToString();
            comboBoxTipoDni.SelectedValue = cells[3].Value.ToString();
            textBoxDNI.Text = cells[4].Value.ToString();
            textBoxDireccion.Text = cells[5].Value.ToString();
            textBoxTelefono.Text = cells[6].Value.ToString();
            textBoxMail.Text = cells[7].Value.ToString();
            dateTimePickerFechaNacimiento.Value = Convert.ToDateTime(cells[8].Value.ToString()) ;
            comboBoxPlanMedico.SelectedValue = cells[9].Value.ToString();
            //comboBoxEstadoCivil.SelectedValue = cells[] TODO
            
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;
            ExecSQL();
            MessageBox.Show("¡Se guardaron los datos correctamente!", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (EstaCasadoOConcubino())
            {
                DialogResult dialogResult = MessageBox.Show("Afiliado creado, quiere agregar un pariente?", "pariente", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    new AbmAfiliadoCrear(true,comboBoxPlanMedico.SelectedValue);
                    this.Dispose();
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Creacion de afiliado finalizada", "pariente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }

            }
            Dispose();
        }

        private bool EstaCasadoOConcubino()
        {
            if (comboBoxEstadoCivil.SelectedValue.Equals(1) || comboBoxEstadoCivil.SelectedValue.Equals(4))
                return true;
            else return false;
        }

        private void ExecSQL()
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_crearAfiliado");

            //sexo
            if (radioButtonMasculino.Checked)
                cmd.Parameters.Add("@paci_sexo", SqlDbType.NVarChar).Value = 1;
            else
                cmd.Parameters.Add("@paci_sexo", SqlDbType.NVarChar).Value = 0;
            // fin sexo
            cmd.Parameters.Add("@paci_matricula", SqlDbType.NVarChar).Value = IDAfiliado;
            cmd.Parameters.Add("@paci_nom", SqlDbType.VarChar).Value = textBoxNombre.Text;
            cmd.Parameters.Add("@paci_apell", SqlDbType.VarChar).Value = textBoxApellido.Text;
            cmd.Parameters.Add("@paci_direccion", SqlDbType.VarChar).Value = textBoxDireccion.Text;
            cmd.Parameters.Add("@paci_tipodni", SqlDbType.NVarChar).Value = comboBoxTipoDni.SelectedValue;
            cmd.Parameters.Add("@paci_dni", SqlDbType.NVarChar).Value = textBoxDNI.Text;
            cmd.Parameters.Add("@paci_tel", SqlDbType.NVarChar).Value = textBoxTelefono.Text;
            cmd.Parameters.Add("@paci_mail", SqlDbType.VarChar).Value = textBoxMail.Text;
            cmd.Parameters.Add("@paci_estado_civil", SqlDbType.NVarChar).Value = comboBoxEstadoCivil.SelectedValue;
            cmd.Parameters.Add("@paci_plan_medi", SqlDbType.NVarChar).Value = comboBoxPlanMedico.SelectedValue;
            cmd.Parameters.Add("@paci_fecha_nac", SqlDbType.DateTime).Value = dateTimePickerFechaNacimiento.Value;
            
            cmd.Parameters.Add("@paci_cant_fam", SqlDbType.NVarChar).Value = 0;
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
            if (StaticUtils.EsSoloNumerico(textBoxDNI.Text.ToString()))
            {
                MessageBox.Show("¡DNI debe ser numerico!", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return false;
            }
            return true;

        }

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

        private void buttonCrearFamiliar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;
            ExecSQL();
            comboBoxPlanMedico.Enabled = false;

            DialogResult dialogResult = MessageBox.Show("Pariente creado, quiere agregar otro mas?", "pariente", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)
            {
                new AbmAfiliadoCrear(true,comboBoxPlanMedico.SelectedValue);
                this.Dispose();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

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
    }
}
