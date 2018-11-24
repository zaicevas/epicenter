using System;

namespace WebApplication1.Infrastructure.Utils
{
    public static class TimestampFormatter
    {
        public static string GetFormattedTimestamp(DateTime timestamp)
        {
            return timestamp.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
