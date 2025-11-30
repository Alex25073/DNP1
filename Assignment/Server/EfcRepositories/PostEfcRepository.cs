using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace EfcRepositories;

public class PostEfcRepository : IPostRepository
{
    private readonly AppContext _ctx;

    public PostEfcRepository(AppContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<Post> AddAsync(Post post)
    {
        _ctx.Posts.Add(post);
        await _ctx.SaveChangesAsync();
        return post;
    }

    public async Task UpdateAsync(Post post)
    {
        _ctx.Posts.Update(post);
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(Post post)
    {
        _ctx.Posts.Remove(post);
        await _ctx.SaveChangesAsync();
    }

    public async Task<Post> GetSingleAsync(int id)
    {
        // include related data if you want it available
        var post = await _ctx.Posts
            .Include(p => p.User)
            .Include(p => p.Comments)
            .SingleOrDefaultAsync(p => p.Id == id);

        if (post is null)
            throw new InvalidOperationException($"Post with Id {id} not found.");

        return post;
    }

    public IQueryable<Post> GetManyAsync()
    {
        return _ctx.Posts.AsQueryable();
    }
}
