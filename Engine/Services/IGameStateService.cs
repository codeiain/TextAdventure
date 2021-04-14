using System.Threading.Tasks;

namespace Engine.Services
{
    public interface IGameStateService
    {
        Task<GameStateReply> CreateNewGameState(GameRequest request);
    }
}