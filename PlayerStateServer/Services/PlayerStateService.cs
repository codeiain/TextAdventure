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

        public override async Task<GameStateReply> CreatePlayerState(CreateRequest request, ServerCallContext context)
        {
            var PlayerState = new PlayerGameState();
            PlayerState.Game = JsonConvert.DeserializeObject<Cartridge>(request.Game);
            PlayerState.PlayerKey = Guid.NewGuid().ToString();
            PlayerState.Inventory = new Inventory();
            PlayerState.PlayerHp = 10;
            PlayerState.WalkedEast = 0;
            PlayerState.WalkedNorth = 0;
            PlayerState.WalkedSouth = 0;
            PlayerState.WalkedWest = 0;
            PlayerState.PlayerKey = request.PlayerName;
            PlayerState.CurrentScene = PlayerState.Game.Locations.FirstOrDefault()?.Name;

            await _mongoRepository.InsertOneAsync(PlayerState);

            //TODO: Add Call to Cache server here to store the player name under the game id in redis

            return new GameStateReply()
            {
                Message = JsonConvert.SerializeObject(PlayerState)
            };

        }
    } 
}