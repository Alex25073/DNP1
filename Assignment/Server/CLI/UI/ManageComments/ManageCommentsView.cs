using System;
using System.Threading.Tasks;
using RepositoryContracts;

namespace CliApp.UI.ManageComments;

public sealed class ManageCommentsView
{
    private readonly ICommentRepository _comments;
    private readonly IUserRepository _users;
    private readonly IPostRepository _posts;

    public ManageCommentsView(ICommentRepository comments, IUserRepository users, IPostRepository posts)
    {
        _comments = comments;
        _users = users;
        _posts = posts;
    }

    public async Task ShowAsync()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Comments:");
            Console.WriteLine("1) Add Comment to Post");
            Console.WriteLine("b) Back");
            Console.Write("> ");

            var cmd = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
            switch (cmd)
            {
                case "1": await new CreateCommentView(_comments, _users, _posts).ShowAsync(); break;
                case "b": return;
                default: Console.WriteLine("Unknown command."); break;
            }
        }
    }
}
