using System.Text.Json.Serialization;

namespace GameApiServer.Models
{
    public class North
    {
        [JsonPropertyName("node")]
        public string Node { get; set; }

        [JsonPropertyName("distance")]
        public int Distance { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("details")]
        public string Details { get; set; }
    }
}