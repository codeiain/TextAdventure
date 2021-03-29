using System;
using System.Collections.Generic;
using GameApiServer.DTO;

namespace GameApiServer.Services
{
    public interface IGameStateService
    {
        GameStateSchema GetById(Guid gameId);
        List<GameStateSchema> FindGameStateforPlayerAndGame(Guid gameId, string playerName);
        GameStateSchema SaveGameState(GameStateSchema stateModel);
    }
}