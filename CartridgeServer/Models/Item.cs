using System.Collections.Generic;

namespace CartridgeServer.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public List<Trigger> Triggers { get; set; }
        public string Destination { get; set; }
        public List<Subitem> Subitems { get; set; }
        public string Type { get; set; }
    }
}