using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Dominio;

namespace GestionDatos
{
    public class CategoriaDat
    {
        int id;
        SqlConnection conexion;

        public CategoriaDat()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void MandaId(T_CategoriaFlujo objCat)
        {
            id = objCat.idCategoria;
        }

        public void InsertCategoria(T_CategoriaFlujo objCat)
        {
            string Insertar = "INSERT T_CategoriaFlujo(nombre,descripcion) VALUES('" + objCat.nombre + "','" + objCat.descripcion + "')";

            SqlCommand unComando = new SqlCommand(Insertar, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public void UpdateCategoria(T_CategoriaFlujo objCat)
        {
            string Update = "UPDATE T_CategoriaFlujo SET nombre = '" + objCat.nombre + "', descripcion = '" + objCat.descripcion + "' WHERE idCategoria = " + id + "";

            SqlCommand unComando = new SqlCommand(Update, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public void DeleteCategoria(T_CategoriaFlujo objCat)
        {
            string Delete = "DELETE T_CategoriaFlujo WHERE idCategoria = " + objCat.idCategoria + "";

            SqlCommand unComando = new SqlCommand(Delete, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public DataSet ListarCategoria()
        {
            DataSet dscateite = new DataSet();

            SqlDataAdapter dacateite = new SqlDataAdapter("sp_ListarCategoriaF", conexion);
            dacateite.SelectCommand.CommandType = CommandType.StoredProcedure;
            dacateite.Fill(dscateite, "cait");
            return dscateite;
        }

        public DataSet ListarHerramienta()
        {
            DataSet dscateite = new DataSet();

            SqlDataAdapter dacateite = new SqlDataAdapter("sp_ListarHerramienta", conexion);
            dacateite.SelectCommand.CommandType = CommandType.StoredProcedure;
            dacateite.Fill(dscateite, "herra");
            return dscateite;
        }

        public DataSet SelectCategorias()
        {
            string select = "SELECT * FROM T_CategoriaFlujo";
            DataSet dscategorias = new DataSet();
            SqlDataAdapter unComando = new SqlDataAdapter(select, conexion);
            unComando.Fill(dscategorias, "categorias");
            return dscategorias;
        }

        public bool SelectCategoriaDatos(T_CategoriaFlujo objCat)
        {
            bool hayRegistros;
            string select = "SELECT * FROM T_CategoriaFlujo WHERE idCategoria =" + objCat.idCategoria + "";
            SqlCommand unComando = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader registros = unComando.ExecuteReader();
            hayRegistros = registros.Read();
            if (hayRegistros)
            {
                objCat.nombre = (string)registros[1];
                objCat.descripcion = (string)registros[2];
                objCat.Estado = 99;
            }
            else
            {
                objCat.Estado = 1;
            }
            conexion.Close();

            return hayRegistros;
        }

        public bool SelectCheck(T_CategoriaFlujo objCat)
        {
            bool hayRegistros;
            string select = "SELECT * FROM T_CategoriaFlujo WHERE nombre ='" + objCat.nombre + "'";//Para validar si el nombre de usuario ya existe
            SqlCommand unComando = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader registros = unComando.ExecuteReader();
            hayRegistros = registros.Read();
            if (hayRegistros)
            {

                objCat.nombre = (string)registros[1];
                objCat.descripcion = (string)registros[2];
                objCat.Estado = 99;
            }
            else
            {
                objCat.Estado = 1;
            }
            conexion.Close();

            return hayRegistros;
        }
    }
}
