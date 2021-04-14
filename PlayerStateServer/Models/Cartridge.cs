using System.Collections.Generic;
using Models;
using PlayerStateServer.DTO;

namespace PlayerStateServer.Models
{
    [BsonCollection("cartridge")]
    public class Cartridge : Document
    {
        public string GameId { get; set; }
        public string Name { get; set; }
        public WinCondition WinCondition { get; set; }
        public LoseCondition LoseCondition { get; set; }
        public List<Graph> Graph { get; set; }
        public List<Location> Locations { get; set; }
    }
}