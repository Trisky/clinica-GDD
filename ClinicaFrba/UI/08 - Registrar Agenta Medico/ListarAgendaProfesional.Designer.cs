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
            this.buttonVerDia = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelIdMedico = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.label3);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Controls.Add(this.labelIdMedico);
            this.gbFiltros.Controls.Add(this.label2);
            this.gbFiltros.Controls.Add(this.buttonVerDia);
            this.gbFiltros.Location = new System.Drawing.Point(12, 3);
            this.gbFiltros.Size = new System.Drawing.Size(943, 114);
            this.gbFiltros.Controls.SetChildIndex(this.btnBuscar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.buttonVerDia, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label2, 0);
            this.gbFiltros.Controls.SetChildIndex(this.labelIdMedico, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label1, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label3, 0);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(791, 45);
            this.btnBuscar.Size = new System.Drawing.Size(146, 30);
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(791, 81);
            this.btnLimpiar.Size = new System.Drawing.Size(146, 30);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(961, 14);
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(961, 84);
            // 
            // buttonVerDia
            // 
            this.buttonVerDia.Location = new System.Drawing.Point(791, 11);
            this.buttonVerDia.Margin = new System.Windows.Forms.Padding(2);
            this.buttonVerDia.Name = "buttonVerDia";
            this.buttonVerDia.Size = new System.Drawing.Size(147, 30);
            this.buttonVerDia.TabIndex = 6;
            this.buttonVerDia.Text = "Ver agenda del medico";
            this.buttonVerDia.UseVisualStyleBackColor = true;
            this.buttonVerDia.Click += new System.EventHandler(this.buttonVerDia_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Id Medico:";
            // 
            // labelIdMedico
            // 
            this.labelIdMedico.AutoSize = true;
            this.labelIdMedico.Location = new System.Drawing.Point(70, 19);
            this.labelIdMedico.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIdMedico.Name = "labelIdMedico";
            this.labelIdMedico.Size = new System.Drawing.Size(35, 13);
            this.labelIdMedico.TabIndex = 8;
            this.labelIdMedico.Text = "label3";
            this.labelIdMedico.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Posee horas semanales  de trabajo: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // ListarAgendaProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 422);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ListarAgendaProfesional";
            this.Text = "ListarAgendaProfesional";
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonVerDia;
        private System.Windows.Forms.Label labelIdMedico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}