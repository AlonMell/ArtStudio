using ArtStudio.Core.Dto;
using ArtStudio.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtStudio.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult> Register(RegisterUserRequest userRequest)
    {
        var token = await userService.Register(userRequest);
        return Ok(token);
    }
    [HttpGet("login")]
    public async Task<ActionResult> Login(LoginUserRequest loginRequest)
    {
        var token = await userService.Login(loginRequest);
        return Ok(token);
    }
}