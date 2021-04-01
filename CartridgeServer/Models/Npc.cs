using MongoDB.Bson.Serialization.Attributes;

namespace CartridgeServer.Models
{
    public class Npc
    {
        [BsonElement("id")]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("details")]
        public string Details { get; set; }
        [BsonElement("stats")]
        public Stats Stats { get; set; }
    }
}