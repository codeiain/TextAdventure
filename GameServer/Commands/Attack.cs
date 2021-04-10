using System;
using System.Text.RegularExpressions;
using System.Transactions;
using GameServer.DTO;
using GameServer.Models;
using GameServer.Services;
using Humanizer;

namespace GameServer.Commands
{
    public class Attack : BaseCommand
    {
        public string Weapon { get; set; }
        
        
        public void SetData(CommandModel cmdData)
        {
            Data = cmdData;
            Action = "get";
        }
        public Attack(ICartridgeService cartridgeService) : base(cartridgeService)
        {
            _cartridgeService = cartridgeService;
            base._cartridgeService = cartridgeService;
        }

        public string Parse()
        {
            var commandPattern = new Regex("/attack ([a-z _]+) with ([a-z _]+)/i");
            var matches = commandPattern.Matches(Action.ToLower());
            switch (matches.Count)
            {
                case 0:
                    return "Malformed attack command, please specify the target and the weapon";
                    break;
                case 1:
                    return "Unable to understand what to attack";
                    break;  
                case 2:
                    return "Unable to understand that weapon to use";
            }

            Target = matches[1].Value;
            Weapon = matches[2].Value;
            return "true";
        }

        public void AttackNpc(Root param, Func<string,string> cb)
        {
           
        }

        public void AttackItem(Func<int, string>cb)
        {
            
        }

        public void Run(Func<int, string> cb)
        {
            
        }
    }
}