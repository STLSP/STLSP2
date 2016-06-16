namespace STLSP
{
    partial class CambiarContrasena
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// sadsadasd
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnGNC = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 20;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(360, 63);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(0, 13);
            this.lblUsuario.TabIndex = 19;
            // 
            // btnGNC
            // 
            this.btnGNC.Location = new System.Drawing.Point(71, 211);
            this.btnGNC.Name = "btnGNC";
            this.btnGNC.Size = new System.Drawing.Size(243, 23);
            this.btnGNC.TabIndex = 18;
            this.btnGNC.Text = "CAMBIAR";
            this.btnGNC.UseVisualStyleBackColor = true;
            this.btnGNC.Click += new System.EventHandler(this.btnGNC_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(139, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "CAMBIAR CONTRASEÑA";
            // 
            // txtNC
            // 
            this.txtNC.Location = new System.Drawing.Point(196, 143);
            this.txtNC.Name = "txtNC";
            this.txtNC.PasswordChar = '*';
            this.txtNC.Size = new System.Drawing.Size(100, 20);
            this.txtNC.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Ingrese nueva Contrasena:";
            // 
            // CambiarContrasena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 360);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnGNC);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNC);
            this.Controls.Add(this.label4);
            this.Name = "CambiarContrasena";
            this.Text = "CambiarContrasena";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnGNC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNC;
        private System.Windows.Forms.Label label4;

    }
}