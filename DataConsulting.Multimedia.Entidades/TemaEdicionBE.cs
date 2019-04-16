using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Multimedia.Entidades
{
    public partial class TemaEdicionBE
    {
        public int IdTemaEdicion { get; set; }
        public int IdTema { get; set; }
        public short Estado { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public string ContenidoHTML { get; set; }
        public short IdUsuarioModificador { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public string Tag3 { get; set; }
        public string Tag4 { get; set; }
        public string Tag5 { get; set; }
        public string Tags { get; set; }
        public string ResumenEdicion { get; set; }

        public virtual TemaBE Tema { get; set; }
    }
}
