using System;
using System.Collections.Generic;

namespace Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Description Description { get; set; }
        public LocationType LocationType { get; set; }
        public List<Npc> Npcs { get; set; }
        public List<Item> Items { get; set; }
        public List<Exit> Exits { get; set; }
        
    }
}