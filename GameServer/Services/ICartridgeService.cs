using System.Threading.Tasks;
using Models;

namespace GameServer.Services
{
    public interface ICartridgeService
    {
        Task<Cartridge> GetCartage(string cartridgeId);
    }
}