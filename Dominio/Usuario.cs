using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Usuario
    {
        int idUsuario;

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        string nombreUsuario;

        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }
        string contraseña;

        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }
        string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        int idPerfil;

        public int IdPerfil
        {
            get { return idPerfil; }
            set { idPerfil = value; }
        }

        int estado;

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Usuario()
        {
            idUsuario = 0;
            nombreUsuario = "";
            contraseña = "";
            email = "";
            idPerfil = 0;
        }

        public Usuario(string nom, string con, string ema, int per)
        {
            nombreUsuario = nom;
            contraseña = con;
            email = ema;
            idPerfil = per;
        }
    }
}
