using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Perfil
    {
        int idPerfil;

        public int IdPerfil
        {
            get { return idPerfil; }
            set { idPerfil = value; }
        }
        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        int estado;

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Perfil()
        {
            idPerfil = 0;
            nombre = "";
            descripcion = "";
        }

        public Perfil(int idPer, string nom, string des)
        {
            idPerfil = idPer;
            nombre = nom;
            descripcion = des;
        }
    }
}
