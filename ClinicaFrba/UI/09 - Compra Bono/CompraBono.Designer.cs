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
            this.buttonComprar.Location = new System.Drawing.Point(63, 228);
            this.buttonComprar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonComprar.Name = "buttonComprar";
            this.buttonComprar.Size = new System.Drawing.Size(241, 47);
            this.buttonComprar.TabIndex = 1;
            this.buttonComprar.Text = "Comprar";
            this.buttonComprar.UseVisualStyleBackColor = true;
            this.buttonComprar.Click += new System.EventHandler(this.buttonComprar_Click);
            // 
            // textBoxPrecio
            // 
            this.textBoxPrecio.Location = new System.Drawing.Point(579, 31);
            this.textBoxPrecio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPrecio.Name = "textBoxPrecio";
            this.textBoxPrecio.Size = new System.Drawing.Size(146, 26);
            this.textBoxPrecio.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cantidad";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(606, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Precio total";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(84, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Compra de bonos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 294);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(301, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Estas Comprando para el grupo familiar #";
            // 
            // labelGrupoFamiliar
            // 
            this.labelGrupoFamiliar.AutoSize = true;
            this.labelGrupoFamiliar.Location = new System.Drawing.Point(309, 294);
            this.labelGrupoFamiliar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGrupoFamiliar.Name = "labelGrupoFamiliar";
            this.labelGrupoFamiliar.Size = new System.Drawing.Size(80, 20);
            this.labelGrupoFamiliar.TabIndex = 8;
            this.labelGrupoFamiliar.Text = "NUMERO";
            // 
            // numericUpDownCantidad
            // 
            this.numericUpDownCantidad.Location = new System.Drawing.Point(162, 74);
            this.numericUpDownCantidad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownCantidad.Name = "numericUpDownCantidad";
            this.numericUpDownCantidad.Size = new System.Drawing.Size(142, 26);
            this.numericUpDownCantidad.TabIndex = 9;
            this.numericUpDownCantidad.ValueChanged += new System.EventHandler(this.numericUpDownCantidad_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 347);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "id planMedico";
            // 
            // idPlanMedicoLabel
            // 
            this.idPlanMedicoLabel.AutoSize = true;
            this.idPlanMedicoLabel.Location = new System.Drawing.Point(151, 346);
            this.idPlanMedicoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.idPlanMedicoLabel.Name = "idPlanMedicoLabel";
            this.idPlanMedicoLabel.Size = new System.Drawing.Size(51, 20);
            this.idPlanMedicoLabel.TabIndex = 11;
            this.idPlanMedicoLabel.Text = "label6";
            this.idPlanMedicoLabel.Click += new System.EventHandler(this.idPlanMedicoLabel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(467, 294);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "precio bono farmacia";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(471, 329);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "precio bono atencion";
            // 
            // precioFarmaciaLabel
            // 
            this.precioFarmaciaLabel.AutoSize = true;
            this.precioFarmaciaLabel.Location = new System.Drawing.Point(646, 294);
            this.precioFarmaciaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.precioFarmaciaLabel.Name = "precioFarmaciaLabel";
            this.precioFarmaciaLabel.Size = new System.Drawing.Size(59, 20);
            this.precioFarmaciaLabel.TabIndex = 14;
            this.precioFarmaciaLabel.Text = "p_farm";
            // 
            // precioAtencionLabel
            // 
            this.precioAtencionLabel.AutoSize = true;
            this.precioAtencionLabel.Location = new System.Drawing.Point(635, 329);
            this.precioAtencionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.precioAtencionLabel.Name = "precioAtencionLabel";
            this.precioAtencionLabel.Size = new System.Drawing.Size(59, 20);
            this.precioAtencionLabel.TabIndex = 15;
            this.precioAtencionLabel.Text = "p_aten";
            // 
            // radioButtonFarmacia
            // 
            this.radioButtonFarmacia.AutoSize = true;
            this.radioButtonFarmacia.Location = new System.Drawing.Point(89, 124);
            this.radioButtonFarmacia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonFarmacia.Name = "radioButtonFarmacia";
            this.radioButtonFarmacia.Size = new System.Drawing.Size(137, 24);
            this.radioButtonFarmacia.TabIndex = 16;
            this.radioButtonFarmacia.TabStop = true;
            this.radioButtonFarmacia.Text = "Bono farmacia";
            this.radioButtonFarmacia.UseVisualStyleBackColor = true;
            this.radioButtonFarmacia.CheckedChanged += new System.EventHandler(this.radioButtonFarmacia_CheckedChanged);
            // 
            // radioButtonAtencion
            // 
            this.radioButtonAtencion.AutoSize = true;
            this.radioButtonAtencion.Location = new System.Drawing.Point(89, 154);
            this.radioButtonAtencion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonAtencion.Name = "radioButtonAtencion";
            this.radioButtonAtencion.Size = new System.Drawing.Size(139, 24);
            this.radioButtonAtencion.TabIndex = 17;
            this.radioButtonAtencion.TabStop = true;
            this.radioButtonAtencion.Text = "Bono Atencion";
            this.radioButtonAtencion.UseVisualStyleBackColor = true;
            this.radioButtonAtencion.CheckedChanged += new System.EventHandler(this.radioButtonAtencion_CheckedChanged);
            // 
            // CompraBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 390);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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