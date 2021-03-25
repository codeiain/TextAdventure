using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace CartageServer
{
    public class CartageService : Cartage.CartageBase
    {
        private readonly ILogger<CartageService> _logger;

        public CartageService(ILogger<CartageService> logger)
        {
            _logger = logger;
        }

        public override Task<CartageReply> GetCartage(CartageRequest request, ServerCallContext context)
        {
            return Task.FromResult(new CartageReply()
            {
                Message = "poop"
            });
        }
    } 
}