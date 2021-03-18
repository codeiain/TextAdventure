using System;
using GameServer.DTO;
using GameServer.Models;

namespace GameServer.Services
{
    public class GameService : IGameService
    {
        private IRepository<GameSchema> _gameRepository;
        private ICartridgeService _cartridgeService;
        public GameService(IRepository<GameSchema> gameRepository, ICartridgeService cartridgeService)
        {
            _gameRepository = gameRepository;
            _cartridgeService = cartridgeService;
        }
        
        public bool CreateNewGame(string cartridgeName)
        {
            
            var game = new GameSchema(_cartridgeService)
            {
                CartridgeName = cartridgeName
            };
            game.PreSave();
            return _gameRepository.Insert(game);
        }
    }
}