using System.Collections.Generic;

namespace Models
{
    public class Item
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public List<Trigger> Triggers { get; set; }
        public ItemDestination Destination { get; set; }
        public List<Subitem> Subitems { get; set; }
        public ItemType Type { get; set; }
        public List<Stats> Statses { get; set; }
    }
}