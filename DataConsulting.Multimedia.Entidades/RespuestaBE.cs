using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Multimedia.Entidades
{
    public partial class RespuestaBE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RespuestaBE()
        {
            this.ComentarioRespuesta = new HashSet<ComentarioRespuestaBE>();
            this.ValoracionRespuesta = new HashSet<ValoracionRespuestaBE>();
            this.RespuestaContenido = new HashSet<RespuestaContenidoBE>();
        }

        public int IdRespuesta { get; set; }
        public int IdTema { get; set; }
        public string Titulo { get; set; }
        public short IdUsuarioCreador { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string NombreUsuarioCreador { get; set; }
        public short IdUsuarioModificador { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        public string NombreUsuarioModificador { get; set; }
        public byte FlagRespuesta { get; set; }
        public short UsuarioFlagPor { get; set; }
        public System.DateTime FechaFlagPor { get; set; }
        public string NombreFlagPor { get; set; }
        public short Estado { get; set; }
        public short UsuarioEstadoPor { get; set; }
        public System.DateTime FechaEstadoPor { get; set; }
        public string NombreEstadoPor { get; set; }
        public short CantidadVista { get; set; }
        public short ScoreObtenido { get; set; }
        public short CantidadComentario { get; set; }
        public string ResumenEdicion { get; set; }
        public string VisitanteIP { get; set; }
        public short CantidadEdicion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComentarioRespuestaBE> ComentarioRespuesta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ValoracionRespuestaBE> ValoracionRespuesta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RespuestaContenidoBE> RespuestaContenido { get; set; }
        public virtual TemaBE Tema { get; set; }
    }
}
