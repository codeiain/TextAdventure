using System;
using System.Threading.Tasks;
using CartridgeServer;
using CartridgeServer.Test;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PlayerStateServer.Models;

namespace PlayerStateServer.Services
{
    public class CartridgeService : CatridgeServerGRPC.CatridgeServerGRPCBase
    {
        private readonly ILogger<CartridgeService> _logger;
        private readonly IMongoRepository<Cartridge> _mongoRepository;

        public CartridgeService(ILogger<CartridgeService> logger, IMongoRepository<Cartridge> mongoRepository)
        {
            _logger = logger;
            _mongoRepository = mongoRepository;
        }

        public override async  Task<CartridgeReply> GetCartridge(CartridgeRequest request, ServerCallContext context)
        {
            var result = await _mongoRepository.FindOneAsync(x=>x.GameId == request.Id);
            return new CartridgeReply
            {
                Message = JsonConvert.SerializeObject(result)
            };
        }

        public override async Task<CartridgeReply> CreateCartridge(CreateRequest request, ServerCallContext context)
        {
            var newId = Guid.NewGuid();
            var x = new CartridgeTests().TestCartridge;
            Cartridge m = new Cartridge();
            
            m.Name = x.Name;
            m.Graph = x.Graph;
            m.WinCondition = x.WinCondition;
            m.LoseCondition = x.LoseCondition;
            m.Locations = x.Locations;
            m.GameId = newId.ToString();
            await _mongoRepository.InsertOneAsync(m);
            return new CartridgeReply
            {
                Message = newId.ToString()
            };
        }
    } 
}