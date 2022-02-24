using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotivappAPI.ViewModels
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string AvatarURL { get; set; }
        public List<Milestone> Milestones { get; set; }
    }
}
