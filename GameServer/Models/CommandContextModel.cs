using System;

namespace GameServer.Models
{
    public class CommandContextModel
    {
        public Guid GameId { get; set; }
        public string PlayerName { get; set; }
    }
}