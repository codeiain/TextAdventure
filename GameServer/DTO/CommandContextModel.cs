using System;

namespace GameServer.DTO
{
    public class CommandContextModel
    {
        public Guid GameId { get; set; }
        public string PlayerName { get; set; }
    }
}