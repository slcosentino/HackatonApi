using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotivappAPI.ViewModels
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AvatarURL { get; set; }
        public int EarnedPoints { get; set; }
        public int NeededPoints { get; set; }
    }
}
