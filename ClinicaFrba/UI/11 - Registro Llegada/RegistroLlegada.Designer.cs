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
            this.idPacienteLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxPacienteSeleccionado.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(198, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(258, 112);
            this.button1.TabIndex = 0;
            this.button1.Text = "Indicar paciente";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(494, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Entregando turno para el dia de la fecha";
            // 
            // btnMedicoHora
            // 
            this.btnMedicoHora.Location = new System.Drawing.Point(198, 407);
            this.btnMedicoHora.Name = "btnMedicoHora";
            this.btnMedicoHora.Size = new System.Drawing.Size(258, 94);
            this.btnMedicoHora.TabIndex = 2;
            this.btnMedicoHora.Text = "Indicar medico y hora";
            this.btnMedicoHora.UseVisualStyleBackColor = true;
            this.btnMedicoHora.Visible = false;
            this.btnMedicoHora.Click += new System.EventHandler(this.btnMedicoHora_Click);
            // 
            // pacienteNombreLabel
            // 
            this.pacienteNombreLabel.AutoSize = true;
            this.pacienteNombreLabel.Location = new System.Drawing.Point(15, 46);
            this.pacienteNombreLabel.Name = "pacienteNombreLabel";
            this.pacienteNombreLabel.Size = new System.Drawing.Size(113, 25);
            this.pacienteNombreLabel.TabIndex = 3;
            this.pacienteNombreLabel.Text = "Pa_nombre";
            // 
            // pacienteApellidoLabel
            // 
            this.pacienteApellidoLabel.AutoSize = true;
            this.pacienteApellidoLabel.Location = new System.Drawing.Point(15, 83);
            this.pacienteApellidoLabel.Name = "pacienteApellidoLabel";
            this.pacienteApellidoLabel.Size = new System.Drawing.Size(114, 25);
            this.pacienteApellidoLabel.TabIndex = 4;
            this.pacienteApellidoLabel.Text = "Pa_apellido";
            // 
            // groupBoxPacienteSeleccionado
            // 
            this.groupBoxPacienteSeleccionado.Controls.Add(this.label2);
            this.groupBoxPacienteSeleccionado.Controls.Add(this.idPacienteLabel);
            this.groupBoxPacienteSeleccionado.Controls.Add(this.pacienteNombreLabel);
            this.groupBoxPacienteSeleccionado.Controls.Add(this.pacienteApellidoLabel);
            this.groupBoxPacienteSeleccionado.Location = new System.Drawing.Point(91, 241);
            this.groupBoxPacienteSeleccionado.Name = "groupBoxPacienteSeleccionado";
            this.groupBoxPacienteSeleccionado.Size = new System.Drawing.Size(558, 130);
            this.groupBoxPacienteSeleccionado.TabIndex = 5;
            this.groupBoxPacienteSeleccionado.TabStop = false;
            this.groupBoxPacienteSeleccionado.Text = "Paciente seleccionado:";
            // 
            // idPacienteLabel
            // 
            this.idPacienteLabel.AutoSize = true;
            this.idPacienteLabel.Location = new System.Drawing.Point(382, 46);
            this.idPacienteLabel.Name = "idPacienteLabel";
            this.idPacienteLabel.Size = new System.Drawing.Size(75, 25);
            this.idPacienteLabel.TabIndex = 5;
            this.idPacienteLabel.Text = "idLabel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "#ID=";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // RegistroLlegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 729);
            this.Controls.Add(this.groupBoxPacienteSeleccionado);
            this.Controls.Add(this.btnMedicoHora);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
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