using MotivappData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotivappServices
{
    public interface IMilestoneService
    {
        Task<List<Milestone>> GetMilestones();
        Task<List<Milestone>> GetMilestonesByUser(int userId);
    }
}
