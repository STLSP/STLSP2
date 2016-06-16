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
    public partial class IngresarUsuario : Form
    {
        Usuario objUsuario = new Usuario();
        UsuarioNeg objUsuarioNeg = new UsuarioNeg();
        string usu = string.Empty;
        public IngresarUsuario(int idUsu, string usuario)
        {
            InitializeComponent();
            usu = usuario;
            lblIdUsuario.Text = "" + idUsu;
            objUsuario.IdUsuario = int.Parse(lblIdUsuario.Text);
            objUsuarioNeg.LeerUsuarioDatos(objUsuario);
            cargarPerfiles();
            lblIdUsuario.Visible = false;
        }


        private void cargarPerfiles()
        {
            UsuarioNeg objUsuarioNeg = new UsuarioNeg();
            DataSet dsTipoPerfiles = objUsuarioNeg.LeerPerfiles();
            CBPerfil.DataSource = dsTipoPerfiles.Tables[0];
            CBPerfil.DisplayMember = "nombre";
            CBPerfil.ValueMember = "idPerfil";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            objUsuarioNeg.ObtencionId(objUsuario);
            objUsuario = new Usuario();
            objUsuario.NombreUsuario = Regex.Replace(txtUsuario.Text, @"\s+", "");
            objUsuario.Contraseña = Regex.Replace(txtContrasena.Text, @"\s+", "");
            objUsuario.Email = txtEmail.Text;
            objUsuario.IdPerfil = (Int32)CBPerfil.SelectedValue;
            objUsuarioNeg.RegistrarUsuario(objUsuario);
            if (objUsuario.Estado == 99)
            {
                MessageBox.Show("Usuario creado con exito");
            }
            if (objUsuario.Estado == 1)
            {
                MessageBox.Show("Este nombre de usuario ya existe");
            }
            if (objUsuario.Estado == 2)
            {
                MessageBox.Show("Necesita ingresar un Email");
            }
            if (objUsuario.Estado == 3)
            {
                MessageBox.Show("Debe llenar los campos vacios");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Gestionar_Usuarios GU = new Gestionar_Usuarios(usu);
            GU.Show();
            GU.refrescar();
            this.Visible = false;
        }
    }
}
