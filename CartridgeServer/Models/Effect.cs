using MongoDB.Bson.Serialization.Attributes;

namespace CartridgeServer.Models
{
    public class Effect
    {
        [BsonElement("addStatus")]
        public string AddStatus { get; set; }
        [BsonElement("target")]
        public string Target { get; set; }
        [BsonElement("removeStatus")]
        public string RemoveStatus { get; set; }
        [BsonElement("statusUpdate")]
        public string StatusUpdate { get; set; }
        [BsonElement("sub")]
        public Subtarget Subtarget { get; set; }
    }
}