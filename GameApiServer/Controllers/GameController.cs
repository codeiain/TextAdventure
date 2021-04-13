using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameApiServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameApiServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private IGameService _gameService;

        public GameController(IGameService gameService)
        {

            _gameService = gameService;
        }

        [HttpPost]
        [Route(("/"))]
        public async Task<GameCatridgeReply> CreateNewGame([FromBody] string catridgeId)
        {
            return await _gameService.CreateNewGame(new GameCatridgeRequest(){ Id = catridgeId });
        }
        
        [HttpPost]
        [Route("{gameId}")]
        public async Task<JoinResponce> JoinGame(Guid gameId,[FromBody] string playerInfo)
        {
            var newGameState = new GameRequest()
            {
                GameId = gameId.ToString(),
                PlayerName = playerInfo
                
            };
            return await _gameService.JoinGame(newGameState);
        }

        [HttpGet]
        [Route("{gameId}/state/{playerName}")]
        public void GetGameStateOfPlayer(Guid gameId, string playerName)
        {
            
        }

        [HttpPost]
        [Route("{gameId}/{playerName}/command")]
        public void SendCommandToGame(Guid gameId, string playerName, [FromBody] string action)
        {

        }
    }
}