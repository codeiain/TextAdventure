using System.Text.Json.Serialization;

namespace GameServer.Models
{
    public class Trigger
    {
        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("effect")]
        public Effect Effect { get; set; }

        [JsonPropertyName("target")]
        public Target Target { get; set; }
    }
}