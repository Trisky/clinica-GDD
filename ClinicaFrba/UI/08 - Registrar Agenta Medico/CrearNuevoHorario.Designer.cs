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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBoxNuevoHorario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutoFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHoraFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutoInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHoraInicio)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxDia
            // 
            this.comboBoxDia.FormattingEnabled = true;
            this.comboBoxDia.Location = new System.Drawing.Point(11, 18);
            this.comboBoxDia.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxDia.Name = "comboBoxDia";
            this.comboBoxDia.Size = new System.Drawing.Size(277, 21);
            this.comboBoxDia.TabIndex = 0;
            this.comboBoxDia.SelectedIndexChanged += new System.EventHandler(this.comboBoxDia_SelectedIndexChanged);
            // 
            // buttonNuevoHorario
            // 
            this.buttonNuevoHorario.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonNuevoHorario.Enabled = false;
            this.buttonNuevoHorario.Location = new System.Drawing.Point(40, 176);
            this.buttonNuevoHorario.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNuevoHorario.Name = "buttonNuevoHorario";
            this.buttonNuevoHorario.Size = new System.Drawing.Size(257, 33);
            this.buttonNuevoHorario.TabIndex = 2;
            this.buttonNuevoHorario.Text = "Crear Horario ";
            this.buttonNuevoHorario.UseVisualStyleBackColor = false;
            this.buttonNuevoHorario.Click += new System.EventHandler(this.buttonNuevoHorario_Click);
            // 
            // comboBoxEspecialidad
            // 
            this.comboBoxEspecialidad.FormattingEnabled = true;
            this.comboBoxEspecialidad.Location = new System.Drawing.Point(11, 18);
            this.comboBoxEspecialidad.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxEspecialidad.Name = "comboBoxEspecialidad";
            this.comboBoxEspecialidad.Size = new System.Drawing.Size(277, 21);
            this.comboBoxEspecialidad.TabIndex = 5;
            this.comboBoxEspecialidad.SelectedIndexChanged += new System.EventHandler(this.comboBoxEspecialidad_SelectedIndexChanged);
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
            this.groupBoxNuevoHorario.Location = new System.Drawing.Point(13, 64);
            this.groupBoxNuevoHorario.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxNuevoHorario.Name = "groupBoxNuevoHorario";
            this.groupBoxNuevoHorario.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxNuevoHorario.Size = new System.Drawing.Size(293, 54);
            this.groupBoxNuevoHorario.TabIndex = 6;
            this.groupBoxNuevoHorario.TabStop = false;
            this.groupBoxNuevoHorario.Text = "Horario";
            this.groupBoxNuevoHorario.Visible = false;
            // 
            // numMinutoFin
            // 
            this.numMinutoFin.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numMinutoFin.Location = new System.Drawing.Point(250, 22);
            this.numMinutoFin.Margin = new System.Windows.Forms.Padding(2);
            this.numMinutoFin.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numMinutoFin.Name = "numMinutoFin";
            this.numMinutoFin.Size = new System.Drawing.Size(34, 20);
            this.numMinutoFin.TabIndex = 12;
            // 
            // numHoraFin
            // 
            this.numHoraFin.Location = new System.Drawing.Point(208, 22);
            this.numHoraFin.Margin = new System.Windows.Forms.Padding(2);
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
            this.numHoraFin.Size = new System.Drawing.Size(34, 20);
            this.numHoraFin.TabIndex = 6;
            this.numHoraFin.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numHoraFin.ValueChanged += new System.EventHandler(this.numHoraFin_ValueChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = ":";
            // 
            // numMinutoInicio
            // 
            this.numMinutoInicio.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numMinutoInicio.Location = new System.Drawing.Point(111, 22);
            this.numMinutoInicio.Margin = new System.Windows.Forms.Padding(2);
            this.numMinutoInicio.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numMinutoInicio.Name = "numMinutoInicio";
            this.numMinutoInicio.Size = new System.Drawing.Size(34, 20);
            this.numMinutoInicio.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hora Fin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hora Inicio";
            // 
            // numHoraInicio
            // 
            this.numHoraInicio.Location = new System.Drawing.Point(69, 23);
            this.numHoraInicio.Margin = new System.Windows.Forms.Padding(2);
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
            this.numHoraInicio.Size = new System.Drawing.Size(34, 20);
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
            this.label6.Location = new System.Drawing.Point(102, 26);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = ":";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxDia);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 54);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione Dia";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxEspecialidad);
            this.groupBox2.Location = new System.Drawing.Point(13, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 48);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccione Especialidad";
            // 
            // CrearNuevoHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 217);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxNuevoHorario);
            this.Controls.Add(this.buttonNuevoHorario);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CrearNuevoHorario";
            this.Text = "CrearNuevoHorario";
            this.groupBoxNuevoHorario.ResumeLayout(false);
            this.groupBoxNuevoHorario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutoFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHoraFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutoInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHoraInicio)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDia;
        private System.Windows.Forms.Button buttonNuevoHorario;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}