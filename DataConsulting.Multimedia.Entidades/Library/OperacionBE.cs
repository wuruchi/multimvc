using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataConsulting.Multimedia.Entidades
{
    public abstract class OperacionBE : Base
    {
        protected int miIdAprobador;
        protected string msAprobador;
        protected DateTime mdFechaAprobacion;
        protected EEstadoOperacion miEstado;
        protected string msEstadoNombre;

        public OperacionBE()
            : base()
        {
            msAprobador = string.Empty;
            miEstado = EEstadoOperacion.Generado;
        }

        public OperacionBE(IDataRecord datarec)
            : base(datarec)
        {
            //try { msDescripcion = datarec["Descripcion"].ToString(); } catch { msDescripcion = string.Empty; }
            try { miIdAprobador = DbConvert.ToInt32(datarec["IdAprobador"]); } catch { miIdAprobador = 0; }
            try { mdFechaAprobacion = DbConvert.ToDateTime(datarec["FechaAprobacion"]); } catch { mdFechaAprobacion = DateTime.MinValue; }
            try { msAprobador = DbConvert.ToString(datarec["Aprobador"]); } catch { msAprobador = string.Empty; }
            miEstado = (EEstadoOperacion)Convert.ToInt32((datarec["Estado"]));
        }
        
        public int IdAprobador
        {
            get { return miIdAprobador; }
            set { miIdAprobador = value; }
        }

        public DateTime FechaAprobacion
        {
            get { return mdFechaAprobacion; }
            set { mdFechaAprobacion = value; }
        }

        public string FechaAprobacionCadena
        {
            get { return mdFechaAprobacion != DateTime.MinValue ? mdFechaAprobacion.Date.ToShortDateString() : string.Empty; }
        }

        public string Aprobador
        {
            get { return msAprobador; }
            set { msAprobador = value; }
        }

        public EEstadoOperacion Estado
        {
            get { return miEstado; }
            set { miEstado = value; }
        }

        //public string EstadoNombre
        //{
        //    get { return EntitySet.EstadoOperacionDic[(int)miEstado].Descripcion; }
        //}

        public bool EsGenerado
        {
            get { return miEstado == EEstadoOperacion.Generado; }
        }

        public bool EsAprobado
        {
            get { return miEstado == EEstadoOperacion.Aprobado; }
        }

        public bool EsAnulado
        {
            get { return miEstado == EEstadoOperacion.Anulado; }
        }

        public bool EsCerrado
        {
            get { return miEstado == EEstadoOperacion.Cerrado; }
            set { miEstado = EEstadoOperacion.Cerrado; }
        }

        public bool EsAtendidoParcial
        {
            get { return miEstado == EEstadoOperacion.AtendidoParcial; }
        }

        public bool EsAtendido
        {
            get { return miEstado == EEstadoOperacion.Atendido; }
        }
    }
}
