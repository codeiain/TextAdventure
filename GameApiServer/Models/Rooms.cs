using System.Text.Json.Serialization;

namespace GameApiServer.Models
{
    public class Rooms
    {
        [JsonPropertyName("entrance")]
        public Entrance Entrance { get; set; }

        [JsonPropertyName("1stroom")]
        public _1stroom _1stroom { get; set; }

        [JsonPropertyName("bigroom")]
        public Bigroom Bigroom { get; set; }

        [JsonPropertyName("leftwing")]
        public Leftwing Leftwing { get; set; }

        [JsonPropertyName("rightwing")]
        public Rightwing Rightwing { get; set; }

        [JsonPropertyName("bossroom")]
        public Bossroom Bossroom { get; set; }
    }
}