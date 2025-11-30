using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace EfcRepositories;

public class UserEfcRepository : IUserRepository
{
    private readonly AppContext _ctx;

    public UserEfcRepository(AppContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<User> AddAsync(User user)
    {
        _ctx.Users.Add(user);
        await _ctx.SaveChangesAsync();
        return user;
    }

    public async Task UpdateAsync(User user)
    {
        _ctx.Users.Update(user);
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _ctx.Users.Remove(user);
        await _ctx.SaveChangesAsync();
    }

    public async Task<User> GetSingleAsync(int id)
    {
        var user = await _ctx.Users.SingleOrDefaultAsync(u => u.Id == id);
        if (user is null)
            throw new InvalidOperationException($"User with Id {id} not found.");

        return user;
    }

    public IQueryable<User> GetManyAsync()
    {
        return _ctx.Users.AsQueryable();
    }
}
