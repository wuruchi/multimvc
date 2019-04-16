using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace DataConsulting.Multimedia.Entidades
{
    public enum EEstadoActualizacion : int
    {
        INSERTADO = 1,
        NUEVO = 2,
        MODIFICADO = 3,
        ELIMINADO = 4
    }

    public static class EEstadoActualizacionNombre
    {
        public const string INSERTADO = "INSERTADO";
        public const string NUEVO = "NUEVO";
        public const string MODIFICADO = "MODIFICADO";
        public const string ELIMINADO = "ELIMINADO";
    }

    public abstract class Base : IDbConcurrency2
    {
        protected short miUpdateToken;
        private EEstadoActualizacion miEstadoActualizacion;

        public Base()
        {
            miEstadoActualizacion = EEstadoActualizacion.NUEVO;
        }

        public Base(IDataRecord datarec)
        {
            try { miUpdateToken = Convert.ToInt16(datarec["UpdateToken"]); }
            catch { miUpdateToken = 0; }            
            miEstadoActualizacion = EEstadoActualizacion.INSERTADO;
        }

        [NotMapped]
        public bool EsNuevo { get { return miEstadoActualizacion == EEstadoActualizacion.NUEVO; } }
        [NotMapped]
        public bool EsInsertado { get { return miEstadoActualizacion == EEstadoActualizacion.INSERTADO; } }
        [NotMapped]
        public bool EsModificado { get { return miEstadoActualizacion == EEstadoActualizacion.MODIFICADO; }  }
        [NotMapped]
        public bool EsEliminado { get { return miEstadoActualizacion == EEstadoActualizacion.ELIMINADO; } }
        [NotMapped]
        public bool NoEsEliminado { get { return miEstadoActualizacion != EEstadoActualizacion.ELIMINADO; } }
        [NotMapped]
        public bool EsInsOrUpd
        {
            get
            {
                return (miEstadoActualizacion == EEstadoActualizacion.INSERTADO)
                  || miEstadoActualizacion == EEstadoActualizacion.MODIFICADO;
            }
        }

        public void SetInsertado()
        {
            miEstadoActualizacion = EEstadoActualizacion.INSERTADO;
        }

        public void SetModificado()
        {
            miEstadoActualizacion = EEstadoActualizacion.MODIFICADO;
        }

        public void SetEliminado()
        {
            miEstadoActualizacion = EEstadoActualizacion.ELIMINADO;
        }

        #region IListItemBE IDbConcurrency2

        public short UpdateToken
        {
            get { return miUpdateToken; }
            set { miUpdateToken = value; }
        }

        public void SetUpdateToken(short UpdateToken)
        {
            miUpdateToken = UpdateToken;
        }

        public void RestartToken()
        {
            miUpdateToken = 0;
        }

        public void RefreshToken()
        {
            miUpdateToken++;
        }

        #endregion
    }

    public interface IDbConcurrency
    {
        byte UpdateToken { get; }
        void RefreshToken();
    }

    /// <summary>
    /// Interfaz que trabaja con el token de tipo entero
    /// </summary>
    public interface IDbConcurrency2
    {
        short UpdateToken { get; }
        void RefreshToken();
    }

    public interface IAuditDate
    {
        DateTime FechaCreacion { get; set; }
        DateTime? FechaModificacion { get; set; }
    }
}
