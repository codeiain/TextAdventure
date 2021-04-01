using MongoDB.Bson.Serialization.Attributes;

namespace CartridgeServer.Models
{
    public class Condition
    {
        [BsonElement("type")]
        public string Type { get; set; }
        [BsonElement("left")]
        public string Left { get; set; }
        [BsonElement("right")]
        public string Right { get; set; }
        [BsonElement("symbol")]
        public string Symbol { get; set; }
        [BsonElement("room")]
        public string Room { get; set; }
        [BsonElement("id")]
        public string Id { get; set; }
    }
}