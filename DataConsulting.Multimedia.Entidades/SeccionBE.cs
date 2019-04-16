using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Multimedia.Entidades
{
    public partial class SeccionBE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SeccionBE()
        {
            this.AccesoSeccion = new HashSet<AccesoSeccionBE>();
            this.LogActividad = new HashSet<LogActividadBE>();
            this.Tema = new HashSet<TemaBE>();
        }

        public SeccionBE(IDataRecord datarec)
        {
            IdSeccion = Convert.ToInt32(datarec["IdSeccion"]);
            Titulo = Convert.ToString(datarec["Titulo"]);
            Descripcion = Convert.ToString(datarec["Descripcion"]);
            Estado = Convert.ToInt16(datarec["Estado"]);
            IdTipoSeccion = Convert.ToInt16(datarec["IdTipoSeccion"]);
        }

        public int IdSeccion { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public short Estado { get; set; }
        public short IdUsuarioCreador { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public short IdUsuarioModificador { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        public Nullable<short> IdTipoSeccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccesoSeccionBE> AccesoSeccion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LogActividadBE> LogActividad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemaBE> Tema { get; set; }
        public virtual TipoSeccionBE TipoSeccion { get; set; }
    }
}
