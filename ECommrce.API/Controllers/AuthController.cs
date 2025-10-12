using ECommerce.Core.DTO;
using ECommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace ECommrce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    //Endpoint for user registration
    [HttpPost("register")] // POST: api/Auth/register
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        //checl for invalid registerRequest
        if (registerRequest == null)
        {
            return BadRequest("Invalid RegisterRequest data");
        }
        // 
        AuthenticationResopnse? authenticationResopnse = await _userService.Register(registerRequest);
        if (authenticationResopnse == null || authenticationResopnse.Success == false)
        {
            return BadRequest("Registration failed. Please try again.");
        }
        return Ok(authenticationResopnse);
    }

    //Endpoint for user login
    [HttpPost("login")] // POST: api/Auth/login
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        //check for invalid loginRequest
        if (loginRequest == null)
        {
            return BadRequest("Invalid login data");
        }
        AuthenticationResopnse? authenticationResopnse = await _userService.Login(loginRequest);
        if (authenticationResopnse == null || authenticationResopnse.Success == false)
        {
            return Unauthorized(authenticationResopnse);
        }
        return Ok(authenticationResopnse);
    }
}