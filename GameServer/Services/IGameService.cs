using System;

namespace GameServer.Services
{
    public interface IGameService
    {
        bool CreateNewGame(string cartridgeName);
    }
}