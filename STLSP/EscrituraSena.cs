using Dominio;
using Negocio;
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
    public partial class EscrituraSena : Form
    {
        T_Señas objSenas;
        SenasNeg objSenasNeg;
        string usu = string.Empty;
        public EscrituraSena(int idSena, string usuario)
        {
            InitializeComponent();
            usu = usuario;
            objSenas = new T_Señas();
            objSenasNeg = new SenasNeg();
            lblIdSena.Text = "" + idSena;
            objSenas.idSeñas = int.Parse(lblIdSena.Text);
            objSenasNeg.LeerSenasDatos(objSenas);
            cargarSena();
            cargarCategoria();
            lblIdSena.Visible = false;
            txtRuta.Visible = false;
        }

        private void cargarCategoria()
        {
            DataSet dsTipoCategoria = objSenasNeg.LeerCategoriaSenas();
            CBCategoria.DataSource = dsTipoCategoria.Tables[0];
            CBCategoria.DisplayMember = "nombre";
            CBCategoria.ValueMember = "idCategoriaSeñas";
        }

        private void btnGIFT_Click(object sender, EventArgs e)
        {
            txtRuta.Text = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "gif (*.gif)|*.gif";

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                txtRuta.Text = "C:\\Users\\Usuario\\Desktop\\Progra STLSP\\STLSP\\STLSP\\Imagenes\\" + txtSena.Text + ".gif";
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            objSenasNeg.ObtencionId(objSenas);
            if (MessageBox.Show("Estas seguro que desea actualizar?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                objSenas.nombre = txtSena.Text;
                objSenas.descripcion = txtDescripcion.Text;
                objSenas.gift = txtRuta.Text;
                objSenas.idCategoriaSeñas = (Int32)CBCategoria.SelectedValue;
                if (pictureBox1.Image != null) { objSenas.estado = "Validado"; }
                else { objSenas.estado = "No Validado"; }
                objSenasNeg.ActualizarSenas(objSenas);
                if (objSenas.state == 99)
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    //System.IO.File.Delete("C:\\Users\\Usuario\\Desktop\\Progra STLSP\\STLSP\\STLSP\\Imagenes\\" + txtSena.Text + ".gif");
                    MessageBox.Show("Seña actualizada con exito");
                    pictureBox1.Image.Save("C:\\Users\\Usuario\\Desktop\\Progra STLSP\\STLSP\\STLSP\\Imagenes\\" + txtSena.Text + ".gif");
                }
                else if (objSenas.state == 1)
                {
                    MessageBox.Show("Este nombre de sena ya existe");
                }
                else if (objSenas.state == 3)
                {
                    MessageBox.Show("Debe llenar los campos vacios");
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Gestionar_Señas GS = new Gestionar_Señas(usu);
            GS.refrescar();
            GS.Show();
            this.Close();
        }

        private void cargarSena()
        {
            txtSena.Text = objSenas.nombre;
            txtDescripcion.Text = objSenas.descripcion;
            txtRuta.Text = objSenas.gift;
            if (txtRuta.Text != string.Empty)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile("C:\\Users\\Usuario\\Desktop\\Progra STLSP\\STLSP\\STLSP\\Imagenes\\" + txtSena.Text + ".gif");
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pictureBox1.Image = null;
                pictureBox1.SizeMode = 0;
            }
        }
    }
}
