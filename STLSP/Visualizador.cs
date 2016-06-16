using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace STLSP
{
    public partial class Visualizador : Form
    {
        string usu = string.Empty;
        public Visualizador(string IMGnom, string usuario)
        {
            InitializeComponent();
            usu = usuario;
            if(IMGnom == null)
            {
                MessageBox.Show("Esta seña no tiene un gif asignado.");
            }
            else
            {
                pictureBox1.Image = System.Drawing.Image.FromFile("C:\\Users\\Usuario\\Desktop\\Progra STLSP\\STLSP\\STLSP\\Imagenes\\" + IMGnom + ".gif");
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Gestionar_Señas GS = new Gestionar_Señas(usu);
            GS.Show();
            this.Close();
        }
    }
}
