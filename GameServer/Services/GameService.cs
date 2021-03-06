using System.Threading.Tasks;
using Grpc.Core;

namespace GameServer.Services
{
    public class GameService : GameServer.GameServerBase, IGameService
    {

        private ICartridgeService _cartridgeService;

        public GameService(ICartridgeService cartridgeService)
        {
            _cartridgeService = cartridgeService;
        }

        public override async Task<CatridgeReply> CreateNewGame(CatridgeRequest request, ServerCallContext context)
        {
            var cart = await _cartridgeService.GetCartage(request.Id);
            return new CatridgeReply(){ Message = cart.ToString()};
        }

        public override async Task<JoinResponce> JoinGame(GameRequest request, ServerCallContext context)
        {
            throw new System.NotSupportedException();
        }

        public override async Task<GameResponce> GetGameStateOfPlayer(GameRequest request, ServerCallContext context)
        {
            throw new System.NotSupportedException();
        }

        public override async Task<GameResponce> SendCommand(GameRequest request, ServerCallContext context)
        {
            throw new System.NotSupportedException();
        }
    }
}



