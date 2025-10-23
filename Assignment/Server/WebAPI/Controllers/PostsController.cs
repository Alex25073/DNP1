
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;
using ApiContracts;
using Entities;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostRepository _posts;
    private readonly IUserRepository _users;

    public PostsController(IPostRepository posts, IUserRepository users)
    {
        _posts = posts;
        _users = users;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PostDto>> GetAll([FromQuery] string? title)
    {
        var query = _posts.GetManyAsync();
        if (!string.IsNullOrWhiteSpace(title))
            query = query.Where(p => p.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

        var result = query.Select(p => new PostDto { Id = p.Id, Title = p.Title, Body = p.Body }).ToList();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PostDto>> GetSingle(int id)
    {
        try
        {
            var post = await _posts.GetSingleAsync(id);
            return Ok(new PostDto { Id = post.Id, Title = post.Title, Body = post.Body });
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<PostDto>> Create([FromBody] CreatePostDto dto)
    {
        var post = new Post { Title = dto.Title, Body = dto.Body, UserId = dto.UserId };
        var created = await _posts.AddAsync(post);
        var result = new PostDto { Id = created.Id, Title = created.Title, Body = created.Body };
        return CreatedAtAction(nameof(GetSingle), new { id = created.Id }, result);
    }
}
