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
            this.textBoxSintomas = new System.Windows.Forms.TextBox();
            this.textBoxDiagnostico = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCerrarConsulta = new System.Windows.Forms.Button();
            this.groupBoxPasoDos = new System.Windows.Forms.GroupBox();
            this.groupBoxSintomaDiagnostico = new System.Windows.Forms.GroupBox();
            this.groupBoxPasoDos.SuspendLayout();
            this.groupBoxSintomaDiagnostico.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSintomas
            // 
            this.textBoxSintomas.Location = new System.Drawing.Point(85, 18);
            this.textBoxSintomas.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSintomas.Multiline = true;
            this.textBoxSintomas.Name = "textBoxSintomas";
            this.textBoxSintomas.Size = new System.Drawing.Size(549, 48);
            this.textBoxSintomas.TabIndex = 3;
            // 
            // textBoxDiagnostico
            // 
            this.textBoxDiagnostico.Location = new System.Drawing.Point(85, 82);
            this.textBoxDiagnostico.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDiagnostico.Multiline = true;
            this.textBoxDiagnostico.Name = "textBoxDiagnostico";
            this.textBoxDiagnostico.Size = new System.Drawing.Size(549, 55);
            this.textBoxDiagnostico.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sintomas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Diagnostico";
            // 
            // buttonCerrarConsulta
            // 
            this.buttonCerrarConsulta.ForeColor = System.Drawing.Color.Red;
            this.buttonCerrarConsulta.Location = new System.Drawing.Point(27, 178);
            this.buttonCerrarConsulta.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCerrarConsulta.Name = "buttonCerrarConsulta";
            this.buttonCerrarConsulta.Size = new System.Drawing.Size(617, 24);
            this.buttonCerrarConsulta.TabIndex = 7;
            this.buttonCerrarConsulta.Text = "Cerra consulta";
            this.buttonCerrarConsulta.UseVisualStyleBackColor = true;
            this.buttonCerrarConsulta.Click += new System.EventHandler(this.buttonCerrarConsulta_Click);
            // 
            // groupBoxPasoDos
            // 
            this.groupBoxPasoDos.Controls.Add(this.groupBoxSintomaDiagnostico);
            this.groupBoxPasoDos.Enabled = false;
            this.groupBoxPasoDos.Location = new System.Drawing.Point(11, 3);
            this.groupBoxPasoDos.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxPasoDos.Name = "groupBoxPasoDos";
            this.groupBoxPasoDos.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxPasoDos.Size = new System.Drawing.Size(662, 171);
            this.groupBoxPasoDos.TabIndex = 8;
            this.groupBoxPasoDos.TabStop = false;
            this.groupBoxPasoDos.Text = "Ingrese Datos";
            // 
            // groupBoxSintomaDiagnostico
            // 
            this.groupBoxSintomaDiagnostico.Controls.Add(this.textBoxDiagnostico);
            this.groupBoxSintomaDiagnostico.Controls.Add(this.textBoxSintomas);
            this.groupBoxSintomaDiagnostico.Controls.Add(this.label1);
            this.groupBoxSintomaDiagnostico.Controls.Add(this.label2);
            this.groupBoxSintomaDiagnostico.Location = new System.Drawing.Point(16, 18);
            this.groupBoxSintomaDiagnostico.Name = "groupBoxSintomaDiagnostico";
            this.groupBoxSintomaDiagnostico.Size = new System.Drawing.Size(641, 143);
            this.groupBoxSintomaDiagnostico.TabIndex = 8;
            this.groupBoxSintomaDiagnostico.TabStop = false;
            this.groupBoxSintomaDiagnostico.Text = "Diagnostico";
            // 
            // EscribirSintomasYDiagnostico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 209);
            this.Controls.Add(this.buttonCerrarConsulta);
            this.Controls.Add(this.groupBoxPasoDos);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EscribirSintomasYDiagnostico";
            this.Text = "Diagnostico";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxPasoDos.ResumeLayout(false);
            this.groupBoxSintomaDiagnostico.ResumeLayout(false);
            this.groupBoxSintomaDiagnostico.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxSintomas;
        private System.Windows.Forms.TextBox textBoxDiagnostico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCerrarConsulta;
        private System.Windows.Forms.GroupBox groupBoxPasoDos;
        private System.Windows.Forms.GroupBox groupBoxSintomaDiagnostico;
    }
}