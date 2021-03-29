using System.Text.Json.Serialization;

namespace GameApiServer.Models
{
    public class Conditionals
    {
        [JsonPropertyName("haslight")]
        public string Haslight { get; set; }
    }
}