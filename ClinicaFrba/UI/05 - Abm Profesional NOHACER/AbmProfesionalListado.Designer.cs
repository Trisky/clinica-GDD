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
            this.buttonRegistroLlegada = new System.Windows.Forms.Button();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.buttonRegistroLlegada);
            this.gbFiltros.Controls.Add(this.textBoxApellido);
            this.gbFiltros.Controls.Add(this.textBoxNombre);
            this.gbFiltros.Controls.Add(this.label2);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Location = new System.Drawing.Point(12, 1);
            this.gbFiltros.Size = new System.Drawing.Size(930, 116);
            this.gbFiltros.Controls.SetChildIndex(this.btnBuscar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label1, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label2, 0);
            this.gbFiltros.Controls.SetChildIndex(this.textBoxNombre, 0);
            this.gbFiltros.Controls.SetChildIndex(this.textBoxApellido, 0);
            this.gbFiltros.Controls.SetChildIndex(this.buttonRegistroLlegada, 0);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(772, 47);
            this.btnBuscar.Size = new System.Drawing.Size(152, 35);
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(772, 83);
            this.btnLimpiar.Size = new System.Drawing.Size(152, 30);
            this.btnLimpiar.Visible = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(961, 84);
            this.btnEliminar.Visible = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(961, 18);
            this.btnAgregar.Visible = false;
            // 
            // btnModificar
            // 
            this.btnModificar.Visible = false;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(961, 84);
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Apellido";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(65, 19);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(200, 20);
            this.textBoxNombre.TabIndex = 4;
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(65, 42);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(200, 20);
            this.textBoxApellido.TabIndex = 5;
            // 
            // buttonRegistroLlegada
            // 
            this.buttonRegistroLlegada.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonRegistroLlegada.Enabled = false;
            this.buttonRegistroLlegada.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonRegistroLlegada.Location = new System.Drawing.Point(772, 8);
            this.buttonRegistroLlegada.Name = "buttonRegistroLlegada";
            this.buttonRegistroLlegada.Size = new System.Drawing.Size(152, 37);
            this.buttonRegistroLlegada.TabIndex = 6;
            this.buttonRegistroLlegada.Text = "Mostrar Turnos de Hoy";
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
        private System.Windows.Forms.Button buttonRegistroLlegada;
    }
}