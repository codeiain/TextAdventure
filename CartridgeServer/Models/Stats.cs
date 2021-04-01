using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace CartridgeServer.Models
{
    public class Stats
    {
        [BsonElement("weaknesses")]
        public List<string> Weaknesses { get; set; }
        [BsonElement("damage")]
        public int Damage { get; set; }
    }
}