using System;
using System.IO;
using ServiceStack.Logging;

namespace Logging
{
    public class FileLogFactory : ILogFactory
    {
        private readonly string _logName;
        private readonly bool _appendDate;
        private readonly bool _prependTimeToLogs;

        public FileLogFactory(string logName, bool appendDate = false, bool prependTimeToLogs = true)
        {
            _logName = logName;
            _appendDate = appendDate;
            _prependTimeToLogs = prependTimeToLogs;
        }

        public ILog GetLogger(Type type)
        {
            return GetLogger(type.ToString());
        }

        public ILog GetLogger(string typeName)
        {
            return new FileLogger(_logName, _appendDate,_prependTimeToLogs);
        }
    }
}