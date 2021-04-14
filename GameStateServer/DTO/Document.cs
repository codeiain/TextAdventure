using System;
using MongoDB.Bson;

namespace GameStateServer.DTO
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}