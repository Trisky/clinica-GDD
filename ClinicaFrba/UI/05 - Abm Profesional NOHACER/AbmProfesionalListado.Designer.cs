namespace ClinicaFrba.UI._05___Abm_Profesional
{
    partial class AbmProfesionalListado
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.comboBoxEspecialidades = new System.Windows.Forms.ComboBox();
            this.labelEspec = new System.Windows.Forms.Label();
            this.buttonRegistroLlegada = new System.Windows.Forms.Button();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.labelEspec);
            this.gbFiltros.Controls.Add(this.comboBoxEspecialidades);
            this.gbFiltros.Controls.Add(this.textBoxApellido);
            this.gbFiltros.Controls.Add(this.textBoxNombre);
            this.gbFiltros.Controls.Add(this.label2);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Controls.Add(this.buttonRegistroLlegada);
            this.gbFiltros.Controls.SetChildIndex(this.btnBuscar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.buttonRegistroLlegada, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label1, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label2, 0);
            this.gbFiltros.Controls.SetChildIndex(this.textBoxNombre, 0);
            this.gbFiltros.Controls.SetChildIndex(this.textBoxApellido, 0);
            this.gbFiltros.Controls.SetChildIndex(this.comboBoxEspecialidades, 0);
            this.gbFiltros.Controls.SetChildIndex(this.labelEspec, 0);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Visible = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(961, 129);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Visible = false;
            // 
            // btnModificar
            // 
            this.btnModificar.Visible = false;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(961, 91);
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(675, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "nombre";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(675, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "apellido";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(724, 51);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(100, 20);
            this.textBoxNombre.TabIndex = 4;
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(724, 76);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(100, 20);
            this.textBoxApellido.TabIndex = 5;
            // 
            // comboBoxEspecialidades
            // 
            this.comboBoxEspecialidades.FormattingEnabled = true;
            this.comboBoxEspecialidades.Location = new System.Drawing.Point(724, 15);
            this.comboBoxEspecialidades.Name = "comboBoxEspecialidades";
            this.comboBoxEspecialidades.Size = new System.Drawing.Size(200, 21);
            this.comboBoxEspecialidades.TabIndex = 6;
            // 
            // labelEspec
            // 
            this.labelEspec.AutoSize = true;
            this.labelEspec.Location = new System.Drawing.Point(651, 18);
            this.labelEspec.Name = "labelEspec";
            this.labelEspec.Size = new System.Drawing.Size(66, 13);
            this.labelEspec.TabIndex = 7;
            this.labelEspec.Text = "especialidad";
            // 
            // buttonRegistroLlegada
            // 
            this.buttonRegistroLlegada.BackColor = System.Drawing.Color.Yellow;
            this.buttonRegistroLlegada.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonRegistroLlegada.Location = new System.Drawing.Point(516, 84);
            this.buttonRegistroLlegada.Name = "buttonRegistroLlegada";
            this.buttonRegistroLlegada.Size = new System.Drawing.Size(133, 60);
            this.buttonRegistroLlegada.TabIndex = 6;
            this.buttonRegistroLlegada.Text = "Mostrar Turnos de este medico para hoy";
            this.buttonRegistroLlegada.UseVisualStyleBackColor = false;
            this.buttonRegistroLlegada.Visible = false;
            this.buttonRegistroLlegada.Click += new System.EventHandler(this.button1_Click);
            // 
            // AbmProfesionalListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 469);
            this.Name = "AbmProfesionalListado";
            this.Text = "AbmProfesionalListado";
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelEspec;
        private System.Windows.Forms.ComboBox comboBoxEspecialidades;
        private System.Windows.Forms.Button buttonRegistroLlegada;
    }
}