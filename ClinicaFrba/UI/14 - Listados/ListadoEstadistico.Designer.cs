namespace ClinicaFrba.UI._14___Listados
{
    partial class ListadoEstadistico
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.numericAnio = new System.Windows.Forms.NumericUpDown();
            this.numericSemestre = new System.Windows.Forms.NumericUpDown();
            this.gbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSemestre)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.numericSemestre);
            this.gbFiltros.Controls.Add(this.numericAnio);
            this.gbFiltros.Controls.Add(this.button4);
            this.gbFiltros.Controls.Add(this.button5);
            this.gbFiltros.Controls.Add(this.label2);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Controls.Add(this.button3);
            this.gbFiltros.Controls.Add(this.button2);
            this.gbFiltros.Controls.Add(this.button1);
            this.gbFiltros.Size = new System.Drawing.Size(926, 105);
            this.gbFiltros.Text = "Visualizacion de estadisticas TOP 5";
            this.gbFiltros.Controls.SetChildIndex(this.btnBuscar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.button1, 0);
            this.gbFiltros.Controls.SetChildIndex(this.button2, 0);
            this.gbFiltros.Controls.SetChildIndex(this.button3, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label1, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label2, 0);
            this.gbFiltros.Controls.SetChildIndex(this.button5, 0);
            this.gbFiltros.Controls.SetChildIndex(this.button4, 0);
            this.gbFiltros.Controls.SetChildIndex(this.numericAnio, 0);
            this.gbFiltros.Controls.SetChildIndex(this.numericSemestre, 0);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(289, 69);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(415, 69);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(958, 93);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(958, 21);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(958, 57);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(958, 93);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(265, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(307, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Especialidades  Mas Canceladas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(578, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(342, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Profesionales con menos horas trabajadas por especialidad";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(265, 35);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(307, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Profesiones mas consultadas por plan";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Año:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Semestre";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(578, 35);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(342, 23);
            this.button4.TabIndex = 23;
            this.button4.Text = "Afiliados con mas bonos";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(578, 64);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(342, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "Especialidad con mas bonos utilizados";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // numericAnio
            // 
            this.numericAnio.Location = new System.Drawing.Point(61, 33);
            this.numericAnio.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numericAnio.Minimum = new decimal(new int[] {
            2005,
            0,
            0,
            0});
            this.numericAnio.Name = "numericAnio";
            this.numericAnio.Size = new System.Drawing.Size(120, 20);
            this.numericAnio.TabIndex = 24;
            this.numericAnio.Value = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            // 
            // numericSemestre
            // 
            this.numericSemestre.Location = new System.Drawing.Point(61, 60);
            this.numericSemestre.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericSemestre.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSemestre.Name = "numericSemestre";
            this.numericSemestre.Size = new System.Drawing.Size(120, 20);
            this.numericSemestre.TabIndex = 25;
            this.numericSemestre.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 424);
            this.Name = "ListadoEstadistico";
            this.Text = "ListadoEstadistico";
            this.Load += new System.EventHandler(this.ListadoEstadistico_Load);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSemestre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.NumericUpDown numericSemestre;
        private System.Windows.Forms.NumericUpDown numericAnio;
    }
}