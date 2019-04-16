using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Multimedia.Entidades
{
    public static class ErrorLog
    {
        public static void WriteLog(string Message, Exception Error)
        {
            WriteLog(Message, Error, null);
        }

        public static void WriteLog(string Message, Exception Error, DbContext DbContext)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "\\LogError.txt", true))
                {
                    sw.WriteLine("---------------------------------------------------------------");
                    sw.WriteLine("Error DataConsulting.Facturacion.Negocio.Contexto");
                    sw.WriteLine("Message: " + Message);
                    sw.WriteLine("Date: " + DateTime.Now);
                    sw.WriteLine("Source: " + Error.Source);
                    sw.WriteLine("GetType: " + Error.GetType().ToString());
                    sw.WriteLine("Error Message: " + Error.Message.ToString());
                    if (DbContext != null)
                        sw.WriteLine("ConecctionString: " + DbContext.Database.Connection.ConnectionString);
                }
            }
            catch
            {

            }
        }
    }
}
