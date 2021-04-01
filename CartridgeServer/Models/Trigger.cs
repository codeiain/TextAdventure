using MongoDB.Bson.Serialization.Attributes;

namespace CartridgeServer.Models
{
    public class Trigger
    {
        [BsonElement("action")]
        public string Action { get; set; }
        [BsonElement("effect")]
        public Effect Effect { get; set; }
        [BsonElement("target")]
        public string Target { get; set; }
        [BsonElement("sub")]
        public Subtarget Sub { get; set; }
    }
}