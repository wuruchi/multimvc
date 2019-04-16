using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Multimedia.Entidades
{
    public partial class LogActividadBE
    {
        public int IdLogActividad { get; set; }
        public short IdRolSistema { get; set; }
        public int IdRolSisCompany { get; set; }
        public string NombreModulo { get; set; }
        public string NombrePagina { get; set; }
        public string Accion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public short IdUsuarioCreador { get; set; }
        public Nullable<int> IdSeccion { get; set; }
        public Nullable<int> IdTema { get; set; }

        public virtual SeccionBE Seccion { get; set; }
        public virtual RolSistemaBE RolSistema { get; set; }
        public virtual RolSistemaCompanyBE RolSistemaCompany { get; set; }
        public virtual TemaBE Tema { get; set; }
    }
}
