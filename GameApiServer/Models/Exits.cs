using System.Text.Json.Serialization;

namespace GameApiServer.Models
{
    public class Exits
    {
        [JsonPropertyName("north")]
        public North North { get; set; }
    }
}