using System;


namespace DataConsulting.Multimedia.Entidades
{
    public enum EEstado : int
    {
        Todos = 0,
        Activo = 1,
        Inactivo = 2
    }
    public enum EFormatoArchivo : int
    {
        Todos = 0,
        Excel = 1,
        Pdf = 2
    }
    public enum ETipoPrecio : int
    {
        Todos = 0,
        Afecto = 1,
        Inafecto = 2,
        Exonerado = 3,
        Regalo = 4
    }
    public enum ETipoNota : int
    {
        Todos = 0,
        NotaCredito = 1,
        NotaDebito = 2
    }
    public enum EEmpresa : int
    {
        Todos = 0,
        DataConsulting = 1,
        Biond = 2,
        DestileriaPeruana = 3,
        ColegioContadores = 4,
        EstudioHenandez = 5,
        IDConsultores = 6,
        CamaraComercio = 7,
        ServiciosData = 8,
        ITSoftware = 9,
        Interamericana = 10,
        DPI = 11,
        Dalcorp = 12,
        VargasBeltran = 13,
        ElMeson = 14,
        EstrellitaDelSur = 15,
        Vallesur = 16,
        AgroData = 18,
        Cebu = 19,
        JaraAlmonte = 20,
        GlorietaTacneña = 21,
        SoldeOro = 22,
        InversionesIruri = 23,
        ServicentroMelsa = 24,
        Nodiex = 25,
        Malibu = 26,
        LadrilleraMaxx = 27,
        LadrilleraMartorell = 28,
        TransporteAlmeda = 29,
        MinaLasVegas = 30,
        JMAutomotriz = 31,
        InstGuillermoAlmenara = 32,
        HotelBolivar = 33,
        NotariaFernandez = 34,
        EmpresaDemo = 35
    }
    public enum EDocumento : int
    {
        Todos = 0,
        GuiaRemision = 6,
        GuiaRemisionTransportista = 7,
        OrdenCompra = 27,
        Factura = 9,
        Boleta = 10,
        NotaCredito = 15,
        NotaDebito = 16,
        TicketBoleta = 17,
        TicketFactura = 18,
        NotaCréditoNoDomiciliado = 166,
        NotaDébitoNoDomiciliado = 167,
        NotaCréditoEspecial = 168,
        NotaDébitoEspecial = 169,
        FacturaElectronica = 184,
        BoletaElectronica = 191,
        NotaCreditoElectronica = 186,
        NotaDebitoElectronica = 187,
        RetencionElectronica = 130
    }

    public enum EDocIdentidadLong : byte
    {
        DNI = 8,
        RUC = 11
    }
    public enum ETipoMoneda : int
    {
        Todos = 0,
        Soles = 1,
        Dolares = 2,
        Euros = 3,
        Pesos = 4
    }
    public enum EDocumentoIdentidad : byte
    {
        Todos = 0,
        DNI = 1,
        RUC = 2,
        CIDENTIDAD = 3,
        PASAPORTE = 4,
        CARNETDEEXTRANJERIA = 6,
        CEP = 7,
        RIF = 8,
        CNP = 9,
        OTRO = 10,
        CNPJ = 11,
        RUT = 12,
        CIF = 13,
        NIF = 14,
        COMPROBANTEDENODOMICILIADO = 214
    }
    public enum EFlagOrigen : byte
    {
        Todos = 0,
        Manual = 1,
        Migrado = 2
    }

    public enum EEstadoPedido : byte
    {
        Todos = 0,
        Pendiente = 1,
        Atendido = 2,
        AtendidoParcial = 3,
        Anulado = 4
    }
    public enum ETipoVenta : int
    {
        Todos = 0,
        FacturasYBoletasElectronicas = 1,
        NotasElectrónicas = 2,
        FacturasElectronicasExportacion = 3,
        FacturaElectronicaHospedaje = 4,
        FacturaElectronicaAuto = 5,
        FacturaElectronicaMinera = 6
    }
    //ENTIDAD PARA MARTORELL
    public enum EIdTipoEstadoSunat : int
    {
        NoMigrado = 0,
        Migrado = 1,
        ErrorMigracion = 2,
        NoEnviado = 3,
        Aceptado = 4,
        AceptadoConObservaciones = 5,
        ErrorFormato = 6,
        ErrorDatos = 7
    }

    public enum EMotivoContingencia : int
    {
        Todos = 0,
        ConexionInternet = 1,
        FallaFluidoElectrico = 2,
        DesastresNaturales = 3,
        Robo = 4,
        FallaSistemaFacturacion = 5,
        VentaItinerante = 6,
        Otros = 7
    }
    public static class ETipoResuesta
    {
        public const string SI = "SI";
        public const string NO = "NO";
    }

    public static class EEstadoGenericoStr
    {
        public const string Todos = "T";
        public const string Activo = "A";
        public const string Inactivo = "I";
    }

