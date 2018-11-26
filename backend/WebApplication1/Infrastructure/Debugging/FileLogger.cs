using System;
using System.IO;
using WebApplication1.Infrastructure.Extensions;
using WebApplication1.Infrastructure.Debugging.Abstract;
using WebApplication1.Models;

namespace WebApplication1.Infrastructure.Debugging
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
                string time = DateTime.Now.GetFormattedDateAndTime();
                try
                {
                    _writer = new StreamWriter(_mainLogFileName);
                    _writer.WriteLine($"[{messageType}][{time}]: {message}");
                }
                catch(Exception e) {
                    var a = e;
                }
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
                Writer = new StreamWriter(_fileName);
            }
            catch (IOException e)
            {
                MainLogger.Log(LogType.ERROR, e.Message);
            }
        }

        public void Log(LogType type, string message)
        {
            string messageType = Enum.GetName(typeof(LogType), type);
            string time = DateTime.Now.GetFormattedDateAndTime();
            if (Writer != null)
                Writer.WriteLine($"[{messageType}][{time}]: {message}");
        }

        public void Dispose()
        {
            Writer.Dispose();
        }
    }
}
