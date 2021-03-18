using System.Text.Json.Serialization;

namespace GameServer.Models
{
    public class Conditionals
    {
        [JsonPropertyName("haslight")]
        public string Haslight { get; set; }
    }
}