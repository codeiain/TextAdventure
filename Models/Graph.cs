using System.Dynamic;

namespace Models
{
    public class Graph
    {
        public string Source { get;set; } 
        public string Target { get; set; }
        public int Distance { get; set; }
        public Direction Direction { get; set; }
    }
}