using System.Threading.Tasks;
using Grpc.Core;

namespace Engine.Services
{
    public interface IGameService
    {
        Task<GameCatridgeReply> CreateNewGame(GameCatridgeRequest request, ServerCallContext context);
        Task<JoinResponce> JoinGame(GameRequest request, ServerCallContext context);
        Task<GameResponce> GetGameStateOfPlayer(GameRequest request, ServerCallContext context);
        Task<GameResponce> SendCommand(GameRequest request, ServerCallContext context);
    }
}