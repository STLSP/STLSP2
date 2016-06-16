using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace STLSP
{
    public partial class IngresarSena : Form
    {
        T_Señas objSena;
        SenasNeg objSenaNeg;
        string usu = string.Empty;
        public IngresarSena(string usuario)
        {
            InitializeComponent();
            objSena = new T_Señas();
            objSenaNeg = new SenasNeg();
            cargarCategoria();
            txtRuta.Visible = false;
            usu = usuario;
        }

        private void cargarCategoria()
        {
            DataSet dsTipoCategoria = objSenaNeg.LeerCategoriaSenas();
            CBCategoria.DataSource = dsTipoCategoria.Tables[0];
            CBCategoria.DisplayMember = "nombre";
            CBCategoria.ValueMember = "idCategoriaSeñas";
        }
        private void btnGIFT_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "gif (*.gif)|*.gif";

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                txtRuta.Text = "C:\\Users\\Usuario\\Desktop\\Progra STLSP\\STLSP\\Imagenes\\" + txtSena.Text + ".gif";
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save("C:\\Users\\Usuario\\Desktop\\Progra STLSP\\STLSP\\Imagenes\\" + txtSena.Text + ".gif");
            objSena.nombre = Regex.Replace(txtSena.Text, @"\s+", "");
            objSena.descripcion = txtDescripcion.Text;
            objSena.gift = txtRuta.Text;
            objSena.idCategoriaSeñas = (Int32)CBCategoria.SelectedValue;
            objSenaNeg.RegistrarSenas(objSena);
            if (objSena.state == 99)
            {
                MessageBox.Show("Seña creada con exito");
            }
            if (objSena.state == 1)
            {
                MessageBox.Show("Este nombre de sena ya existe");
            }
            if (objSena.state == 3)
            {
                MessageBox.Show("Debe llenar los campos vacios");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Gestionar_Señas GS = new Gestionar_Señas(usu);
            GS.Show();
            GS.refrescar();
            this.Visible = false;
        }
    }
}
