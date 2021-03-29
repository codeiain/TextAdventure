using System.Text.Json.Serialization;

namespace GameApiServer.Models
{
    public class Description
    {
        [JsonPropertyName("default")]
        public string Default { get; set; }

        [JsonPropertyName("conditionals")]
        public Conditionals Conditionals { get; set; }
    }
}