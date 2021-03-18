using System.Linq;
using System.Threading;
using GameServer.DTO;
using GameServer.Factories;
using GameServer.Models;
using GameServer.Services;

namespace GameServer.Commands
{
    public class BaseCommand
    {
        private ICartridgeService _cartridgeService;
        public BaseCommand(ICartridgeService cartridgeService)
        {
            _cartridgeService = cartridgeService;
        }

        private string _action;
        public void ProcessTrigger(GameStateSchema gstate, Item item)
        {
                if(item?.Triggers == null ){ return;}

                var triggers = item.Triggers.FindAll(x => x.Action == _action);

                foreach (var trigger in triggers)
                {
                    var effect = EffectFactory.GetEffect(trigger.Effect);
                    effect.SetGameState(gstate);
                    effect.SetGame(gstate.Game);
                    effect.execute();
                }
        }

        public bool CheckWinCondition(dynamic gstate, dynamic game, WinCondition c)
        {
            if (c != null) return false;
            if (c.Source == "gamestate")
            {
                if (c.Condition.Type == "comparison")
                {
                    if (c.Condition.Symbol == "=")
                    {
                        return gstate[c.Condition.Left] == c.Condition.Right;
                    }
                }
            }

            return false;
        }

        public bool CheckFinalConditions(Root gstate, dynamic game)
        {
            var gCart = _cartridgeService.GetCartridge(game.cartridgeid);
            if (!gCart) return false;
            var conditions = gCart.game;
            if (CheckWinCondition(gstate, game, conditions["win-condition"]))
            {
                return true;
            }

            return false;
        }
    }
}