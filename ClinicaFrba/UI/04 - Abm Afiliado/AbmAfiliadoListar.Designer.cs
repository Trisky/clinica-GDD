namespace ClinicaFrba.UI._04___Abm_Afiliado
{
    partial class AbmAfiliadoListar
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
            this.textBoxCantidadEncontrada = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.groupBoxLlegada = new System.Windows.Forms.GroupBox();
            this.buttonTurnoHoy = new System.Windows.Forms.Button();
            this.buttonSeleccionParaTurno = new System.Windows.Forms.Button();
            this.gbFiltros.SuspendLayout();
            this.groupBoxLlegada.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.groupBoxLlegada);
            this.gbFiltros.Controls.Add(this.textBoxApellido);
            this.gbFiltros.Controls.Add(this.textBoxNombre);
            this.gbFiltros.Controls.Add(this.label3);
            this.gbFiltros.Controls.Add(this.label2);
            this.gbFiltros.Location = new System.Drawing.Point(29, 13);
            this.gbFiltros.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbFiltros.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbFiltros.Controls.SetChildIndex(this.btnBuscar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label2, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label3, 0);
            this.gbFiltros.Controls.SetChildIndex(this.textBoxNombre, 0);
            this.gbFiltros.Controls.SetChildIndex(this.textBoxApellido, 0);
            this.gbFiltros.Controls.SetChildIndex(this.groupBoxLlegada, 0);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Text = "eliminar";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click_1);
            // 
            // textBoxCantidadEncontrada
            // 
            this.textBoxCantidadEncontrada.Location = new System.Drawing.Point(132, 712);
            this.textBoxCantidadEncontrada.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCantidadEncontrada.Name = "textBoxCantidadEncontrada";
            this.textBoxCantidadEncontrada.ReadOnly = true;
            this.textBoxCantidadEncontrada.Size = new System.Drawing.Size(148, 26);
            this.textBoxCantidadEncontrada.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 712);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Encontrados:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Apellido:";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(95, 32);
            this.textBoxNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(248, 26);
            this.textBoxNombre.TabIndex = 4;
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(95, 74);
            this.textBoxApellido.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(248, 26);
            this.textBoxApellido.TabIndex = 5;
            // 
            // groupBoxLlegada
            // 
            this.groupBoxLlegada.Controls.Add(this.buttonTurnoHoy);
            this.groupBoxLlegada.Controls.Add(this.buttonSeleccionParaTurno);
            this.groupBoxLlegada.Enabled = false;
            this.groupBoxLlegada.Location = new System.Drawing.Point(884, 19);
            this.groupBoxLlegada.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxLlegada.Name = "groupBoxLlegada";
            this.groupBoxLlegada.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxLlegada.Size = new System.Drawing.Size(412, 101);
            this.groupBoxLlegada.TabIndex = 23;
            this.groupBoxLlegada.TabStop = false;
            this.groupBoxLlegada.Text = "Seleccione afiliado para turnos";
            // 
            // buttonTurnoHoy
            // 
            this.buttonTurnoHoy.BackColor = System.Drawing.Color.Aqua;
            this.buttonTurnoHoy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonTurnoHoy.Location = new System.Drawing.Point(67, 41);
            this.buttonTurnoHoy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonTurnoHoy.Name = "buttonTurnoHoy";
            this.buttonTurnoHoy.Size = new System.Drawing.Size(317, 55);
            this.buttonTurnoHoy.TabIndex = 1;
            this.buttonTurnoHoy.Text = "Darle un turno para hoy";
            this.buttonTurnoHoy.UseVisualStyleBackColor = false;
            this.buttonTurnoHoy.Click += new System.EventHandler(this.buttonTurnoHoy_Click);
            // 
            // buttonSeleccionParaTurno
            // 
            this.buttonSeleccionParaTurno.Location = new System.Drawing.Point(67, 164);
            this.buttonSeleccionParaTurno.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSeleccionParaTurno.Name = "buttonSeleccionParaTurno";
            this.buttonSeleccionParaTurno.Size = new System.Drawing.Size(290, 56);
            this.buttonSeleccionParaTurno.TabIndex = 0;
            this.buttonSeleccionParaTurno.Text = "Darle un turno para hoy a este afiliado";
            this.buttonSeleccionParaTurno.UseVisualStyleBackColor = true;
            this.buttonSeleccionParaTurno.Click += new System.EventHandler(this.buttonSeleccionParaTurno_Click);
            // 
            // AbmAfiliadoListar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1657, 739);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCantidadEncontrada);
            this.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.Name = "AbmAfiliadoListar";
            this.Text = "AbmAfiliadoListar";
            this.Controls.SetChildIndex(this.gbFiltros, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnModificar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnSeleccionar, 0);
            this.Controls.SetChildIndex(this.textBoxCantidadEncontrada, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.groupBoxLlegada.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCantidadEncontrada;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxLlegada;
        private System.Windows.Forms.Button buttonSeleccionParaTurno;
        private System.Windows.Forms.Button buttonTurnoHoy;
    }
}