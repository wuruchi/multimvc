using DataConsulting.Multimedia.Negocio.Contexto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Multimedia.Negocio.Main.BusinessRules
{
    public class SeccionDA
    {

        internal static IDataReader GetSeccionById(int IdSeccion)
        {
            DbCommand command = new MainContext().Database.Connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "dbo.GetSeccionById";
            command.Parameters.Add(new SqlParameter("@IdSeccion", SqlDbType.Int) { Value = IdSeccion });

            return MainContext.ExecuteReader(command);
        }

    }
}
