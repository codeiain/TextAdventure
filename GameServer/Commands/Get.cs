using System;
using GameServer.DTO;
using GameServer.Services;

namespace GameServer.Commands
{
    public class Get : BaseCommand
    {
        private ICartridgeService _cartridgeService;
        
        public void SetData(CommandModel cmdData)
        {
            Data = cmdData;
            Action = "get";
        }
        public Get() : base
        {
            _cartridgeService = cartridgeService;
            base._cartridgeService = _cartridgeService;
        }
        public void Parse()
        {
            
        }

        public void get(GameStateSchema gstat, GameSchema game, Func<int, string> cb)
        {
            
        }

        public void run(Func<int, string> cb)
        {
            
        }
    }
}