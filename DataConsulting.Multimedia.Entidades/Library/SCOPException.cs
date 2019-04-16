
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace DataConsulting.Multimedia.Entidades
{
	public class SCOPException : Exception
	{

		private string sExtraInfo;

		public SCOPException(string Message): this(Message, "")
		{
		}

		public SCOPException(string Message, string ExtraInfo) : base(Message)
		{
			sExtraInfo = ExtraInfo;
		}

		public string FullMessage
		{
			get
			{
				return Message + System.Environment.NewLine + sExtraInfo;
			}
		}

        public SCOPException(string Message, Exception Error)
            : this(Message, "")
        {
            ErrorLog.WriteLog(Message, Error, null);
        }

        public SCOPException(string Message, Exception Error, DbContext DbContext = null)
            : this(Message, "")
        {
            ErrorLog.WriteLog(Message, Error, DbContext);
        }
	}


} //end of root namespace