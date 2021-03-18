using System;
using System.Collections.Generic;
using System.Security;
using System.Threading.Tasks;
using GameServer.Models;
using GameServer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace GameServer.Controllers
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
        public bool CreateNewGame([FromBody] Guid catridgeId)
        {
            return _gameService.CreateNewGame(catridgeId);
        }
        
        [HttpPost]
        [Route("{gameId}")]
        public GameStateModel JoinGame(Guid gameId,[FromBody] string playerInfo)
        {
            var newGameState = new GameStateModel()
            {
                Id = gameId,
                PlayerName = playerInfo
                
            };
            return _gameStateService.SaveGameState(newGameState);
        }

        [HttpGet]
        [Route("{gameId}/state/{playerName}")]
        public List<GameStateModel> GetGameStateOfPlayer(Guid gameId, string playerName)
        {
            return _gameStateService.FindGameStateforPlayerAndGame(gameId, playerName);
        }

        [HttpPost]
        [Route("{gameId}/{playerName}/command")]
        public GameStateModel SendCommandToGame(Guid gameId, string playerName, [FromBody] string action)
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