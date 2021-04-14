using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Engine.Exceptions
{
    public class ErrorSummary
    {
        public ErrorSummary()
        {
            Errors = new List<ErrorDetails>();
        }
        /// <summary>
        /// gbg-correlation-id
        /// </summary>
        public string CorrelationId { get; set; }
        /// <summary>
        /// An informative message
        /// </summary>
        public object Response { get; set; }
        /// <summary>
        /// the errors
        /// </summary>
        public List<ErrorDetails> Errors { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

    }
}