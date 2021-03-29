using System.Text.Json.Serialization;

namespace GameApiServer.Models
{
    public class East
    {
        [JsonPropertyName("node")]
        public string Node { get; set; }

        [JsonPropertyName("distance")]
        public int Distance { get; set; }
    }
}