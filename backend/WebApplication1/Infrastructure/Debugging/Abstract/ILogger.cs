namespace WebApplication1.Infrastructure.Debugging.Abstract
{
    public interface ILogger
    {
        void Log(LogType type, string message);
    }
}
