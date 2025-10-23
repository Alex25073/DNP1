
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;
using ApiContracts;
using Entities;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ICommentRepository _comments;
    private readonly IPostRepository _posts;

    public CommentsController(ICommentRepository comments, IPostRepository posts)
    {
        _comments = comments;
        _posts = posts;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CommentDto>> GetAll([FromQuery] int? postId)
    {
        var query = _comments.GetManyAsync();
        if (postId.HasValue)
            query = query.Where(c => c.PostId == postId.Value);

        var result = query.Select(c => new CommentDto { Id = c.Id, Body = c.Body, PostId = c.PostId, UserId = c.UserId }).ToList();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CommentDto>> GetSingle(int id)
    {
        try
        {
            var comment = await _comments.GetSingleAsync(id);
            return Ok(new CommentDto { Id = comment.Id, Body = comment.Body, PostId = comment.PostId, UserId = comment.UserId });
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<CommentDto>> Create([FromBody] CreateCommentDto dto)
    {
        var comment = new Comment { Body = dto.Body, PostId = dto.PostId, UserId = dto.UserId };
        var created = await _comments.AddAsync(comment);
        var result = new CommentDto { Id = created.Id, Body = created.Body, PostId = created.PostId, UserId = created.UserId };
        return CreatedAtAction(nameof(GetSingle), new { id = created.Id }, result);
    }
}
