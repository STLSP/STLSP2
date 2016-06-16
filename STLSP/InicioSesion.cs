using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using Negocio;
using System.Text.RegularExpressions;

namespace STLSP
{
    public partial class Form1 : Form
    {
        int inco = 0;
        int errormax = 3;
        int inten;
        Usuario objUsuario;
        UsuarioNeg objUsuarioNeg;
        public Form1()
        {
            InitializeComponent();
            objUsuarioNeg = new UsuarioNeg();
        }

        public void pictureBox2_Click(object sender, EventArgs e)
        {
            objUsuario = new Usuario();
            objUsuario.NombreUsuario = Regex.Replace(textBox1.Text, @"\s+", "");
            objUsuario.Contraseña = Regex.Replace(textBox2.Text, @"\s+", "");
            objUsuarioNeg.VerificarUsuario(objUsuario);

            if (objUsuario.Estado == 99)
            {
                String usu = textBox1.Text;
                CambiarContrasena cambcontra = new CambiarContrasena(usu);
                Menu_Principal obj = new Menu_Principal(usu);
                //CambiarContrasena CC = new CambiarContrasena(usu);
            }
            else
            {
                inco++;
                inten = errormax - inco;
                MessageBox.Show("Usuario o Contrasena INCORRECTOS!, Usted todavia tiene " + inten + " intentos para poder ingresar");

                if (inco == 3)
                {
                    this.Close();
                }
            }
        }
        public void ejecutar(string dato)
        {
            textBox1.Text = dato;
        }
    }
}
