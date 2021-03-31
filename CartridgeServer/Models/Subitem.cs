using System.Collections.Generic;

namespace CartridgeServer.Models
{
    public class Subitem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Triggeraction> Triggeractions { get; set; }
        public string Destination { get; set; }
        public int Damage { get; set; }
    }
}