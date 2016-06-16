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
    public partial class Gestionar_Categorias : Form
    {
        string usu = string.Empty;
        T_CategoriaFlujo objCategoria;
        CategoriaNeg objCategoriaNeg;
        public Gestionar_Categorias(string usuario)
        {
            InitializeComponent();
            objCategoriaNeg = new CategoriaNeg();
            llenarTabla();
            lblNombreUsuario.Text = usuario;
            usu = usuario;
        }
        public void refrescar()
        {
            DataSet dscategorias = objCategoriaNeg.LeerCategorias();
            dgvCategoria.DataSource = dscategorias.Tables[0];
        }

        public void llenarTabla()
        {
            DataSet dscategorias = objCategoriaNeg.LeerCategorias();
            dgvCategoria.DataSource = dscategorias.Tables[0];

            this.dgvCategoria.Columns["idCategoria"].Visible = false;

            dgvCategoria.Columns["nombre"].HeaderText = "Nombre de la Categoria";
            dgvCategoria.Columns["descripcion"].HeaderText = "Descripcion";

            DataGridViewButtonColumn Actualizar = new DataGridViewButtonColumn();
            dgvCategoria.Columns.Add(Actualizar);
            Actualizar.HeaderText = "Actualizar";
            Actualizar.Text = "Actualizar";
            Actualizar.Name = "btnActualizar";
            Actualizar.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn Eliminar = new DataGridViewButtonColumn();
            dgvCategoria.Columns.Add(Eliminar);
            Eliminar.HeaderText = "Eliminar";
            Eliminar.Text = "Eliminar";
            Eliminar.Name = "btnEliminar";
            Eliminar.UseColumnTextForButtonValue = true;
        }
        private void btn_GestionarUsuarios_Click(object sender, EventArgs e)
        {
            Gestionar_Usuarios GU = new Gestionar_Usuarios(usu);
            GU.Show();
            this.Hide();
        }

        private void btn_GestionarCategorias_Click(object sender, EventArgs e)
        {
            //Gestionar_Categorias GC = new Gestionar_Categorias();
            //GC.Show();
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
            Ejecutar_Workflow EW = new Ejecutar_Workflow(usu);
            EW.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataSet dscategorias = objCategoriaNeg.LeerCategorias();
            dgvCategoria.DataSource = dscategorias.Tables[0];

            DataView dv;
            dv = new DataView(dscategorias.Tables[0], "nombre = '" + txtNombre.Text + "'", "nombre Desc", DataViewRowState.CurrentRows);
            dgvCategoria.DataSource = dv;
            if (txtNombre.Text == "")
            {
                refrescar();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            IngresarCategoria IC = new IngresarCategoria(usu);
            IC.Show();
        }

        private void dgvCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategoria.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                if (MessageBox.Show("Estas seguro que desea eliminar?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idCate = Convert.ToInt32(dgvCategoria.CurrentRow.Cells["idCategoria"].Value.ToString());
                    objCategoria = new T_CategoriaFlujo();
                    objCategoria.idCategoria = idCate;
                    objCategoriaNeg.EliminarCategoria(objCategoria);
                    refrescar();
                }
            }

            if (dgvCategoria.Columns[e.ColumnIndex].Name == "btnActualizar")
            {
                int idCate = Convert.ToInt32(dgvCategoria.CurrentRow.Cells["idCategoria"].Value.ToString());
                EscrituraCategoria EC = new EscrituraCategoria(idCate, usu);
                EC.Show();
            }
        }

    }
}
