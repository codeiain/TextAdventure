using System.Text.Json.Serialization;

namespace GameApiServer.Models
{
    public class Game
    {
        // [JsonPropertyName("---win-condition")]
        // public WinCondition WinCondition { get; set; }

        [JsonPropertyName("win-condition")]
        public WinCondition WinCondition { get; set; }

        [JsonPropertyName("lose-condition")]
        public LoseCondition LoseCondition { get; set; }
    }
}