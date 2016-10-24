namespace ClinicaFrba.UI._08___Registrar_Agenta_Medico
{
    partial class CrearNuevoHorario
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
            this.buttonNuevoHorario = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxEspecialidad = new System.Windows.Forms.ComboBox();
            this.groupBoxNuevoHorario = new System.Windows.Forms.GroupBox();
            this.numMinutoFin = new System.Windows.Forms.NumericUpDown();
            this.numHoraFin = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numMinutoInicio = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numHoraInicio = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxNuevoHorario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutoFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHoraFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutoInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHoraInicio)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxDia
            // 
            this.comboBoxDia.FormattingEnabled = true;
            this.comboBoxDia.Location = new System.Drawing.Point(11, 37);
            this.comboBoxDia.Name = "comboBoxDia";
            this.comboBoxDia.Size = new System.Drawing.Size(165, 32);
            this.comboBoxDia.TabIndex = 0;
            // 
            // buttonNuevoHorario
            // 
            this.buttonNuevoHorario.BackColor = System.Drawing.Color.Yellow;
            this.buttonNuevoHorario.Enabled = false;
            this.buttonNuevoHorario.Location = new System.Drawing.Point(161, 294);
            this.buttonNuevoHorario.Name = "buttonNuevoHorario";
            this.buttonNuevoHorario.Size = new System.Drawing.Size(166, 87);
            this.buttonNuevoHorario.TabIndex = 2;
            this.buttonNuevoHorario.Text = "Crear nuevo horario en este dia";
            this.buttonNuevoHorario.UseVisualStyleBackColor = false;
            this.buttonNuevoHorario.Click += new System.EventHandler(this.buttonNuevoHorario_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seleccione Dia";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Seleccione especialidad";
            // 
            // comboBoxEspecialidad
            // 
            this.comboBoxEspecialidad.FormattingEnabled = true;
            this.comboBoxEspecialidad.Location = new System.Drawing.Point(23, 243);
            this.comboBoxEspecialidad.Name = "comboBoxEspecialidad";
            this.comboBoxEspecialidad.Size = new System.Drawing.Size(436, 32);
            this.comboBoxEspecialidad.TabIndex = 5;
            // 
            // groupBoxNuevoHorario
            // 
            this.groupBoxNuevoHorario.Controls.Add(this.numMinutoFin);
            this.groupBoxNuevoHorario.Controls.Add(this.numHoraFin);
            this.groupBoxNuevoHorario.Controls.Add(this.label5);
            this.groupBoxNuevoHorario.Controls.Add(this.numMinutoInicio);
            this.groupBoxNuevoHorario.Controls.Add(this.label3);
            this.groupBoxNuevoHorario.Controls.Add(this.label4);
            this.groupBoxNuevoHorario.Controls.Add(this.numHoraInicio);
            this.groupBoxNuevoHorario.Controls.Add(this.label6);
            this.groupBoxNuevoHorario.Location = new System.Drawing.Point(191, 9);
            this.groupBoxNuevoHorario.Name = "groupBoxNuevoHorario";
            this.groupBoxNuevoHorario.Size = new System.Drawing.Size(370, 137);
            this.groupBoxNuevoHorario.TabIndex = 6;
            this.groupBoxNuevoHorario.TabStop = false;
            this.groupBoxNuevoHorario.Text = "Nuevo Horario";
            this.groupBoxNuevoHorario.Visible = false;
            // 
            // numMinutoFin
            // 
            this.numMinutoFin.Location = new System.Drawing.Point(234, 92);
            this.numMinutoFin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numMinutoFin.Name = "numMinutoFin";
            this.numMinutoFin.Size = new System.Drawing.Size(63, 29);
            this.numMinutoFin.TabIndex = 12;
            // 
            // numHoraFin
            // 
            this.numHoraFin.Location = new System.Drawing.Point(157, 92);
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
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = ":";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hora fin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hora inicio";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = ":";
            // 
            // CrearNuevoHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 654);
            this.Controls.Add(this.groupBoxNuevoHorario);
            this.Controls.Add(this.comboBoxEspecialidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDia);
            this.Controls.Add(this.buttonNuevoHorario);
            this.Name = "CrearNuevoHorario";
            this.Text = "CrearNuevoHorario";
            this.groupBoxNuevoHorario.ResumeLayout(false);
            this.groupBoxNuevoHorario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutoFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHoraFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutoInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHoraInicio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDia;
        private System.Windows.Forms.Button buttonNuevoHorario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxEspecialidad;
        private System.Windows.Forms.GroupBox groupBoxNuevoHorario;
        private System.Windows.Forms.NumericUpDown numMinutoFin;
        private System.Windows.Forms.NumericUpDown numHoraFin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numMinutoInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numHoraInicio;
        private System.Windows.Forms.Label label6;
    }
}