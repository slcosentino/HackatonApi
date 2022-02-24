using MotivappData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotivappServices
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
    }
}
