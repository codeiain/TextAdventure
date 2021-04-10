using System;
using System.Collections.Generic;
using GameServer.DTO;

namespace GameServer.Services
{
    public interface ICommandService
    {
        CommandModel Command { get; set; }
        List<Type> VeifiedCommands { get; set; }
        string NormalisaAction(string action);
        Type verifyCommand();
        object Parse();
    }
}