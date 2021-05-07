using System.Threading.Tasks;
using Engine.Models.Settings;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;

namespace Engine.Services
{
    public class GameStateService : IGameStateService
    {
        private readonly ILogger<GameStateService> _logger;
        private AppSettings _config;
        private readonly GameStateServerGRPC.GameStateServerGRPCClient _client;

        public GameStateService(ILogger<GameStateService> logger, AppSettings config)
        {
            _logger = logger;
            _config = config;
            var channel = GrpcChannel.ForAddress(_config.GameStateServerAddress);
            _client = new GameStateServerGRPC.GameStateServerGRPCClient(channel);

        }
        //TODO: clean up the models here
        public async Task<GameStateReply> CreateNewGameState(GameStateRequest request)
        {
            return await _client.CreateNewGameStateAsync(request);
        }

        public async Task<GameStateReply> GetGameState(string id)
        {
            return await _client.GetGameStateAsync(new GameStateRequest() { Message = id });
        }
    }
}