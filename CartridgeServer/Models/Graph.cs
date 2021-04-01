using MongoDB.Bson.Serialization.Attributes;

namespace CartridgeServer.Models
{
    public class Graph
    {
        [BsonElement("id")] public string id { get; set; }
        [BsonElement("Name")] public string Name { get; set; }
        [BsonElement("north")] public North North { get; set; }
        [BsonElement("south")] public South South { get; set; }
        [BsonElement("east")] public East East { get; set; }
        [BsonElement("west")] public West West { get; set; }
    }
}