using System.Collections.Generic;

namespace CartridgeServer.Models
{
    public class Room
    {
        public string Name { get; set; }
        public Description Description { get; set; }
        public List<Item> Items { get; set; }
        public Exits Exits { get; set; }
        public List<Npc> Npcs { get; set; }
    }
}