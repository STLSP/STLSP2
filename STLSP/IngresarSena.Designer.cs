namespace STLSP
{
    partial class IngresarSena
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
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.txtSena = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CBCategoria
            // 
            this.CBCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBCategoria.FormattingEnabled = true;
            this.CBCategoria.Location = new System.Drawing.Point(129, 239);
            this.CBCategoria.Name = "CBCategoria";
            this.CBCategoria.Size = new System.Drawing.Size(152, 21);
            this.CBCategoria.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Categoria:";
            // 
            // btnGIFT
            // 
            this.btnGIFT.Location = new System.Drawing.Point(354, 65);
            this.btnGIFT.Name = "btnGIFT";
            this.btnGIFT.Size = new System.Drawing.Size(75, 23);
            this.btnGIFT.TabIndex = 54;
            this.btnGIFT.Text = "...";
            this.btnGIFT.UseVisualStyleBackColor = true;
            this.btnGIFT.Click += new System.EventHandler(this.btnGIFT_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(354, 280);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(248, 20);
            this.txtRuta.TabIndex = 53;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(354, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 162);
            this.pictureBox1.TabIndex = 52;
            this.pictureBox1.TabStop = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(129, 111);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(152, 105);
            this.txtDescripcion.TabIndex = 51;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(540, 315);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 50;
            this.btnVolver.Text = "VOLVER";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "INGRESAR SEÑAS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Descripcion:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Nombre de Gift: ";
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(51, 315);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(75, 23);
            this.btnIngresar.TabIndex = 46;
            this.btnIngresar.Text = "INGRESAR";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // txtSena
            // 
            this.txtSena.Location = new System.Drawing.Point(129, 65);
            this.txtSena.Name = "txtSena";
            this.txtSena.Size = new System.Drawing.Size(152, 20);
            this.txtSena.TabIndex = 45;
            // 
            // IngresarSena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 348);
            this.Controls.Add(this.CBCategoria);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGIFT);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.txtSena);
            this.Name = "IngresarSena";
            this.Text = "IngresarSena";
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.TextBox txtSena;
    }
}