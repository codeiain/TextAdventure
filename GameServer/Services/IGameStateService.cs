using System;
using System.Collections.Generic;
using GameServer.Models;

namespace GameServer.Services
{
    public interface IGameStateService
    {
        GameStateModel GetById(Guid gameId);
        List<GameStateModel> FindGameStateforPlayerAndGame(Guid gameId, string playerName);
        GameStateModel SaveGameState(GameStateModel stateModel);
    }
}