//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dominio
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_PerfilxPermiso
    {
        public bool estadopermiso { get; set; }
        public int idPermiso { get; set; }
        public int idPerfil { get; set; }
    
        public virtual T_Perfil T_Perfil { get; set; }
        public virtual T_Permiso T_Permiso { get; set; }
    }
}
