using System.Collections.Generic;

namespace Models
{
    public class Npc
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public List<Stats> Stats { get; set; }
    }
}