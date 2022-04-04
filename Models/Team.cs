﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Bowling.Models
{
    public class Team
    {
        [Key]
        [Required]
        public int TeamID { get; set; }

        public string TeamName { get; set; }


    }
}
