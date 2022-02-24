using Microsoft.EntityFrameworkCore;
using MotivappData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Milestone>> GetMilestones()
        {
            return await context.Milestones
                .Include(x => x.Category)
                .Include(x => x.User)
                .OrderByDescending(x => x.EarnedAt).ToListAsync();
        }

        public async Task<List<Milestone>> GetMilestonesByUser(int userId)
        {
            return await context.Milestones
                .Include(x => x.Category)
                .Include(x => x.User)
                .Where(x => x.User.Id == userId)
                .OrderByDescending(x => x.EarnedAt).ToListAsync();
        }

        public async Task<User> GetUser(int userId)
        {
            return await context.Users
                .Include(x => x.Milestones)
                .ThenInclude(x => x.Category)
                .SingleOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<List<User>> GetUsers()
        {
            return await context.Users
                .Include(x => x.Milestones)
                .ThenInclude(x => x.Category).ToListAsync();
        }
    }
}
