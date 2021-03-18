using System.Text.Json.Serialization;

namespace GameServer.Models
{
    public class WinCondition2
    {
        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("condition")]
        public Condition Condition { get; set; }
    }
}