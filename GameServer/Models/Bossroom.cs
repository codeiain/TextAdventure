using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GameServer.Models
{
    public class Bossroom
    {
        [JsonPropertyName("description")]
        public Description Description { get; set; }

        [JsonPropertyName("npcs")]
        public List<Npc> Npcs { get; set; }
    }
}