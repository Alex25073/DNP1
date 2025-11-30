using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace EfcRepositories;

public class CommentEfcRepository : ICommentRepository
{
    private readonly AppContext _ctx;

    public CommentEfcRepository(AppContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<Comment> AddAsync(Comment comment)
    {
        _ctx.Comments.Add(comment);
        await _ctx.SaveChangesAsync();
        return comment;
    }

    public async Task UpdateAsync(Comment comment)
    {
        _ctx.Comments.Update(comment);
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(Comment comment)
    {
        _ctx.Comments.Remove(comment);
        await _ctx.SaveChangesAsync();
    }

    public async Task<Comment> GetSingleAsync(int id)
    {
        var comment = await _ctx.Comments
            .Include(c => c.User)
            .Include(c => c.Post)
            .SingleOrDefaultAsync(c => c.Id == id);

        if (comment is null)
            throw new InvalidOperationException($"Comment with Id {id} not found.");

        return comment;
    }

    public IQueryable<Comment> GetManyAsync()
    {
        return _ctx.Comments.AsQueryable();
    }
}
