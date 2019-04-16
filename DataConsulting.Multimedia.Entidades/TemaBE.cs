using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Multimedia.Entidades
{
    public partial class TemaBE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TemaBE()
        {
            this.ComentarioTema = new HashSet<ComentarioTemaBE>();
            this.LogActividad = new HashSet<LogActividadBE>();
            this.Respuesta = new HashSet<RespuestaBE>();
            this.TemaContenido = new HashSet<TemaContenidoBE>();
            this.TemaEdicion = new HashSet<TemaEdicionBE>();
            this.ValoracionTema = new HashSet<ValoracionTemaBE>();
        }

        public int IdTema { get; set; }
        public short IdTipoTema { get; set; }
        public int IdSeccion { get; set; }
        public short Estado { get; set; }
        public string Titulo { get; set; }
        public short CantidadComentario { get; set; }
        public short CantidadRespuesta { get; set; }
        public short ScoreObtenido { get; set; }
        public short CantidadVista { get; set; }
        public string ResumenEdicion { get; set; }
        public short IdUsuarioEstadoPor { get; set; }
        public System.DateTime FechaEstadoPor { get; set; }
        public string NombreEstadoPor { get; set; }
        public byte FlagTema { get; set; }
        public short IdUsuarioFlagPor { get; set; }
        public System.DateTime FechaFlagPor { get; set; }
        public string NombreFlagPor { get; set; }
        public byte IdUsuarioCreador { get; set; }
        public string NombreUsuarioCreador { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public short IdUsuarioModificador { get; set; }
        public string NombreUsuarioModificador { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public string Tag3 { get; set; }
        public string Tag4 { get; set; }
        public string Tag5 { get; set; }
        public string Tags { get; set; }
        public string VisitanteIP { get; set; }
        public short CantidadEdicion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComentarioTemaBE> ComentarioTema { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LogActividadBE> LogActividad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RespuestaBE> Respuesta { get; set; }
        public virtual SeccionBE Seccion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemaContenidoBE> TemaContenido { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemaEdicionBE> TemaEdicion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ValoracionTemaBE> ValoracionTema { get; set; }
        public virtual TipoTemaBE TipoTema { get; set; }
    }
}
