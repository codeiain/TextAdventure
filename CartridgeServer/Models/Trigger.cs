namespace CartridgeServer.Models
{
    public class Trigger
    {
        public string Action { get; set; }
        public Effect Effect { get; set; }
        public string Target { get; set; }
        public Subtarget Sub { get; set; }
    }
}