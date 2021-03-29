using System.Text.Json.Serialization;

namespace GameApiServer.Models
{
    public class Triggeraction
    {
        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("target")]
        public string Target { get; set; }
    }
}