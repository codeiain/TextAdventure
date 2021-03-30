using System.Threading.Tasks;
using CacheServer;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace CacheServer.Services
{
    public class CacheService : Cache.CacheBase
    {
        private readonly ILogger<CacheService> _logger;

        public CacheService(ILogger<CacheService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
