using System;
using System.Collections.Generic;
using GameServer.Services;

namespace GameServer.DTO
{
    public class GameSchema : EntityBase
    {
        private ICartridgeService _cartridgeService;
        public GameSchema(ICartridgeService cartridgeService)
        {
            _cartridgeService = cartridgeService;
        }
        
        public string CartridgeName { get; set; }
        public DateTime CreationDate { get; set; }
        public dynamic Scenes { get; set; }
        public List<dynamic> Status { get; set; }

        public void PreSave()
        {
            CreationDate = new DateTime();
            this.Scenes = _cartridgeService.GetCartridge(CartridgeName).Rooms;
            this.Status = new List<dynamic>();
        }
    }
}