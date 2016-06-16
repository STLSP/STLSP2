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
    public partial class IngresarCategoria : Form
    {
        T_CategoriaFlujo objCategoria;
        CategoriaNeg objCategoriaNeg;
        string usu = string.Empty;
        public IngresarCategoria(string usuario)
        {
            InitializeComponent();
            objCategoriaNeg = new CategoriaNeg();
            objCategoria = new T_CategoriaFlujo();
            usu = usuario;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            objCategoria.nombre = txtCategoria.Text;
            objCategoria.descripcion = txtDescripcion.Text;
            objCategoriaNeg.RegistrarCategoria(objCategoria);
            if (objCategoria.Estado == 99)
            {
                MessageBox.Show("Categoria creada con exito");
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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Gestionar_Categorias GU = new Gestionar_Categorias(usu);
            GU.Show();
            GU.refrescar();
            this.Visible = false;
        }
    }
}
