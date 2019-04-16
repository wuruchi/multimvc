using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Multimedia.Entidades
{
    public partial class TemaContenidoBE
    {
        public int IdTemaContenido { get; set; }
        public int IdTema { get; set; }
        public string Contenido { get; set; }
        public string ContenidoHtml { get; set; }

        public virtual TemaBE Tema { get; set; }
    }
}
