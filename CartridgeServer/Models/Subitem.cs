using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace CartridgeServer.Models
{
    public class Subitem
    {
        [BsonElement("id")]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("triggerActions")]
        public List<Triggeraction> Triggeractions { get; set; }
        [BsonElement("destination")]
        public string Destination { get; set; }
        [BsonElement("damage")]
        public int Damage { get; set; }
    }
}