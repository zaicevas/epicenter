using System;
using System.IO;
using WebApplication1.Infrastructure.Extensions;
using WebApplication1.Infrastructure.Debugging.Abstract;

namespace WebApplication1.Infrastructure.Debugging
{
    public class FileLogger : ILogger, IDisposable
    {
        private static Lazy<FileLogger> _mainLogger = new Lazy<FileLogger>(() => new FileLogger("main_log.log"));
        public static FileLogger MainLogger
        {
            get
            {
                return _mainLogger.Value;
            }
        }

        private string _fileName;
        private Lazy<StreamWriter> _streamWriter;
        private StreamWriter Writer
        {
            get
            {
                try
                {
                    return _streamWriter.Value;
                }
                catch (IOException e)
                {
                    MainLogger.Log(LogType.ERROR, e.Message);
                }
                return null;
            }
        }

        public FileLogger(string fileName)
        {
            _fileName = fileName;
            _streamWriter = new Lazy<StreamWriter>(() => new StreamWriter(_fileName));
        }

        public void Log(LogType type, string message)
        {
            string messageType = nameof(type);
            string time = DateTime.Now.GetFormattedDateAndTime();
            if (Writer != null)
                Writer.WriteLine($"[{messageType}] [{time}]: {message}");
        }

        public void Dispose()
        {
            Writer.Dispose();
        }
    }
}
