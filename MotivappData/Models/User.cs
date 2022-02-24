using System;
using System.Collections.Generic;
using System.Text;

namespace MotivappData.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string AvatarURL { get; set; }
        public List<Milestone> Milestones { get; set; }
    }
}
