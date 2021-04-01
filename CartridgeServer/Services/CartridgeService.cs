using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CartridgeServer.Models;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
            var result = await _mongoRepository.FindOneAsync(x=>x.GameId ==request.Id);
            return new CartridgeReply
            {
                Message = JsonConvert.SerializeObject(result)
            };
        }

        public override async Task<CartridgeReply> CreateCartridge(CreateRequest request, ServerCallContext context)
        {
            var newId = Guid.NewGuid();
            
            var graph1 = new Graph()
            {
                id = "entrance",
                Name = "Entrance",
                North = new North(){
                    Node = "1stroom",
                    Distance = 1
                }
            };

            var graph2 = new Graph()
            {
                id = "1stroom",
                Name = "1st Room",
                North = new North(){
                    Node = "bigroom",
                    Distance = 1
                },
                South = new South()
                {
                    Node = "entrance",
                    Distance = 1
                }
            };

            var graph3 = new Graph()
            {
                id = "bigroom",
                Name = "Big room",
                South =  new South()
                {
                    Node = "1stroom",
                    Distance = 1
                },
                North = new North()
                {
                    Node = "bossroom",
                    Distance = 2
                },
                East = new East()
                {
                    Node = "rightwing",
                    Distance = 3
                },
                West = new West()
                {
                    Node = "leftwing",
                    Distance =  3
                }
            };

            var graph4 = new Graph()
            {
                id = "bossroom",
                Name = "Boss room",
                South = new South()
                {
                    Node = "bigroom",
                    Distance = 2
                }
            };

            var graph5 = new Graph()
            {
                id = "leftwing",
                Name = "Left Wing",
                East = new East()
                {
                    Node = "bigroom",
                    Distance = 3
                }
            };

            var graph6 = new Graph()
            {
                id="rightwing",
                Name = "Right Wing",
                West = new West()
                {
                    Node = "bigroom",
                    Distance = 3
                }
                    
            };
            
            var temp = new CartridgeModel()
            {
                Name = request.Name,
                GameId = newId.ToString(),
                Graph = new List<Graph>()
                {
                    graph1,
                    graph2,
                    graph3,
                    graph4,
                    graph5,
                    graph6
                }
            };
            
            
            await _mongoRepository.InsertOneAsync(temp);
            return new CartridgeReply
            {
                Message = newId.ToString()
            };
        }
    } 
}