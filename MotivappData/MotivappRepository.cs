using Microsoft.EntityFrameworkCore;
using MotivappData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotivappData
{
    public class MotivappRepository : IMotivappRepository
    {
        private readonly MotivappContext context;

        public MotivappRepository(MotivappContext context)
        {
            this.context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return await context.Users
                .Include(x => x.Milestones)
                .ThenInclude(x => x.Category).ToListAsync();
        }
    }
}
