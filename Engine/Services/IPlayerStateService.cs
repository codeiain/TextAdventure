using System.Threading.Tasks;

namespace Engine.Services
{
    public interface IPlayerStateService
    {
        Task<CreatePlayerStateReply> CreateNewGameState(CreatePlayerStateRequest request);
    }
}