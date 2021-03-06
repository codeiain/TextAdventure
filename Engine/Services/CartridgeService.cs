using System.Threading.Tasks;
using Engine.Models.Settings;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using Models;
using Newtonsoft.Json;

namespace Engine.Services
{
    public class CartridgeService : ICartridgeService
    {

        private readonly ILogger<CartridgeService> _logger;
        private AppSettings _config;
        private readonly CatridgeServerGRPC.CatridgeServerGRPCClient _client;

        public CartridgeService(ILogger<CartridgeService> logger, AppSettings config)
        {
            _logger = logger;
            _config = config;
            var channel = GrpcChannel.ForAddress(_config.CatridgeServerAddress);
            _client = new CatridgeServerGRPC.CatridgeServerGRPCClient(channel);
        }

        public async Task<Cartridge> GetCartage(string cartridgeId)
        {
            var cart = await _client.GetCartridgeAsync(new CatridgeRequest() {Id = cartridgeId});
            var result = JsonConvert.DeserializeObject<Cartridge>(cart.Message);
            return result;
        }
    }

}