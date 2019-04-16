using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Multimedia.Entidades
{
    public partial class RolSistemaBE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RolSistemaBE()
        {
            this.AccesoSeccion = new HashSet<AccesoSeccionBE>();
            this.LogActividad = new HashSet<LogActividadBE>();
            this.RolSistemaCompany = new HashSet<RolSistemaCompanyBE>();
        }

        public short IdRolSistema { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool EsBase { get; set; }
        public short Estado { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        public short IdUsuarioCreador { get; set; }
        public byte IdUsuarioModificador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccesoSeccionBE> AccesoSeccion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LogActividadBE> LogActividad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RolSistemaCompanyBE> RolSistemaCompany { get; set; }
    }
}
