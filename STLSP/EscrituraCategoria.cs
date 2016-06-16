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
    public partial class EscrituraCategoria : Form
    {
        T_CategoriaFlujo objCategoria;
        CategoriaNeg objCategoriaNeg;
        string usu = string.Empty;
        public EscrituraCategoria(int idCat, string usuario)
        {
            InitializeComponent();
            usu = usuario;
            objCategoria = new T_CategoriaFlujo();
            objCategoriaNeg = new CategoriaNeg();
            lblIdCategoria.Text = "" + idCat;
            objCategoria.idCategoria = int.Parse(lblIdCategoria.Text);
            objCategoriaNeg.LeerCategoriaDatos(objCategoria);
            cargarCategoria();
            lblIdCategoria.Visible = false;
        }

        private void cargarCategoria()
        {
            txtCategoria.Text = objCategoria.nombre;
            txtDescripcion.Text = objCategoria.descripcion;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            objCategoriaNeg.ObtencionId(objCategoria);
            if (MessageBox.Show("Estas seguro que desea actualizar?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                objCategoria.nombre = txtCategoria.Text;
                objCategoria.descripcion = txtDescripcion.Text;
                objCategoriaNeg.ActualizarCategoria(objCategoria);
                if (objCategoria.Estado == 99)
                {
                    MessageBox.Show("Categoria actualizada con exito");
                }
                if (objCategoria.Estado == 1)
                {
                    MessageBox.Show("Este nombre de Categoria ya existe");
                }
                if (objCategoria.Estado == 3)
                {
                    MessageBox.Show("Tiene que llenar los campos vacios");
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Gestionar_Categorias GC = new Gestionar_Categorias(usu);
            GC.refrescar();
            GC.Show();
            this.Visible = false;
        }
    }
}
