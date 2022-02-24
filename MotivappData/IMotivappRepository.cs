
using MotivappData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotivappData
{
    public interface IMotivappRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(int userId);
        Task<List<Milestone>> GetMilestones();
        Task<List<Milestone>> GetMilestonesByUser(int userId);
    }
}
