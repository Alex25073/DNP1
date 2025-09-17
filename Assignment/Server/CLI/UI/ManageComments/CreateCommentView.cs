using System.Linq;
using System.Threading.Tasks;
using Entities;
using RepositoryContracts;
using CliApp.UI.Utilities;

namespace CliApp.UI.ManageComments;

public sealed class CreateCommentView
{
    private readonly ICommentRepository _comments;
    private readonly IUserRepository _users;
    private readonly IPostRepository _posts;

    public CreateCommentView(ICommentRepository comments, IUserRepository users, IPostRepository posts)
    {
        _comments = comments;
        _users = users;
        _posts = posts;
    }

    public async Task ShowAsync()
    {
        var userId = Input.ReadInt("UserId: ");
        if (!_users.GetManyAsync().Any(u => u.Id == userId))
        {
            System.Console.WriteLine($"No user with Id {userId}.");
            return;
        }

        var postId = Input.ReadInt("PostId: ");
        if (!_posts.GetManyAsync().Any(p => p.Id == postId))
        {
            System.Console.WriteLine($"No post with Id {postId}.");
            return;
        }

        var body = Input.ReadRequired("Body: ");

        var created = await _comments.AddAsync(new Comment { UserId = userId, PostId = postId, Body = body });
        System.Console.WriteLine($"Comment created with Id={created.Id}");
    }
}
