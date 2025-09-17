using System;
using System.Threading.Tasks;
using RepositoryContracts;

namespace CliApp.UI.ManagePosts;

public sealed class ManagePostsView
{
    private readonly IPostRepository _posts;
    private readonly IUserRepository _users;

    public ManagePostsView(IPostRepository posts, IUserRepository users)
    {
        _posts = posts;
        _users = users;
    }

    public async Task ShowAsync()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Posts:");
            Console.WriteLine("1) Create Post");
            Console.WriteLine("2) List Posts (overview)");
            Console.WriteLine("3) View Single Post");
            Console.WriteLine("b) Back");
            Console.Write("> ");

            var cmd = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
            switch (cmd)
            {
                case "1": await new CreatePostView(_posts, _users).ShowAsync(); break;
                case "2": new ListPostsView(_posts).Show(); break;
                case "3": await new SinglePostView(_posts).ShowAsync(); break;
                case "b": return;
                default: Console.WriteLine("Unknown command."); break;
            }
        }
    }
}
