using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class PostInMemoryRepositories : IPostRepository
{
    private readonly List<Post> _posts = new();

    public Task AddAsync(Post post)
    {
        _posts.Add(post);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Post post)
    {
        _posts.Remove(post);
        return Task.CompletedTask;
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        var post = _posts.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(post);
    }

    public Task<List<Post>> ListAllAsync()
    {
        return Task.FromResult(_posts.ToList());
    }

    public Task UpdateAsync(Post post)
    {
        var existingPost = _posts.FirstOrDefault(p => p.Id == post.Id);
        if (existingPost != null)
        {
            _posts.Remove(existingPost);
            _posts.Add(post);
        }
        return Task.CompletedTask;
    }
}