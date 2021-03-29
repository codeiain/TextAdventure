using System;

namespace GameApiServer.DTO
{
    public class CommandContextModel
    {
        public Guid GameId { get; set; }
        public string PlayerName { get; set; }
    }
}