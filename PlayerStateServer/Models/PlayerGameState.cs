using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using PlayerStateServer.DTO;

namespace PlayerStateServer.Models
{
    [BsonCollection("PlayerGameState")]
    public class PlayerGameState : Document
    {
        public GameState Game { get; set; }
        public string PlayerName { get; set; }
        public string PlayerKey { get; set; }
        public string CurrentScene { get; set; }
        public int WalkedNorth { get; set; }
        public int WalkedSouth { get; set; }
        public int WalkedEast { get; set; }
        public int WalkedWest { get; set; }
        public int PlayerHp { get; set; }
        public Inventory Inventory { get; set; }
    }
}
