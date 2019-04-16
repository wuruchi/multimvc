using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Multimedia.Entidades
{
    public partial class TipoSeccionBE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoSeccionBE()
        {
            this.Seccion = new HashSet<SeccionBE>();
        }

        public short IdTipoSeccion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public short Estado { get; set; }
        public short IdUsuarioCreador { get; set; }
        public short IdUsuarioModificador { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public System.DateTime FechaModificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeccionBE> Seccion { get; set; }
    }
}
