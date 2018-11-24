using System;
using WebApplication1.Infrastructure.Loggers.Abstract;
using WebApplication1.Infrastructure.Utils;
using WebApplication1.Models;
using WebApplication1.Repositories;
using static WebApplication1.Models.Log;

namespace WebApplication1.Infrastructure.Loggers
{
    public class DatabaseLogger : ILogger
    {
        private readonly LogRepository _logRepository;

        public DatabaseLogger(LogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public void Log(LoggableEntity identifiedEntity, int identifiedEntityID)
        {
            string timestamp = TimestampFormatter.GetFormattedTimestamp(DateTime.Now);
            _logRepository.Add(new Log { IdentifiedEntity = identifiedEntity, Timestamp = timestamp, IdentifiedEntityID = identifiedEntityID });
        }
    }
}
