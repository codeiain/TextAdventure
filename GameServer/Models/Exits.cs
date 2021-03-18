using System.Text.Json.Serialization;
using GameServer.Models;

public class Exits
{
    [JsonPropertyName("north")]
    public North North { get; set; }
}