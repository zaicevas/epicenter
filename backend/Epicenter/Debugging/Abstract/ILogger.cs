namespace Epicenter.Debugging.Abstract
{
    public interface ILogger
    {
        void Log(LogType type, string message);
    }
}
