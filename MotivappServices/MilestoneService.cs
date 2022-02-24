using MotivappData;
using MotivappData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotivappServices
{
    public class MilestoneService : IMilestoneService
    {
        private readonly IMotivappRepository motivappRepository;

        public MilestoneService(IMotivappRepository motivappRepository)
        {
            this.motivappRepository = motivappRepository;
        }
        public async Task<List<Milestone>> GetMilestones()
        {
            return await motivappRepository.GetMilestones();
        }

        public async Task<List<Milestone>> GetMilestonesByUser(int userId)
        {
            return await motivappRepository.GetMilestonesByUser(userId);
        }
    }
}
