using System.Threading.Tasks;
using CartageServer;
using GameServer.Models.Settings;
using Grpc.Core;
using GameServer;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;

namespace GameServer.Services
{
    public class CatridgeService : ICatridgeService
    {
        private readonly ILogger<CatridgeService> _logger;
        private AppSettings _config;
        private Catridge.CatridgeClient _client;

        public CatridgeService(ILogger<CatridgeService> logger, AppSettings config)
        {
            _logger = logger;
            _config = config;
            var channel = GrpcChannel.ForAddress(_config.CatridgeServerAddress);
            _client = new Catridge.CatridgeClient(channel);
        }

        public async Task<CatridgeReply> GetCatridgeById(string Id)
        {
             return await _client.GetCartageAsync(new CatridgeRequest { Id  = Id});

        }

    } 
}