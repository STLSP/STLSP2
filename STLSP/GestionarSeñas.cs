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
    public partial class Gestionar_Señas : Form
    {
        T_Señas objSenas;
        SenasNeg objSenasNeg;
        string usu = string.Empty;
        public Gestionar_Señas(string usuario)
        {
            InitializeComponent();
            lblNombreUsuario.Text = usuario;
            usu = usuario;
            objSenasNeg = new SenasNeg();
            llenarTabla();
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
            //Gestionar_Señas GS = new Gestionar_Señas();
            //GS.Show();
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
            Ejecutar_Workflow EW = new Ejecutar_Workflow(usu);
            EW.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataSet dssenas = objSenasNeg.LeerSenas();
            dgvSenas.DataSource = dssenas.Tables[0];

            DataView dv;
            dv = new DataView(dssenas.Tables[0], "nombre = '" + txtBuscar.Text + "'", "nombre Desc", DataViewRowState.CurrentRows);
            dgvSenas.DataSource = dv;
            if (txtBuscar.Text == "")
            {
                refrescar();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            IngresarSena IS = new IngresarSena(usu);
            IS.Show();
        }

        private void dgvSenas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSenas.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                if (MessageBox.Show("Estas seguro que desea eliminar?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idSena = Convert.ToInt32(dgvSenas.CurrentRow.Cells["idSeñas"].Value.ToString());
                    string deletepath = dgvSenas.CurrentRow.Cells["gift"].Value.ToString();
                    objSenas = new T_Señas();
                    objSenas.idSeñas = idSena;
                    objSenasNeg.EliminarSenas(objSenas);
                    System.IO.File.Delete(deletepath);
                    refrescar();
                }
            }

            if (dgvSenas.Columns[e.ColumnIndex].Name == "btnActualizar")
            {
                int idSena = Convert.ToInt32(dgvSenas.CurrentRow.Cells["idSeñas"].Value.ToString());
                EscrituraSena ES = new EscrituraSena(idSena, usu);
                ES.Show();
                this.Close();
            }

            if (dgvSenas.Columns[e.ColumnIndex].Name == "btnVisualizar")
            {
                string IMGnom = dgvSenas.CurrentRow.Cells["nombre"].Value.ToString();
                Visualizador ES = new Visualizador(IMGnom, usu);
                ES.Show();
                this.Close();
            }
        }

        public void refrescar()
        {
            DataSet dssenas = objSenasNeg.LeerSenas();
            dgvSenas.DataSource = dssenas.Tables[0];
        }

        public void llenarTabla()
        {
            DataSet dssenas = objSenasNeg.LeerSenas();
            dgvSenas.DataSource = dssenas.Tables[0];

            this.dgvSenas.Columns["idSeñas"].Visible = false;
            this.dgvSenas.Columns["gift"].Visible = false;
            this.dgvSenas.Columns["idCategoriaSeñas"].Visible = false;
            this.dgvSenas.Columns["idCategoriaSeñas1"].Visible = false;
            this.dgvSenas.Columns["descripcion1"].Visible = false;

            dgvSenas.Columns["nombre"].HeaderText = "Nombre de la Seña";
            dgvSenas.Columns["descripcion"].HeaderText = "Descripcion";
            dgvSenas.Columns["nombre1"].HeaderText = "Categoria";
            DataGridViewButtonColumn Visualizar = new DataGridViewButtonColumn();
            dgvSenas.Columns.Add(Visualizar);
            Visualizar.HeaderText = "Visualizar";
            Visualizar.Text = "Visualizar";
            Visualizar.Name = "btnVisualizar";
            Visualizar.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn Actualizar = new DataGridViewButtonColumn();
            dgvSenas.Columns.Add(Actualizar);
            Actualizar.HeaderText = "Actualizar";
            Actualizar.Text = "Actualizar";
            Actualizar.Name = "btnActualizar";
            Actualizar.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn Eliminar = new DataGridViewButtonColumn();
            dgvSenas.Columns.Add(Eliminar);
            Eliminar.HeaderText = "Eliminar";
            Eliminar.Text = "Eliminar";
            Eliminar.Name = "btnEliminar";
            Eliminar.UseColumnTextForButtonValue = true;
        }
    }
}
