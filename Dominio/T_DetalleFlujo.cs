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
    
    public partial class T_DetalleFlujo
    {
        public int idSeñas { get; set; }
        public int idHerramienta { get; set; }
        public int idSecuencia { get; set; }
        public int idUsuario { get; set; }
        public string nombreFlujo { get; set; }
        public int idCategoria { get; set; }
        public bool existe { get; set; }
        public string estado { get; set; }
        public int idFlujo { get; set; }
    
        public virtual T_CategoriaFlujo T_CategoriaFlujo { get; set; }
        public virtual T_Flujo T_Flujo { get; set; }
        public virtual T_Flujo T_Flujo1 { get; set; }
        public virtual T_Herramienta T_Herramienta { get; set; }
        public virtual T_Secuencia T_Secuencia { get; set; }
        public virtual T_Señas T_Señas { get; set; }
        public virtual T_Usuario T_Usuario { get; set; }
    }
}