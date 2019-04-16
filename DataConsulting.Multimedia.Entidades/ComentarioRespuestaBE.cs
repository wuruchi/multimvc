using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Multimedia.Entidades
{
    public partial class ComentarioRespuestaBE
    {
        public int IdComentarioRespuesta { get; set; }
        public int IdRespuesta { get; set; }
        public short Estado { get; set; }
        public short ScoreObtenido { get; set; }
        public string ComentarioTexto { get; set; }
        public string ComentarioTextoHtml { get; set; }
        public short CantidadEdicion { get; set; }
        public short IdUsuarioCreador { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string NombreUsuarioCreador { get; set; }
        public short IdUsuarioModificador { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        public string NombreUsuarioModificador { get; set; }

        public virtual RespuestaBE Respuesta { get; set; }
    }
}
