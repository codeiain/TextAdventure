using MongoDB.Bson.Serialization.Attributes;

namespace CartridgeServer.Models
{
    public class Triggeraction
    {
        [BsonElement("action")]
        public string Action { get; set; }
        [BsonElement("target")]
        public string Target { get; set; }
    }
}