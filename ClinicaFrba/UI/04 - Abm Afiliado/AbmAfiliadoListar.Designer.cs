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
            this.gbFiltros.Location = new System.Drawing.Point(19, 8);
            this.gbFiltros.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbFiltros.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbFiltros.Size = new System.Drawing.Size(930, 151);
            this.gbFiltros.Enter += new System.EventHandler(this.gbFiltros_Enter);
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
            this.btnBuscar.Location = new System.Drawing.Point(679, 115);
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(805, 115);
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(961, 93);
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
            this.btnSeleccionar.Location = new System.Drawing.Point(961, 93);
            this.btnSeleccionar.Text = "Eliminar";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click_1);
            // 
            // textBoxCantidadEncontrada
            // 
            this.textBoxCantidadEncontrada.Location = new System.Drawing.Point(88, 463);
            this.textBoxCantidadEncontrada.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxCantidadEncontrada.Name = "textBoxCantidadEncontrada";
            this.textBoxCantidadEncontrada.ReadOnly = true;
            this.textBoxCantidadEncontrada.Size = new System.Drawing.Size(100, 20);
            this.textBoxCantidadEncontrada.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 463);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Encontrados:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Apellido:";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(63, 21);
            this.textBoxNombre.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(167, 20);
            this.textBoxNombre.TabIndex = 4;
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(63, 48);
            this.textBoxApellido.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(167, 20);
            this.textBoxApellido.TabIndex = 5;
            // 
            // groupBoxLlegada
            // 
            this.groupBoxLlegada.Controls.Add(this.buttonTurnoHoy);
            this.groupBoxLlegada.Controls.Add(this.buttonSeleccionParaTurno);
            this.groupBoxLlegada.Enabled = false;
            this.groupBoxLlegada.Location = new System.Drawing.Point(679, 12);
            this.groupBoxLlegada.Margin = new System.Windows.Forms.Padding(1);
            this.groupBoxLlegada.Name = "groupBoxLlegada";
            this.groupBoxLlegada.Padding = new System.Windows.Forms.Padding(1);
            this.groupBoxLlegada.Size = new System.Drawing.Size(246, 99);
            this.groupBoxLlegada.TabIndex = 23;
            this.groupBoxLlegada.TabStop = false;
            this.groupBoxLlegada.Text = "Seleccione afiliado para turnos";
            // 
            // buttonTurnoHoy
            // 
            this.buttonTurnoHoy.BackColor = System.Drawing.Color.Aqua;
            this.buttonTurnoHoy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonTurnoHoy.Location = new System.Drawing.Point(27, 37);
            this.buttonTurnoHoy.Margin = new System.Windows.Forms.Padding(1);
            this.buttonTurnoHoy.Name = "buttonTurnoHoy";
            this.buttonTurnoHoy.Size = new System.Drawing.Size(211, 36);
            this.buttonTurnoHoy.TabIndex = 1;
            this.buttonTurnoHoy.Text = "Dar Turno";
            this.buttonTurnoHoy.UseVisualStyleBackColor = false;
            this.buttonTurnoHoy.Click += new System.EventHandler(this.buttonTurnoHoy_Click);
            // 
            // buttonSeleccionParaTurno
            // 
            this.buttonSeleccionParaTurno.Location = new System.Drawing.Point(45, 107);
            this.buttonSeleccionParaTurno.Margin = new System.Windows.Forms.Padding(1);
            this.buttonSeleccionParaTurno.Name = "buttonSeleccionParaTurno";
            this.buttonSeleccionParaTurno.Size = new System.Drawing.Size(193, 36);
            this.buttonSeleccionParaTurno.TabIndex = 0;
            this.buttonSeleccionParaTurno.Text = "Darle un turno para hoy a este afiliado";
            this.buttonSeleccionParaTurno.UseVisualStyleBackColor = true;
            this.buttonSeleccionParaTurno.Click += new System.EventHandler(this.buttonSeleccionParaTurno_Click);
            // 
            // AbmAfiliadoListar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 480);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCantidadEncontrada);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
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