using System;
using System.Collections.Generic;
using System.Text;

namespace MotivappData.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string AvatarURL { get; set; }
        public int NeededPoints { get; set; }
        public List<Milestone> Milestones { get; set; }
    }
}
