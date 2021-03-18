using System;

namespace GameServer.Services
{
    public interface IGameService
    {
        bool CreateNewGame(Guid catrideId);
    }
}