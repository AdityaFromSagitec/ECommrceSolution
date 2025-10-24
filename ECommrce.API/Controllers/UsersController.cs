using ECommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommrce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;
        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        // GET: api/users/{userID}
        [HttpGet("{userID}")]
        public async Task<IActionResult> GetUserByUserID(Guid userID)
        {
            if (userID == Guid.Empty)
            {
                return BadRequest("Invalid userID");
            }
            var userDTO = await _userService.GetUserByUserID(userID);
            if (userDTO == null)
            {
                return NotFound();
            }
            return Ok(userDTO);
        }
    }
}
