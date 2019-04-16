using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Multimedia.Entidades
{
    public partial class AccesoSeccionBE
    {
        public int IdAccesoSeccion { get; set; }
        public int IdSeccion { get; set; }
        public short Estado { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public short IdUsuarioCreador { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        public short UsuarioModificador { get; set; }
        public bool Acceso { get; set; }
        public bool Crear { get; set; }
        public bool Marcado { get; set; }
        public bool Edicion { get; set; }
        public bool Desactivado { get; set; }
        public short IdRolSistema { get; set; }

        public virtual SeccionBE Seccion { get; set; }
        public virtual RolSistemaBE RolSistema { get; set; }
    }
}
