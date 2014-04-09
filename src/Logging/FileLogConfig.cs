using System;

namespace Logging
{
    public class FileLogConfig
    {
        public Lazy<FileLogConfig> Instance = new Lazy<FileLogConfig>(() => new FileLogConfig());

        static FileLogConfig()
        {
            LogDirectory = "Logs";
            LogExtension = ".log";
        }
        private FileLogConfig(){}
        public static string LogDirectory { get; set; }
        public static string LogExtension { get; set; }
    }
}