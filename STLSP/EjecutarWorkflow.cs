using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Speech.Recognition;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
using System.Windows.Input;
using Negocio;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

namespace STLSP
{
    public partial class Ejecutar_Workflow : Form
    {
        SpeechRecognitionEngine escucha = new SpeechRecognitionEngine();
        string usu = string.Empty;


        string[] buscadores = { "Hola", "vuelto", " Bienvenido", " cómo estas", "su", "Gracias", "soles", "cinco", "Vuelva pronto" };
        string[] grupos = { "Libido", "La ley", "Amen", "Sin bandera" };
        string[] terminos = { "en vivo", "en concierto", "solo letras", "solo mp3" };


        public Ejecutar_Workflow(string usuario)
        {
            InitializeComponent();
            lblNombreUsuario.Text = usuario;
            usu = usuario;
            LlenaCategoria();
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
            Diccionario_LSP DTLS = new Diccionario_LSP(usu);
            DTLS.Show();
            this.Hide();
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
            //Ejecutar_Workflow EW = new Ejecutar_Workflow();
            //EW.Show();
        }

        private void btnEscuchar_Click(object sender, EventArgs e)
        {
            try {
                escucha.SetInputToDefaultAudioDevice();
                Grammar gramatica = new Grammar(new GrammarBuilder("Me gustaria pagar en efectivo."));
                escucha.LoadGrammar(gramatica);
                escucha.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Reconocedor);
                escucha.RecognizeAsync(RecognizeMode.Multiple);
                escucha.AudioLevelUpdated += Nivel_Audio;
            }
            catch (InvalidOperationException){
                MessageBox.Show("Micrófono en uso.");
            }
        }

        void construirGramatica()
        {
            GrammarBuilder frases = new GrammarBuilder("buscar"); // empezamos la frase con la palabra buscar
            frases.Append(new Choices(grupos));// primero anñadimos los grupos
            frases.Append(new Choices(terminos));// segundo añadimos los terminos de busqueda
            frases.Append(new Choices(buscadores));// por ultimo añadimos los buscadores
            escucha.LoadGrammar(new Grammar(frases)); // cargamos nuestras gramaticas al lexico
        }

        public void Reconocedor(object sender, SpeechRecognizedEventArgs e)
        {
            foreach (RecognizedWordUnit palabra in e.Result.Words)
            {
                tbTextoCliente.Text += palabra.Text + "  ";
            }
        }

        public void Nivel_Audio(object sender, AudioLevelUpdatedEventArgs e)
        {
            int audio = e.AudioLevel;
            pbAudioCliente.Value = audio;            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tbTextoCliente.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
        private void LlenaCategoria()
        {
            CategoriaNeg blL = new CategoriaNeg();
            DataSet dscait = blL.ListarCategorias();

            DataRow unitem = dscait.Tables["cait"].NewRow();
            dscait.Tables["cait"].Rows.InsertAt(unitem, 0);
            unitem["idCategoria"] = "0";
            unitem["nombre"] = "Seleccionar..";

            cbCategoriaF.DataSource = dscait.Tables["cait"];
            cbCategoriaF.DisplayMember = "nombre";
            cbCategoriaF.ValueMember = "idCategoria";
        }
    }
}
