//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebMultimediaMvc.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class RolSistemaCompany
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RolSistemaCompany()
        {
            this.LogActividad = new HashSet<LogActividad>();
        }
    
        public int IdRolSisCompany { get; set; }
        public short IdRolSistema { get; set; }
        public int IdCompany { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Simbolo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public short ScoreTotal { get; set; }
        public short Estado { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        public short IdUsuarioCreador { get; set; }
        public short IdUsuarioModificador { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LogActividad> LogActividad { get; set; }
        public virtual RolSistema RolSistema { get; set; }
    }
}
