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

    [HttpPost("login")]
    public ActionResult<UserDto> Login([FromBody] LoginRequest request)
    {
        var user = _users
            .GetManyAsync()
            .FirstOrDefault(u =>
                u.Username.Equals(request.Username, StringComparison.OrdinalIgnoreCase));

        if (user == null)
        {
            return Unauthorized("Unknown user.");
        }

        if (!string.Equals(user.Password, request.Password))
        {
            return Unauthorized("Incorrect password.");
        }

        var dto = new UserDto
        {
            Id = user.Id,
            UserName = user.Username,
            Email = user.Email
        };

        return Ok(dto);
    }
}
