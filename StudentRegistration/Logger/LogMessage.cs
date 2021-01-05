using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace StudentRegistration.Logger
{
    public  sealed class LogMessage
    {
        public enum LogType
        {
            Info,
            Warning,
            Error,
            Ok
        }
        static object lockObj = new object();
        private static LogMessage _logger;
        public static LogMessage LoggerInstance
        {
            get
            {
                lock (lockObj)
                {
                    if (_logger == null)
                    {
                        _logger = new LogMessage();
                    }
                    return _logger;
                }
            }
        }
        private LogMessage()
        {
        }

        static int count;
        string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).
            Parent.Parent.FullName, "LogFile.txt");
        public void Log(LogType logType, string message)
        {
            using (var sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{++count} - {DateTime.Now} - {logType} - {message}");
            }
        }
    }
}
