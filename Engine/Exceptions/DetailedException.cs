using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engine.Exceptions
{
    public class DetailedException : Exception
    {
        /// <summary>
        /// The base user exception type handled by the middleware
        /// </summary>
        /// <param name="location"></param>
        /// <param name="code"></param>
        /// <param name="jsonData"></param>
        /// <param name="originalException"></param>
        public DetailedException(string location, int code, string jsonData, Exception originalException)
        {
            LocationCodePairs = new KeyValuePair<string, int>(location, code);
            JsonData = jsonData;
            OriginalException = originalException;
        }

        public string JsonData { get; }
        public KeyValuePair<string, int> LocationCodePairs { get; set; }
        public Exception OriginalException { get; }
    }
}
