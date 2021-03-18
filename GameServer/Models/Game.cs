using System.Text.Json.Serialization;

namespace GameServer.Models
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