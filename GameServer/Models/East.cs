using System.Text.Json.Serialization;

namespace GameServer.Models
{
    public class East
    {
        [JsonPropertyName("node")]
        public string Node { get; set; }

        [JsonPropertyName("distance")]
        public int Distance { get; set; }
    }
}