using System.Threading.Tasks;
using GameAPIServer;
using GameApiServer.Models.Settings;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace GameApiServer.Services
{
    public class GameService : IGameService
    {
        private readonly ILogger<GameService> _logger;
        private AppSettings _config;
        private readonly GameServer.GameServerClient _client;

        public GameService(ILogger<GameService> logger, AppSettings config)
        {
            _logger = logger;
            _config = config;
            var channel = GrpcChannel.ForAddress(_config.GameServerAddress);
            _client = new GameServer.GameServerClient(channel);
        }


        public async Task<CatridgeReply> CreateNewGame(CatridgeRequest request)
        {
            return await _client.CreateNewGameAsync(request);
        }

        public async Task<JoinResponce> JoinGame(GameRequest request)
        {
            return await _client.JoinGameAsync(request);
        }
        
        public async Task<GameResponce> SendCommand(GameRequest request)
        {
            return await _client.SendCommandAsync(request);
        }

        Task<List<GameResponce>> IGameService.GetGameStateOfPlayer(GameRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}