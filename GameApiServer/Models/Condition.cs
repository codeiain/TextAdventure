using System.Text.Json.Serialization;

namespace GameApiServer.Models
{
    public class Condition
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("left")]
        public string Left { get; set; }

        [JsonPropertyName("right")]
        public string Right { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("room")]
        public string Room { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}