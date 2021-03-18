using System.Text.Json.Serialization;
using GameServer.Models;

public abstract class WinCondition
{
    [JsonPropertyName("source")]
    public string Source { get; set; }

    [JsonPropertyName("condition")]
    public Condition Condition { get; set; }
}