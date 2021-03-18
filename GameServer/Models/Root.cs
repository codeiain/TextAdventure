using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GameServer.Models
{
    public class Root
    {
        [JsonPropertyName("graph")]
        public List<Graph> Graph { get; set; }

        [JsonPropertyName("game")]
        public Game Game { get; set; }

        [JsonPropertyName("rooms")]
        public Rooms Rooms { get; set; }
    }
}