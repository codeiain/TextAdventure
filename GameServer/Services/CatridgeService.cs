using System.Threading.Tasks;
using CatridgeServer;
using GameServer.Models.Settings;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;

namespace GameServer.Services
{
    public class CatridgeService : ICatridgeService
    {
        private readonly ILogger<CatridgeService> _logger;
        private AppSettings _config;
        private readonly Catridge.CatridgeClient _client;

        public CatridgeService(ILogger<CatridgeService> logger, AppSettings config)
        {
            _logger = logger;
            _config = config;
            var channel = GrpcChannel.ForAddress(_config.CatridgeServerAddress);
            _client = new Catridge.CatridgeClient(channel);
        }

        public async Task<CatridgeServer.CatridgeReply> GetCatridgeById(string id)
        {
            return await _client.GetCatridgeAsync(new CatridgeServer.CatridgeRequest { Id = id });

        }

    } 
}