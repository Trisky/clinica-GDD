namespace ClinicaFrba.Compra_Bono
{
    partial class CompraBono
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
            this.buttonComprar = new System.Windows.Forms.Button();
            this.textBoxPrecio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownCantidad = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.idPlanMedicoLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.precioFarmaciaLabel = new System.Windows.Forms.Label();
            this.precioAtencionLabel = new System.Windows.Forms.Label();
            this.radioButtonFarmacia = new System.Windows.Forms.RadioButton();
            this.radioButtonAtencion = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCantidad)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonComprar
            // 
            this.buttonComprar.Enabled = false;
            this.buttonComprar.Location = new System.Drawing.Point(42, 148);
            this.buttonComprar.Margin = new System.Windows.Forms.Padding(1);
            this.buttonComprar.Name = "buttonComprar";
            this.buttonComprar.Size = new System.Drawing.Size(161, 31);
            this.buttonComprar.TabIndex = 1;
            this.buttonComprar.Text = "Comprar";
            this.buttonComprar.UseVisualStyleBackColor = true;
            this.buttonComprar.Click += new System.EventHandler(this.buttonComprar_Click);
            // 
            // textBoxPrecio
            // 
            this.textBoxPrecio.Location = new System.Drawing.Point(21, 35);
            this.textBoxPrecio.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxPrecio.Name = "textBoxPrecio";
            this.textBoxPrecio.Size = new System.Drawing.Size(99, 20);
            this.textBoxPrecio.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cantidad";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Precio total";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Compra de bonos";
            // 
            // numericUpDownCantidad
            // 
            this.numericUpDownCantidad.Location = new System.Drawing.Point(108, 48);
            this.numericUpDownCantidad.Margin = new System.Windows.Forms.Padding(1);
            this.numericUpDownCantidad.Name = "numericUpDownCantidad";
            this.numericUpDownCantidad.Size = new System.Drawing.Size(95, 20);
            this.numericUpDownCantidad.TabIndex = 9;
            this.numericUpDownCantidad.ValueChanged += new System.EventHandler(this.numericUpDownCantidad_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 231);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "id planMedico =";
            // 
            // idPlanMedicoLabel
            // 
            this.idPlanMedicoLabel.AutoSize = true;
            this.idPlanMedicoLabel.Location = new System.Drawing.Point(90, 231);
            this.idPlanMedicoLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.idPlanMedicoLabel.Name = "idPlanMedicoLabel";
            this.idPlanMedicoLabel.Size = new System.Drawing.Size(35, 13);
            this.idPlanMedicoLabel.TabIndex = 11;
            this.idPlanMedicoLabel.Text = "label6";
            this.idPlanMedicoLabel.Click += new System.EventHandler(this.idPlanMedicoLabel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 78);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "precio bono farmacia:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 93);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "precio bono atencion;";
            // 
            // precioFarmaciaLabel
            // 
            this.precioFarmaciaLabel.AutoSize = true;
            this.precioFarmaciaLabel.Location = new System.Drawing.Point(137, 78);
            this.precioFarmaciaLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.precioFarmaciaLabel.Name = "precioFarmaciaLabel";
            this.precioFarmaciaLabel.Size = new System.Drawing.Size(39, 13);
            this.precioFarmaciaLabel.TabIndex = 14;
            this.precioFarmaciaLabel.Text = "p_farm";
            this.precioFarmaciaLabel.Click += new System.EventHandler(this.precioFarmaciaLabel_Click);
            // 
            // precioAtencionLabel
            // 
            this.precioAtencionLabel.AutoSize = true;
            this.precioAtencionLabel.Location = new System.Drawing.Point(137, 93);
            this.precioAtencionLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.precioAtencionLabel.Name = "precioAtencionLabel";
            this.precioAtencionLabel.Size = new System.Drawing.Size(40, 13);
            this.precioAtencionLabel.TabIndex = 15;
            this.precioAtencionLabel.Text = "p_aten";
            // 
            // radioButtonFarmacia
            // 
            this.radioButtonFarmacia.AutoSize = true;
            this.radioButtonFarmacia.Location = new System.Drawing.Point(59, 81);
            this.radioButtonFarmacia.Margin = new System.Windows.Forms.Padding(1);
            this.radioButtonFarmacia.Name = "radioButtonFarmacia";
            this.radioButtonFarmacia.Size = new System.Drawing.Size(93, 17);
            this.radioButtonFarmacia.TabIndex = 16;
            this.radioButtonFarmacia.TabStop = true;
            this.radioButtonFarmacia.Text = "Bono farmacia";
            this.radioButtonFarmacia.UseVisualStyleBackColor = true;
            this.radioButtonFarmacia.CheckedChanged += new System.EventHandler(this.radioButtonFarmacia_CheckedChanged);
            // 
            // radioButtonAtencion
            // 
            this.radioButtonAtencion.AutoSize = true;
            this.radioButtonAtencion.Location = new System.Drawing.Point(59, 100);
            this.radioButtonAtencion.Margin = new System.Windows.Forms.Padding(1);
            this.radioButtonAtencion.Name = "radioButtonAtencion";
            this.radioButtonAtencion.Size = new System.Drawing.Size(95, 17);
            this.radioButtonAtencion.TabIndex = 17;
            this.radioButtonAtencion.TabStop = true;
            this.radioButtonAtencion.Text = "Bono Atencion";
            this.radioButtonAtencion.UseVisualStyleBackColor = true;
            this.radioButtonAtencion.CheckedChanged += new System.EventHandler(this.radioButtonAtencion_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.precioFarmaciaLabel);
            this.groupBox1.Controls.Add(this.precioAtencionLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxPrecio);
            this.groupBox1.Location = new System.Drawing.Point(302, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 115);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Precios";
            // 
            // CompraBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 253);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioButtonAtencion);
            this.Controls.Add(this.radioButtonFarmacia);
            this.Controls.Add(this.idPlanMedicoLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownCantidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonComprar);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "CompraBono";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCantidad)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonComprar;
        private System.Windows.Forms.TextBox textBoxPrecio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownCantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label idPlanMedicoLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label precioFarmaciaLabel;
        private System.Windows.Forms.Label precioAtencionLabel;
        private System.Windows.Forms.RadioButton radioButtonFarmacia;
        private System.Windows.Forms.RadioButton radioButtonAtencion;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}