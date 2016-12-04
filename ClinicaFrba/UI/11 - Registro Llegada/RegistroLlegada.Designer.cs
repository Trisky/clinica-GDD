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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pacienteNombreLabel = new System.Windows.Forms.Label();
            this.pacienteApellidoLabel = new System.Windows.Forms.Label();
            this.groupBoxPacienteSeleccionado = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idPacienteLabel = new System.Windows.Forms.Label();
            this.gbFiltros.SuspendLayout();
            this.groupBoxPacienteSeleccionado.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Controls.Add(this.button1);
            this.gbFiltros.Controls.Add(this.groupBoxPacienteSeleccionado);
            this.gbFiltros.Location = new System.Drawing.Point(12, 9);
            this.gbFiltros.Controls.SetChildIndex(this.groupBoxPacienteSeleccionado, 0);
            this.gbFiltros.Controls.SetChildIndex(this.button1, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label1, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnBuscar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Text = "Cancelar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Text = "Confirmar";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button1.Location = new System.Drawing.Point(160, 48);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 60);
            this.button1.TabIndex = 0;
            this.button1.Text = "Buscar paciente";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(466, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Primero busque el paciente y luego seleccione el turno para confirmar";
            // 
            // pacienteNombreLabel
            // 
            this.pacienteNombreLabel.AutoSize = true;
            this.pacienteNombreLabel.Location = new System.Drawing.Point(8, 25);
            this.pacienteNombreLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.pacienteNombreLabel.Name = "pacienteNombreLabel";
            this.pacienteNombreLabel.Size = new System.Drawing.Size(61, 13);
            this.pacienteNombreLabel.TabIndex = 3;
            this.pacienteNombreLabel.Text = "Pa_nombre";
            // 
            // pacienteApellidoLabel
            // 
            this.pacienteApellidoLabel.AutoSize = true;
            this.pacienteApellidoLabel.Location = new System.Drawing.Point(7, 47);
            this.pacienteApellidoLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.pacienteApellidoLabel.Name = "pacienteApellidoLabel";
            this.pacienteApellidoLabel.Size = new System.Drawing.Size(62, 13);
            this.pacienteApellidoLabel.TabIndex = 4;
            this.pacienteApellidoLabel.Text = "Pa_apellido";
            // 
            // groupBoxPacienteSeleccionado
            // 
            this.groupBoxPacienteSeleccionado.Controls.Add(this.label2);
            this.groupBoxPacienteSeleccionado.Controls.Add(this.idPacienteLabel);
            this.groupBoxPacienteSeleccionado.Controls.Add(this.pacienteNombreLabel);
            this.groupBoxPacienteSeleccionado.Controls.Add(this.pacienteApellidoLabel);
            this.groupBoxPacienteSeleccionado.Location = new System.Drawing.Point(481, 17);
            this.groupBoxPacienteSeleccionado.Margin = new System.Windows.Forms.Padding(1);
            this.groupBoxPacienteSeleccionado.Name = "groupBoxPacienteSeleccionado";
            this.groupBoxPacienteSeleccionado.Padding = new System.Windows.Forms.Padding(1);
            this.groupBoxPacienteSeleccionado.Size = new System.Drawing.Size(239, 70);
            this.groupBoxPacienteSeleccionado.TabIndex = 5;
            this.groupBoxPacienteSeleccionado.TabStop = false;
            this.groupBoxPacienteSeleccionado.Text = "Paciente seleccionado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "#ID=";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // idPacienteLabel
            // 
            this.idPacienteLabel.AutoSize = true;
            this.idPacienteLabel.Location = new System.Drawing.Point(188, 25);
            this.idPacienteLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.idPacienteLabel.Name = "idPacienteLabel";
            this.idPacienteLabel.Size = new System.Drawing.Size(41, 13);
            this.idPacienteLabel.TabIndex = 5;
            this.idPacienteLabel.Text = "idLabel";
            // 
            // RegistroLlegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 473);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "RegistroLlegada";
            this.Text = "RegistroLlegada";
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.groupBoxPacienteSeleccionado.ResumeLayout(false);
            this.groupBoxPacienteSeleccionado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pacienteNombreLabel;
        private System.Windows.Forms.Label pacienteApellidoLabel;
        private System.Windows.Forms.GroupBox groupBoxPacienteSeleccionado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label idPacienteLabel;
    }
}