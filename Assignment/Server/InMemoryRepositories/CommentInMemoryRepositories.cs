using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class CommentInMemoryRepositories : ICommentRepository
{
    private readonly List<Comment> _comments = new();
    private int _nextId = 1;

    public Task<Comment> AddAsync(Comment comment)
    {
        comment.Id = _nextId++;
        _comments.Add(comment);
        return Task.FromResult(comment);
    }

    public Task UpdateAsync(Comment comment)
    {
        var existingComment = _comments.FirstOrDefault(c => c.Id == comment.Id);
        if (existingComment != null)
        {
            _comments.Remove(existingComment);
            _comments.Add(comment);
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Comment comment)
    {
        _comments.RemoveAll(c => c.Id == comment.Id);
        return Task.CompletedTask;
    }

    public Task<Comment> GetSingleAsync(int id)
    {
        var comment = _comments.FirstOrDefault(c => c.Id == id);
        if (comment == null)
            throw new InvalidOperationException($"Comment with Id {id} not found.");
        return Task.FromResult(comment);
    }

    public IQueryable<Comment> GetManyAsync()
    {
        return _comments.AsQueryable();
    }
}