using ServiceStack.Logging;

namespace Logging
{
    public interface IEnableLog
    { }

    public static class EnableLogMixins
    {
        public static void Log(this IEnableLog This, LogType type, object message, ILog logger = null)
        {
            logger = logger ?? LogManager.GetLogger(This.GetType());
            switch (type)
            {
                case LogType.Debug:
                    logger.Debug(message);
                    break;
                case LogType.Error:
                    logger.Error(message);
                    break;
                case LogType.Fatal:
                    logger.Fatal(message);
                    break;
                case LogType.Info:
                    logger.Info(message);
                    break;
                case LogType.Warn:
                    logger.Warn(message);
                    break;
            }
        }

        public static void Debug(this IEnableLog This, string message, ILog logger = null)
        {
            Log(This, LogType.Debug, message, logger);
        }
        public static void Info(this IEnableLog This, string message, ILog logger = null)
        {
            Log(This, LogType.Info, message, logger);
        }
        public static void LogFormat(this IEnableLog This, LogType type, string format, params object[] args)
        {
            LogFormat(This, LogManager.GetLogger(This.GetType()), type, format, args);
        }
        public static void LogFormat(this IEnableLog This, ILog logger, LogType type, string format, params object[] args)
        {
            switch (type)
            {
                case LogType.Debug:
                    logger.DebugFormat(format, args);
                    break;
                case LogType.Error:
                    logger.ErrorFormat(format, args);
                    break;
                case LogType.Fatal:
                    logger.FatalFormat(format, args);
                    break;
                case LogType.Info:
                    logger.InfoFormat(format, args);
                    break;
                case LogType.Warn:
                    logger.WarnFormat(format, args);
                    break;
            }
        }
    }
}
