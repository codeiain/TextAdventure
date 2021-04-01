using System;
using System.Collections.Generic;
using CartridgeServer.DTO;
using MongoDB.Bson.Serialization.Attributes;

namespace CartridgeServer.Models
{

    [BsonCollection("cartridge")]
    public class CartridgeModel : Document
    {
        public string GameId { get; set; }
        public string Name { get; set; }
        
        [BsonElement("graph")]
        public List<Graph> Graph { get; set; }
        public Game Game { get; set; }
        public List<Room> Rooms { get; set; }

        public CartridgeModel()
        {
            Graph = new List<Graph>();
            Rooms = new List<Room>();
        }
    }
}