using System.Threading.Tasks;

namespace Engine.Services
{
    public interface IPlayerStateService
    {
        Task<PlayerStateReply> CreateNewGameState(CreateRequest request);
    }
}