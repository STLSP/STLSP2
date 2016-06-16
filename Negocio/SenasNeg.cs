using Dominio;
using GestionDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class SenasNeg
    {
    SenasDat objSenasDat;
        public SenasNeg()
        {
            objSenasDat = new SenasDat();
        }

        public void ObtencionId(T_Señas objSe)
        {
            objSenasDat.MandaId(objSe);
        }

        public void RegistrarSenas(T_Señas objSe)
        {
            bool verificar;
            T_Señas objSeT = new T_Señas();
            objSeT.nombre = objSe.nombre;
            verificar = !objSenasDat.SelectCheckNombre(objSeT);
            if (!verificar)
            {
                objSe.state = 1;
                return;
            }

            string nom = objSe.nombre.Trim();
            verificar = nom.Length > 0;
            if (!verificar)
            {
                objSe.state = 3;
                return;
            }

            string con = objSe.gift.Trim(); //Trim()
            verificar = con.Length > 0;
            if (!verificar)
            {
                objSe.state = 3;
                return;
            }

            objSenasDat.InsertSenas(objSe);
            objSe.state = 99;
        }

        public void ActualizarSenas(T_Señas objSe)
        {
            bool verificar;
            //T_Señas objSeT = new T_Señas();
            //objSeT.nombre = objSe.nombre;
            /*verificar = !objSenasDat.SelectCheckNombre(objSeT);
            if (!verificar)
            {
                objSe.state = 1;
                return;
            }*/

            string nom = objSe.nombre.Trim();
            verificar = nom.Length > 0;
            if (!verificar)
            {
                objSe.state = 3;
                return;
            }

            string con = objSe.gift.Trim();
            verificar = con.Length > 0;
            if (!verificar)
            {
                objSe.state = 3;
                return;
            }

            objSenasDat.UpdateSenas(objSe);
            objSe.state = 99;
        }

        public void EliminarSenas(T_Señas objSe)
        {
            objSenasDat.DeleteSenas(objSe);
        }

        public DataSet LeerSenas()
        {
            return objSenasDat.SelectSenas();
        }

        public DataSet LeerCategoriaSenas()
        {
            return objSenasDat.SelectCategoriaSenas();
        }

        public bool LeerSenasDatos(T_Señas objSe)
        {
            return objSenasDat.SelectSenasDatos(objSe);
        }
    }
}
