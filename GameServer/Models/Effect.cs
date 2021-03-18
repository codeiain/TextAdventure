using System.Text.Json.Serialization;

namespace GameServer.Models
{
    public class Effect
    {
        [JsonPropertyName("addStatus")]
        public string AddStatus { get; set; }

        [JsonPropertyName("target")]
        public string Target { get; set; }

        [JsonPropertyName("removeStatus")]
        public string RemoveStatus { get; set; }

        [JsonPropertyName("statusUpdate")]
        public string StatusUpdate { get; set; }
    }
}