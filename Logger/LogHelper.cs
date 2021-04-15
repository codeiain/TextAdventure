using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Logger
{
    public static class LogHelper

    {
        private static readonly ILogWrapper logWrapper;
        private static readonly string logLevel;

        static LogHelper()
        {
            logWrapper = new NLogWrapper(new LoggerFactory());
        }

        public static ILogger Log<T>(this T type)
        {
            return logWrapper.GetLogger<T>();
        }

        /// <returns>Instance of a logger for the object.</returns>
        public static ILogger Log(this object obj)
        {
            return logWrapper.GetLogger(obj?.ToString() ?? "");
        }


        public static void SetContextValue(string key, object value)
        {
            logWrapper.SetContextValue(key, value);
        }

        public static void UnSetContextValue(string key)
        {
            logWrapper.UnsetContextValue(key);
        }
        public static void SetContextValue(Dictionary<string, object> values)
        {
            foreach (var pair in values) logWrapper.SetContextValue(pair.Key, pair.Value);
        }

        public static void SetLogLevel(string logLevel)
        {
            logWrapper.SetLogLevel(logLevel);
        }
    }
}