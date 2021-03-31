namespace CartridgeServer.Models
{
    public class Graph
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public North North { get; set; }
        public South South { get; set; }
        public East East { get; set; }
        public West West { get; set; }
    }
}