#nullable enable
using System.Collections.Generic;

namespace GameServer.Models
{
    public interface IRoom
    {
        public Description? Description { get; set; }
        public List<Item>? Items { get; set; }
        
        public List<Npc>? Npcs { get; set; }
        public Exits? Exits { get; set; }
        
    }
}