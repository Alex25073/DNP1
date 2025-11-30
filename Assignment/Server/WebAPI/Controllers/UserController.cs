using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;
using Entities;
using ApiContracts;
using Microsoft.EntityFrameworkCore;  

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _users;

    public UsersController(IUserRepository users)
    {
        _users = users;
    }

    // GET /Users?contains=abc
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAll([FromQuery] string? contains)
    {
        var query = _users.GetManyAsync(); 

        if (!string.IsNullOrWhiteSpace(contains))
        {
            query = query.Where(u => u.Username.Contains(contains));
        }

        var users = await query.ToListAsync();

        var result = users.Select(u => new UserDto
        {
            Id       = u.Id,
            UserName = u.Username,
            Email    = u.Email
        });

        return Ok(result);
    }

    // POST /Users
    [HttpPost]
    public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserDto dto)
    {
    
        bool usernameTaken = await _users.GetManyAsync()
            .AnyAsync(u => u.Username.ToLower() == dto.UserName.ToLower());

        if (usernameTaken)
            return Conflict("Username already taken");

        var user = new User
        {
            Username = dto.UserName,
            Email    = dto.Email,
            Password = dto.Password
        };

        var created = await _users.AddAsync(user);

        var result = new UserDto
        {
            Id       = created.Id,
            UserName = created.Username,
            Email    = created.Email
        };

        return Created($"/Users/{result.Id}", result);
    }

    // GET /Users/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserDto>> GetById(int id)
    {
        var user = await _users.GetSingleAsync(id);

        var dto = new UserDto
        {
            Id       = user.Id,
            UserName = user.Username,
            Email    = user.Email
        };

        return Ok(dto);
    }
}
