using System;
using System.Collections.Generic;
using GameApiServer.DTO;
using GameApiServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameApiServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private IGameStateService _gameStateService;
        private IGameService _gameService;

        public GameController(IGameService gameService, IGameStateService gameStateService)
        {
            _gameStateService = gameStateService;
            _gameService = gameService;
        }

        [HttpPost]
        [Route(("/"))]
        public bool CreateNewGame([FromBody] string catridgeId)
        {
            return _gameService.CreateNewGame(catridgeId);
        }
        
        [HttpPost]
        [Route("{gameId}")]
        public GameStateSchema JoinGame(Guid gameId,[FromBody] string playerInfo)
        {
            var newGameState = new GameStateSchema()
            {
                Id = gameId,
                PlayerName = playerInfo
                
            };
            return _gameStateService.SaveGameState(newGameState);
        }

        [HttpGet]
        [Route("{gameId}/state/{playerName}")]
        public List<GameStateSchema> GetGameStateOfPlayer(Guid gameId, string playerName)
        {
            return _gameStateService.FindGameStateforPlayerAndGame(gameId, playerName);
        }

        [HttpPost]
        [Route("{gameId}/{playerName}/command")]
        public GameStateSchema SendCommandToGame(Guid gameId, string playerName, [FromBody] string action)
        {
            var command = new CommandModel()
            {
                Action = action,
                Context = new CommandContextModel()
                {
                    GameId = gameId,
                    PlayerName = playerName
                }
            };
            
            //Add call here to command parser
            
            return null;
        }
    }
}