using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataConsulting.Multimedia.Entidades
{
    public abstract class BaseBE : Base
    {
        //protected EEstado miEstado;
        protected short miEstado;

        public BaseBE()
            : base()
        {
            miEstado = (byte)EEstado.Activo;
        }

        public BaseBE(IDataRecord datarec)
            : base(datarec)
        {
            try { miEstado = Convert.ToInt16(datarec["Estado"]); } //(EEstado)
            catch { miEstado = 0; }
        }

        //public EEstado Estado
        public short Estado
        {
            get { return miEstado; }
            set { miEstado = value; }
        }

        [NotMapped]
        public bool EsActivo
        {
            get { return miEstado == (short)EEstado.Activo; }
            set { miEstado = value ? (short)EEstado.Activo : (short)EEstado.Inactivo; }
        }

        [NotMapped]
        public bool EsInactivo
        {
            get { return miEstado == (short)EEstado.Inactivo; }
            set { miEstado = value ? (short)EEstado.Inactivo : (short)EEstado.Activo; }
        }

        //[NotMapped]
        //public string EstadoNombre
        //{
        //    get { return EntitySet.EstadoBaseDic[(int)miEstado].Descripcion; }
        //}
    }
}
