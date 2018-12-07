using System;

namespace Epicenter.Extensions
{
    public static class DateTimeExtentions
    {
        public static string GetFormattedDateAndTime(this DateTime timestamp)
        {
            return timestamp.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static DateTime ToUTC2(this DateTime timestamp)
        {
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("E. Europe Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(timestamp, timeZoneInfo);
        }
    }
}