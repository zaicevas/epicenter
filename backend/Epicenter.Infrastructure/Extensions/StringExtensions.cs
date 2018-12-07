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
    }
}
