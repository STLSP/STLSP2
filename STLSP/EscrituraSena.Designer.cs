namespace STLSP
{
    partial class EscrituraSena
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
            this.CBCategoria = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGIFT = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.txtSena = new System.Windows.Forms.TextBox();
            this.lblIdSena = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CBCategoria
            // 
            this.CBCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBCategoria.FormattingEnabled = true;
            this.CBCategoria.Location = new System.Drawing.Point(139, 216);
            this.CBCategoria.Name = "CBCategoria";
            this.CBCategoria.Size = new System.Drawing.Size(152, 21);
            this.CBCategoria.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 66;
            this.label3.Text = "Categoria:";
            // 
            // btnGIFT
            // 
            this.btnGIFT.Location = new System.Drawing.Point(364, 42);
            this.btnGIFT.Name = "btnGIFT";
            this.btnGIFT.Size = new System.Drawing.Size(75, 23);
            this.btnGIFT.TabIndex = 65;
            this.btnGIFT.Text = "...";
            this.btnGIFT.UseVisualStyleBackColor = true;
            this.btnGIFT.Click += new System.EventHandler(this.btnGIFT_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(364, 257);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(248, 20);
            this.txtRuta.TabIndex = 64;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(364, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 162);
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(139, 88);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(152, 105);
            this.txtDescripcion.TabIndex = 62;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(550, 292);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 61;
            this.btnVolver.Text = "VOLVER";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Descripcion:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Nombre de Gift: ";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(61, 292);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 58;
            this.btnActualizar.Text = "ACTUALIZA";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // txtSena
            // 
            this.txtSena.Location = new System.Drawing.Point(139, 42);
            this.txtSena.Name = "txtSena";
            this.txtSena.Size = new System.Drawing.Size(152, 20);
            this.txtSena.TabIndex = 57;
            // 
            // lblIdSena
            // 
            this.lblIdSena.AutoSize = true;
            this.lblIdSena.Location = new System.Drawing.Point(601, 25);
            this.lblIdSena.Name = "lblIdSena";
            this.lblIdSena.Size = new System.Drawing.Size(0, 13);
            this.lblIdSena.TabIndex = 68;
            // 
            // EscrituraSena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 368);
            this.Controls.Add(this.lblIdSena);
            this.Controls.Add(this.CBCategoria);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGIFT);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.txtSena);
            this.Name = "EscrituraSena";
            this.Text = "EscrituraSena";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGIFT;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.TextBox txtSena;
        private System.Windows.Forms.Label lblIdSena;
    }
}