using System.Threading.Tasks;
using Models;

namespace Engine.Services
{
    public interface ICartridgeService
    {
        Task<Cartridge> GetCartage(string cartridgeId);
    }
}