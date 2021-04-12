using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Models
{
    public class Subitem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ItemDestination Destination { get; set; }
        public List<Trigger> Triggers { get; set; }
        public List<Stats> Statses { get; set; }

    }
}