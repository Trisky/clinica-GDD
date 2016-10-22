namespace ClinicaFrba.Registrar_Agenta_Medico
{
    partial class RegistroAgendaMedica
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
            this.comboBoxDia = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonNuevoHorario = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxNuevoHorario = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.numHoraInicio = new System.Windows.Forms.NumericUpDown();
            this.numHoraFin = new System.Windows.Forms.NumericUpDown();
            this.numMinutoInicio = new System.Windows.Forms.NumericUpDown();
            this.numMinutoFin = new System.Windows.Forms.NumericUpDown();
            this.groupBoxHorarios = new System.Windows.Forms.GroupBox();
            this.groupBoxNuevoHorario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHoraInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHoraFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutoInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutoFin)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxDia
            // 
            this.comboBoxDia.FormattingEnabled = true;
            this.comboBoxDia.Location = new System.Drawing.Point(12, 49);
            this.comboBoxDia.Name = "comboBoxDia";
            this.comboBoxDia.Size = new System.Drawing.Size(166, 32);
            this.comboBoxDia.TabIndex = 0;
            this.comboBoxDia.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione dia:";
            // 
            // buttonNuevoHorario
            // 
            this.buttonNuevoHorario.BackColor = System.Drawing.Color.Yellow;
            this.buttonNuevoHorario.Enabled = false;
            this.buttonNuevoHorario.Location = new System.Drawing.Point(12, 100);
            this.buttonNuevoHorario.Name = "buttonNuevoHorario";
            this.buttonNuevoHorario.Size = new System.Drawing.Size(166, 87);
            this.buttonNuevoHorario.TabIndex = 2;
            this.buttonNuevoHorario.Text = "Crear nuevo horario en este dia";
            this.buttonNuevoHorario.UseVisualStyleBackColor = false;
            this.buttonNuevoHorario.Click += new System.EventHandler(this.buttonNuevoHorario_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hora inicio";
            // 
            // groupBoxNuevoHorario
            // 
            this.groupBoxNuevoHorario.Controls.Add(this.numMinutoFin);
            this.groupBoxNuevoHorario.Controls.Add(this.button1);
            this.groupBoxNuevoHorario.Controls.Add(this.numHoraFin);
            this.groupBoxNuevoHorario.Controls.Add(this.label5);
            this.groupBoxNuevoHorario.Controls.Add(this.numMinutoInicio);
            this.groupBoxNuevoHorario.Controls.Add(this.label3);
            this.groupBoxNuevoHorario.Controls.Add(this.label2);
            this.groupBoxNuevoHorario.Controls.Add(this.numHoraInicio);
            this.groupBoxNuevoHorario.Controls.Add(this.label4);
            this.groupBoxNuevoHorario.Location = new System.Drawing.Point(17, 459);
            this.groupBoxNuevoHorario.Name = "groupBoxNuevoHorario";
            this.groupBoxNuevoHorario.Size = new System.Drawing.Size(166, 288);
            this.groupBoxNuevoHorario.TabIndex = 4;
            this.groupBoxNuevoHorario.TabStop = false;
            this.groupBoxNuevoHorario.Text = "Nuevo Horario";
            this.groupBoxNuevoHorario.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hora fin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = ":";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 64);
            this.button1.TabIndex = 11;
            this.button1.Text = "crear nuevo horario";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numHoraInicio
            // 
            this.numHoraInicio.Location = new System.Drawing.Point(6, 88);
            this.numHoraInicio.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numHoraInicio.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numHoraInicio.Name = "numHoraInicio";
            this.numHoraInicio.Size = new System.Drawing.Size(63, 29);
            this.numHoraInicio.TabIndex = 5;
            this.numHoraInicio.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // numHoraFin
            // 
            this.numHoraFin.Location = new System.Drawing.Point(6, 162);
            this.numHoraFin.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numHoraFin.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numHoraFin.Name = "numHoraFin";
            this.numHoraFin.Size = new System.Drawing.Size(63, 29);
            this.numHoraFin.TabIndex = 6;
            this.numHoraFin.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numHoraFin.ValueChanged += new System.EventHandler(this.numHoraFin_ValueChanged);
            // 
            // numMinutoInicio
            // 
            this.numMinutoInicio.Location = new System.Drawing.Point(83, 88);
            this.numMinutoInicio.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numMinutoInicio.Name = "numMinutoInicio";
            this.numMinutoInicio.Size = new System.Drawing.Size(63, 29);
            this.numMinutoInicio.TabIndex = 11;
            // 
            // numMinutoFin
            // 
            this.numMinutoFin.Location = new System.Drawing.Point(83, 162);
            this.numMinutoFin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numMinutoFin.Name = "numMinutoFin";
            this.numMinutoFin.Size = new System.Drawing.Size(63, 29);
            this.numMinutoFin.TabIndex = 12;
            this.numMinutoFin.ValueChanged += new System.EventHandler(this.numMinutoFin_ValueChanged);
            // 
            // groupBoxHorarios
            // 
            this.groupBoxHorarios.Location = new System.Drawing.Point(184, 21);
            this.groupBoxHorarios.Name = "groupBoxHorarios";
            this.groupBoxHorarios.Size = new System.Drawing.Size(1076, 726);
            this.groupBoxHorarios.TabIndex = 5;
            this.groupBoxHorarios.TabStop = false;
            this.groupBoxHorarios.Text = "Horarios Del dia seleccionado";
            // 
            // RegistroAgendaMedica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 759);
            this.Controls.Add(this.groupBoxHorarios);
            this.Controls.Add(this.groupBoxNuevoHorario);
            this.Controls.Add(this.buttonNuevoHorario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDia);
            this.Name = "RegistroAgendaMedica";
            this.Text = "RegistroAgendaMedica";
            this.groupBoxNuevoHorario.ResumeLayout(false);
            this.groupBoxNuevoHorario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHoraInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHoraFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutoInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutoFin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonNuevoHorario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxNuevoHorario;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numHoraInicio;
        private System.Windows.Forms.NumericUpDown numHoraFin;
        private System.Windows.Forms.NumericUpDown numMinutoInicio;
        private System.Windows.Forms.NumericUpDown numMinutoFin;
        private System.Windows.Forms.GroupBox groupBoxHorarios;
    }
}