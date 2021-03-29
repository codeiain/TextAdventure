using System;

namespace GameApiServer.DTO
{
    public class GameStateSchema : EntityBase
    {
        public GameSchema Game { get; set; }
        public string PlayerName { get; set; }
        public string PlayerKey { get; set; }
        public string CurrentScene { get; set; }
        public DateTime CreationData { get; set; }
        public int WalkedNorth { get; set; }
        public int WalkedSouth { get; set; }
        public int WalkedEast { get; set; }
        public int WalkedWest { get; set; }
        public int PlayerHp { get; set; }
        public InventorySchema Imventory { get; set; }
    }
}