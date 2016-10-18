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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonComprar
            // 
            this.buttonComprar.Location = new System.Drawing.Point(77, 204);
            this.buttonComprar.Name = "buttonComprar";
            this.buttonComprar.Size = new System.Drawing.Size(295, 56);
            this.buttonComprar.TabIndex = 1;
            this.buttonComprar.Text = "Comprar";
            this.buttonComprar.UseVisualStyleBackColor = true;
            // 
            // textBoxPrecio
            // 
            this.textBoxPrecio.Location = new System.Drawing.Point(198, 141);
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
            this.label2.Location = new System.Drawing.Point(77, 141);
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
            // 
            // CompraBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 380);
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
    }
}