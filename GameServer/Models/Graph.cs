using System.Text.Json.Serialization;

namespace GameServer.Models
{
    public class Graph
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("north")]
        public North North { get; set; }

        [JsonPropertyName("south")]
        public South South { get; set; }

        [JsonPropertyName("east")]
        public East East { get; set; }

        [JsonPropertyName("west")]
        public West West { get; set; }
    }
}