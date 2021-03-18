using System;
using System.Collections.Generic;
using System.Linq;
using GameServer.Models;

namespace GameServer.Services
{
    public class GameStateService : IGameStateService
    {

        private IRepository<GameStateModel> _gameStateRepository;

        
        public GameStateService(IRepository<GameStateModel> gameStateRepository)
        {
            _gameStateRepository = gameStateRepository;
            
        }



        public GameStateModel GetById(Guid gameId)
        {
            return _gameStateRepository.GetById(gameId);
        }

        public List<GameStateModel> FindGameStateforPlayerAndGame(Guid gameId, string playerName)
        {
            return _gameStateRepository.SearchFor(x => x.PlayerName == playerName && x.Id == gameId).ToList();
        }

        public GameStateModel SaveGameState(GameStateModel stateModel)
        {
            if (_gameStateRepository.Insert(stateModel))
            {
                return stateModel;
            }

            return null;
        }
    }
}