using System.Collections.Generic;
using System.Linq;
using GameServer.DTO;
using GameServer.Models;

namespace GameServer.Effects
{
    public class AddStatus : IStatus
    {
        private string _target;
        private string _newStatus;
        private GameStateSchema _gameState;
        private GameSchema _game;

        public AddStatus(Effect data)
        {
            _target = data.Target;
            _newStatus = data.AddStatus;
        }

        public void SetGameState(GameStateSchema g)
        {
            _gameState = g;
        }

        public void SetGame(GameSchema g)
        {
            _game = g;
        }

        public void execute()
        {
            if (_target == "game")
            {
                if (_game.Status == null)
                {
                    _game.Status = new List<dynamic>();
                }

                
            }

            throw new System.NotImplementedException();
        }
    }
}