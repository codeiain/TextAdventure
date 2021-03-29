using System.Text.Json.Serialization;

namespace GameApiServer.Models
{
    public class Npc
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("details")]
        public string Details { get; set; }

        [JsonPropertyName("stats")]
        public Stats Stats { get; set; }
    }
}