    public enum ECabeceraVentaSQL : byte
    {
        IdEmpresa = 0,
        IdDocumento = 1,
        DocumentoNombre = 2,
        DocumentoSiglas = 3,
        ClienteNumero = 4,
        NombreCliente = 5,
        IdDocumentoIdentidad = 6,
        DocumentoIdentidadNombre = 7,
        Longitud = 8,
        Direccion = 9,
        IdTipoMoneda = 10,
        TipoMonedaNombre = 11,
        MotivoNotaNombre = 12,
        MotivoCodigoSunat = 13,
        NumSerieCliente = 14,
        NumDocumentoCliente = 15,
        FechaEmision = 16,
        FormaPago = 17,
        Observaciones = 18,
        Estado = 19,
        IdVentaScop = 20,
        IdDocRef = 21,
        ISC = 22,
        IGV = 23,
        DescuentoGlobal = 24,
        ValorAfecto = 25,
        ValorInafecto = 26,
        ValorExonerado = 27,
        ValorRegalo = 28,
        ImporteTotal = 29,
        NombreArchivoXML = 30,
        NombreRespuestaXML = 31,
        CodigoSunat = 32,
        EstadoSunat = 33,
        RucEmpresa = 34,
        TipoIgv = 35,
        FlagComercioExterior = 36
    }

    public enum EDetalleVentaSQL : byte
    {
        IdEmpresa = 0,
        IdVentaScop = 1,
        Correlativo = 2,
        ArticuloNombre = 3,
        UnidadNombre = 4,
        SiglaUnidad = 5,
        UnidadCodSunat = 6,
        Cantidad = 7,
        PrecioUnitario = 8,
        TipoPrecio = 9,
        Descuento = 10,
        SubTotal = 11,
        Estado = 12
    }

    public enum ECabeceraRetencionSQL : byte
    {
        IdEmpresa = 0,
        RucEmpresa = 1,
        IdProveedor = 2,
        NombreProveedor = 3,
        DireccionProveedor = 4,
        RucProveedor = 5,
        IdTipoDocumento = 6,
        Serie = 7,
        NumDocumento = 8,
        DocumentoSiglas = 9,
        FechaEmision = 10,
        IdRetencionScop = 11,
        ImporteTotalSoles = 12,
        ImporteTotalRetenido = 13,
        NombreArchivoXML = 14,
        NombreRespuestaXML = 15,
        CodigoSunat = 16,
        EstadoSunat = 17
    }

    public enum EDetalleRetencionSQL : byte
    {
        IdEmpresa = 0,
        IdCompra = 1,
        SerieCompra = 2,
        Numero = 3,
        FechaEmision = 4,
        TipoMonedaOrigen = 5,
        ImporteMonedaOrigen = 6,
        ImporteSoles = 7,
        TasaRetencion = 8,
        ImporteRetenido = 9
    }

    public enum EColumnaCabecera : byte
    {
        IdTipoDocumento = 0,
        NombreCliente = 1,
        IdDocumentoIdentidad = 2,
        NumDocumentoCliente = 3,
        Direccion = 4,
        NombreCliente2 = 5,
        IdDocumentoIdentidad2 = 6,
        NumDocumentoCliente2 = 7,
        Direccion2 = 8,
        IdTipoMoneda = 9,
        NombreMotivoNota = 10,
        CodSunatMotivo = 11,
        SerieNumerica = 12,
        NumNumerico = 13,
        SerieAlfanumerica = 14,
        NumeroAlfanumerico = 15,
        FechaEmision = 16,
        FormaPago = 17,
        Observaciones = 18,
        Estado = 19,
        SerieNumReferencia = 20,
        NumeroNumReferencia = 21,
        SerieAlfaReferencia = 22,
        NumeroAlfaReferencia = 23,
        IdTipoDocumentoRef = 24,
        ISC = 25,
        IGV = 26,
        DescuentoGlobal = 27,
        ValorAfecto = 28,
        ValorInafecto = 29,
        ValorExonerado = 30,
        ValorRegalo = 31,
        ImporteTotal = 32,
        TipoVenta = 33,
        ToTalDescuento = 34, 
        TasaServicio = 35,
        MontoServicio = 36,
        TipoIgv = 37,
        FechaIngresoPais = 38,
        FechaIngresoHospedaje = 39,
        FechaSalidaHospedaje = 40,
        DiasPermanencia = 41,
        PaisPasaporte = 42,
        PaisResidencia = 43,
        AgenciaViaje = 44,
        DescripcionServicio = 45,
        Marca = 46,
        SerieVIN = 47,
        Version = 48,
        AnioFabricacion = 49,
        Motor = 50,
        Combustible = 51,
        Cilindros = 52,
        Traccion = 53,
        NroRuedas = 54,
        NroEjes = 55,
        Ancho = 56,
        Largo = 57,
        Alto = 58,
        Modelo = 59,
        Categoria = 60,
        AnioModelo = 61,
        Color = 62,
        Carroceria = 63,
        Cilindrada = 64,
        Transmision = 65,
        PotenciaHP = 66,
        PotenciaKM = 67,
        TipoNeumatico = 68,
        DistanciaEjes = 69,
        Puertas = 70
    }

