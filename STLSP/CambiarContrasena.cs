using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace STLSP
{
    public partial class CambiarContrasena : Form
    {
        Usuario objUsuario;
        UsuarioNeg objUsuarioNeg;
        string usuario;
        public CambiarContrasena(string usu)
        {
            InitializeComponent();
            objUsuarioNeg = new UsuarioNeg();
            usuario = usu;
            capturarIdPerfil();
            label2.Text = usuario;
            label2.Visible = false;
        }

        public void capturarIdPerfil()
        {
            objUsuario = new Usuario();
            objUsuarioNeg = new UsuarioNeg();
            objUsuario.NombreUsuario = usuario;
            objUsuarioNeg.LeercontraUsuarios(objUsuario);
        }

        private void btnGNC_Click_1(object sender, EventArgs e)
        {
            objUsuario.NombreUsuario = label2.Text;
            objUsuario.Contraseña = txtNC.Text;
            objUsuarioNeg.ActualizarCC(objUsuario);
            if (objUsuario.Estado == 99)
            {
                MessageBox.Show("Contrasena cambiada con exito");
            }
            if (objUsuario.Estado == 3)
            {
                MessageBox.Show("Debe ingresar una contrasena");
            }
        }
    }
}
