namespace ClinicaFrba.UI._13___Cancelar_Atencion
{
    partial class CancelarAtencionAfiliado
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
            this.turnosActivos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSelectedTurn = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.turnosActivos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // turnosActivos
            // 
            this.turnosActivos.AllowUserToAddRows = false;
            this.turnosActivos.AllowUserToDeleteRows = false;
            this.turnosActivos.AllowUserToResizeColumns = false;
            this.turnosActivos.AllowUserToResizeRows = false;
            this.turnosActivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.turnosActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.turnosActivos.Location = new System.Drawing.Point(6, 19);
            this.turnosActivos.Name = "turnosActivos";
            this.turnosActivos.RowHeadersVisible = false;
            this.turnosActivos.Size = new System.Drawing.Size(577, 127);
            this.turnosActivos.TabIndex = 0;
            this.turnosActivos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.turnosActivos_CellClick);
            this.turnosActivos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.turnosActivos_RowEnter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.turnosActivos);
            this.groupBox1.Controls.Add(this.txtSelectedTurn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 178);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione el turno que desea cancelar";
            // 
            // txtSelectedTurn
            // 
            this.txtSelectedTurn.Location = new System.Drawing.Point(6, 152);
            this.txtSelectedTurn.Name = "txtSelectedTurn";
            this.txtSelectedTurn.Size = new System.Drawing.Size(577, 20);
            this.txtSelectedTurn.TabIndex = 2;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(125, 255);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(158, 59);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(561, 302);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hay que usar la clase que tiene el 2, no esta salame";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtReason);
            this.groupBox2.Location = new System.Drawing.Point(12, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(589, 53);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Por favor introduzca el motivo de la cancelacion";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(6, 19);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(577, 20);
            this.txtReason.TabIndex = 0;
            this.txtReason.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // CancelarAtencionAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 324);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.groupBox1);
            this.Name = "CancelarAtencionAfiliado";
            this.Text = "CancelarAtencionAfiliado";
            this.Load += new System.EventHandler(this.CancelarAtencionAfiliado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.turnosActivos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView turnosActivos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSelectedTurn;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtReason;
    }
}