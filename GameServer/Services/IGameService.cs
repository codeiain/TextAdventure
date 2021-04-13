using System.Threading.Tasks;
using Grpc.Core;

namespace GameServer.Services
{
    public interface IGameService
    {
        Task<CatridgeReply> CreateNewGame(CatridgeRequest request, ServerCallContext context);
        Task<JoinResponce> JoinGame(GameRequest request, ServerCallContext context);
        Task<GameResponce> GetGameStateOfPlayer(GameRequest request, ServerCallContext context);
        Task<GameResponce> SendCommand(GameRequest request, ServerCallContext context);
    }
}