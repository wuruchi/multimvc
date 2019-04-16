using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Multimedia.Entidades
{
    public partial class ValoracionTemaBE
    {
        public int IdValoracionTema { get; set; }
        public byte Cantidad { get; set; }
        public byte TipoMarca { get; set; }
        public short IdUsuarioCreador { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<int> IdTema { get; set; }

        public virtual TemaBE Tema { get; set; }
    }
}
