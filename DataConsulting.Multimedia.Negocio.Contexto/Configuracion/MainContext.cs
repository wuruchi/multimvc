using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.SqlClient;
using DataConsulting.Multimedia.Entidades;

namespace DataConsulting.Multimedia.Negocio.Contexto
{
    [DbConfigurationType(typeof(DbContextConfiguration))]
    public partial class MainContext : DbContext
    {
        public const int MaxCommandTimeout = 3600;
        public static int SqlError;
        public static string InternalConectionString;
        public static string NombreCadena = "Multimedia";

        //public static void CargarCadena(string moNombreCadena)
        //{
        //    NombreCadena = "name=" + moNombreCadena;
        //}

        public MainContext()
            : base(NombreCadena)
        //: base("FacturaElectronica")
        {
            InternalConectionString = Database.Connection.ConnectionString;
        }

        #region Clases Virtuales

        public virtual DbSet<AccesoSeccionBE> AccesoSeccion { get; set; }
        public virtual DbSet<ComentarioRespuestaBE> ComentarioRespuesta { get; set; }
        public virtual DbSet<ComentarioTemaBE> ComentarioTema { get; set; }
        public virtual DbSet<LogActividadBE> LogActividad { get; set; }
        public virtual DbSet<RespuestaBE> Respuesta { get; set; }
        public virtual DbSet<RespuestaContenidoBE> RespuestaContenido { get; set; }
        public virtual DbSet<RolSistemaBE> RolSistema { get; set; }
        public virtual DbSet<RolSistemaCompanyBE> RolSistemaCompany { get; set; }
        public virtual DbSet<SeccionBE> Seccion { get; set; }
        public virtual DbSet<TemaBE> Tema { get; set; }
        public virtual DbSet<TemaContenidoBE> TemaContenido { get; set; }
        public virtual DbSet<TemaEdicionBE> TemaEdicion { get; set; }
        public virtual DbSet<TipoSeccionBE> TipoSeccion { get; set; }
        public virtual DbSet<TipoTemaBE> TipoTema { get; set; }
        public virtual DbSet<ValoracionRespuestaBE> ValoracionRespuesta { get; set; }
        public virtual DbSet<ValoracionTemaBE> ValoracionTema { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<AgenciaViajeBE>()
            // .Property(e => e.Nombre)
            // .IsUnicode(false);

            //modelBuilder.Entity<AgenciaViajeBE>()
            //    .Property(e => e.RUC)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ArticuloBE>()
            //    .Property(e => e.Nombre)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ArticuloBE>()
            //   .Property(e => e.TasaISC)
            //   .HasPrecision(10, 4);

            //modelBuilder.Entity<ArticuloBE>()
            //    .Property(e => e.TasaPercepcion)
            //    .HasPrecision(10, 4);

            //modelBuilder.Entity<ArticuloBE>()
            //    .Property(e => e.TasaDetraccion)
            //    .HasPrecision(10, 4);

            //modelBuilder.Entity<ArticuloBE>()
            //    .HasMany(e => e.VentaDetalle)
            //    .WithRequired(e => e.Articulo)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<CatalogoISCBE>()
            //    .Property(e => e.Descripcion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CatalogoISCBE>()
            //    .Property(e => e.CodigoSunat)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CatalogoTributarioBE>()
            //    .Property(e => e.Descripcion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CatalogoTributarioBE>()
            //    .Property(e => e.CodigoSunat)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CatObsSunatBE>()
            //    .Property(e => e.Descripcion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CatObsSunatBE>()
            //    .Property(e => e.CodigoSunat)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ClienteBE>()
            //    .Property(e => e.Nombre)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ClienteBE>()
            //    .Property(e => e.Direccion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ClienteBE>()
            //    .Property(e => e.NumeroDocumento)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ClienteBE>()
            //    .HasMany(e => e.Venta)
            //    .WithRequired(e => e.Cliente)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<ConfiguracionCorreoBE>()
            //    .Property(e => e.DireccionCorreo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ConfiguracionCorreoBE>()
            //    .Property(e => e.NombreEnvio)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ConfiguracionCorreoBE>()
            //    .Property(e => e.UsuarioId)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ConfiguracionCorreoBE>()
            //    .Property(e => e.Contraseña)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ConfiguracionCorreoBE>()
            //    .Property(e => e.Servidor)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ConfiguracionCorreoBE>()
            //    .Property(e => e.Firma)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ConstanteMovimientoBE>()
            //    .Property(e => e.ValorMoney)
            //    .HasPrecision(19, 4);

            //modelBuilder.Entity<ConstanteMovimientoBE>()
            //    .Property(e => e.ValorCaracter)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ConstantesBE>()
            //    .Property(e => e.Descripcion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ConstantesBE>()
            //    .Property(e => e.Clave)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ConstantesBE>()
            //    .HasMany(e => e.ConstantesGrant)
            //    .WithRequired(e => e.Constantes)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<ConstantesGrantBE>()
            //    .Property(e => e.ValorMoney)
            //    .HasPrecision(19, 4);

            //modelBuilder.Entity<ConstantesGrantBE>()
            //    .Property(e => e.ValorCaracter)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ConstantesGrantBE>()
            //    .Property(e => e.Observaciones)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ConstantesGrantBE>()
            //    .HasMany(e => e.ConstanteMovimiento)
            //    .WithRequired(e => e.ConstantesGrant)
            //    .HasForeignKey(e => new { e.IdEmpresa, e.IdConstante })
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<CorrelativoDocumentoBE>()
            // .Property(e => e.NumSerie)
            // .IsUnicode(false);

            //modelBuilder.Entity<DepartamentoBE>()
            //    .Property(e => e.Descripcion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<DepartamentoBE>()
            //    .Property(e => e.Ubigeo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Departamento>()
            //    .HasMany(e => e.Provincia)
            //    .WithRequired(e => e.Departamento)
            //    .HasForeignKey(e => new { e.IdPais, e.IdDepartamento })
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<DistritoBE>()
            //    .Property(e => e.Descripcion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<DistritoBE>()
            //    .Property(e => e.Ubigeo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<DocumentoBE>()
            //    .Property(e => e.Siglas)
            //    .IsUnicode(false);

            //modelBuilder.Entity<DocumentoBE>()
            //    .Property(e => e.Descripcion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<DocumentoBE>()
            //    .Property(e => e.CodSunat)
            //    .IsUnicode(false);

            //modelBuilder.Entity<DocumentoBE>()
            //    .HasMany(e => e.CorrelativoDocumento)
            //    .WithRequired(e => e.Documento)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<DocumentoBE>()
            //    .HasMany(e => e.Venta)
            //    .WithRequired(e => e.Documento)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<DocumentoIdentidadBE>()
            //    .Property(e => e.Nombre)
            //    .IsUnicode(false);

            //modelBuilder.Entity<DocumentoIdentidadBE>()
            //    .HasMany(e => e.Cliente)
            //    .WithRequired(e => e.DocumentoIdentidad)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<DocumentoTributario>()
            //    .Property(e => e.Descripcion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<DocumentoTributario>()
            //    .Property(e => e.CodigoSunat)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ElementoAdicionalBE>()
            //    .Property(e => e.Descripcion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ElementoAdicionalBE>()
            //    .Property(e => e.CodigoSunat)
            //    .IsUnicode(false);

            //modelBuilder.Entity<EmpresaBE>()
            //    .Property(e => e.RazonSocial)
            //    .IsUnicode(false);

            //modelBuilder.Entity<EmpresaBE>()
            //    .Property(e => e.NumDocumento)
            //    .IsUnicode(false);

            //modelBuilder.Entity<EmpresaBE>()
            //    .Property(e => e.Direccion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<EmpresaBE>()
            //  .Property(e => e.UsuarioSunat)
            //  .IsUnicode(false);

            //modelBuilder.Entity<EmpresaBE>()
            //    .Property(e => e.ClaveSol)
            //    .IsUnicode(false);

            //modelBuilder.Entity<EmpresaBE>()
            //    .Property(e => e.NombreCertificado)
            //    .IsUnicode(false);

            //modelBuilder.Entity<EmpresaBE>()
            //    .Property(e => e.ClaveCertificado)
            //    .IsUnicode(false);

            //modelBuilder.Entity<EmpresaBE>()
            //    .Property(e => e.Resolucion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<EmpresaBE>()
            //    .HasMany(e => e.CorrelativoDocumento)
            //    .WithRequired(e => e.Empresa)
            //    .WillCascadeOnDelete(false);

            ////modelBuilder.Entity<EmpresaBE>()
            ////    .HasMany(e => e.Venta)
            ////    .WithRequired(e => e.Empresa)
            ////    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<EmpresaBE>()
            //   .HasMany(e => e.ConstantesGrant)
            //   .WithRequired(e => e.Empresa)
            //   .WillCascadeOnDelete(false);

            //modelBuilder.Entity<MotivoNotaBE>()
            //    .Property(e => e.Descripcion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<MotivoNotaBE>()
            //    .Property(e => e.CodigoSunat)
            //    .IsUnicode(false);

            //modelBuilder.Entity<PaisBE>()
            //    .Property(e => e.Nombre)
            //    .IsUnicode(false);

            //modelBuilder.Entity<PaisBE>()
            //    .Property(e => e.CodigoSunat)
            //    .IsUnicode(false);

            //modelBuilder.Entity<PaisBE>()
            //    .Property(e => e.CodigoNacionalidad)
            //    .IsUnicode(false);

            //modelBuilder.Entity<PaisBE>()
            //    .HasMany(e => e.Departamento)
            //    .WithRequired(e => e.Pais)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<ProvinciaBE>()
            //    .Property(e => e.Descripcion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<ProvinciaBE>()
            //    .Property(e => e.Ubigeo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Provincia>()
            //    .HasMany(e => e.Distrito)
            //    .WithRequired(e => e.Provincia)
            //    .HasForeignKey(e => new { e.IdProvincia, e.IdDepartamento, e.IdPais })
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<RegistroBE>()
            // .Property(e => e.NombresApellidos)
            // .IsUnicode(false);

            //modelBuilder.Entity<RegistroBE>()
            //    .Property(e => e.Empresa)
            //    .IsUnicode(false);

            //modelBuilder.Entity<RegistroBE>()
            //    .Property(e => e.RUC)
            //    .IsUnicode(false);

            //modelBuilder.Entity<RegistroBE>()
            //    .Property(e => e.Telefono)
            //    .IsUnicode(false);

            //modelBuilder.Entity<RegistroBE>()
            //    .Property(e => e.Correo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<RegistroBE>()
            //    .Property(e => e.CantidadEmpleados)
            //    .IsUnicode(false);

            //modelBuilder.Entity<RegistroBE>()
            //    .Property(e => e.VolumenFacturas)
            //    .IsUnicode(false);

            //modelBuilder.Entity<RegistroBE>()
            //    .Property(e => e.Observacion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TipoCliente>()
            //    .Property(e => e.Descripcion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TipoConstanteBE>()
            //    .Property(e => e.Descripcion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TipoConstanteBE>()
            //    .HasMany(e => e.Constantes)
            //    .WithRequired(e => e.TipoConstante)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<TipoMonedaBE>()
            //    .Property(e => e.Descripcion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TipoMonedaBE>()
            //    .Property(e => e.Simbolo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TipoMonedaBE>()
            //    .Property(e => e.CodigoSunat)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TipoMonedaBE>()
            //    .HasMany(e => e.Venta)
            //    .WithRequired(e => e.TipoMoneda)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<TipoOperacionBE>()
            //    .Property(e => e.Descripcion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TipoOperacionBE>()
            //    .Property(e => e.Siglas)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TipoOperacionBE>()
            //    .Property(e => e.CodigoSunat)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TipoPrecioVentaBE>()
            //    .Property(e => e.Descripcion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TipoPrecioVentaBE>()
            //  .HasMany(e => e.Venta)
            //  .WithRequired(e => e.TipoPrecioVenta)
            //  .WillCascadeOnDelete(false);

            //modelBuilder.Entity<UnidadMedidaBE>()
            //    .Property(e => e.SiglasUnidad)
            //    .IsUnicode(false);

            //modelBuilder.Entity<UnidadMedidaBE>()
            //    .Property(e => e.Descripcion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<UnidadMedidaBE>()
            //    .Property(e => e.CodigoSunat)
            //    .IsUnicode(false);

            //modelBuilder.Entity<UnidadMedidaBE>()
            //    .HasMany(e => e.Articulo)
            //    .WithRequired(e => e.UnidadMedida)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<MedioTransporteBE>()
            //  .Property(e => e.Nombre)
            //  .IsUnicode(false);

            //modelBuilder.Entity<PuertoBE>()
            //    .Property(e => e.Nombre)
            //    .IsUnicode(false);

        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        #region "Region: Connection and Transaction Handling"

        private static DbConnection connection;
        private static DbTransaction transaction;
        private static DbCommand command;
        private static ICollection<IDbConcurrency> entities;
        private static ICollection<IDbConcurrency2> entities2;

        public static void BeginTransaction(IsolationLevel isolationLevel)
        {
            if (transaction == null)
            {
                try
                {
                    connection = new MainContext().Database.Connection;
                    connection.Open();
                    transaction = connection.BeginTransaction(isolationLevel);
                    entities = new List<IDbConcurrency>();
                    entities2 = new List<IDbConcurrency2>();
                }
                catch
                {
                    ClearTransaction();
                    throw;
                }
            }
        }

        public static void BeginTransaction()
        {
            if (transaction == null)
            {
                try
                {
                    connection = new MainContext().Database.Connection;
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    entities = new List<IDbConcurrency>();
                    entities2 = new List<IDbConcurrency2>();
                }
                catch
                {
                    ClearTransaction();
                    throw;
                }
            }
        }

        public static void CommitTransaction()
        {
            if (transaction != null)
            {
                try
                {
                    transaction.Commit();
                    connection.Close();

                    foreach (IDbConcurrency entity in entities)
                        entity.RefreshToken();

                    foreach (IDbConcurrency2 entity2 in entities2)
                        entity2.RefreshToken();

                    ClearTransaction();
                }
                catch
                {
                    ClearTransaction();
                    throw;
                }
            }
        }

        public static void RollbackTransaction()
        {
            if (transaction != null)
            {
                try
                {
                    transaction.Rollback();
                    connection.Close();
                    ClearTransaction();
                }
                catch
                {
                    ClearTransaction();
                    throw;
                }
            }
        }

        private static void ClearTransaction()
        {
            //Aceramos transaccion
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }

            //Aceramos comando
            if (command != null)
            {
                command.Dispose();
                command = null;
            }

            //Aceramos conexion
            connection.Close();
            connection.Dispose();
            connection = null;

            //Aceramos entidades
            entities = null;
            entities2 = null;
        }

