using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace CartridgeServer.Models
{
    public class Room
    {
        [BsonElement("name")] public string Name { get; set; }
        [BsonElement("description")] public Description Description { get; set; }
        [BsonElement("items")] public List<Item> Items { get; set; }
        [BsonElement("exits")] public Exits Exits { get; set; }
        [BsonElement("npcs")] public List<Npc> Npcs { get; set; }
    }
}