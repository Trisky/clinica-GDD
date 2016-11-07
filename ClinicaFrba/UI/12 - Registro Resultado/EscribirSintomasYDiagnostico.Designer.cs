namespace ClinicaFrba.Registro_Resultado
{
    partial class EscribirSintomasYDiagnostico
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
            this.radioButtonAtendidoNo = new System.Windows.Forms.RadioButton();
            this.radioButtonAtendidoSi = new System.Windows.Forms.RadioButton();
            this.textBoxSintomas = new System.Windows.Forms.TextBox();
            this.textBoxDiagnostico = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCerrarConsulta = new System.Windows.Forms.Button();
            this.groupBoxPasoDos = new System.Windows.Forms.GroupBox();
            this.groupBoxPasoDos.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonAtendidoNo
            // 
            this.radioButtonAtendidoNo.AutoSize = true;
            this.radioButtonAtendidoNo.Location = new System.Drawing.Point(34, 99);
            this.radioButtonAtendidoNo.Name = "radioButtonAtendidoNo";
            this.radioButtonAtendidoNo.Size = new System.Drawing.Size(228, 29);
            this.radioButtonAtendidoNo.TabIndex = 1;
            this.radioButtonAtendidoNo.TabStop = true;
            this.radioButtonAtendidoNo.Text = "Paciente NO atendido";
            this.radioButtonAtendidoNo.UseVisualStyleBackColor = true;
            // 
            // radioButtonAtendidoSi
            // 
            this.radioButtonAtendidoSi.AutoSize = true;
            this.radioButtonAtendidoSi.Location = new System.Drawing.Point(34, 53);
            this.radioButtonAtendidoSi.Name = "radioButtonAtendidoSi";
            this.radioButtonAtendidoSi.Size = new System.Drawing.Size(193, 29);
            this.radioButtonAtendidoSi.TabIndex = 2;
            this.radioButtonAtendidoSi.TabStop = true;
            this.radioButtonAtendidoSi.Text = "Paciente atendido";
            this.radioButtonAtendidoSi.UseVisualStyleBackColor = true;
            this.radioButtonAtendidoSi.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // textBoxSintomas
            // 
            this.textBoxSintomas.Location = new System.Drawing.Point(34, 191);
            this.textBoxSintomas.Multiline = true;
            this.textBoxSintomas.Name = "textBoxSintomas";
            this.textBoxSintomas.Size = new System.Drawing.Size(871, 132);
            this.textBoxSintomas.TabIndex = 3;
            // 
            // textBoxDiagnostico
            // 
            this.textBoxDiagnostico.Location = new System.Drawing.Point(34, 405);
            this.textBoxDiagnostico.Multiline = true;
            this.textBoxDiagnostico.Name = "textBoxDiagnostico";
            this.textBoxDiagnostico.Size = new System.Drawing.Size(871, 132);
            this.textBoxDiagnostico.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sintomas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Diagnostico";
            // 
            // buttonCerrarConsulta
            // 
            this.buttonCerrarConsulta.ForeColor = System.Drawing.Color.Red;
            this.buttonCerrarConsulta.Location = new System.Drawing.Point(946, 471);
            this.buttonCerrarConsulta.Name = "buttonCerrarConsulta";
            this.buttonCerrarConsulta.Size = new System.Drawing.Size(236, 66);
            this.buttonCerrarConsulta.TabIndex = 7;
            this.buttonCerrarConsulta.Text = "Cerra consulta";
            this.buttonCerrarConsulta.UseVisualStyleBackColor = true;
            this.buttonCerrarConsulta.Click += new System.EventHandler(this.buttonCerrarConsulta_Click);
            // 
            // groupBoxPasoDos
            // 
            this.groupBoxPasoDos.Controls.Add(this.textBoxSintomas);
            this.groupBoxPasoDos.Controls.Add(this.buttonCerrarConsulta);
            this.groupBoxPasoDos.Controls.Add(this.radioButtonAtendidoSi);
            this.groupBoxPasoDos.Controls.Add(this.textBoxDiagnostico);
            this.groupBoxPasoDos.Controls.Add(this.label2);
            this.groupBoxPasoDos.Controls.Add(this.radioButtonAtendidoNo);
            this.groupBoxPasoDos.Controls.Add(this.label1);
            this.groupBoxPasoDos.Enabled = false;
            this.groupBoxPasoDos.Location = new System.Drawing.Point(12, 12);
            this.groupBoxPasoDos.Name = "groupBoxPasoDos";
            this.groupBoxPasoDos.Size = new System.Drawing.Size(1188, 554);
            this.groupBoxPasoDos.TabIndex = 8;
            this.groupBoxPasoDos.TabStop = false;
            this.groupBoxPasoDos.Text = "Paso Dos";
            // 
            // RegistroResultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 575);
            this.Controls.Add(this.groupBoxPasoDos);
            this.Name = "RegistroResultado";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxPasoDos.ResumeLayout(false);
            this.groupBoxPasoDos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton radioButtonAtendidoNo;
        private System.Windows.Forms.RadioButton radioButtonAtendidoSi;
        private System.Windows.Forms.TextBox textBoxSintomas;
        private System.Windows.Forms.TextBox textBoxDiagnostico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCerrarConsulta;
        private System.Windows.Forms.GroupBox groupBoxPasoDos;
    }
}