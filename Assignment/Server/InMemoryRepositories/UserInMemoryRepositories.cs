using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class UserInMemoryRepositories : IUserRepository
{
    private readonly List<User> _users = new();

    public Task<User> AddAsync(User user)
    {
        _users.Add(user);
        return Task.FromResult(_users.Last());
    }

    public Task DeleteAsync(User user)
    {
        _users.Remove(user);
        return Task.CompletedTask;
    }

    public Task<User?> GetByIdAsync(int id)
    {
        var post = _users.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(post);
    }

    public Task<List<User>> ListAllAsync()
    {
        return Task.FromResult(_users.ToList());
    }

    public Task UpdateAsync(User user)
    {
        var existingPost = _users.FirstOrDefault(p => p.Id == user.Id);
        if (existingPost != null)
        {
            _users.Remove(existingPost);
            _users.Add(user);
        }
        return Task.CompletedTask;
    }

    public IQueryable<User> GetManyAsync()
    {
        return _users.AsQueryable();
    }

    public Task<User> GetSingleAsync(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null)
            throw new InvalidOperationException($"User with Id {id} not found.");
        return Task.FromResult(user);
    }
}