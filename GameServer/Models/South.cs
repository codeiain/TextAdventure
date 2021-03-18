using System.Text.Json.Serialization;

namespace GameServer.Models
{
    public class South
    {
        [JsonPropertyName("node")]
        public string Node { get; set; }

        [JsonPropertyName("distance")]
        public int Distance { get; set; }
    }
}