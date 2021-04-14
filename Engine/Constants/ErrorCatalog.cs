namespace Engine.Constants
{
    public class ErrorCatalog
    {
        public int Code { get; set; }
        public string Problem { get; set; }
        public string Action { get; set; }
        public int? HttpResponseCode { get; set; }
    }
}