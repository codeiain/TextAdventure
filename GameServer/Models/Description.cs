using System.Text.Json.Serialization;

namespace GameServer.Models
{
    public class Description
    {
        [JsonPropertyName("default")]
        public string Default { get; set; }

        [JsonPropertyName("conditionals")]
        public Conditionals Conditionals { get; set; }
    }
}