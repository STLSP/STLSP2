using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace STLSP
{
    public partial class Gestionar_Workflow : Form
    {
        string usu = string.Empty;
        public Gestionar_Workflow(string usuario)
        {

            InitializeComponent();
            lblNombreUsuario.Text = usuario;
            usu = usuario;
            LlenaCategoria();
            LlenarHerramienta();
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
            //Gestionar_Workflow GW = new Gestionar_Workflow();
            //GW.Show();
        }

        private void btn_EjecutarWorkflow_Click(object sender, EventArgs e)
        {
            Ejecutar_Workflow EW = new Ejecutar_Workflow(usu);
            EW.Show();
            this.Hide();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            
            dgvFlujo.AllowUserToAddRows = true;
            string cod = string.Empty;
            UsuarioNeg neg = new UsuarioNeg();
            DataSet id = neg.ObtenerId(lblNombreUsuario.Text);
            cod = id.Tables[0].Rows[0].ItemArray[0].ToString();

            string flujoId = neg.registrarFlujoDevId(txtNombreFlujo.Text);

            Dominio.T_DetalleFlujo flujo = new Dominio.T_DetalleFlujo();
            Dominio.T_Señas seña = new Dominio.T_Señas();
            Dominio.T_Secuencia se = new Dominio.T_Secuencia();
            Dominio.T_Herramienta he = new Dominio.T_Herramienta();

            foreach (DataGridViewRow rows in dgvFlujo.Rows)
            {
                List<string> array = new List<string>();
                string valse = rows.Cells[1].Value.ToString();
                DataSet valseña = neg.ValidaSeña(valse);
                if (valseña.Tables[0].Rows.Count == 0)
                {
                    seña.nombre = rows.Cells[1].Value.ToString();
                    seña.descripcion = "No Asignado";
                    seña.idCategoriaSeñas = 1002;
                    seña.estado = "No validado";
                    se.nombreSecuencia = rows.Cells[0].Value.ToString();
                    flujo.idHerramienta = Convert.ToInt32(rows.Cells[4].Value);
                    flujo.idUsuario = Convert.ToInt32(cod);
                    flujo.idFlujo = Convert.ToInt32(flujoId);
                    flujo.estado = "Pendiente de Aprobación";
                    flujo.existe = false;
                    flujo.idCategoria = Convert.ToInt32(rows.Cells[3].Value);
                    string respuesta = neg.registrarFlujoSeña(flujo, se, seña);
                    if (respuesta == "Flujo S Registrado")
                    {
                        array.Add(rows.Cells[1].Value.ToString());
                    }
                    else
                    {
                        array = new List<string>();
                        array.Add("Error");
                    }
                }
                else 
                {  
                    flujo.idSeñas = Convert.ToInt32(valseña.Tables[0].Rows[0].ItemArray[0]);
                    se.nombreSecuencia = rows.Cells[0].Value.ToString();
                    flujo.idHerramienta = Convert.ToInt32(rows.Cells[4].Value);
                    flujo.idUsuario = Convert.ToInt32(cod);
                    flujo.idFlujo = Convert.ToInt32(flujoId);
                    flujo.estado = "Pendiente de Aprobación";
                    flujo.existe = true;
                    flujo.idCategoria = Convert.ToInt32(rows.Cells[3].Value);
                    string respuesta = neg.registrarFlujo(flujo, se);
                    if (respuesta == "Flujo Registrado")
                    {
                        array.Add(rows.Cells[1].Value.ToString());
                    }
                    else
                    {
                        array = new List<string>();
                        array.Add("Error");
                    }
                }
                if (array.Contains("Error"))
                {
                    MessageBox.Show("Error. Consulte con el Administrador del Sistema.");
                }
                else
                {
                    string toDisplay = string.Join(Environment.NewLine, array);
                    MessageBox.Show("Flujo, con señas:" + toDisplay + " registrado correctamente.");
                }
                limpiar();
                if (dgvFlujo.Rows.Count == 0)
                {
                    dgvFlujo.AllowUserToAddRows = true;

                }
                else
                {
                    dgvFlujo.AllowUserToAddRows = false;
                }
            }
            Gestionar_Workflow gwf = new Gestionar_Workflow(usu);
            this.Close();
            gwf.Show();

        }

        public void limpiar()
        {
            cbCategoria.SelectedIndex = 0;
            cbHerramienta.SelectedIndex = 0;

            txtNombreFlujo.Text = string.Empty;
            txtSeña.Text = string.Empty;

        }
        int i = 0;
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //dgvFlujo.AllowUserToAddRows = true;

            CategoriaNeg blL = new CategoriaNeg();
            DataSet dscait = blL.ListarCategorias();
            DataGridViewRow row = (DataGridViewRow)dgvFlujo.Rows[0].Clone();
            row.Cells[0].Value = i;
            row.Cells[1].Value = txtSeña.Text;
            row.Cells[3].Value = cbCategoria.SelectedValue;
            row.Cells[4].Value = cbHerramienta.SelectedValue;
            dgvFlujo.Rows.Add(row);
            row.Cells[2].Value = true;
            i = i + 10;
        }

        private void LlenaCategoria()
        {
            CategoriaNeg blL = new CategoriaNeg();
            DataSet dscait = blL.ListarCategorias();

            DataRow unitem = dscait.Tables["cait"].NewRow();
            dscait.Tables["cait"].Rows.InsertAt(unitem, 0);
            unitem["idCategoria"] = "0";
            unitem["nombre"] = "Seleccionar..";

            cbCategoria.DataSource = dscait.Tables["cait"];
            cbCategoria.DisplayMember = "nombre";
            cbCategoria.ValueMember = "idCategoria";
            DataGridViewComboBoxColumn colbox = new DataGridViewComboBoxColumn();
            colbox.DataSource = cbCategoria.DataSource;
            colbox.HeaderText = "Categoria";
            colbox.DisplayMember = "nombre";
            colbox.ValueMember = "idCategoria";
            dgvFlujo.Columns.Add(colbox);
        }

        private void LlenarHerramienta()
        {
            CategoriaNeg blL = new CategoriaNeg();
            DataSet dsherra = blL.ListarHerramienta();

            DataRow unitem = dsherra.Tables["herra"].NewRow();
            dsherra.Tables["herra"].Rows.InsertAt(unitem, 0);
            unitem["idHerramienta"] = "0";
            unitem["cnombre"] = "Seleccionar..";

            cbHerramienta.DataSource = dsherra.Tables["herra"];
            cbHerramienta.DisplayMember = "cnombre";
            cbHerramienta.ValueMember = "idHerramienta";
            DataGridViewComboBoxColumn colbox1 = new DataGridViewComboBoxColumn();
            colbox1.DataSource = cbHerramienta.DataSource;
            colbox1.HeaderText = "Herramienta";
            colbox1.DisplayMember = "cnombre";
            colbox1.ValueMember = "idHerramienta";
            dgvFlujo.Columns.Add(colbox1);
        }

        private void btnRevisar_Click(object sender, EventArgs e)
        {
            this.Close();
            GestionarWFAdministrador ga = new GestionarWFAdministrador(usu);
            ga.Show();
        }
    }
}
