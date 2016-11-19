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
            this.btnMedicoHora = new System.Windows.Forms.Button();
            this.pacienteNombreLabel = new System.Windows.Forms.Label();
            this.pacienteApellidoLabel = new System.Windows.Forms.Label();
            this.groupBoxPacienteSeleccionado = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idPacienteLabel = new System.Windows.Forms.Label();
            this.groupBoxPacienteSeleccionado.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 40);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 93);
            this.button1.TabIndex = 0;
            this.button1.Text = "Indicar paciente";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(440, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Entregando turno para el dia de la fecha";
            // 
            // btnMedicoHora
            // 
            this.btnMedicoHora.Enabled = false;
            this.btnMedicoHora.Location = new System.Drawing.Point(89, 249);
            this.btnMedicoHora.Margin = new System.Windows.Forms.Padding(2);
            this.btnMedicoHora.Name = "btnMedicoHora";
            this.btnMedicoHora.Size = new System.Drawing.Size(211, 78);
            this.btnMedicoHora.TabIndex = 2;
            this.btnMedicoHora.Text = "Indicar medico y hora para este paciente HOY";
            this.btnMedicoHora.UseVisualStyleBackColor = true;
            this.btnMedicoHora.Click += new System.EventHandler(this.btnMedicoHora_Click);
            // 
            // pacienteNombreLabel
            // 
            this.pacienteNombreLabel.AutoSize = true;
            this.pacienteNombreLabel.Location = new System.Drawing.Point(12, 38);
            this.pacienteNombreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pacienteNombreLabel.Name = "pacienteNombreLabel";
            this.pacienteNombreLabel.Size = new System.Drawing.Size(91, 20);
            this.pacienteNombreLabel.TabIndex = 3;
            this.pacienteNombreLabel.Text = "Pa_nombre";
            // 
            // pacienteApellidoLabel
            // 
            this.pacienteApellidoLabel.AutoSize = true;
            this.pacienteApellidoLabel.Location = new System.Drawing.Point(12, 69);
            this.pacienteApellidoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pacienteApellidoLabel.Name = "pacienteApellidoLabel";
            this.pacienteApellidoLabel.Size = new System.Drawing.Size(91, 20);
            this.pacienteApellidoLabel.TabIndex = 4;
            this.pacienteApellidoLabel.Text = "Pa_apellido";
            // 
            // groupBoxPacienteSeleccionado
            // 
            this.groupBoxPacienteSeleccionado.Controls.Add(this.label2);
            this.groupBoxPacienteSeleccionado.Controls.Add(this.idPacienteLabel);
            this.groupBoxPacienteSeleccionado.Controls.Add(this.pacienteNombreLabel);
            this.groupBoxPacienteSeleccionado.Controls.Add(this.pacienteApellidoLabel);
            this.groupBoxPacienteSeleccionado.Location = new System.Drawing.Point(11, 137);
            this.groupBoxPacienteSeleccionado.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxPacienteSeleccionado.Name = "groupBoxPacienteSeleccionado";
            this.groupBoxPacienteSeleccionado.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxPacienteSeleccionado.Size = new System.Drawing.Size(358, 108);
            this.groupBoxPacienteSeleccionado.TabIndex = 5;
            this.groupBoxPacienteSeleccionado.TabStop = false;
            this.groupBoxPacienteSeleccionado.Text = "Paciente seleccionado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "#ID=";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // idPacienteLabel
            // 
            this.idPacienteLabel.AutoSize = true;
            this.idPacienteLabel.Location = new System.Drawing.Point(282, 38);
            this.idPacienteLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.idPacienteLabel.Name = "idPacienteLabel";
            this.idPacienteLabel.Size = new System.Drawing.Size(60, 20);
            this.idPacienteLabel.TabIndex = 5;
            this.idPacienteLabel.Text = "idLabel";
            // 
            // RegistroLlegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 361);
            this.Controls.Add(this.groupBoxPacienteSeleccionado);
            this.Controls.Add(this.btnMedicoHora);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RegistroLlegada";
            this.Text = "RegistroLlegada";
            this.groupBoxPacienteSeleccionado.ResumeLayout(false);
            this.groupBoxPacienteSeleccionado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMedicoHora;
        private System.Windows.Forms.Label pacienteNombreLabel;
        private System.Windows.Forms.Label pacienteApellidoLabel;
        private System.Windows.Forms.GroupBox groupBoxPacienteSeleccionado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label idPacienteLabel;
    }
}