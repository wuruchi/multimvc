using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Multimedia.Entidades
{
    public partial class RolSistemaCompanyBE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RolSistemaCompanyBE()
        {
            this.LogActividad = new HashSet<LogActividadBE>();
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
        public virtual ICollection<LogActividadBE> LogActividad { get; set; }
        public virtual RolSistemaBE RolSistema { get; set; }
    }
}
