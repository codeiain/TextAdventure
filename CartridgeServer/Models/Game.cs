using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace CartridgeServer.Models
{
    public class Game
    {
        [JsonProperty("---win-condition")]
        [BsonElement("---win-condition")]
        public WinCondition WinCondition { get; set; }

        //[JsonProperty("win-condition")]
        //public WinCondition WinCondition { get; set; }

        [JsonProperty("lose-condition")]
        [BsonElement("lose-condition")]
        public LoseCondition LoseCondition { get; set; }
    }
}