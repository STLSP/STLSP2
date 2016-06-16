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
using System.Text.RegularExpressions;

namespace STLSP
{
    public partial class EscrituraUsuarios : Form
    {
        Usuario objUsuario;
        UsuarioNeg objUsuarioNeg;
        string usu = string.Empty;
        public EscrituraUsuarios(int idUsu, string usuario)
        {
            InitializeComponent();
            objUsuario = new Usuario();
            objUsuarioNeg = new UsuarioNeg();
            lblIdUsuario.Text = "" + idUsu;
            objUsuario.IdUsuario = int.Parse(lblIdUsuario.Text);
            objUsuarioNeg.LeerUsuarioDatos(objUsuario);
            cargarUsuario();
            cargarPerfiles();
            lblIdUsuario.Visible = false;
        }

        private void cargarPerfiles()
        {
            DataSet dsTipoPerfiles = objUsuarioNeg.LeerPerfiles();
            comboBox1.DataSource = dsTipoPerfiles.Tables[0];
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "idPerfil";
        }

        private void cargarUsuario()
        {
            txtUsuario.Text = objUsuario.NombreUsuario;
            txtContrasena.Text = objUsuario.Contraseña;
            txtEmail.Text = objUsuario.Email;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desea actualizar?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                objUsuarioNeg.ObtencionId(objUsuario);
                objUsuario.NombreUsuario = Regex.Replace(txtUsuario.Text, @"\s+", "");
                objUsuario.Contraseña = Regex.Replace(txtContrasena.Text, @"\s+", "");
                objUsuario.Email = txtEmail.Text;
                objUsuario.IdPerfil = (Int32)comboBox1.SelectedValue;
                objUsuarioNeg.ActualizarUsuario(objUsuario);
                if (objUsuario.Estado == 99)
                {
                    MessageBox.Show("Usuario actualizado con exito");
                }
                if (objUsuario.Estado == 1)
                {
                    MessageBox.Show("Este nombre de usuario ya existe");
                }
                if (objUsuario.Estado == 2)
                {
                    MessageBox.Show("Necesita ingresar un Email");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gestionar_Usuarios obj = new Gestionar_Usuarios(usu);
            obj.refrescar();
            obj.Show();
            this.Visible = false;
        }

        private void EscrituraUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            Gestionar_Usuarios GU = new Gestionar_Usuarios(usu);
        }
    }
}
