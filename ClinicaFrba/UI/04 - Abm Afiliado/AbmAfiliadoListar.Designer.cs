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
            this.buttonSeleccionParaTurno = new System.Windows.Forms.Button();
            this.buttonTurnoHoy = new System.Windows.Forms.Button();
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
            this.gbFiltros.Location = new System.Drawing.Point(35, 16);
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
            this.textBoxCantidadEncontrada.Location = new System.Drawing.Point(161, 854);
            this.textBoxCantidadEncontrada.Name = "textBoxCantidadEncontrada";
            this.textBoxCantidadEncontrada.ReadOnly = true;
            this.textBoxCantidadEncontrada.Size = new System.Drawing.Size(180, 29);
            this.textBoxCantidadEncontrada.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 854);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Encontrados:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Apellido:";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(116, 38);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(302, 29);
            this.textBoxNombre.TabIndex = 4;
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(116, 89);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(302, 29);
            this.textBoxApellido.TabIndex = 5;
            // 
            // groupBoxLlegada
            // 
            this.groupBoxLlegada.Controls.Add(this.buttonTurnoHoy);
            this.groupBoxLlegada.Controls.Add(this.buttonSeleccionParaTurno);
            this.groupBoxLlegada.Enabled = false;
            this.groupBoxLlegada.Location = new System.Drawing.Point(1081, 23);
            this.groupBoxLlegada.Name = "groupBoxLlegada";
            this.groupBoxLlegada.Size = new System.Drawing.Size(504, 121);
            this.groupBoxLlegada.TabIndex = 23;
            this.groupBoxLlegada.TabStop = false;
            this.groupBoxLlegada.Text = "Seleccione afiliado para turnos";
            // 
            // buttonSeleccionParaTurno
            // 
            this.buttonSeleccionParaTurno.Location = new System.Drawing.Point(82, 197);
            this.buttonSeleccionParaTurno.Name = "buttonSeleccionParaTurno";
            this.buttonSeleccionParaTurno.Size = new System.Drawing.Size(355, 67);
            this.buttonSeleccionParaTurno.TabIndex = 0;
            this.buttonSeleccionParaTurno.Text = "Darle un turno para hoy a este afiliado";
            this.buttonSeleccionParaTurno.UseVisualStyleBackColor = true;
            this.buttonSeleccionParaTurno.Click += new System.EventHandler(this.buttonSeleccionParaTurno_Click);
            // 
            // buttonTurnoHoy
            // 
            this.buttonTurnoHoy.BackColor = System.Drawing.Color.Aqua;
            this.buttonTurnoHoy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonTurnoHoy.Location = new System.Drawing.Point(82, 49);
            this.buttonTurnoHoy.Name = "buttonTurnoHoy";
            this.buttonTurnoHoy.Size = new System.Drawing.Size(388, 66);
            this.buttonTurnoHoy.TabIndex = 1;
            this.buttonTurnoHoy.Text = "Darle un turno para hoy";
            this.buttonTurnoHoy.UseVisualStyleBackColor = false;
            this.buttonTurnoHoy.Click += new System.EventHandler(this.buttonTurnoHoy_Click);
            // 
            // AbmAfiliadoListar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2025, 887);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCantidadEncontrada);
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