        public static int ExecuteNonQuery(DbCommand moCommand, IDbConcurrency entity = null, IDbConcurrency2 entity2 = null)
        {
            int result;
            try
            {
                //if(connection.State == ConnectionState.Closed)
                //    connection.Open();

                //command.Connection = connection;
                //command.CommandTimeout = MaxCommandTimeout;

                //
                command = moCommand; //Asignamos comando
                if (connection == null || connection.State == ConnectionState.Closed)
                    command.Connection.Open();
                else command.Connection = connection;

                command.CommandTimeout = MaxCommandTimeout;

                //

                if (transaction != null)
                    command.Transaction = transaction;

                result = command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                DbErrorLog.WriteLog(command, ex); //Registro de error técnico
                string errMsg = string.Empty;

                SqlError = ex.Number;
                switch (ex.Number)
                {
                    case (int)ESqlException.PrimaryKey:
                        errMsg = "Ya existe un registro con los mismos campos únicos." + Environment.NewLine;
                        break;
                    case (int)ESqlException.ForeignKey:
                        errMsg = "El registro que está siendo referenciado no se encuentra existente." + Environment.NewLine;
                        break;
                    default:
                        errMsg = ex.Message + Environment.NewLine;
                        break;
                }
                throw new SCOPException(errMsg);
            }

            if (entity != null || entity2 != null)
                if (result == 0)
                    throw new SCOPException("Los datos del documento han sido actualizados desde otro contexto o por otro usuario." + Environment.NewLine +
                                            "Por favor vuelva a cargar el documento e inténtelo de nuevo.");
                else if (transaction == null)
                {
                    if (entity != null) entity.RefreshToken();
                    if (entity2 != null) entity2.RefreshToken();
                }
                else
                {
                    if (entity != null) entities.Add(entity);
                    if (entity2 != null) entities2.Add(entity2);
                }

            return result;
        }

