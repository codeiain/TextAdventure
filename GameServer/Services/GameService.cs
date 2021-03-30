using CatridgeServer;
using GameServer.Models.Settings;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GameServer.Services
{
    public class GameService : IGameService
    {
        private readonly ILogger<GameService> _logger;
        private AppSettings _config;
        private readonly ICatridgeService _catridgeService;

        public GameService(ILogger<GameService> logger, AppSettings config, ICatridgeService catridgeService)
        {
            _logger = logger;
            _config = config;
            _catridgeService = catridgeService;
        }

        public Task<CatridgeReply> CreateNewGame(CatridgeRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<JoinResponce> JoinGame(GameRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<GameResponce> GetGameStateOfPlater(GameRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<GameResponce> SendCommand(GameRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}