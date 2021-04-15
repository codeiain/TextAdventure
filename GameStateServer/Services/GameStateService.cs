using System;
using System.Threading.Tasks;
using CartridgeServer;
using GameStateServer.Models;
using GameStateServer.Models.Settings;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Models;
using Newtonsoft.Json;

namespace GameStateServer.Services
{
    public class GameStateService :GameStateServerGRPC.GameStateServerGRPCBase
    {
        private readonly ILogger<GameStateService> _logger;
        private readonly IMongoRepository<GameState> _mongoRepository;

        public GameStateService(ILogger<GameStateService> logger, IMongoRepository<GameState> mongoRepository)
        {
            _logger = logger;
            _mongoRepository = mongoRepository;
        }

        public override async Task<GameStateReply> CreateNewGameState(GameRequest request, ServerCallContext context)
        {
            var newId = Guid.NewGuid();
            var game = JsonConvert.DeserializeObject<Cartridge>(request.Message);
            var currentState = new GameState()
            {
                GameId = newId,
                Scenes = game.Locations
            };

            await _mongoRepository.InsertOneAsync(currentState);

            return new GameStateReply()
            {
                Message = newId.ToString()
            };
        }
    }
}