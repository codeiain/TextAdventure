using System.Threading.Tasks;
using Engine.Models.Settings;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;

namespace Engine.Services
{
    public class PlayerStateService : IPlayerStateService
    {
        private readonly ILogger<PlayerStateService> _logger;
        private AppSettings _config;
        private readonly PlayerStateServerGRPC.PlayerStateServerGRPCClient _client;

        public PlayerStateService(ILogger<PlayerStateService> logger, AppSettings config)
        {
            _logger = logger;
            _config = config;
            var channel = GrpcChannel.ForAddress(_config.PlayerStateServerAddress);
            _client = new PlayerStateServerGRPC.PlayerStateServerGRPCClient(channel);

        }
        //TODO: clean up the models here
        public async Task<PlayerStateReply> CreateNewGameState(CreateRequest request)
        {
            return await _client.CreatePlayerStateAsync(request);
        }
    }
}