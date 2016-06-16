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
    public partial class Diccionario_LSP : Form
    {
        string usu = string.Empty;
        public Diccionario_LSP(string usuario)
        {
            InitializeComponent();
            lblNombreUsuario.Text = usuario;
            usu = usuario;
        }

        private void btn_GestionarUsuarios_Click(object sender, EventArgs e)
        {
            Gestionar_Usuarios GU = new Gestionar_Usuarios(usu);
            GU.Show();
            this.Hide();
        }

        private void btn_GestionarCategorias_Click(object sender, EventArgs e)
        {
            Gestionar_Categorias GC = new Gestionar_Categorias(usu);
            GC.Show();
            this.Hide();
        }

        private void btn_GestionarSeñas_Click(object sender, EventArgs e)
        {
            Gestionar_Señas GS = new Gestionar_Señas(usu);
            GS.Show();
            this.Hide();
        }

        private void btn_TraductorLSP_Click(object sender, EventArgs e)
        {
            Traductor_LSP TTLS = new Traductor_LSP(usu);
            TTLS.Show();
            this.Hide();
        }

        private void btn_DiccionarioLSP_Click(object sender, EventArgs e)
        {
            //Diccionario_LSP DTLS = new Diccionario_LSP();
            //DTLS.Show();
        }

        private void btn_ReconocimientoDeMovimientos_Click(object sender, EventArgs e)
        {
            Reconocimiento_de_Movimientos RM = new Reconocimiento_de_Movimientos(usu);
            RM.Show();
            this.Hide();
        }

        private void btn_ConversionTextoAAudio_Click(object sender, EventArgs e)
        {
            Conversión_de_Texto_a_Audio CTAA = new Conversión_de_Texto_a_Audio(usu);
            CTAA.Show();
            this.Hide();
        }

        private void btn_GestionarWorkflow_Click(object sender, EventArgs e)
        {
            Gestionar_Workflow GW = new Gestionar_Workflow(usu);
            GW.Show();
            this.Hide();
        }

        private void btn_EjecutarWorkflow_Click(object sender, EventArgs e)
        {
            Ejecutar_Workflow EW = new Ejecutar_Workflow(usu);
            EW.Show();
            this.Hide();
        }


    }
}
