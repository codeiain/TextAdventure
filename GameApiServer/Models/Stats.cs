using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GameApiServer.Models
{
    public class Stats
    {
        [JsonPropertyName("weaknesses")]
        public List<string> Weaknesses { get; set; }

        [JsonPropertyName("damage")]
        public int Damage { get; set; }
    }
}