using MongoDB.Bson.Serialization.Attributes;

namespace CartridgeServer.Models
{
    public class Subtarget
    {
        [BsonElement("room")]
        public string Room { get; set; }
        [BsonElement("exit")]
        public string Exit { get; set; }
    }
}