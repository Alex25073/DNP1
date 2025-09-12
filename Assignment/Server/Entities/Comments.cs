using InMemoryRepositories;
using Repositories.Interfaces;

namespace Entities;

public class Comment 
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public int PostId { get; set; }
    public int UserId { get; set; }
}