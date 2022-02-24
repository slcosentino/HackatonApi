using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MotivappAPI.ViewModels;
using MotivappServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotivappAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MilestonesController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IMilestoneService milestoneService;
        private readonly IMapper mapper;

        public MilestonesController(ILogger<UsersController> logger, 
            IMilestoneService milestoneService,
            IMapper mapper)
        {
            _logger = logger;
            this.milestoneService = milestoneService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<UserResponse>> Get()
        {
            var response = mapper.Map<List<Milestone>>(await milestoneService.GetMilestones());
            return Ok(response);
        }



        [HttpGet]
        [Route("users/{userId}")]
        public async Task<ActionResult<UserResponse>> GetByUser([FromRoute(Name = "userId")] int userId)
        {
            var response = mapper.Map<List<Milestone>>(await milestoneService.GetMilestonesByUser(userId));
            return Ok(response);
        }
    }
}
