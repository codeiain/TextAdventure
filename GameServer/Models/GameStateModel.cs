using Microsoft.VisualBasic.CompilerServices;

namespace GameServer.Models
{
    public class GameStateModel : EntityBase
    {
        public string PlayerName { get; set; }
        public string PlayerKey { get; set; }
        public string CurrentScene { get; set; }
        public DateType CreationDate { get; set; }
        public int WalkedNorth { get; set; }
        public int WalkedSouth { get; set; }
        public int WalkedEast { get; set; }
        public int WalkedWest { get; set; }
        public int PlayerHp { get; set; }
        public InventoryModel Inventory { get; set; }
    }
}