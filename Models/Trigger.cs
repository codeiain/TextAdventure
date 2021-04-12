namespace Models
{
    public class Trigger
    {
        public Action Action { get; set; }
        public string Target { get; set; }
        public SubTarget SubTarget { get; set; }
        public Effect Effect { get; set; }
    }
}