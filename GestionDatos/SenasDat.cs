using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GestionDatos
{
    public class SenasDat
    {
        int id;
        SqlConnection conexion;

        public SenasDat()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void MandaId(T_Señas objSe)
        {
            id = objSe.idSeñas;
        }

        public void InsertSenas(T_Señas objSe)
        {
            string Insertar = "INSERT T_Señas(nombre,descripcion,gift,idCategoriaSeñas,estado) VALUES('" + objSe.nombre + "','" + objSe.descripcion + "','" + objSe.gift + "'," + objSe.idCategoriaSeñas  +"'," + objSe.estado + ")";

            SqlCommand unComando = new SqlCommand(Insertar, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public void UpdateSenas(T_Señas objSe)
        {
            string Update = "UPDATE T_Señas SET nombre = '" + objSe.nombre + "', descripcion = '" + objSe.descripcion + "', gift = '" + objSe.gift + "', idCategoriaSeñas = '" + objSe.idCategoriaSeñas + "', estado = '" + objSe.estado + "' WHERE idSeñas = " + id + "";

            SqlCommand unComando = new SqlCommand(Update, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public void DeleteSenas(T_Señas objSe)
        {
            string Delete = "DELETE T_Señas WHERE idSeñas = " + objSe.idSeñas + "";

            SqlCommand unComando = new SqlCommand(Delete, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public DataSet SelectSenas()
        {
            string select = "SELECT * FROM T_Señas INNER JOIN T_CategoriaSeñas ON T_Señas.idCategoriaSeñas = T_CategoriaSeñas.idCategoriaSeñas";
            DataSet dssenas = new DataSet();
            SqlDataAdapter unComando = new SqlDataAdapter(select, conexion);
            unComando.Fill(dssenas, "senas");
            return dssenas;
        }

        public DataSet SelectCategoriaSenas()
        {
            string select = "SELECT * FROM T_CategoriaSeñas";
            DataSet dsCS = new DataSet();
            SqlDataAdapter unComando = new SqlDataAdapter(select, conexion);
            unComando.Fill(dsCS);
            return dsCS;
        }

        public bool SelectSenasDatos(T_Señas objSe)
        {
            bool hayRegistros;
            string select = "SELECT * FROM T_Señas WHERE idSeñas =" + objSe.idSeñas + "";
            SqlCommand unComando = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader registros = unComando.ExecuteReader();
            hayRegistros = registros.Read();
            if (hayRegistros)
            {
                objSe.nombre = (string)registros[1];
                objSe.descripcion = (string)registros[2];
                objSe.gift = (string)registros[3];
                objSe.idCategoriaSeñas = (int)registros[4];
                objSe.state = 99;
            }
            else
            {
                objSe.state = 1;
            }
            conexion.Close();

            return hayRegistros;
        }

        public bool SelectCheckNombre(T_Señas objSe)
        {
            bool hayRegistros;
            string select = "SELECT * FROM T_Señas WHERE nombre ='" + objSe.nombre + "'";
            SqlCommand unComando = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader registros = unComando.ExecuteReader();
            hayRegistros = registros.Read();
            if (hayRegistros)
            {

                objSe.nombre = (string)registros[1];
                objSe.descripcion = (string)registros[2];
                objSe.gift = (string)registros[3];
                objSe.idCategoriaSeñas = (int)registros[4];
                objSe.state = 99;
            }
            else
            {
                objSe.state = 1;
            }
            conexion.Close();

            return hayRegistros;
        }

        public bool SelectCheckRuta(T_Señas objSe)
        {
            bool hayRegistros;
            string select = "SELECT * FROM T_Señas WHERE gift ='" + objSe.gift + "'";
            SqlCommand unComando = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader registros = unComando.ExecuteReader();
            hayRegistros = registros.Read();
            if (hayRegistros)
            {

                objSe.nombre = (string)registros[1];
                objSe.descripcion = (string)registros[2];
                objSe.gift = (string)registros[3];
                objSe.idCategoriaSeñas = (int)registros[4];
                objSe.state = 99;
            }
            else
            {
                objSe.state = 1;
            }
            conexion.Close();

            return hayRegistros;
        }
    }


}
