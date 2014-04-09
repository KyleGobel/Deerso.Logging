using System;
using System.IO;
using System.Text;
using ServiceStack.Logging;

namespace Logging
{
    public class FileLogger : ILog
    {
        private string _logName;
        private readonly bool _appendFileWithDate;
        private readonly bool _prependTimesToLogs;
        public const string DEBUG = "DEBUG: ";
        public const string ERROR = "ERROR: ";
        public const string WARN = "WARN: ";
        public const string INFO = "INFO: ";
        public const string FATAL = "FATAL: ";


        public FileLogger(string logName,bool appendFileWithDate, bool prependTimesToLogs)
        {
            _logName = logName;
            _appendFileWithDate = appendFileWithDate;
            _prependTimesToLogs = prependTimesToLogs;
        }

        private void Write(object message, Exception exception)
        {
            var sb = new StringBuilder();

            if (_prependTimesToLogs)
                sb.Append(DateTime.Now.ToString("u") + ": ");

            while (exception != null)
            {
                sb.Append(Environment.NewLine);
                sb.Append("Message: ").Append(exception.Message).Append(Environment.NewLine)
                    .Append("Source: ").Append(exception.Source).Append(Environment.NewLine)
                    .Append("Target site: ").Append(exception.TargetSite).Append(Environment.NewLine)
                    .Append("Stack trace: ").Append(exception.StackTrace).Append(Environment.NewLine);

                exception = exception.InnerException;
            }

            sb.Append(message);
            sb.Append(Environment.NewLine);

            var logName = _logName;
            if (_appendFileWithDate)
            {
                logName += "_" + DateTime.Now.ToString("yy-MM-dd");
            }
            if (!Directory.Exists(FileLogConfig.LogDirectory))
                Directory.CreateDirectory(FileLogConfig.LogDirectory);
            File.AppendAllText(Path.Combine(FileLogConfig.LogDirectory, logName + FileLogConfig.LogExtension), sb.ToString());
        }
        public void Debug(object message)
        {
            Write(DEBUG + message, null);
        }

        public void Debug(object message, Exception exception)
        {
            Write(DEBUG + message, exception);
        }

        public void DebugFormat(string format, params object[] args)
        {
            Write(DEBUG + string.Format(format, args), null);
        }

        public void Error(object message)
        {
            Write(ERROR + message, null);
        }

        public void Error(object message, Exception exception)
        {
            Write(ERROR + message, exception);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            Write(ERROR + string.Format(format, args), null);
        }

        public void Fatal(object message)
        {
            Write(FATAL + message, null);
        }

        public void Fatal(object message, Exception exception)
        {
            Write(FATAL + message, exception);
        }

        public void FatalFormat(string format, params object[] args)
        {
            Write(FATAL + string.Format(format, args),null);
        }

        public void Info(object message)
        {
            Write(INFO + message, null);
        }

        public void Info(object message, Exception exception)
        {
            Write(INFO + message, exception);
        }

        public void InfoFormat(string format, params object[] args)
        {
            Write(INFO + string.Format(format, args), null);
        }

        public void Warn(object message)
        {
            Write(WARN + message,null);
        }

        public void Warn(object message, Exception exception)
        {
            Write(WARN + message, exception);
        }

        public void WarnFormat(string format, params object[] args)
        {
            Write(WARN + string.Format(format, args),null);
        }

        public bool IsDebugEnabled { get { return true; } }
    }
}