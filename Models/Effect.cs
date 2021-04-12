namespace Models
{
    public class Effect
    {
        public string StatusUpdate { get; set; }
        public string AddStatus { get; set; }
        public string RemoveStatus { get; set; }
        public string Target { get; set; }
        public SubTarget SubTarget { get; set; }
    }
}