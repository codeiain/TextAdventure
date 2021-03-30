using System.Threading.Tasks;

namespace GameServer.Services
{
    public interface ICatridgeService
    {
        Task<CatridgeReply> GetCatridgeById(string Id);
    }
}