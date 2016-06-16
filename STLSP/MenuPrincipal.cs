using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;
using System.Threading;

namespace STLSP
{
    public partial class Menu_Principal : Form
    {
        Usuario objUsuario;
        UsuarioNeg objUsuarioNeg;
        int idPerfil;
        string usuario;

        public Menu_Principal(string usu)
        {
            InitializeComponent();
            usuario = usu;
            this.Show();
            capturarIdPerfil();
            lblNombreUsuario.Text = usu;
            label1.Text = "" + idPerfil;
            if (idPerfil == 1)
            {//administrador
                //nada
            }
            if (idPerfil == 2)
            {  //Usuario
                btn_GestionarUsuarios.Enabled = false;
                btn_GestionarCategorias.Enabled = false;
            }
            if (idPerfil == 3)
            {
                //Recepecionista
                btn_GestionarSeñas.Enabled=false;
                btn_GestionarWorkflow.Enabled = false;
                btn_TraductorLSP.Enabled = false;
                btn_ReconocimientoDeMovimientos.Enabled = false;
                btn_EjecutarWorkflow.Enabled = false;
                btn_ConversionTextoAAudio.Enabled = false;
                btn_DiccionarioLSP.Enabled = false;
                btn_GestionarCategorias.Enabled = false;
            }
        }

        public void capturarIdPerfil()
        {
            objUsuario = new Usuario();
            objUsuarioNeg = new UsuarioNeg();
            objUsuario.NombreUsuario = usuario;
            objUsuarioNeg.LeerIdPerfil(objUsuario);
            idPerfil = objUsuario.IdPerfil;

        }

        public void btn_GestionarUsuarios_Click(object sender, EventArgs e)
        {
            Gestionar_Usuarios GU = new Gestionar_Usuarios(usuario);
            GU.Show();
            this.Hide();


        }

        private void btn_GestionarCategorias_Click(object sender, EventArgs e)
        {
            Gestionar_Categorias GC = new Gestionar_Categorias(usuario);
            GC.Show();
            this.Hide();
        }

        private void btn_GestionarSeñas_Click(object sender, EventArgs e)
        {
            Gestionar_Señas GS = new Gestionar_Señas(usuario);
            GS.Show();
            this.Hide();
        }

        private void btn_DiccionarioLSP_Click(object sender, EventArgs e)
        {
            Diccionario_LSP DTLS = new Diccionario_LSP(usuario);
            DTLS.Show();
            this.Hide();
        }

        private void btn_TraductorLSP_Click(object sender, EventArgs e)
        {
            Traductor_LSP TTLS = new Traductor_LSP(usuario);
            TTLS.Show();
            this.Hide();
        }

        private void btn_ConversionTextoAAudio_Click(object sender, EventArgs e)
        {
            Conversión_de_Texto_a_Audio CTAA = new Conversión_de_Texto_a_Audio(usuario);
            CTAA.Show();
            this.Hide();
        }

        private void btn_ReconocimientoDeMovimientos_Click(object sender, EventArgs e)
        {
            Reconocimiento_de_Movimientos RM = new Reconocimiento_de_Movimientos(usuario);
            RM.Show();
            this.Hide();
        }

        private void btn_GestionarWorkflow_Click(object sender, EventArgs e)
        {
            Gestionar_Workflow GW = new Gestionar_Workflow(usuario);
            GW.Show();
            this.Hide();
        }

        private void btn_EjecutarWorkflow_Click(object sender, EventArgs e)
        {
            Ejecutar_Workflow EW = new Ejecutar_Workflow(usuario);
            EW.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CambiarContrasena cc = new CambiarContrasena(usuario);
            cc.Show();
        }
    }
}
