using System.Linq;
using System.Threading.Tasks;
using Entities;
using RepositoryContracts;
using CliApp.UI.Utilities;

namespace CliApp.UI.ManagePosts;

public sealed class CreatePostView
{
    private readonly IPostRepository _posts;
    private readonly IUserRepository _users;

    public CreatePostView(IPostRepository posts, IUserRepository users)
    {
        _posts = posts;
        _users = users;
    }

    public async Task ShowAsync()
    {
        var userId = Input.ReadInt("UserId: ");
        if (!_users.GetManyAsync().Any(u => u.Id == userId))
        {
            System.Console.WriteLine($"No user with Id {userId}.");
            return;
        }

        var title = Input.ReadRequired("Title: ");
        var body  = Input.ReadRequired("Body: ");

        var created = await _posts.AddAsync(new Post { UserId = userId, Title = title, Body = body });
        System.Console.WriteLine($"Post created with Id={created.Id}");
    }
}
