using System;

namespace DataConsulting.Multimedia.Entidades
{
    public static class DbConvert
    {
        public static object ToDBNull(byte value)
        {
            return value == 0 ? Convert.DBNull : value;
        }
        
        public static object ToDBNull(short value)
        {
            return value == 0 ? Convert.DBNull : value;
        }

        public static object ToDBNull(int value)
        {
            return value == 0 ? Convert.DBNull : value;
        }

        public static object ToDBNull(long value)
        {
            return value == 0 ? Convert.DBNull : value;
        }

        public static object ToDBNull(decimal value)
        {
            return value == 0m ? Convert.DBNull : value;
        }

        public static object ToDBNull(string value)
        {
            return value == null || value == string.Empty ? Convert.DBNull : value;
        }

        public static object ToDBNull(System.DateTime value)
        {
            return value == DateTime.MinValue ? Convert.DBNull : value;
        }

        public static int ToInt32(object value)
        {
            return Convert.IsDBNull(value) ? 0 : Convert.ToInt32(value);
        }

        public static byte ToByte(object value)
        {
            return Convert.IsDBNull(value) ? (byte)0 : Convert.ToByte(value);
        }

        public static string ToString(object value)
        {
            return Convert.IsDBNull(value) ? string.Empty : value.ToString();
        }

        public static decimal ToDecimal(object value)
        {
            return Convert.IsDBNull(value) ? 0m : Convert.ToDecimal(value);
        }

        public static DateTime ToDateTime(object value)
        {
            return Convert.IsDBNull(value) ? DateTime.MinValue : Convert.ToDateTime(value);
        }

        public static object ToDBNull(byte[] value)
        {
            return value == null ? Convert.DBNull : value;
        }
    }
}