    public enum EColumnaDetalle : byte
    {
        NombreArticulo = 0,
        NombreUnidad = 1,
        SiglasUnidad = 2,
        CodSunatUnidad = 3,
        Cantidad = 4,
        PrecioUnitario = 5,
        TipoPrecio = 6,
        Descuento = 7,
        SubTotal = 8,
        CodArticulo = 9,
        FlagDescuento = 10,
        ISC = 11,
        TasaISC = 12,
        ValorVentaBruto = 13,
        MontoServicio = 14,
        IGV = 15,
        DesServicio = 16,
    }

    public enum ETipoEntidad : byte
    {
        Almacen = 0,
        Empresa = 1,
        Proveedor = 2,
        Cliente = 3,
        Trabajador = 4
    }

    public enum ERespuestaOperacion : byte
    {
        TODOS = 0,
        SI = 1,
        NO = 2
    }

    public enum EEstadoOperacion : int
    {
        Todos = 0,
        Generado = 20501,
        Aprobado = 20502,
        Anulado = 20503,
        AtendidoParcial = 20504,
        Atendido = 20505,
        Cerrado = 20506
    }

    public enum EEstadoOperacionGenerico : byte
    {
        Todos = 0,
        Generado = 1,
        Aprobado = 2,
        Anulado = 3,
        AtendidoParcial = 4,
        Atendido = 5,
        Cerrado = 6,
        CerradoParcial = 7
    }

    public enum ESqlException : int
    {
        PrimaryKey = 2627,
        ForeignKey = 547,
        UniqueKey = 2601
    }

    public enum ESituacion : short
    {
        Todos = 0,
        EnFecha = 1,
        PorVencer = 2,
        Vencido = 3,
        EnTramite = 4
    }

    public enum ESituacionEmbarcacion : short
    {
        Todos = 0,
        EnDescansoLaboral = 1,
        Vacaciones = 2,
        Embarcado = 3,
        NoEmbarcado = 4
    }

    public static class ESituacionEmbarcacionNombreStr
    {
        public const string EnDescansoLaboral = "EN DESCANSO LABORAL";
        public const string Vacaciones = "VACACIONES";
        public const string Embarcado = "EMBARCADO";
        public const string NoEmbarcado = "NO EMBARCADO";
    }

    public enum ETipoEstadoSunat : byte
    {
        Todos = 0,
        NoEnviado = 1,
        Aceptado = 2,
        Rechazado = 3,
        Enviado = 4,
        Emitido = 5,
        Restante = 6
    }

    public static class ETipoNombre
    {
        public const string NoEnviado = "No Enviados";
        public const string Aceptado = "Aceptados";
        public const string Rechazado = "Rechazados";
        public const string Enviado = "Enviados (Aceptados + Rechazados)";
        public const string Emitido = "Emitidos";
        public const string Restante = "Restantes";
    }

    public enum EEstadoVenta : int
    {
        Todos = 0,
        Grabado = 1,
        Anulado = 2,
        AceptadoSunat = 3,
        RechasadoSunat = 4,
        ConProblemas = 5
    }
    //public enum ECategoriaDocumento : short
    //{
    //    Todos = 0,
    //    Poliza = 1,
    //    Certificado = 2,
    //    Legajo = 3,
    //    Legal = 4,
    //    Flota = 5
    //}

    //public enum EClaseDocumento : short
    //{
    //    Todos = 0,
    //    Poliza = 1,
    //    CertificadoEstaturario = 2,
    //    CertificadoClase = 3,
    //    Licencia = 4,
    //    Identificacion = 5,
    //    Certificados = 6,
    //    FormacionSeguridad = 7,
    //    Contrato = 8,
    //    ProcesoLegal = 9,
    //    Reclamo = 10,
    //    Dotacion = 11
    //}

    //public enum EEscalafonDocumento
    //    : short
    //{
    //    Todos = 0,
    //    Poliza = 1,
    //    ContratoGenerico = 4,
    //    ContratoComercial = 5,
    //    ContratoLaboral = 6,
    //    Dotacion = 7
    //}

    public static class ESituacionNombreStr
    {
        public const string EnFecha = "EN FECHA";
        public const string PorVencer = "POR VENCER";
        public const string Vencido = "VENCIDO";
        public const string EnTramite = "EN TRAMITE";
    }

    //Estados de un formulario
    public enum EFormState : short
    {
        Empty = 0,
        Navigating = 1,
        Inserting = 2,
        Updating = 3,
        Editing = 4
    }

    
    //Tipos de Asignacion
    public enum ETipoAsignacion : short
    {
        Todos = 0,
        Maniobra = 21601,
        Travesia = 21602
    }

    public enum ETipoDescanso : short
    {
        Todos = 0,
        Descanso = 1,
        Vacacion = 2
    }

    public enum EFlagClasificacion : byte
    {
        Todos = 0,
        Flota = 1,
        Practico = 2,
        Otros = 3
    }
}