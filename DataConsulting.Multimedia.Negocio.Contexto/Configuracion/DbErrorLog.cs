using System;
using System.IO;
using System.Data;
using System.Data.Common;

namespace DataConsulting.Multimedia.Negocio.Contexto
{
    internal class DbErrorLog
    {
        public static void WriteLog(DbCommand oDbCommand, DbException DbError)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "\\DbLogError.txt", true))
                {
                    sw.WriteLine("---------------------------------------------------------------");
                    sw.WriteLine("Error DataConsulting.Facturacion.Negocio.Contexto");
                    sw.WriteLine("Command: " + oDbCommand.CommandText);
                    sw.WriteLine("Date: " + DateTime.Now);
                    sw.WriteLine("Source: " + DbError.Source.ToString());
                    sw.WriteLine("GetType: " + DbError.GetType().ToString());
                    sw.WriteLine("ErrorCode: " + DbError.ErrorCode.ToString());
                    sw.WriteLine("Message: " + DbError.Message.ToString());

                    foreach (DbParameter Param in oDbCommand.Parameters)
                    {
                        sw.WriteLine("ParameterName: " + Param.ParameterName + " = " + Param.Value.ToString()
                            + ", DbType: " + Param.DbType.ToString()
                            + ", Direction: " + Param.Direction.ToString()
                            + ", Size: " + Param.Size.ToString());
                    }
                }
            }
            catch
            {

            }
        }
    }
}
