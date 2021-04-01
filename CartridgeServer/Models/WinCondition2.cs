﻿using MongoDB.Bson.Serialization.Attributes;

namespace CartridgeServer.Models
{
    public class WinCondition2
    {
        [BsonElement("source")]
        public string Source { get; set; }
        [BsonElement("condition")]
        public Condition Condition { get; set; }
    }
}