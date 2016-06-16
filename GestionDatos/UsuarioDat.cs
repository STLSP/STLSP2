using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Dominio;

namespace GestionDatos
{
    public class UsuarioDat
    {
        SqlConnection conexion;
        int idob;
        string nomUsu;
        public UsuarioDat()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void MandaId(Usuario objusu)
        {
            idob = objusu.IdUsuario;
        }

        public void MandaNombreUsuario(Usuario objusu)
        {
            nomUsu = objusu.NombreUsuario;
        }

        public void InsertUsuario(Usuario objUsu)
        {
            string Insertar = "INSERT T_Usuario(nombreUsuario, contraseña, email, idPerfil) VALUES('" + objUsu.NombreUsuario + "','" + objUsu.Contraseña + "','" + objUsu.Email + "'," + objUsu.IdPerfil + ")";

            SqlCommand unComando = new SqlCommand(Insertar, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public void UpdateUsuario(Usuario objUsu)
        {
            string Update = "UPDATE T_Usuario SET nombreUsuario = '" + objUsu.NombreUsuario + "', contraseña = '" + objUsu.Contraseña + "', email = '" + objUsu.Email + "', idPerfil = " + objUsu.IdPerfil + " WHERE idUsuario = " + idob + "";

            SqlCommand unComando = new SqlCommand(Update, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public void UpdateContrasena(Usuario objUsu)//Se usa para el cambiar contrasena
        {
            string Update = "UPDATE T_Usuario SET contraseña = '" + objUsu.Contraseña + "'  WHERE nombreUsuario = '" + objUsu.NombreUsuario + "'";

            SqlCommand unComando = new SqlCommand(Update, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public void DeleteUsuario(Usuario objUsu)
        {
            string Delete = "DELETE T_Usuario WHERE idUsuario = '" + objUsu.IdUsuario + "'";

            SqlCommand unComando = new SqlCommand(Delete, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public bool SelectUsuarioscontra(Usuario objusu)
        {
            bool hayRegistros;
            string select = "SELECT * FROM T_Usuario WHERE nombreUsuario ='" + objusu.NombreUsuario + "'";
            SqlCommand unComando = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader registros = unComando.ExecuteReader();
            hayRegistros = registros.Read();
            if (hayRegistros)
            {
                objusu.NombreUsuario = (string)registros[1];
                objusu.Contraseña = (string)registros[2];
                objusu.Estado = 99;
            }
            else
            {
                objusu.Estado = 1;
            }
            conexion.Close();

            return hayRegistros;
        }
        public bool VerificarUsuario(Usuario objUsu)//Se usa para el iniciar sesion y para cambiar contrasena
        {
            bool hayRegistros;
            string select = "SELECT * FROM T_Usuario2 WHERE nombreUsuario ='" + objUsu.NombreUsuario + "' AND contraseña = '" + objUsu.Contraseña + "'";
            SqlCommand unComando = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader registros = unComando.ExecuteReader();
            hayRegistros = registros.Read();
            if (hayRegistros)
            {
                objUsu.Estado = 99;
            }
            else
            {
                objUsu.Estado = 1;
            }
            conexion.Close();

            return hayRegistros;
        }

        public bool SelectUsuarioDatos(Usuario objUsu)
        {
            bool hayRegistros;
            string select = "SELECT * FROM T_Usuario WHERE idUsuario =" + objUsu.IdUsuario + "";
            SqlCommand unComando = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader registros = unComando.ExecuteReader();
            hayRegistros = registros.Read();
            if (hayRegistros)
            {

                objUsu.NombreUsuario = (string)registros[1];
                objUsu.Contraseña = (string)registros[2];
                objUsu.Email = (string)registros[3];
                objUsu.IdPerfil = (int)registros[4];
                objUsu.Estado = 99;
            }
            else
            {
                objUsu.Estado = 1;
            }
            conexion.Close();

            return hayRegistros;
        }

        public bool SelectCheck(Usuario objUsu)
        {
            bool hayRegistros;
            string select = "SELECT * FROM T_Usuario WHERE nombreUsuario ='" + objUsu.NombreUsuario + "'";//Para validar si el nombre de usuario ya existe
            SqlCommand unComando = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader registros = unComando.ExecuteReader();
            hayRegistros = registros.Read();
            if (hayRegistros)
            {

                objUsu.NombreUsuario = (string)registros[1];
                objUsu.Contraseña = (string)registros[2];
                objUsu.Email = (string)registros[3];
                objUsu.IdPerfil = (int)registros[4];
                objUsu.Estado = 99;
            }
            else
            {
                objUsu.Estado = 1;
            }
            conexion.Close();

            return hayRegistros;
        }

        public bool SelectIdPerfil(Usuario objUsu)
        {
            bool hayRegistros;
            string select = "SELECT * FROM T_Usuario WHERE nombreUsuario ='" + objUsu.NombreUsuario + "'";
            SqlCommand unComando = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader registros = unComando.ExecuteReader();
            hayRegistros = registros.Read();
            if (hayRegistros)
            {
                objUsu.IdPerfil = (int)registros[4];
                objUsu.Estado = 99;
            }
            else
            {
                objUsu.Estado = 1;
            }
            conexion.Close();

            return hayRegistros;
        }

        public DataSet SelectUsuarios()
        {
            string select = "Select * from T_Usuario INNER JOIN T_Perfil ON T_Usuario.idPerfil = T_Perfil.idPerfil";//INNER JOIN para mostrar perfiles
            DataSet dsusuarios = new DataSet();
            SqlDataAdapter unComando = new SqlDataAdapter(select, conexion);
            unComando.Fill(dsusuarios, "usuarios");
            return dsusuarios;
        }

        public DataSet ObtenerId(string nombreUsuario)
        {
            string select = "Select idUsuario from T_Usuario where nombreUsuario="+nombreUsuario+"";//INNER JOIN para mostrar perfiles
            DataSet dsusuarios = new DataSet();
            SqlDataAdapter unComando = new SqlDataAdapter(select, conexion);
            unComando.Fill(dsusuarios, "usuarios");
            return dsusuarios;
        }

        public DataSet SelectPerfil()
        {
            string select = "SELECT * from T_Perfil";
            DataSet dsperfil = new DataSet();
            SqlDataAdapter unComando = new SqlDataAdapter(select, conexion);
            unComando.Fill(dsperfil);
            return dsperfil;
        }

        public DataSet BuscarUsuarios()
        {
            string sql = "SELECT nombreUsuario FROM T_Usuario";
            DataSet ds = new DataSet();
            SqlDataAdapter unComando = new SqlDataAdapter(sql, conexion);
            unComando.Fill(ds);
            return ds;
        }
    }
}
