using System.Threading.Tasks;

namespace Engine.Services
{
    public interface IGameStateService
    {
        Task<GameStateReply> CreateNewGameState(GameStateRequest request);
        Task<GameStateReply> GetGameState(string id);
    }
}