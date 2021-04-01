using MongoDB.Bson.Serialization.Attributes;

namespace CartridgeServer.Models
{
    public class Description
    {
        [BsonElement("default")]
        public string Default { get; set; }
        [BsonElement("conditionals")]
        public Conditionals Conditionals { get; set; }
    }
}