        public static DataTable ExecuteDataTable(DbCommand moCommand)
        {
            try
            {
                command = moCommand; //Asignamos comando
                if (connection == null)
                    command.Connection.Open();
                else command.Connection = connection;

                command.CommandTimeout = MaxCommandTimeout;
                if (transaction != null)
                    command.Transaction = transaction;

                DataTable dtResult = new DataTable();
                using (IDataReader reader = command.ExecuteReader())
                    dtResult.Load(reader);

                //Aceramos variables
                ClearConnection();

                return dtResult;
            }
            catch (DbException ex)
            {
                DbErrorLog.WriteLog(command, ex);
                ClearConnection(); //Aceramos variables
                throw;
            }
        }

        public static IDataReader ExecuteReader(DbCommand moCommand)
        {
            try
            {
                command = moCommand; //Asignamos comando
                if (connection == null)
                    command.Connection.Open();
                else command.Connection = connection;

                command.CommandTimeout = MaxCommandTimeout;

                if (transaction != null)
                    command.Transaction = transaction;

                return command.ExecuteReader();
            }
            catch (DbException ex)
            {
                DbErrorLog.WriteLog(command, ex);
                ClearConnection(); //Aceramos variables
                throw;
            }
        }

        public static object ExecuteScalar(DbCommand moCommand)
        {
            try
            {
                command = moCommand; //Asignamos comando
                if (connection == null)
                    command.Connection.Open();
                else command.Connection = connection;

                command.CommandTimeout = MaxCommandTimeout;

                if (transaction != null)
                    command.Transaction = transaction;

                object scalar = command.ExecuteScalar();

                //Aceramos variables
                ClearConnection();

                return scalar;
            }
            catch (DbException ex)
            {
                DbErrorLog.WriteLog(command, ex);
                ClearConnection(); //Aceramos variables
                throw;
            }
        }

