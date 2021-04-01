using MongoDB.Bson.Serialization.Attributes;

namespace CartridgeServer.Models
{
    public class Conditionals
    {
        [BsonElement("haslight")]
        public string Haslight { get; set; }
    }
}