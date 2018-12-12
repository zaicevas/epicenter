using System;
using System.IO;
using Epicenter.Infrastructure.Debugging.Abstract;
using Epicenter.Infrastructure.Extensions;

namespace Epicenter.Infrastructure.Debugging
{
    public class FileLogger : ILogger, IDisposable
    {
        private readonly string _fileName;
        private StreamWriter Writer { get; }
        private Lazy<FailLogger> _mainLogger = new Lazy<FailLogger>(() => new FailLogger());
        private FailLogger MainLogger
        {
            get
            {
                return _mainLogger.Value;
            }
        }

        private class FailLogger : ILogger
        {
            // If we for some reason can't log, let's try to log the fact that we can't log!
            private static readonly string _mainLogFileName = AppSettings.Configuration.MainLogFileName;
            StreamWriter _writer;
            public void Log(LogType type, string message)
            {
                string messageType = Enum.GetName(typeof(LogType), type);
                string time = DateTime.UtcNow.ToUTC2().GetFormattedDateAndTime();
                try
                {
                    _writer = new StreamWriter(_mainLogFileName);
                    _writer.WriteLine($"[{messageType}][{time}]: {message}");
                }
                catch{ }
                finally
                {
                    _writer.Dispose();
                }
            }
        }

        public FileLogger(string fileName)
        {
            _fileName = fileName;
            try
            {
                new System.IO.DirectoryInfo("Logs").Create();
                Writer = new StreamWriter(_fileName);
            }
            catch (IOException e)
            {
                Writer = StreamWriter.Null;
                MainLogger.Log(LogType.ERROR, e.Message);
            }
        }

        public void Log(LogType type, string message)
        {
            string messageType = Enum.GetName(typeof(LogType), type);
            string time = DateTime.UtcNow.ToUTC2().GetFormattedDateAndTime();
            Writer.WriteLine($"[{messageType}][{time}]: {message}");
        }

        public void Dispose()
        {
            Writer.Dispose();
        }
    }
}