        public static void ClearConnection()
        {
            //Aceramos variables
            if (command != null)
            {
                //Aceramos Transaccion
                if (command.Transaction != null)
                {
                    command.Transaction.Dispose();
                    command.Transaction = null;
                }

                //Aceramos Conexion
                if (command.Connection != null)
                {
                    command.Connection.Close();
                    command.Connection.Dispose();
                    command.Connection = null;
                }

                command.Dispose();
                command = null;
            }
        }

        public static DateTime ServerDate
        {
            get
            {
                try
                {
                    DbCommand command = new MainContext().Database.Connection.CreateCommand();
                    command.CommandText = "SELECT GETDATE()";
                    command.CommandType = CommandType.Text;

                    return Convert.ToDateTime(ExecuteScalar(command));
                }
                catch
                {
                    return DateTime.Now;
                }
            }
        }

        #endregion

        #region: Administracion de datos de auditoria
        public static void SetFechaAudit(IAuditDate entity)
        {
            if (entity.FechaCreacion == DateTime.MinValue) //Insercion
                entity.FechaCreacion = MainContext.ServerDate;
            else //Actualizacion
                entity.FechaModificacion = MainContext.ServerDate;
        }

        public static bool ValidConcurrency(IDbConcurrency2 entityNew, IDbConcurrency2 entityOld)
        {
            return entityNew.UpdateToken == entityOld.UpdateToken;
        }

        #endregion
    }
}
