﻿using ClinicaFrba.Helpers;
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
using ClinicaFrba.UI._05___Abm_Profesional;

namespace ClinicaFrba.UI._04___Abm_Afiliado
{
    public partial class CrearHijo : Form
    {
        private AbmAfiliadoCrear abmAfiliadoCrear;
        private string numeroDePlanMedico;

        private CrearHijo(int tailNumber)
        {
            
        }
        /// <summary>
        /// recibe el tail number de la matricula que corresponde y el abmafiliado para q gestion la creacion de mas hijos
        /// </summary>
        /// <param name="hijosCount"></param>
        public CrearHijo(int tailNumber,string planMedico, AbmAfiliadoCrear abmAfiliadoCrear) : this(tailNumber)
        {
            numeroDePlanMedico = planMedico;

            this.abmAfiliadoCrear = abmAfiliadoCrear;
            TailNumber = "0" + tailNumber.ToString();
            InitializeComponent();

            ComboBoxManager cb = new ComboBoxManager();
            comboBoxEstadoCivil = cb.CrearEstadoCivil(comboBoxEstadoCivil);
            comboBoxTipoDni = cb.CrearTiposDni(comboBoxTipoDni);
            Show();
            if (tailNumber == 1)
            {
                groupBoxCrear.Text = buttonCrearHijo.Text = "crear concubino";
            }

        }

        public string Matricula { get; private set; }
        public string TailNumber { get;  set; }


        private bool Validar()
        {
            if (!StaticUtils.esNumerico(textBoxDNI.Text) ||
                !StaticUtils.esNumerico(textBoxTelefono.Text))
            {
                MessageBox.Show("¡Telefono y dni deben ser numericos", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (
                !StaticUtils.CheckSelectedValueCB(comboBoxEstadoCivil) ||
                !StaticUtils.CheckSelectedValueCB(comboBoxTipoDni) ||
                !StaticUtils.checkControls(groupBoxCrear.Controls) ||
                !CheckearTextBoxesNoVacios()
              )
            {
                MessageBox.Show("¡Debe seleccionar todas las opciones y completar todos los campos", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
                return true;
        }

        private void buttonCrearHijo_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            //primero obtengo el numero de matricula
            string getMat = @"select substring(max(Paci_Matricula),1,6) from gruposa.Paciente";
            Conexion con = new Conexion();
            DataTable dt = con.SimpleQuery(getMat);
            Matricula =StaticUtils.getUniqueValueFrom(dt);

            //ahora mando el hijo a la base
            ExecSQL();
            abmAfiliadoCrear.consultarPorMasHijos();
            Dispose();

        }


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
            // fin sexo
            string a = comboBoxTipoDni.SelectedValue.ToString();
            cmd.Parameters.Add("@paci_nom", SqlDbType.VarChar).Value = textBoxNombre.Text;
            cmd.Parameters.Add("@paci_apell", SqlDbType.VarChar).Value = textBoxApellido.Text;
            cmd.Parameters.Add("@paci_direccion", SqlDbType.VarChar).Value = textBoxDireccion.Text;
            cmd.Parameters.Add("@paci_tipodni", SqlDbType.VarChar).Value = a;
            cmd.Parameters.Add("@paci_dni", SqlDbType.VarChar).Value = textBoxDNI.Text;
            cmd.Parameters.Add("@paci_tel", SqlDbType.VarChar).Value = textBoxTelefono.Text;
            cmd.Parameters.Add("@paci_mail", SqlDbType.VarChar).Value = textBoxMail.Text;
            cmd.Parameters.Add("@paci_estado_civil", SqlDbType.VarChar).Value = comboBoxEstadoCivil.SelectedValue;
            cmd.Parameters.Add("@paci_plan_medi", SqlDbType.VarChar).Value = numeroDePlanMedico;
            cmd.Parameters.Add("@paci_fecha_nac", SqlDbType.VarChar).Value = dateTimePickerFechaNacimiento.Value;
            cmd.Parameters.Add("@paci_tipoFamiliar", SqlDbType.VarChar).Value = TailNumber; //le mando la matricula que va a tener + el trailing number
            cmd.Parameters.Add("@fechaHoy", SqlDbType.VarChar).Value = StaticUtils.getDate();
            con.ExecConsulta(cmd);
        }

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
    }
}
