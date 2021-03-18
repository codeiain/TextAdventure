using System;

namespace GameServer.Models
{
    public class CommandModel
    {
        public string Action { get; set; }
        public CommandContextModel Context { get; set; }
    }
}