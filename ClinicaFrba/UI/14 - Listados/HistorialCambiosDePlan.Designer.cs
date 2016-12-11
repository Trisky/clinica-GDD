namespace ClinicaFrba.UI._14___Listados
{
    partial class HistorialCambiosDePlan
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
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Controls.Add(this.textBoxUsername);
            this.gbFiltros.Controls.SetChildIndex(this.btnBuscar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.gbFiltros.Controls.SetChildIndex(this.textBoxUsername, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label1, 0);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Visible = false;
            // 
            // btnAgregar
            // 
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
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(158, 36);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(399, 20);
            this.textBoxUsername.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ingrese un nombre de usuario o deje en blanco para listar todos los cambios de pl" +
    "an";
            // 
            // HistorialCambiosDePlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 469);
            this.Name = "HistorialCambiosDePlan";
            this.Text = "HistorialCambiosDePlan";
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label label1;
    }
}