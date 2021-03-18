using GameServer.Models;

namespace GameServer.Services
{
    public interface ICartridgeService
    {
        Root GetCartridge(string fileName);
    }
}