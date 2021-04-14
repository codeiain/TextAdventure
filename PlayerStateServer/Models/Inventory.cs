using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace PlayerStateServer.Models
{
    public class Inventory
    {
        public Item Hand { get; set; }
        public List<Item> Bag { get; set; }
    }
}
