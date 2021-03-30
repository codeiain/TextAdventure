using System.Threading.Tasks;

namespace GameServer.Services
{
    public interface IGameService
    {
        public Task<CatridgeReply> CreateNewGame(CatridgeRequest request);
        public Task<JoinResponce> JoinGame(GameRequest request);
        public Task<GameResponce> GetGameStateOfPlater(GameRequest request);
        public Task<GameResponce> SendCommand(GameRequest request);
    }
}