using System.Collections.Generic;
using GameServer.Models;

namespace GameServer.DTO
{
    public class InventorySchema
    {
        public List<Item> Hands { get; set; }
        public List<Item> Bag { get; set; }
    }
}