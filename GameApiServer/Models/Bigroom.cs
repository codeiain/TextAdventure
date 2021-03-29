using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GameApiServer.Models
{
    public class Bigroom
    {
        [JsonPropertyName("description")]
        public Description Description { get; set; }

        [JsonPropertyName("exits")]
        public Exits Exits { get; set; }

        [JsonPropertyName("items")]
        public List<object> Items { get; set; }
    }
}