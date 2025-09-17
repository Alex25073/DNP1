using System;
using RepositoryContracts;
using CliApp.UI.ManageUsers;
using CliApp.UI.ManagePosts;
using CliApp.UI.ManageComments;

namespace CLI.UI;

public class CliApp
{
    private readonly IUserRepository _users;
    private readonly IPostRepository _posts;
    private readonly ICommentRepository _comments;

    public CliApp(IUserRepository users, IPostRepository posts, ICommentRepository comments)
    {
        _users = users;
        _posts = posts;
        _comments = comments;
    }

    public async Task StartAsync()
    {
        Console.WriteLine("======================================");
        Console.WriteLine("   Forum Management CLI Application   ");    
        Console.WriteLine("======================================");

        var usersView = new ManageUsersView(_users);
        var postsView = new ManagePostsView(_posts, _users);
        var commentsView = new ManageCommentsView(_comments, _users, _posts);

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1) Manage Users");
            Console.WriteLine("2) Manage Posts");
            Console.WriteLine("3) Manage Comments");
            Console.WriteLine("x) Exit");
            Console.Write("> ");

            var cmd = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
            switch (cmd)
            {
                case "1": await usersView.ShowAsync(); break;
                case "2": await postsView.ShowAsync(); break;
                case "3": await commentsView.ShowAsync(); break;
                case "x": return;
                default: Console.WriteLine("Unknown command."); break;
            }
        }
    }
}
