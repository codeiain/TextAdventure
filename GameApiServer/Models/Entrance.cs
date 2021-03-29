using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GameApiServer.Models
{
    public class Entrance
    {
        [JsonPropertyName("description")]
        public Description Description { get; set; }

        [JsonPropertyName("items")]
        public List<Item> Items { get; set; }
    }
}