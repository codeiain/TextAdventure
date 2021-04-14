using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engine.Exceptions
{
    public class ErrorDetails
    {
        /// <summary>
        /// The location of the issue which could be a JSON path, URI parameter, http-header or a query parameter
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// A unique code for this API that can be used to automate the handling of the issue
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// Describes the problem such as  a missing element or a malformed one
        /// </summary>
        public object Problem { get; set; }
        /// <summary>
        /// Possible action that could be undertaken to resolve the issue
        /// </summary>
        public string Action { get; set; }

    }
}
