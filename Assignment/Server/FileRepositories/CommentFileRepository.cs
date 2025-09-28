using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using FileRepositories.Internal;
using RepositoryContracts;

namespace FileRepositories;

public sealed class CommentFileRepository : ICommentRepository
{
    private readonly JsonFileStore<Comment> _store = new("comments.json");

    public async Task<Comment> AddAsync(Comment comment)
    {
        var comments = await _store.LoadAsync();
        comment.Id = comments.Any() ? comments.Max(c => c.Id) + 1 : 1;
        comments.Add(comment);
        await _store.SaveAsync(comments);
        return comment;
    }

    public async Task UpdateAsync(Comment comment)
    {
        var comments = await _store.LoadAsync();
        var idx = comments.FindIndex(c => c.Id == comment.Id);
        if (idx == -1) throw new InvalidOperationException($"Comment with ID '{comment.Id}' not found");
        comments[idx] = comment;
        await _store.SaveAsync(comments);
    }

    public async Task DeleteAsync(Comment comment)
    {
        var comments = await _store.LoadAsync();
        var existing = comments.SingleOrDefault(c => c.Id == comment.Id)
            ?? throw new InvalidOperationException($"Comment with ID '{comment.Id}' not found");
        comments.Remove(existing);
        await _store.SaveAsync(comments);
    }

    public async Task<Comment> GetSingleAsync(int id)
    {
        var comments = await _store.LoadAsync();
        return comments.SingleOrDefault(c => c.Id == id)
            ?? throw new InvalidOperationException($"Comment with ID '{id}' not found");
    }

    public IQueryable<Comment> GetManyAsync()
    {
        var json = System.IO.File.ReadAllTextAsync(_store.path).Result;
        var comments = JsonSerializer.Deserialize<List<Comment>>(json) ?? new List<Comment>();
        return comments.AsQueryable();
    }
}
