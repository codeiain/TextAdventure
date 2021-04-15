using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Logger
{
    public interface ILogWrapper

    {
        ILogger GetLogger(object obj);

        ILogger GetLogger<T>();

        void SetContextValue(params KeyValuePair<string, object>[] values);

        void SetContextValue(string key, object value);
        void UnsetContextValue(string key);

        void SetLogLevel(string logLevel);
    }
}
