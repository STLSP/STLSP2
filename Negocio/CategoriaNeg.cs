using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDatos;
using Dominio;
using System.Data;

namespace Negocio
{
    public class CategoriaNeg
    {
        CategoriaDat objCategoriaDat;

        public CategoriaNeg()
        {
            objCategoriaDat = new CategoriaDat();

        }
        public DataSet ListarCategorias()
        {
            return objCategoriaDat.ListarCategoria();
        }
        public DataSet ListarHerramienta()
        {
            return objCategoriaDat.ListarHerramienta();
        }
        public void ObtencionId(T_CategoriaFlujo objCat)
        {
            objCategoriaDat.MandaId(objCat);
        }

        public void RegistrarCategoria(T_CategoriaFlujo objCat)
        {
            bool verificar;
            T_CategoriaFlujo objCatT = new T_CategoriaFlujo();
            objCatT.nombre = objCat.nombre;
            verificar = !objCategoriaDat.SelectCheck(objCatT);
            if (!verificar)
            {
                objCat.Estado = 1;
                return;
            }

            string con = objCat.nombre.Trim();
            verificar = con.Length > 0;
            if (!verificar)
            {
                objCat.Estado = 3;
                return;
            }

            objCategoriaDat.InsertCategoria(objCat);
            objCat.Estado = 99;
        }

        public void ActualizarCategoria(T_CategoriaFlujo objCat)
        {
            bool verificar;
            T_CategoriaFlujo objCatT = new T_CategoriaFlujo();
            objCatT.nombre = objCat.nombre;
            verificar = !objCategoriaDat.SelectCheck(objCatT);
            if (!verificar)
            {
                objCat.Estado = 1;
                return;
            }

            string con = objCat.nombre.Trim();
            verificar = con.Length > 0;
            if (!verificar)
            {
                objCat.Estado = 3;
                return;
            }

            objCategoriaDat.UpdateCategoria(objCat);
            objCat.Estado = 99;
        }

        public void EliminarCategoria(T_CategoriaFlujo objCat)
        {
            objCategoriaDat.DeleteCategoria(objCat);
        }

        public DataSet LeerCategorias()
        {
            return objCategoriaDat.SelectCategorias();
        }

        public bool LeerCategoriaDatos(T_CategoriaFlujo objCat)
        {
            return objCategoriaDat.SelectCategoriaDatos(objCat);
        }
    }
}
