using System;
using System.Threading.Tasks;
using CartridgeServer.Models;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace CartridgeServer.Services
{
    public class CartridgeService : Cartridge.CartridgeBase
    {
        private readonly ILogger<CartridgeService> _logger;
        private readonly IMongoRepository<CartridgeModel> _mongoRepository;
        public CartridgeService(ILogger<CartridgeService> logger, IMongoRepository<CartridgeModel> mongoRepository)
        {
            _logger = logger;
            _mongoRepository = mongoRepository;
        }

        public override async  Task<CartridgeReply> GetCartage(CartridgeRequest request, ServerCallContext context)
        {
            var result = await _mongoRepository.FindOneAsync(x=>x.GameId == Guid.Parse(request.Id));
            return new CartridgeReply
            {
                Message = result.Id.ToString()
            };
        }

        public override async Task<CartridgeReply> CreateCartridge(CreateRequest request, ServerCallContext context)
        {
            var newId = Guid.NewGuid();
            await _mongoRepository.InsertOneAsync(new CartridgeModel() {Name = request.Name, GameId = newId});
            return new CartridgeReply
            {
                Message = newId.ToString()
            };
        }
    } 
}