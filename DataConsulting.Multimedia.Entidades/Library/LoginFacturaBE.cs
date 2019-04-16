using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataConsulting.Multimedia.Entidades
{
    public class LoginFacturaBE
    {
        public LoginFacturaBE()
        {
            TipoDocumento = string.Empty;
            IdTipoDocumento = 0;
            Serie = string.Empty;
            Documento = string.Empty;
            Moneda = string.Empty;
            IdMoneda = 0;
            Monto = 0M;
            Message = string.Empty;
        }

        public LoginFacturaBE(string moTipoDocumento, string moSerie, string moDocumento, string moMoneda, decimal moMonto)
        {
            Serie = moSerie;
            Documento = moDocumento;
            Moneda = moMoneda;
            Monto = moMonto;
            if(Moneda == "SOLES")
            {
                IdMoneda = 1;
            }
            else
            {
                IdMoneda = 2;
            }
            TipoDocumento = moTipoDocumento;
            switch (TipoDocumento)
            {
                case "FT":
                    IdTipoDocumento = 184;
                    break;
                case "NC":
                    IdTipoDocumento = 186;
                    break;
                case "ND":
                    IdTipoDocumento = 187;
                    break;
                case "BV":
                    IdTipoDocumento = 191;
                    break;
                default:
                    IdTipoDocumento = 184;
                    break;
            }

            Message = string.Empty;


        }

        public string TipoDocumento { get; set; }
        public int IdTipoDocumento { get; set; }
        public string Serie { get; set; }
        public string Documento { get; set; }
        public string Moneda { get; set; }
        public int IdMoneda { get; set; }
        public decimal Monto { get; set; }
        public string Message { get; set; }

        public string CamposValidos()
        {
            string mensaje = string.Empty;

            if (string.IsNullOrEmpty(Documento))
            { mensaje += "Ingrese un Documento." + Environment.NewLine; }

            if (Monto <= 0)
            { mensaje += "Ingrese el Monto." + Environment.NewLine; }

            return mensaje;
        }
    }
}