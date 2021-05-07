using System;
using System.Collections.Generic;
using Models;

namespace Engine.Models
{

    public class GameState
    {
        public string GameId { get; set; }
        public List<Location> Scenes { get; set; }
        public List<dynamic> Status { get; set; }
    }
}