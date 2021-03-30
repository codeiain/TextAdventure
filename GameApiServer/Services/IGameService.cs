using System.Collections.Generic;
using System.Threading.Tasks;
using GameAPIServer;

namespace GameApiServer.Services
{
    public interface IGameService
    {
        public Task<CatridgeReply> CreateNewGame(CatridgeRequest request);
        public Task<JoinResponce> JoinGame(GameRequest request);
        public Task<List<GameResponce>> GetGameStateOfPlayer(GameRequest request);
        public Task<GameResponce> SendCommand(GameRequest request);
    }
}