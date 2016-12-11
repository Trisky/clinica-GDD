namespace ClinicaFrba.UI._11___Registro_Llegada
{
    partial class RegistroLlegada
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pacienteNombreLabel = new System.Windows.Forms.Label();
            this.pacienteApellidoLabel = new System.Windows.Forms.Label();
            this.groupBoxPacienteSeleccionado = new System.Windows.Forms.GroupBox();
            this.idPacienteLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.gbFiltros.SuspendLayout();
            this.groupBoxPacienteSeleccionado.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.button2);
            this.gbFiltros.Controls.Add(this.groupBoxPacienteSeleccionado);
            this.gbFiltros.Location = new System.Drawing.Point(12, 9);
            this.gbFiltros.Size = new System.Drawing.Size(930, 108);
            this.gbFiltros.Text = "Seleccione medico y especialidad. Luego seleccione el turno a confirmar";
            this.gbFiltros.Controls.SetChildIndex(this.groupBoxPacienteSeleccionado, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnBuscar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.button2, 0);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(804, 12);
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(804, 48);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(948, 83);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(948, 12);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.IndianRed;
            this.btnModificar.Location = new System.Drawing.Point(948, 47);
            this.btnModificar.Text = "Cancelar Atencion";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSeleccionar.Enabled = false;
            this.btnSeleccionar.Location = new System.Drawing.Point(948, 83);
            this.btnSeleccionar.Text = "Confirmar";
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Visible = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click_1);
            // 
            // pacienteNombreLabel
            // 
            this.pacienteNombreLabel.AutoSize = true;
            this.pacienteNombreLabel.Location = new System.Drawing.Point(8, 17);
            this.pacienteNombreLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.pacienteNombreLabel.Name = "pacienteNombreLabel";
            this.pacienteNombreLabel.Size = new System.Drawing.Size(61, 13);
            this.pacienteNombreLabel.TabIndex = 3;
            this.pacienteNombreLabel.Text = "Pa_nombre";
            // 
            // pacienteApellidoLabel
            // 
            this.pacienteApellidoLabel.AutoSize = true;
            this.pacienteApellidoLabel.Location = new System.Drawing.Point(8, 36);
            this.pacienteApellidoLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.pacienteApellidoLabel.Name = "pacienteApellidoLabel";
            this.pacienteApellidoLabel.Size = new System.Drawing.Size(62, 13);
            this.pacienteApellidoLabel.TabIndex = 4;
            this.pacienteApellidoLabel.Text = "Pa_apellido";
            // 
            // groupBoxPacienteSeleccionado
            // 
            this.groupBoxPacienteSeleccionado.Controls.Add(this.idPacienteLabel);
            this.groupBoxPacienteSeleccionado.Controls.Add(this.pacienteNombreLabel);
            this.groupBoxPacienteSeleccionado.Controls.Add(this.pacienteApellidoLabel);
            this.groupBoxPacienteSeleccionado.Location = new System.Drawing.Point(370, 12);
            this.groupBoxPacienteSeleccionado.Margin = new System.Windows.Forms.Padding(1);
            this.groupBoxPacienteSeleccionado.Name = "groupBoxPacienteSeleccionado";
            this.groupBoxPacienteSeleccionado.Padding = new System.Windows.Forms.Padding(1);
            this.groupBoxPacienteSeleccionado.Size = new System.Drawing.Size(430, 92);
            this.groupBoxPacienteSeleccionado.TabIndex = 5;
            this.groupBoxPacienteSeleccionado.TabStop = false;
            this.groupBoxPacienteSeleccionado.Text = "Paciente seleccionado:";
            // 
            // idPacienteLabel
            // 
            this.idPacienteLabel.AutoSize = true;
            this.idPacienteLabel.Location = new System.Drawing.Point(8, 53);
            this.idPacienteLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.idPacienteLabel.Name = "idPacienteLabel";
            this.idPacienteLabel.Size = new System.Drawing.Size(41, 13);
            this.idPacienteLabel.TabIndex = 5;
            this.idPacienteLabel.Text = "idLabel";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(351, 30);
            this.button2.TabIndex = 7;
            this.button2.Text = "Buscar Medico Por Especialidad";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RegistroLlegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 422);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "RegistroLlegada";
            this.Text = "RegistroLlegada";
            this.gbFiltros.ResumeLayout(false);
            this.groupBoxPacienteSeleccionado.ResumeLayout(false);
            this.groupBoxPacienteSeleccionado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label pacienteNombreLabel;
        private System.Windows.Forms.Label pacienteApellidoLabel;
        private System.Windows.Forms.GroupBox groupBoxPacienteSeleccionado;
        private System.Windows.Forms.Label idPacienteLabel;
        private System.Windows.Forms.Button button2;
    }
}