using System;

namespace WebApplication1.Infrastructure.Utils
{
    public static class DateAndTimeFormatter
    {
        public static string GetFormattedDateAndTime(DateTime timestamp)
        {
            return timestamp.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
