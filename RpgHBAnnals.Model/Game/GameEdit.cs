﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHBAnnals.Model.Game
{
    public class GameEdit
    {
        [Key]
        public int GameId { get; set; }
        public string Name { get; set; }
        public decimal Edition { get; set; }

    }
}
