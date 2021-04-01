using MongoDB.Bson.Serialization.Attributes;

namespace CartridgeServer.Models
{
    public class South
    {
        [BsonElement("node")]
        public string Node { get; set; }
        [BsonElement("distance")]
        public int Distance { get; set; }
    }
}