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
    public partial class Gestionar_Usuarios : Form
    {
        Usuario objUsuario;
        UsuarioNeg objUsuarioNeg;
        string usu = string.Empty;
        public Gestionar_Usuarios(string usuario)
        {
            InitializeComponent();
            lblNombreUsuario.Text = usuario;
            usu = usuario;
            objUsuarioNeg = new UsuarioNeg();
            llenarTabla();
        }

        public void llenarTabla()
        {
            DataSet dsusuarios = objUsuarioNeg.LeerUsuarios();
            dgvUsuarios.DataSource = dsusuarios.Tables[0];

            this.dgvUsuarios.Columns["idUsuario"].Visible = false;
            this.dgvUsuarios.Columns["idPerfil"].Visible = false;
            this.dgvUsuarios.Columns["idPerfil1"].Visible = false;
            this.dgvUsuarios.Columns["descripcion"].Visible = false;

            dgvUsuarios.Columns["nombreUsuario"].HeaderText = "Nombre de Usuario";
            dgvUsuarios.Columns["contraseña"].HeaderText = "Contraseña";
            dgvUsuarios.Columns["email"].HeaderText = "Email";
            dgvUsuarios.Columns["nombre"].HeaderText = "Tipo de Permiso";

            DataGridViewButtonColumn Actualizar = new DataGridViewButtonColumn();
            dgvUsuarios.Columns.Add(Actualizar);
            Actualizar.HeaderText = "Actualizar";
            Actualizar.Text = "Actualizar";
            Actualizar.Name = "btnActualizar";
            Actualizar.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn Eliminar = new DataGridViewButtonColumn();
            dgvUsuarios.Columns.Add(Eliminar);
            Eliminar.HeaderText = "Eliminar";
            Eliminar.Text = "Eliminar";
            Eliminar.Name = "btnEliminar";
            Eliminar.UseColumnTextForButtonValue = true;
        }

        public void refrescar()
        {
            DataSet dsusuarios = objUsuarioNeg.LeerUsuarios();
            dgvUsuarios.DataSource = dsusuarios.Tables[0];
        }

        private void btn_GestionarUsuarios_Click(object sender, EventArgs e)
        {
            //Gestionar_Usuarios GU = new Gestionar_Usuarios();
            //GU.Show();
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
            Ejecutar_Workflow EW = new Ejecutar_Workflow(usu);
            EW.Show();
            this.Hide();
        }

        public void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet dsusuarios = objUsuarioNeg.LeerUsuarios();
            dgvUsuarios.DataSource = dsusuarios.Tables[0];

            DataView dv;
            dv = new DataView(dsusuarios.Tables[0], "nombreUsuario = '" + txtFilter.Text + "'", "nombreUsuario Desc", DataViewRowState.CurrentRows);
            dgvUsuarios.DataSource = dv;
            if (txtFilter.Text == "")
            {
                refrescar();
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                if (MessageBox.Show("Estas seguro que desea eliminar?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["idUsuario"].Value.ToString());
                    objUsuario = new Usuario();
                    objUsuario.IdUsuario = idUsuario;
                    objUsuarioNeg.EliminarUsuario(objUsuario);

                    DataSet dsusuarios = objUsuarioNeg.LeerUsuarios();
                    dgvUsuarios.DataSource = dsusuarios.Tables[0];
                }
            }

            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "btnActualizar")
            {
                int idUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["idUsuario"].Value.ToString());
                EscrituraUsuarios EU = new EscrituraUsuarios(idUsuario, usu);
                EU.Show();
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["idUsuario"].Value.ToString());
            IngresarUsuario IU = new IngresarUsuario(idUsuario, usu);
            IU.Show();
        }
    }
}
