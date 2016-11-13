namespace ClinicaFrba.Listados
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
            this.buttonMostrar1 = new System.Windows.Forms.Button();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.buttonMostrar1);
            this.gbFiltros.Controls.SetChildIndex(this.btnBuscar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.buttonMostrar1, 0);
            // 
            // buttonMostrar1
            // 
            this.buttonMostrar1.Location = new System.Drawing.Point(442, 27);
            this.buttonMostrar1.Name = "buttonMostrar1";
            this.buttonMostrar1.Size = new System.Drawing.Size(289, 69);
            this.buttonMostrar1.TabIndex = 2;
            this.buttonMostrar1.Text = "Mostrar Listado 1";
            this.buttonMostrar1.UseVisualStyleBackColor = true;
            this.buttonMostrar1.Click += new System.EventHandler(this.buttonMostrar1_Click);
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1635, 722);
            this.Name = "ListadoEstadistico";
            this.Text = "Form1";
            this.gbFiltros.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonMostrar1;
    }
}