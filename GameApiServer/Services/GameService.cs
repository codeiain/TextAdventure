using GameApiServer.DTO;

namespace GameApiServer.Services
{
    public class GameService : IGameService
    {

        private ICartridgeService _cartridgeService;
        public GameService(ICartridgeService cartridgeService)
        {

            _cartridgeService = cartridgeService;
        }
        
        public bool CreateNewGame(string cartridgeName)
        {
            
            var game = new GameSchema(_cartridgeService)
            {
                CartridgeName = cartridgeName
            };
            game.PreSave();
            return true;
        }
    }
}