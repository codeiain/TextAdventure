using System;
using System.Collections.Generic;
using GameStateServer.DTO;
using Models;

namespace GameStateServer.Models
{
    [BsonCollection("GameState")]
    public class GameState : Document
    {
        public Guid GameId { get; set; }
        public List<Location> Scenes { get; set; }
        public List<dynamic> Status { get; set; }
    }
}