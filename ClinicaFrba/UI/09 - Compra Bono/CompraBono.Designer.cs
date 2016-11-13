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
            this.label4 = new System.Windows.Forms.Label();
            this.labelGrupoFamiliar = new System.Windows.Forms.Label();
            this.numericUpDownCantidad = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.idPlanMedicoLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.precioFarmaciaLabel = new System.Windows.Forms.Label();
            this.precioAtencionLabel = new System.Windows.Forms.Label();
            this.radioButtonFarmacia = new System.Windows.Forms.RadioButton();
            this.radioButtonAtencion = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonComprar
            // 
            this.buttonComprar.Location = new System.Drawing.Point(77, 274);
            this.buttonComprar.Name = "buttonComprar";
            this.buttonComprar.Size = new System.Drawing.Size(295, 56);
            this.buttonComprar.TabIndex = 1;
            this.buttonComprar.Text = "Comprar";
            this.buttonComprar.UseVisualStyleBackColor = true;
            this.buttonComprar.Click += new System.EventHandler(this.buttonComprar_Click);
            // 
            // textBoxPrecio
            // 
            this.textBoxPrecio.Location = new System.Drawing.Point(660, 148);
            this.textBoxPrecio.Name = "textBoxPrecio";
            this.textBoxPrecio.Size = new System.Drawing.Size(177, 29);
            this.textBoxPrecio.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cantidad";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(539, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Precio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(103, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Compra de bonos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(370, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Estas Comprando para el grupo familiar #";
            // 
            // labelGrupoFamiliar
            // 
            this.labelGrupoFamiliar.AutoSize = true;
            this.labelGrupoFamiliar.Location = new System.Drawing.Point(378, 353);
            this.labelGrupoFamiliar.Name = "labelGrupoFamiliar";
            this.labelGrupoFamiliar.Size = new System.Drawing.Size(99, 25);
            this.labelGrupoFamiliar.TabIndex = 8;
            this.labelGrupoFamiliar.Text = "NUMERO";
            // 
            // numericUpDownCantidad
            // 
            this.numericUpDownCantidad.Location = new System.Drawing.Point(198, 89);
            this.numericUpDownCantidad.Name = "numericUpDownCantidad";
            this.numericUpDownCantidad.Size = new System.Drawing.Size(174, 29);
            this.numericUpDownCantidad.TabIndex = 9;
            this.numericUpDownCantidad.ValueChanged += new System.EventHandler(this.numericUpDownCantidad_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 416);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "id planMedico";
            // 
            // idPlanMedicoLabel
            // 
            this.idPlanMedicoLabel.AutoSize = true;
            this.idPlanMedicoLabel.Location = new System.Drawing.Point(184, 415);
            this.idPlanMedicoLabel.Name = "idPlanMedicoLabel";
            this.idPlanMedicoLabel.Size = new System.Drawing.Size(64, 25);
            this.idPlanMedicoLabel.TabIndex = 11;
            this.idPlanMedicoLabel.Text = "label6";
            this.idPlanMedicoLabel.Click += new System.EventHandler(this.idPlanMedicoLabel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(571, 353);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(193, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "precio bono farmacia";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(576, 395);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(193, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "precio bono atencion";
            // 
            // precioFarmaciaLabel
            // 
            this.precioFarmaciaLabel.AutoSize = true;
            this.precioFarmaciaLabel.Location = new System.Drawing.Point(790, 353);
            this.precioFarmaciaLabel.Name = "precioFarmaciaLabel";
            this.precioFarmaciaLabel.Size = new System.Drawing.Size(72, 25);
            this.precioFarmaciaLabel.TabIndex = 14;
            this.precioFarmaciaLabel.Text = "p_farm";
            // 
            // precioAtencionLabel
            // 
            this.precioAtencionLabel.AutoSize = true;
            this.precioAtencionLabel.Location = new System.Drawing.Point(776, 395);
            this.precioAtencionLabel.Name = "precioAtencionLabel";
            this.precioAtencionLabel.Size = new System.Drawing.Size(72, 25);
            this.precioAtencionLabel.TabIndex = 15;
            this.precioAtencionLabel.Text = "p_aten";
            // 
            // radioButtonFarmacia
            // 
            this.radioButtonFarmacia.AutoSize = true;
            this.radioButtonFarmacia.Location = new System.Drawing.Point(109, 149);
            this.radioButtonFarmacia.Name = "radioButtonFarmacia";
            this.radioButtonFarmacia.Size = new System.Drawing.Size(162, 29);
            this.radioButtonFarmacia.TabIndex = 16;
            this.radioButtonFarmacia.TabStop = true;
            this.radioButtonFarmacia.Text = "Bono farmacia";
            this.radioButtonFarmacia.UseVisualStyleBackColor = true;
            this.radioButtonFarmacia.CheckedChanged += new System.EventHandler(this.radioButtonFarmacia_CheckedChanged);
            // 
            // radioButtonAtencion
            // 
            this.radioButtonAtencion.AutoSize = true;
            this.radioButtonAtencion.Location = new System.Drawing.Point(109, 185);
            this.radioButtonAtencion.Name = "radioButtonAtencion";
            this.radioButtonAtencion.Size = new System.Drawing.Size(165, 29);
            this.radioButtonAtencion.TabIndex = 17;
            this.radioButtonAtencion.TabStop = true;
            this.radioButtonAtencion.Text = "Bono Atencion";
            this.radioButtonAtencion.UseVisualStyleBackColor = true;
            // 
            // CompraBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 468);
            this.Controls.Add(this.radioButtonAtencion);
            this.Controls.Add(this.radioButtonFarmacia);
            this.Controls.Add(this.precioAtencionLabel);
            this.Controls.Add(this.precioFarmaciaLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.idPlanMedicoLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownCantidad);
            this.Controls.Add(this.labelGrupoFamiliar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPrecio);
            this.Controls.Add(this.buttonComprar);
            this.Name = "CompraBono";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonComprar;
        private System.Windows.Forms.TextBox textBoxPrecio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelGrupoFamiliar;
        private System.Windows.Forms.NumericUpDown numericUpDownCantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label idPlanMedicoLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label precioFarmaciaLabel;
        private System.Windows.Forms.Label precioAtencionLabel;
        private System.Windows.Forms.RadioButton radioButtonFarmacia;
        private System.Windows.Forms.RadioButton radioButtonAtencion;
    }
}