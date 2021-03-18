using System.Text.Json.Serialization;

namespace GameServer.Models
{
    public class Triggeraction
    {
        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("target")]
        public string Target { get; set; }
    }
}