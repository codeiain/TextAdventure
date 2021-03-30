using System.Threading.Tasks;

namespace GameServer.Services
{
    public interface ICatridgeService
    {
        Task<CatridgeServer.CatridgeReply> GetCatridgeById(string Id);
    }
}