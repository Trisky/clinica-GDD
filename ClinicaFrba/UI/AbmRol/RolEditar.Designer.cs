namespace ClinicaFrba.UI.AbmRol
{
    partial class RolEditar
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.checkBoxInhabilitar = new System.Windows.Forms.CheckBox();
            this.checkBoxAdmin = new System.Windows.Forms.CheckBox();
            this.gcAccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // gcAccion
            // 
            this.gcAccion.Location = new System.Drawing.Point(12, 291);
            this.gcAccion.Size = new System.Drawing.Size(510, 84);
            this.gcAccion.Enter += new System.EventHandler(this.gcAccion_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Funcionalidades:";
            // 
            // checkedListFuncionalidades
            // 
            this.checkedListFuncionalidades.FormattingEnabled = true;
            this.checkedListFuncionalidades.Location = new System.Drawing.Point(130, 79);
            this.checkedListFuncionalidades.Name = "checkedListFuncionalidades";
            this.checkedListFuncionalidades.Size = new System.Drawing.Size(385, 154);
            this.checkedListFuncionalidades.TabIndex = 7;
            this.checkedListFuncionalidades.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(130, 25);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(385, 20);
            this.textBoxNombre.TabIndex = 8;
            this.textBoxNombre.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // checkBoxInhabilitar
            // 
            this.checkBoxInhabilitar.AutoSize = true;
            this.checkBoxInhabilitar.Location = new System.Drawing.Point(130, 240);
            this.checkBoxInhabilitar.Name = "checkBoxInhabilitar";
            this.checkBoxInhabilitar.Size = new System.Drawing.Size(71, 17);
            this.checkBoxInhabilitar.TabIndex = 9;
            this.checkBoxInhabilitar.Text = "Inhabilitar";
            this.checkBoxInhabilitar.UseVisualStyleBackColor = true;
            this.checkBoxInhabilitar.CheckedChanged += new System.EventHandler(this.checkBoxInhabilitar_CheckedChanged);
            // 
            // checkBoxAdmin
            // 
            this.checkBoxAdmin.AutoSize = true;
            this.checkBoxAdmin.Location = new System.Drawing.Point(416, 240);
            this.checkBoxAdmin.Name = "checkBoxAdmin";
            this.checkBoxAdmin.Size = new System.Drawing.Size(89, 17);
            this.checkBoxAdmin.TabIndex = 10;
            this.checkBoxAdmin.Text = "Administrador";
            this.checkBoxAdmin.UseVisualStyleBackColor = true;
            this.checkBoxAdmin.CheckedChanged += new System.EventHandler(this.checkBoxAdmin_CheckedChanged);
            // 
            // RolEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 380);
            this.Controls.Add(this.checkBoxAdmin);
            this.Controls.Add(this.checkBoxInhabilitar);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.checkedListFuncionalidades);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RolEditar";
            this.Text = "RolEditar";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.checkedListFuncionalidades, 0);
            this.Controls.SetChildIndex(this.textBoxNombre, 0);
            this.Controls.SetChildIndex(this.checkBoxInhabilitar, 0);
            this.Controls.SetChildIndex(this.checkBoxAdmin, 0);
            this.Controls.SetChildIndex(this.gcAccion, 0);
            this.gcAccion.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListFuncionalidades;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.CheckBox checkBoxInhabilitar;
        private System.Windows.Forms.CheckBox checkBoxAdmin;
    }
}