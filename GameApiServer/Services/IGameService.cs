using System.Collections.Generic;
using System.Threading.Tasks;


namespace GameApiServer.Services
{
    public interface IGameService
    {
        public Task<GameCatridgeReply> CreateNewGame(GameCatridgeRequest request);
        public Task<JoinResponce> JoinGame(GameRequest request);
        public Task<List<GameResponce>> GetGameStateOfPlayer(GameRequest request);
        public Task<GameResponce> SendCommand(GameRequest request);
    }
}