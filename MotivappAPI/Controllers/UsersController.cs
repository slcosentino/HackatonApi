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
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UsersController(ILogger<UsersController> logger, 
            IUserService userService,
            IMapper mapper)
        {
            _logger = logger;
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<UserResponse>> Get()
        {
            var response = mapper.Map<List<UserResponse>>(await userService.GetUsers());
            return Ok(response);
        }
    }
}
