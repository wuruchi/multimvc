using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DataConsulting.Multimedia.Entidades;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.ModelConfiguration;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataConsulting.Multimedia.Negocio.Contexto
{
    public partial class MainContextSCOP : DbContext
    {
        public const int MaxCommandTimeout = 3600;
        public static int SqlError;
        public static string InternalConectionString;

        public static string NombreCadena = string.Empty;

        //public static void CargarCadena(string moNombreCadena)
        //{
        //    NombreCadena = "name=" + moNombreCadena;
        //}

        public MainContextSCOP()
            : base(NombreCadena)
        {
            InternalConectionString = Database.Connection.ConnectionString;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        #region "Region: Connection and Transaction Handling"

        private static DbConnection connection;
        private static DbTransaction transaction;
        private static ICollection<IDbConcurrency> entities;
        private static ICollection<IDbConcurrency2> entities2;

        public static void BeginTransaction(IsolationLevel isolationLevel)
        {
            if (transaction == null)
            {
                try
                {
                    connection = new MainContextSCOP().Database.Connection;
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
                    connection = new MainContextSCOP().Database.Connection;
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
            connection.Close();
            entities = null; entities2 = null;
            transaction = null;
            connection = null;
        }

        public static int ExecuteNonQuery(DbCommand command, IDbConcurrency entity = null, IDbConcurrency2 entity2 = null)
        {
            int result;
            try
            {
                //if(connection.State == ConnectionState.Closed)
                //    connection.Open();

                //command.Connection = connection;
                //command.CommandTimeout = MaxCommandTimeout;

                //
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
                //DbErrorLog.WriteLog(command, ex); //Registro de error técnico
                string errMsg = string.Empty;

                SqlError = ex.Number;
                switch (ex.Number)
                {
                    case (int)ESqlException.PrimaryKey:
                        errMsg = "Ya existe un registro con el mismo código o nombre." + Environment.NewLine;
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

        public static DataTable ExecuteDataTable(DbCommand command)
        {
            try
            {
                if (connection == null)
                    command.Connection.Open();
                else command.Connection = connection;

                command.CommandTimeout = MaxCommandTimeout;
                if (transaction != null)
                    command.Transaction = transaction;

                DataTable dtResult = new DataTable();
                using (IDataReader reader = command.ExecuteReader())
                    dtResult.Load(reader);

                command.Connection.Dispose();

                return dtResult;
            }
            catch (DbException ex)
            {
                //DbErrorLog.WriteLog(command, ex);
                throw;
            }
        }

        public static IDataReader ExecuteReader(DbCommand command)
        {
            try
            {
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
                //DbErrorLog.WriteLog(command, ex);
                throw;
            }
        }

        public static object ExecuteScalar(DbCommand command)
        {
            try
            {
                if (connection == null)
                    command.Connection.Open();
                else command.Connection = connection;

                command.CommandTimeout = MaxCommandTimeout;

                if (transaction != null)
                    command.Transaction = transaction;

                return command.ExecuteScalar();
            }
            catch (DbException ex)
            {
                //DbErrorLog.WriteLog(command, ex);
                throw;
            }
        }

        public static DateTime ServerDate
        {
            get
            {
                try
                {
                    DbCommand command = new MainContextSCOP().Database.Connection.CreateCommand();
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
                entity.FechaCreacion = MainContextSCOP.ServerDate;
            else //Actualizacion
                entity.FechaModificacion = MainContextSCOP.ServerDate;
        }

        public static bool ValidConcurrency(IDbConcurrency2 entityNew, IDbConcurrency2 entityOld)
        {
            return entityNew.UpdateToken == entityOld.UpdateToken;
        }

        #endregion
    }
}
