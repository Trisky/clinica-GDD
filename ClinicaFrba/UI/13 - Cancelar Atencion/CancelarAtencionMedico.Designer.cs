namespace ClinicaFrba.UI._13___Cancelar_Atencion
{
    partial class CancelarAtencionMedico
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
            this.selectionDates = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLastDate = new System.Windows.Forms.TextBox();
            this.diaryDoctor = new System.Windows.Forms.MonthCalendar();
            this.txtInitDate = new System.Windows.Forms.TextBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.selectionDates)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectionDates
            // 
            this.selectionDates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectionDates.Location = new System.Drawing.Point(21, 19);
            this.selectionDates.Name = "selectionDates";
            this.selectionDates.Size = new System.Drawing.Size(403, 205);
            this.selectionDates.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtLastDate);
            this.groupBox1.Controls.Add(this.diaryDoctor);
            this.groupBox1.Controls.Add(this.txtInitDate);
            this.groupBox1.Controls.Add(this.selectionDates);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 244);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione el dia o los dias que desea cancelar turnos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Desde";
            // 
            // txtLastDate
            // 
            this.txtLastDate.Location = new System.Drawing.Point(290, 185);
            this.txtLastDate.Name = "txtLastDate";
            this.txtLastDate.Size = new System.Drawing.Size(127, 20);
            this.txtLastDate.TabIndex = 3;
            // 
            // diaryDoctor
            // 
            this.diaryDoctor.Location = new System.Drawing.Point(51, 43);
            this.diaryDoctor.MaxSelectionCount = 30;
            this.diaryDoctor.Name = "diaryDoctor";
            this.diaryDoctor.TabIndex = 1;
            this.diaryDoctor.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.diaryDoctor_DateChanged);
            this.diaryDoctor.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.diaryDoctor_DateSelected);
            // 
            // txtInitDate
            // 
            this.txtInitDate.Location = new System.Drawing.Point(290, 115);
            this.txtInitDate.Name = "txtInitDate";
            this.txtInitDate.Size = new System.Drawing.Size(127, 20);
            this.txtInitDate.TabIndex = 2;
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(6, 19);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(418, 20);
            this.txtReason.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtReason);
            this.groupBox2.Location = new System.Drawing.Point(15, 262);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 59);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Indique el motivo de la cancelacion";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(36, 362);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(147, 23);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Aceptar";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(287, 362);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(152, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // CancelarAtencionMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 405);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CancelarAtencionMedico";
            this.Text = "CancelarAtencionMedico";
            this.Load += new System.EventHandler(this.CancelarAtencionMedico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.selectionDates)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView selectionDates;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLastDate;
        private System.Windows.Forms.MonthCalendar diaryDoctor;
        private System.Windows.Forms.TextBox txtInitDate;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}