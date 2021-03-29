using System.Text.Json.Serialization;

namespace GameApiServer.Models
{
    public class Target
    {
        [JsonPropertyName("room")]
        public string Room { get; set; }

        [JsonPropertyName("exit")]
        public string Exit { get; set; }
    }
}