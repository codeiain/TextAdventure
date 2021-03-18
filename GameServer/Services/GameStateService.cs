using System;
using System.Collections.Generic;
using System.Linq;
using GameServer.DTO;
using GameServer.Models;

namespace GameServer.Services
{
    public class GameStateService : IGameStateService
    {

        private IRepository<GameStateSchema> _gameStateRepository;

        
        public GameStateService(IRepository<GameStateSchema> gameStateRepository)
        {
            _gameStateRepository = gameStateRepository;
            
        }
        
        public GameStateSchema GetById(Guid gameId)
        {
            return _gameStateRepository.GetById(gameId);
        }

        public List<GameStateSchema> FindGameStateforPlayerAndGame(Guid gameId, string playerName)
        {
            return _gameStateRepository.SearchFor(x => x.PlayerName == playerName && x.Id == gameId).ToList();
        }

        public GameStateSchema SaveGameState(GameStateSchema stateSchema)
        {
            if (_gameStateRepository.Insert(stateSchema))
            {
                return stateSchema;
            }

            return null;
        }
    }
}