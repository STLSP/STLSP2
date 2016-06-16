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
    public partial class GestionarWFAdministrador : Form
    {
        string usu = string.Empty;
        public GestionarWFAdministrador(string usuario)
        {
            InitializeComponent();
            lblNombreUsuario.Text = usuario;
            usu = usuario;
            LlenarDgv();
            dgv.Columns[5].Visible = false;
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.UseColumnTextForButtonValue = true;
            col.Text = "Actualizar";
            col.Name = "Actualizar";
            dgv2.Columns.Add(col);
        }

        private void LlenarDgv()
        {
            UsuarioNeg neg = new UsuarioNeg();
            DataSet ds = neg.ListarFlujos();
            dgv.DataSource = ds.Tables[0];
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.UseColumnTextForButtonValue = true;
            col.Text = "Ver";
            col.Name = "Ver";
            dgv.Columns.Add(col);            
        }

        private void LlenarDgv2(int idFlujo)
        {
            UsuarioNeg neg = new UsuarioNeg();
            DataSet ds = neg.ListarFlujosxId(idFlujo);
            dgv2.DataSource = ds.Tables[0];
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            int idFlujo = Convert.ToInt32(dgv.Rows[e.ColumnIndex].Cells[6].Value);
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                LlenarDgv2(idFlujo);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Gestionar_Workflow GW = new Gestionar_Workflow(usu);
            GW.Show();
            this.Close();
        }
    }
}
