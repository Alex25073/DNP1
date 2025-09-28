using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using FileRepositories.Internal;
using RepositoryContracts;

namespace FileRepositories;

public sealed class UserFileRepository : IUserRepository
{
    private readonly JsonFileStore<User> _store = new("users.json");

    public async Task<User> AddAsync(User user)
    {
        var users = await _store.LoadAsync();
        user.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
        users.Add(user);
        await _store.SaveAsync(users);
        return user;
    }

    public async Task UpdateAsync(User user)
    {
        var users = await _store.LoadAsync();
        var idx = users.FindIndex(u => u.Id == user.Id);
        if (idx == -1) throw new InvalidOperationException($"User with ID '{user.Id}' not found");
        users[idx] = user;
        await _store.SaveAsync(users);
    }

    public async Task DeleteAsync(User user)
    {
        var users = await _store.LoadAsync();
        var existing = users.SingleOrDefault(u => u.Id == user.Id)
            ?? throw new InvalidOperationException($"User with ID '{user.Id}' not found");
        users.Remove(existing);
        await _store.SaveAsync(users);
    }

    public async Task<User> GetSingleAsync(int id)
    {
        var users = await _store.LoadAsync();
        return users.SingleOrDefault(u => u.Id == id)
            ?? throw new InvalidOperationException($"User with ID '{id}' not found");
    }

    public IQueryable<User> GetMany()
    {
        var json = System.IO.File.ReadAllText(_store.path);
        var users = System.Text.Json.JsonSerializer.Deserialize<List<User>>(json)
                ?? new List<User>();
        return users.AsQueryable();
    }

    public IQueryable<User> GetManyAsync()
    {
        var users = _store.LoadAsync().Result;
        return users.AsQueryable();
    }
}
