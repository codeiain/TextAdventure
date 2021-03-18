using System.Text.Json.Serialization;

namespace GameServer.Models
{
    public class LoseCondition
    {
        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("condition")]
        public Condition Condition { get; set; }
    }
}