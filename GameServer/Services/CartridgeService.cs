using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartridgeServer;
using CatridgeServer;
using GameServer.Models.Settings;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using Models;
using Newtonsoft.Json;

namespace GameServer.Services
{
    public class CartridgeService : ICartridgeService
    {

        private readonly ILogger<CartridgeService> _logger;
        private AppSettings _config;
        private readonly CatridgeServer.Catridge.CatridgeClient _client;

        public CartridgeService(ILogger<CartridgeService> logger, AppSettings config)
        {
            _logger = logger;
            _config = config;
            var channel = GrpcChannel.ForAddress(_config.CatridgeServerAddress);
            _client = new Catridge.CatridgeClient(channel);
        }

        public async Task<Cartridge> GetCartage(string cartridgeId)
        {
            var cart = await _client.GetCatridgeAsync(new CatridgeServer.CatridgeRequest() {Id = cartridgeId});
            var result = JsonConvert.DeserializeObject<Cartridge>(cart.Message);
            return result;
        }
    }

}