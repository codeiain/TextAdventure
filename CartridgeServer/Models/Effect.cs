namespace CartridgeServer.Models
{
    public class Effect
    {
        public string AddStatus { get; set; }
        public string Target { get; set; }
        public string RemoveStatus { get; set; }
        public string StatusUpdate { get; set; }
        public Subtarget Subtarget { get; set; }
    }
}