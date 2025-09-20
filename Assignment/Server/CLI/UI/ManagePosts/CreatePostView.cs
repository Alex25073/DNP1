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
        string userName = Input.ReadRequired("Username: ");
        var userId = _users.GetManyAsync().FirstOrDefault(u => u.Username == userName)?.Id ?? -1;
        if (!_users.GetManyAsync().Any(u => u.Id == userId))
        {
            System.Console.WriteLine($"No user with Username {userName}.");
            return;
        }

        var title = Input.ReadRequired("Title: ");
        var body  = Input.ReadRequired("Body: ");

        var postNr= _posts.GetManyAsync().Count();
        var created = await _posts.AddAsync(new Post { UserId = userId, Title = title, Body = body, Username = userName, Id = postNr + 1 });
        System.Console.WriteLine($"Post created with Title={created.Title}");
    }
}
