using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dominio;

namespace GestionDatos
{
    public class GestionWF
    {
        SqlConnection conexion;

        public GestionWF()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public DataSet ListarCateItems()
        {
            DataSet dscate = new DataSet();

            SqlDataAdapter dacateite = new SqlDataAdapter("sp_listarcateItem", conexion);
            dacateite.SelectCommand.CommandType = CommandType.StoredProcedure;
            dacateite.Fill(dscate, "cait");
            return dscate;
        }

        public String RegistrarFlujo(T_DetalleFlujo re, T_Secuencia se)
        {
            conexion.Open();
            SqlCommand unComando = new SqlCommand("sp_RegistrarFlujo", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.AddWithValue("@idSeñas", re.idSeñas);
            unComando.Parameters.AddWithValue("@idFlujo", re.idFlujo);
            unComando.Parameters.AddWithValue("@idUsuario", re.idUsuario);
            unComando.Parameters.AddWithValue("@idHerramienta", re.idHerramienta);
            unComando.Parameters.AddWithValue("@existe", re.existe);
            unComando.Parameters.AddWithValue("@estado", re.estado);
            unComando.Parameters.AddWithValue("@idCategoria", re.idCategoria);
            unComando.Parameters.AddWithValue("@nombreSecuencia", se.nombreSecuencia);


            SqlDataAdapter da = new SqlDataAdapter(unComando);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
            }
            conexion.Close();
            return "Flujo Registrado";

        }

        public String RegistrarFlujoSeña(T_DetalleFlujo re, T_Secuencia se, T_Señas seña)
        {
            conexion.Open();
            SqlCommand unComando = new SqlCommand("sp_RegistrarFlujoSeña", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.AddWithValue("@idFlujo", re.idFlujo);
            unComando.Parameters.AddWithValue("@idUsuario", re.idUsuario);
            unComando.Parameters.AddWithValue("@idHerramienta", re.idHerramienta);
            unComando.Parameters.AddWithValue("@existe", re.existe);
            unComando.Parameters.AddWithValue("@estado", re.estado);
            unComando.Parameters.AddWithValue("@idCategoria", re.idCategoria);
            unComando.Parameters.AddWithValue("@nombreSecuencia", se.nombreSecuencia);
            unComando.Parameters.AddWithValue("@nombre", seña.nombre);
            unComando.Parameters.AddWithValue("@descripcion", seña.descripcion);
            unComando.Parameters.AddWithValue("@idCategoriaSeñas", seña.idCategoriaSeñas);
            unComando.Parameters.AddWithValue("@gift", seña.gift == null);
            unComando.Parameters.AddWithValue("@estadoS", seña.estado);


            SqlDataAdapter da = new SqlDataAdapter(unComando);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
            }
            conexion.Close();
            return "Flujo S Registrado";

        }

        public String RegistrarFlujoDevId(string nombre)
        {
            conexion.Open();
            SqlCommand unComando = new SqlCommand("sp_RegistrarFlow", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.AddWithValue("@nombreFlujo", nombre);

            SqlDataAdapter da = new SqlDataAdapter(unComando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexion.Close();
            return dt.Rows[0].ItemArray[0].ToString();

        }

        public DataSet ValidaSeña(string seña)
        {
            string select = "SELECT idSeñas FROM T_Señas WHERE nombre ='" + seña + "'";//se hace una consulta completa de toda la tabla palabra
            DataSet dsusuarios = new DataSet();
            SqlDataAdapter unComando = new SqlDataAdapter(select, conexion);
            unComando.Fill(dsusuarios, "usuarios");
            return dsusuarios;
        }

        public DataSet ListarFlujos()
        {
            DataSet dscate = new DataSet();

            SqlDataAdapter dacateite = new SqlDataAdapter("sp_ListarFlujos", conexion);
            dacateite.SelectCommand.CommandType = CommandType.StoredProcedure;
            dacateite.Fill(dscate, "flujos");
            return dscate;
        }
        public DataSet ListarFlujosxId(int idflujo)
        {
            SqlCommand comComando = null;
            comComando = new SqlCommand();
            comComando.Connection = conexion;
            comComando.CommandText = "sp_ListarFlujosxId";
            comComando.CommandType = CommandType.StoredProcedure;
            comComando.Parameters.AddWithValue("@idFlujo", idflujo);
            SqlDataAdapter da = new SqlDataAdapter(comComando);
            DataSet dscs = new DataSet();
            da.Fill(dscs, "Lista");
            return dscs;
        }
    }
}
