using System.Collections.Generic;

namespace GameServer.Models
{
    public class InventoryModel : EntityBase
    {
        public List<dynamic> Hands;
        public List<dynamic> Bag;
    }
}