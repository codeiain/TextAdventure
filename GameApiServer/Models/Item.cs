using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GameApiServer.Models
{
    public class Item
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("details")]
        public string Details { get; set; }

        [JsonPropertyName("triggers")]
        public List<Trigger> Triggers { get; set; }

        [JsonPropertyName("destination")]
        public string Destination { get; set; }

        [JsonPropertyName("subitems")]
        public List<Subitem> Subitems { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}