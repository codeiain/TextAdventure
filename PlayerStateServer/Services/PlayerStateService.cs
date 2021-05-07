using System;
using System.Linq;
using System.Threading.Tasks;
using CartridgeServer;
using CartridgeServer.Test;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Models;
using Newtonsoft.Json;
using PlayerStateServer.Models;

namespace PlayerStateServer.Services
{
    public class PlayerStateService : PlayerStateServerGRPC.PlayerStateServerGRPCBase
    {
        private readonly ILogger<PlayerStateService> _logger;
        private readonly IMongoRepository<PlayerGameState> _mongoRepository;

        public PlayerStateService(ILogger<PlayerStateService> logger, IMongoRepository<PlayerGameState> mongoRepository)
        {
            _logger = logger;
            _mongoRepository = mongoRepository;
        }

        public override async Task<CreatePlayerStateReply> CreatePlayerState(CreatePlayerStateRequest request, ServerCallContext context)
        {
            var game = JsonConvert.DeserializeObject<GameState>(request.Game);

            var newId = Guid.NewGuid();
            var PlayerState = new PlayerGameState();
            PlayerState.Game = game;
            PlayerState.PlayerKey = newId.ToString();
            PlayerState.PlayerName = request.PlayerName;
            PlayerState.Inventory = new Inventory();
            PlayerState.PlayerHp = 10;
            PlayerState.WalkedEast = 0;
            PlayerState.WalkedNorth = 0;
            PlayerState.WalkedSouth = 0;
            PlayerState.WalkedWest = 0;
            PlayerState.CurrentScene = game.Scenes.FirstOrDefault()?.Name;

            await _mongoRepository.InsertOneAsync(PlayerState);

            //TODO: Add Call to Cache server here to store the player name under the game id in redis

            return new CreatePlayerStateReply()
            {
                Message = JsonConvert.SerializeObject(PlayerState)
            };

        }
    } 
}