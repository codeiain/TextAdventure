using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using LogLevel = NLog.LogLevel;

namespace Logger
{
    public class NLogWrapper : ILogWrapper
    {
        private static readonly ConcurrentDictionary<string, ILogger> loggersDictionary =
            new ConcurrentDictionary<string, ILogger>();

        private readonly ILoggerFactory loggerFactory;

        public NLogWrapper(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            this.loggerFactory = loggerFactory;
        }

        public ILogger GetLogger<T>()
        {
            return loggersDictionary.GetOrAdd(typeof(T).FullName, loggerFactory.CreateLogger<T>());
        }


        /// <returns>Instance of a logger for the object.</returns>
        public ILogger GetLogger(object obj)
        {
            return loggersDictionary.GetOrAdd(obj?.ToString() ?? "", loggerFactory.CreateLogger(obj?.ToString() ?? ""));
        }


        public void SetContextValue(string key, object value)
        {
            MappedDiagnosticsLogicalContext.Set(key, value);
        }

        public void UnsetContextValue(string key)
        {
            MappedDiagnosticsLogicalContext.Remove(key);
        }

        public void SetContextValue(params KeyValuePair<string, object>[] values)
        {
            foreach (var pair in values) MappedDiagnosticsLogicalContext.Set(pair.Key, pair.Value);
        }

        public void SetLogLevel(string logLevel)
        {
            var level = LogLevel.FromString(logLevel);
            if (level == LogLevel.Off)
            {
                LogManager.DisableLogging();
            }
            else
            {
                if (!LogManager.IsLoggingEnabled()) LogManager.EnableLogging();
                foreach (var rule in LogManager.Configuration.LoggingRules)
                {
                    rule.DisableLoggingForLevels(LogLevel.Trace, LogLevel.Fatal);
                    // Iterate over all levels up to and including the target, (re)enabling them.
                    for (var i = level.Ordinal; i <= 5; i++)
                    {
                        rule.EnableLoggingForLevel(LogLevel.FromOrdinal(i));
                    }
                }
            }

            LogManager.ReconfigExistingLoggers();
        }
    }
}