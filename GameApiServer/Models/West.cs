
using System.Text.Json.Serialization;

namespace GameApiServer.Models
{
    public class West
    {
        [JsonPropertyName("node")]
        public string Node { get; set; }

        [JsonPropertyName("distance")]
        public int Distance { get; set; }
    }
}