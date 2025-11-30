using ApiContracts;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _users;

    public AuthController(IUserRepository users)
    {
        _users = users;
    }

    // POST /auth/login
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login([FromBody] LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            return BadRequest("Username and password are required.");

        var queryable = _users.GetManyAsync();
        var user = queryable.FirstOrDefault(u =>
            u.Username.Equals(request.Username, StringComparison.OrdinalIgnoreCase));

        if (user is null)
            return Unauthorized("Invalid username or password.");

        if (!string.Equals(user.Password, request.Password, StringComparison.Ordinal))
            return Unauthorized("Invalid username or password.");

        var dto = new UserDto
        {
            Id       = user.Id,
            UserName = user.Username,
            Email    = user.Email
        };

        return Ok(dto);
    }
}
