using System.Text.Json.Serialization;

namespace GameServer.Models
{
    public class Target
    {
        [JsonPropertyName("room")]
        public string Room { get; set; }

        [JsonPropertyName("exit")]
        public string Exit { get; set; }
    }
}