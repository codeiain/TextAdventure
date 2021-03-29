using GameApiServer.Models;

namespace GameApiServer.Services
{
    public interface ICartridgeService
    {
        Root GetCartridge(string fileName);
    }
}