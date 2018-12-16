using System;
using System.Globalization;

namespace Epicenter.Infrastructure.Extensions
{
    public static class StringExtentions
    {
        public static DateTime ParseToDateTime(this string timestamp)
        {
            return DateTime.ParseExact(timestamp, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public static byte[] ConvertToBytesOrDefault(this string base64, byte[] defaultArray)
        {
            try
            {
                return Convert.FromBase64String(base64);
            }
            catch
            {
                return defaultArray;
            }
        }
    }
}
