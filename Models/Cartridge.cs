using System.Collections.Generic;

namespace Models
{
    public class Cartridge
    {
        public string Name { get; set; }
        public WinCondition WinCondition { get; set; }
        public LoseCondition LoseCondition { get; set; }
        public List<Graph> Graph { get; set; }
        public List<Location> Locations { get; set; }
    }
}