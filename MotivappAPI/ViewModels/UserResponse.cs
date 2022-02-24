using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotivappAPI.ViewModels
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AvatarURL { get; set; }
        public List<Category> Categories { get; set; }
        public int TotalPoints { get; set; }

    }
}
