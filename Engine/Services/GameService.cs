using System.Threading.Tasks;
using Engine.Models;
using Grpc.Core;
using Newtonsoft.Json;

namespace Engine.Services
{
    public class GameService : GameServerGRPC.GameServerGRPCBase, IGameService
    {

        private ICartridgeService _cartridgeService;
        private readonly IPlayerStateService _playerStateService;
        private readonly IGameStateService _gameStateService;

        public GameService(ICartridgeService cartridgeService, IPlayerStateService playerStateService, IGameStateService gameStateService)
        {
            _cartridgeService = cartridgeService;
            _gameStateService = gameStateService;
            _playerStateService = playerStateService;
        }

        public override async Task<GameCatridgeReply> CreateNewGame(GameCatridgeRequest request, ServerCallContext context)
        {
            var cart = await _cartridgeService.GetCartage(request.Id);
            var reply = await _gameStateService.CreateNewGameState(new GameStateRequest()
            {
                Message = JsonConvert.SerializeObject(cart)
            });

            var gameState = JsonConvert.DeserializeObject<GameState>(reply.Message);
            return new GameCatridgeReply(){ Message = gameState.GameId};
        }

        public override async Task<JoinResponce> JoinGame(GameRequest request, ServerCallContext context)
        {
            var state = await _gameStateService.GetGameState(request.GameId);
            var reply = await _playerStateService.CreateNewGameState(new CreatePlayerStateRequest()
            {
                Game = state.Message,
                PlayerName = request.PlayerName 
            });

            return new JoinResponce() { Message = reply.Message };
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



