using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDatos;
using Dominio;
using System.Data;
using System.Text.RegularExpressions;

namespace Negocio
{
    public class UsuarioNeg
    {
        UsuarioDat objUsuarioDat;
        GestionWF gestionWF;
        public UsuarioNeg()
        {
            objUsuarioDat = new UsuarioDat();
            gestionWF = new GestionWF();
        }

        public DataSet LeerPerfiles()
        {
            return objUsuarioDat.SelectPerfil();
        }

        public void RegistrarUsuario(Usuario objUsu)
        {
            Regex RX = new Regex("^[a-zA-Z0-9]{1,20}@[a-zA-Z0-9]{1,20}.[a-zA-Z]{2,3}$");

            bool verificar;
            Usuario objUsuT = new Usuario();
            objUsuT.NombreUsuario = objUsu.NombreUsuario;
            verificar = !objUsuarioDat.SelectCheck(objUsuT);
            if (!verificar)
            {
                objUsu.Estado = 1;
                return;
            }

            string email = objUsu.Email;
            if (!RX.IsMatch(email))
            {
                objUsu.Estado = 2;
                return;
            }

            string nom = objUsu.NombreUsuario.Trim();
            verificar = nom.Length > 0;
            if (!verificar)
            {
                objUsu.Estado = 3;
                return;
            }

            string con = objUsu.Contraseña.Trim();
            verificar = con.Length > 0;
            if (!verificar)
            {
                objUsu.Estado = 3;
                return;
            }

            objUsuarioDat.InsertUsuario(objUsu);
            objUsu.Estado = 99;
        }

        public void ActualizarUsuario(Usuario objUsu)
        {
            Regex RX = new Regex("^[a-zA-Z0-9]{1,20}@[a-zA-Z0-9]{1,20}.[a-zA-Z]{2,3}$");
            bool verificar;
            Usuario objUsuT = new Usuario();
            objUsuT.NombreUsuario = objUsu.NombreUsuario;
            verificar = !objUsuarioDat.SelectCheck(objUsuT);
            if (!verificar)
            {
                objUsu.Estado = 1;
                return;
            }

            string email = objUsu.Email;
            if (!RX.IsMatch(email))
            {
                objUsu.Estado = 2;
                return;
            }

            string nom = objUsu.NombreUsuario.Trim();
            verificar = nom.Length > 0;
            if (!verificar)
            {
                objUsu.Estado = 3;
                return;
            }

            string con = objUsu.Contraseña.Trim();
            verificar = con.Length > 0;
            if (!verificar)
            {
                objUsu.Estado = 3;
                return;
            }

            objUsuarioDat.UpdateUsuario(objUsu);
            objUsu.Estado = 99;
        }
        public String registrarFlujo(T_DetalleFlujo tr, T_Secuencia se)
        {
            return gestionWF.RegistrarFlujo(tr,se);
        }
        public String registrarFlujoSeña(T_DetalleFlujo tr, T_Secuencia se, T_Señas seña)
        {
            return gestionWF.RegistrarFlujoSeña(tr, se, seña);
        }
        public String registrarFlujoDevId(string nombre)
        {
            return gestionWF.RegistrarFlujoDevId(nombre);
        }

        public void ObtencionId(Usuario objusu)
        {
            objUsuarioDat.MandaId(objusu);
        }
        public bool LeercontraUsuarios(Usuario objusu)
        {
            return objUsuarioDat.SelectUsuarioscontra(objusu);
        }
        public void ActualizarCC(Usuario objUsu)
        {
            bool verificar;
            string con = objUsu.Contraseña.Trim();
            verificar = con.Length > 0;
            if (!verificar)
            {
                objUsu.Estado = 3;
                return;
            }

            objUsuarioDat.UpdateContrasena(objUsu);
            objUsu.Estado = 99;
        }

        public void ObtencionNom(Usuario objusu)
        {
            objUsuarioDat.MandaNombreUsuario(objusu);
        }

        public void EliminarUsuario(Usuario objUsu)
        {
            bool verificar;

            Usuario objUsuT = new Usuario();
            objUsuT.IdUsuario = objUsu.IdUsuario;
            verificar = objUsuarioDat.SelectUsuarioDatos(objUsuT);
            if (!verificar)
            {
                objUsu.Estado = 1;
                return;
            }
            objUsuarioDat.DeleteUsuario(objUsu);
            objUsu.Estado = 99;
        }

        public bool LeerIdPerfil(Usuario objUsu)
        {
            return objUsuarioDat.SelectIdPerfil(objUsu);
        }

        public bool LeerUsuarioDatos(Usuario objUsu)
        {
            return objUsuarioDat.SelectUsuarioDatos(objUsu);
        }

        public DataSet LeerUsuarios()
        {
            return objUsuarioDat.SelectUsuarios();
        }

        public DataSet ValidaSeña(string nombre)
        {
            return gestionWF.ValidaSeña(nombre);
        }
        public DataSet ObtenerId(string nombreUsuario)
        {
            return objUsuarioDat.ObtenerId(nombreUsuario);
        }
        public DataSet ListarFlujos()
        {
            return gestionWF.ListarFlujos();
        }
        public DataSet ListarFlujosxId(int fl)
        {
            return gestionWF.ListarFlujosxId(fl);
        }

        public bool VerificarUsuario(Usuario objUsu)//Se usa para el iniciar sesion y cambiar contrasena
        {
            return objUsuarioDat.VerificarUsuario(objUsu);
        }


        public DataSet FiltrarUsuarios()
        {
            return objUsuarioDat.BuscarUsuarios();
        }
    }
}
