using static WebApplication1.Models.Log;

namespace WebApplication1.Infrastructure.Loggers.Abstract
{
    interface ILogger
    {
        void Log(LoggableEntity identifiedEntity, int identifiedEntityID);
    }
}
