﻿using System;

namespace MotivappData.Models
{
    public class Milestone
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public DateTime EarnedAt { get; set; }
        public int EarnedPoints { get; set; }
    }
}