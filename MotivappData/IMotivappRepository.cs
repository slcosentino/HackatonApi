
using MotivappData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotivappData
{
    public interface IMotivappRepository
    {
        Task<List<User>> GetUsers();
    }
}
