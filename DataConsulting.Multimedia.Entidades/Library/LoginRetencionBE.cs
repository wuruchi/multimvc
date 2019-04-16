using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataConsulting.Multimedia.Entidades
{
    public class LoginRetencionBE
    {
        public LoginRetencionBE()
        {
            Serie = string.Empty;
            Documento = string.Empty;
            Moneda = string.Empty;
            IdMoneda = 0;
            Monto = 0M;
            Message = string.Empty;
        }

        public LoginRetencionBE(string moSerie, string moDocumento)
        {
            Serie = moSerie;
            Documento = moDocumento;
            //Moneda = moMoneda;
            //Monto = moMonto;
            //if (Moneda == "SOLES")
            //{
            //    IdMoneda = 1;
            //}
            //else
            //{
            //    IdMoneda = 2;
            //}
            Message = string.Empty;
        }

        public string Serie { get; set; }
        public string Documento { get; set; }
        public string Moneda { get; set; }
        public int IdMoneda { get; set; }
        public decimal Monto { get; set; }
        public string Message { get; set; }

        public string CamposValidos()
        {
            string mensaje = string.Empty;

            if (string.IsNullOrEmpty(Serie))
            { mensaje += "Ingrese una Serie." + Environment.NewLine; }

            if (string.IsNullOrEmpty(Documento))
            { mensaje += "Ingrese un Documento." + Environment.NewLine; }

            //if (Monto <= 0)
            //{ mensaje += "Ingrese el Monto." + Environment.NewLine; }
            return mensaje;
        }
    }
}