using System;
using System.Collections.Generic;
using CartridgeServer.DTO;

namespace CartridgeServer.Models
{

    [BsonCollection("cartridge")]
    public class CartridgeModel : Document
    {
        public Guid GameId { get; set; }
        public string Name { get; set; }

        //public List<Graph> Graph { get; set; }
        //public Game Game { get; set; }
        //public List<Room> Rooms { get; set; }
    }
}