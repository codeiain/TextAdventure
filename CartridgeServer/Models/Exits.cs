using MongoDB.Bson.Serialization.Attributes;

namespace CartridgeServer.Models
{
    public class Exits
    {
        [BsonElement("north")]
        public North North { get; set; }
    }
}