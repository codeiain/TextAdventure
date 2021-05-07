﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerStateServer.Models
{
    public class GameState
    {
        public string GameId { get; set; }
        public List<Location> Scenes { get; set; }
        public List<dynamic> Status { get; set; }
    }
}