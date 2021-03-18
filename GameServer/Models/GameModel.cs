using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace GameServer.Models
{
    public class GameModel : EntityBase
    {
        public Guid CartrideId { get; set; }
        public DateType CreationDate { get; set; }
        public List<dynamic> Scenes { get; set; }
        public List<dynamic> Status { get; set; }
    }
}