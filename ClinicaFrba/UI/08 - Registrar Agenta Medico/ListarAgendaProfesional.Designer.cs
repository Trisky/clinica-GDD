namespace ClinicaFrba.UI._08___Registrar_Agenta_Medico
{
    partial class ListarAgendaProfesional
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDia = new System.Windows.Forms.ComboBox();
            this.buttonVerDia = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelIdMedico = new System.Windows.Forms.Label();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.labelIdMedico);
            this.gbFiltros.Controls.Add(this.label2);
            this.gbFiltros.Controls.Add(this.buttonVerDia);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Controls.Add(this.comboBoxDia);
            this.gbFiltros.Controls.SetChildIndex(this.btnBuscar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.comboBoxDia, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label1, 0);
            this.gbFiltros.Controls.SetChildIndex(this.buttonVerDia, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label2, 0);
            this.gbFiltros.Controls.SetChildIndex(this.labelIdMedico, 0);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Seleccione Dia";
            // 
            // comboBoxDia
            // 
            this.comboBoxDia.FormattingEnabled = true;
            this.comboBoxDia.Location = new System.Drawing.Point(168, 44);
            this.comboBoxDia.Name = "comboBoxDia";
            this.comboBoxDia.Size = new System.Drawing.Size(398, 32);
            this.comboBoxDia.TabIndex = 4;
            this.comboBoxDia.SelectedIndexChanged += new System.EventHandler(this.comboBoxDia_SelectedIndexChanged);
            // 
            // buttonVerDia
            // 
            this.buttonVerDia.Location = new System.Drawing.Point(50, 83);
            this.buttonVerDia.Name = "buttonVerDia";
            this.buttonVerDia.Size = new System.Drawing.Size(164, 37);
            this.buttonVerDia.TabIndex = 6;
            this.buttonVerDia.Text = "VerDia";
            this.buttonVerDia.UseVisualStyleBackColor = true;
            this.buttonVerDia.Click += new System.EventHandler(this.buttonVerDia_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(893, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "su ID de medico es: ";
            // 
            // labelIdMedico
            // 
            this.labelIdMedico.AutoSize = true;
            this.labelIdMedico.Location = new System.Drawing.Point(1076, 17);
            this.labelIdMedico.Name = "labelIdMedico";
            this.labelIdMedico.Size = new System.Drawing.Size(64, 25);
            this.labelIdMedico.TabIndex = 8;
            this.labelIdMedico.Text = "label3";
            this.labelIdMedico.Click += new System.EventHandler(this.label3_Click);
            // 
            // ListarAgendaProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1998, 866);
            this.Name = "ListarAgendaProfesional";
            this.Text = "ListarAgendaProfesional";
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDia;
        private System.Windows.Forms.Button buttonVerDia;
        private System.Windows.Forms.Label labelIdMedico;
        private System.Windows.Forms.Label label2;
    }
}