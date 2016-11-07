﻿using ClinicaFrba.FormulariosBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ClinicaFrba.Helpers;
using ClinicaFrba.Logica.Entidades;
//using ClinicaFrba.UI._08___Registrar_Agenta_Medico;
using ClinicaFrba.UI._11___Registro_Llegada;

namespace ClinicaFrba.Pedir_Turno
{

    public partial class PedirTurno : FormBase
    {
        private string userName;
        private string especialidadSeleccionada;
        private string idMedico;
        private DateTime diaSeleccionado;
        private string especialidad;
        private string rangoHorario;

        public PedirTurno(UsuarioLogeado user)
        {
            Init();
            UsuarioLogueado = user;
        }

        private void Init()
        {
            InitializeComponent();
            Show();
            ComboBoxManager listaEspecialidades = new ComboBoxManager();
            cmbBoxListadoEspecialidades = listaEspecialidades.CrearEspecialidades(cmbBoxListadoEspecialidades);
            calendarDoctors.MaxSelectionCount = 1;
        }

        /// <summary>
        /// Para cuando tengo que registrar una llegada en el hospital no dejo que el usuario pueda elegir el dia.
        /// </summary>
        /// <param name="regLlegada"></param>
        /// <param name="username"></param>
        public PedirTurno(RegistroLlegada regLlegada, string username, DateTime dia)
        {
            Init();
            userName = username;
            UsuarioLogueado = new UsuarioLogeado(); 
            //como esto no lo hace el propio usuario, 
            //asigno el usuario al que se le va a asignar el turno al usuariologeado (la villa)
            UsuarioLogueado.UserName = username;
            calendarDoctors.SelectionStart = dia;
            calendarDoctors.SelectionEnd = dia;
            calendarDoctors.Enabled = false;
            diaSeleccionado = dia;
        }

        private void cmbBoxListadoEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            especialidadSeleccionada = cmbBoxListadoEspecialidades.SelectedValue.ToString();
            ComboBoxManager comboMed = new ComboBoxManager();
            cmbMedicos = comboMed.ListarMedicos(especialidadSeleccionada, cmbMedicos);
        }

        private void btnPedirTurno(object sender, EventArgs e)
        {
            bool todoOk = true;
            if (calendarDoctors.Enabled) //si esto no esta activado significa que no puedo elegir el dia y que se va a asignar un turno para el dia de la fecha
            {
                if (diaSeleccionado < DateTime.Today || diaSeleccionado.ToString("dddd") == "domingo")
                {
                    MessageBox.Show("Fecha no valida");
                    todoOk = false;

                }

            }
            if (!todoOk) return; //

            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_turnosMedicosDisponibles");
            cmd.Parameters.Add("@especialidad", SqlDbType.NVarChar).Value = especialidadSeleccionada;
            cmd.Parameters.Add("@diaConsultado", SqlDbType.NVarChar).Value = diaSeleccionado.ToString();
            cmd.Parameters.Add("@id_medico", SqlDbType.NVarChar).Value = idMedico;
            DataTable dTurnos = con.ExecConsulta(cmd);
            dataGridView1.DataSource = dTurnos;


            //si no hay medicos, le aviso al usuario.
            if (dTurnos.Rows.Count == 0)
                MessageBox.Show("No existen medicos de la especialidad elegida que atiendan en ese horario"
                , "Sin medicos", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        private void PedirTurno_Load(object sender, EventArgs e)
        {

        }

        private void tbAfiliado_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

            calendarDoctors.RemoveAllBoldedDates();
            diaSeleccionado = e.Start;
            calendarDoctors.AddBoldedDate(diaSeleccionado);
            calendarDoctors.UpdateBoldedDates();
        }




        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void cmbMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            idMedico = cmbMedicos.SelectedValue.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rangoHorario = dataGridView1.SelectedCells[0].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //selecciona toda la fila al tocar cualquier col.
            if (e.RowIndex > -1)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = con.CrearComandoStoreProcedure("sp_confirmacionTurno");
            cmd.Parameters.Add("@especialidad", SqlDbType.VarChar).Value = especialidadSeleccionada;
            cmd.Parameters.Add("@fecha", SqlDbType.VarChar).Value = diaSeleccionado.ToString();
            cmd.Parameters.Add("@medico", SqlDbType.VarChar).Value = idMedico;
            cmd.Parameters.Add("@hora", SqlDbType.VarChar).Value = rangoHorario;
            cmd.Parameters.Add("@paciente", SqlDbType.VarChar).Value = UsuarioLogueado.UserName;
            con.ExecConsulta(cmd);
        }

    }

}


