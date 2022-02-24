using MotivappData;
using MotivappData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotivappServices
{
    public class UserService : IUserService
    {
        private readonly IMotivappRepository motivappRepository;

        public UserService(IMotivappRepository motivappRepository)
        {
            this.motivappRepository = motivappRepository;
        }

        public async Task<User> GetUser(int userId)
        {
            return await motivappRepository.GetUser(userId);
        }

        public async Task<List<User>> GetUsers()
        {
            return await motivappRepository.GetUsers();
        }
    }
}
