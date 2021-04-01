using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace CartridgeServer.Models
{
    public class Item
    { 
        [BsonElement("id")]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("details")]
        public string Details { get; set; }
        [BsonElement("triggers")]
        public List<Trigger> Triggers { get; set; }
        [BsonElement("destination")]
        public string Destination { get; set; }
        [BsonElement("subitems")]
        public List<Subitem> Subitems { get; set; }
        [BsonElement("type")]
        public string Type { get; set; }
    }
}