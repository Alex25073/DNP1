using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using FileRepositories.Internal;
using RepositoryContracts;

namespace FileRepositories;

public sealed class PostFileRepository : IPostRepository
{
    private readonly JsonFileStore<Post> _store = new("posts.json");

    public async Task<Post> AddAsync(Post post)
    {
        var posts = await _store.LoadAsync();
        post.Id = posts.Any() ? posts.Max(p => p.Id) + 1 : 1;
        posts.Add(post);
        await _store.SaveAsync(posts);
        return post;
    }

    public async Task UpdateAsync(Post post)
    {
        var posts = await _store.LoadAsync();
        var idx = posts.FindIndex(p => p.Id == post.Id);
        if (idx == -1) throw new InvalidOperationException($"Post with ID '{post.Id}' not found");
        posts[idx] = post;
        await _store.SaveAsync(posts);
    }


    public async Task DeleteAsync(Post post)
    {
        var posts = await _store.LoadAsync();
        var existing = posts.SingleOrDefault(p => p.Id == post.Id)
            ?? throw new InvalidOperationException($"Post with ID '{post.Id}' not found");
        posts.Remove(existing);
        await _store.SaveAsync(posts);
    }

    public async Task<Post> GetSingleAsync(int id)
    {
        var posts = await _store.LoadAsync();
        return posts.SingleOrDefault(p => p.Id == id)
            ?? throw new InvalidOperationException($"Post with ID '{id}' not found");
    }

    public IQueryable<Post> GetManyAsync()
    {
        var json = System.IO.File.ReadAllTextAsync(_store.path).Result;
        var posts = JsonSerializer.Deserialize<List<Post>>(json) ?? new List<Post>();
        return posts.AsQueryable();
    }
}
