using System.Collections.Generic;
using GameApiServer.Models;

namespace GameApiServer.DTO
{
    public class InventorySchema
    {
        public List<Item> Hands { get; set; }
        public List<Item> Bag { get; set; }
    }
}