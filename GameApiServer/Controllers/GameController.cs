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
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {

            _gameService = gameService;
        }

        [HttpPost]
        [Route(("/"))]
        public async Task<GameCatridgeReply> CreateNewGame([FromBody] string cartridgeId)
        {
            // ToDo: Create new Game State here based on the Cartridge requested.
            var newGameState = new GameRequest()
            {
                GameId = cartridgeId,
            };


            return await _gameService.CreateNewGame(new GameCatridgeRequest(){ Id = cartridgeId });
        }
        
        [HttpPost]
        [Route("{gameId}")]
        public async Task<JoinResponce> JoinGame(Guid gameId,[FromBody] string playerInfo)
        {
            //TODO: Create new Player state for the game state Id and Player Name. 
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
            // Gets the Players status from the PlayerStateServer
        }

        [HttpPost]
        [Route("{gameId}/{playerName}/command")]
        public void SendCommandToGame(Guid gameId, string playerName, [FromBody] string action)
        {
            // Sends the command to the engine which updates the states based on the action.

        }
    }
}