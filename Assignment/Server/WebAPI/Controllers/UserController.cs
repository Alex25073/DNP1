using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;
using Entities;
using ApiContracts;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _users;
    public UsersController(IUserRepository users) => _users = users;

    [HttpGet]
    public ActionResult<IEnumerable<UserDto>> GetAll([FromQuery] string? contains)
    {
        var query = _users.GetManyAsync();
        if (!string.IsNullOrWhiteSpace(contains))
            query = query.Where(u => u.Username.Contains(contains, StringComparison.OrdinalIgnoreCase));

        var result = query.Select(u => new UserDto { Id = u.Id, UserName = u.Username, Email = u.Email }).ToList();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserDto>> GetSingle(int id)
    {
        try
        {
            var user = await _users.GetSingleAsync(id);
            return Ok(new UserDto { Id = user.Id, UserName = user.Username, Email = user.Email });
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserDto dto)
    {
        var existing = _users.GetManyAsync().Any(u => u.Username.Equals(dto.UserName, StringComparison.OrdinalIgnoreCase));
        if (existing) return Conflict("Username already taken");

        var user = new User { Username = dto.UserName, Password = dto.Password, Email = dto.Email };
        var created = await _users.AddAsync(user);
        var result = new UserDto { Id = created.Id, UserName = created.Username, Email = created.Email };
        return Created($"/Users/{result.Id}", result);
    }
}
