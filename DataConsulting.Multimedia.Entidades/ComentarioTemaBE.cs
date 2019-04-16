using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Multimedia.Entidades
{
    public partial class ComentarioTemaBE
    {
        public int IdComentario { get; set; }
        public int IdTema { get; set; }
        public string ComentarioTexto { get; set; }
        public string ComentarioTextoHtml { get; set; }
        public short ScoreObtenido { get; set; }
        public short Estado { get; set; }
        public short IdUsuarioCreador { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string NombreUsuarioCreador { get; set; }
        public short IdUsuarioModificador { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        public string NombreUsuarioModificador { get; set; }
        public short CantidadEdicion { get; set; }

        public virtual TemaBE Tema { get; set; }
    }
}
