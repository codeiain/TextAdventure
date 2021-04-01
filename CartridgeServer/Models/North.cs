using MongoDB.Bson.Serialization.Attributes;

namespace CartridgeServer.Models
{
    public class North
    {
        [BsonElement("node")]
        public string Node { get; set; }
        [BsonElement("distance")]
        public int Distance { get; set; }
        [BsonElement("id")]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("status")]
        public string Status { get; set; }
        [BsonElement("details")]
        public string Details { get; set; }
    }
}