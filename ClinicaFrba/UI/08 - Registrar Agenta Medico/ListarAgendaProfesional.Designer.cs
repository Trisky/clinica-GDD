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
            // btnBuscar
            // 
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Seleccione Dia";
            // 
            // comboBoxDia
            // 
            this.comboBoxDia.FormattingEnabled = true;
            this.comboBoxDia.Location = new System.Drawing.Point(92, 24);
            this.comboBoxDia.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxDia.Name = "comboBoxDia";
            this.comboBoxDia.Size = new System.Drawing.Size(219, 21);
            this.comboBoxDia.TabIndex = 4;
            this.comboBoxDia.SelectedIndexChanged += new System.EventHandler(this.comboBoxDia_SelectedIndexChanged);
            // 
            // buttonVerDia
            // 
            this.buttonVerDia.Location = new System.Drawing.Point(27, 45);
            this.buttonVerDia.Margin = new System.Windows.Forms.Padding(2);
            this.buttonVerDia.Name = "buttonVerDia";
            this.buttonVerDia.Size = new System.Drawing.Size(89, 20);
            this.buttonVerDia.TabIndex = 6;
            this.buttonVerDia.Text = "VerDia";
            this.buttonVerDia.UseVisualStyleBackColor = true;
            this.buttonVerDia.Click += new System.EventHandler(this.buttonVerDia_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(487, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "su ID de medico es: ";
            // 
            // labelIdMedico
            // 
            this.labelIdMedico.AutoSize = true;
            this.labelIdMedico.Location = new System.Drawing.Point(587, 9);
            this.labelIdMedico.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIdMedico.Name = "labelIdMedico";
            this.labelIdMedico.Size = new System.Drawing.Size(35, 13);
            this.labelIdMedico.TabIndex = 8;
            this.labelIdMedico.Text = "label3";
            this.labelIdMedico.Click += new System.EventHandler(this.label3_Click);
            // 
            // ListarAgendaProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 469);
            this.Margin = new System.Windows.Forms.Padding(2);
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