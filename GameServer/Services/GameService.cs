using System;
using GameServer.Models;

namespace GameServer.Services
{
    public class GameService : IGameService
    {
        private IRepository<GameModel> _gameRepository;
        
        public GameService(IRepository<GameModel> gameRepository)
        {
            _gameRepository = gameRepository;
        }
        
        public bool CreateNewGame(Guid catrideId)
        {
            
            var game = new GameModel()
            {
                CartrideId = catrideId
            };
            return _gameRepository.Insert(game);
        }
    }
}