using System;
using System.Collections.Generic;
using GameServer.DTO;
using GameServer.Models;

namespace GameServer.Services
{
    public interface IGameStateService
    {
        GameStateSchema GetById(Guid gameId);
        List<GameStateSchema> FindGameStateforPlayerAndGame(Guid gameId, string playerName);
        GameStateSchema SaveGameState(GameStateSchema stateModel);
    }
}