using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Multimedia.Entidades
{
    public partial class RespuestaContenidoBE
    {
        public int IdRespuestaContenido { get; set; }
        public int IdRespuesta { get; set; }
        public string Contenido { get; set; }
        public string ContenidHtml { get; set; }

        public virtual RespuestaBE Respuesta { get; set; }
    }
}
