using System;
using System.Threading.Tasks;
using RepositoryContracts;
using CliApp.UI.Utilities;

namespace CliApp.UI.ManagePosts;

public sealed class SinglePostView
{
    private readonly IPostRepository _posts;
    private readonly ICommentRepository _comments;
    public SinglePostView(IPostRepository posts, ICommentRepository comments)
    {
        _posts = posts ?? throw new ArgumentNullException(nameof(posts));
        _comments = comments ?? throw new ArgumentNullException(nameof(comments));
    }

    public async Task ShowAsync()
    {
        string postTitle = Input.ReadRequired("PostTitle: ");
        string userName = Input.ReadRequired("Username: ");
        var id = _posts.GetManyAsync().FirstOrDefault(p => p.Title == postTitle && p.Username == userName)?.Id ?? -1;
        try
        {
            var post = await _posts.GetSingleAsync(id);
            Console.WriteLine();
            Console.WriteLine($"Post #{post.Id} by User {post.Username}");
            Console.WriteLine($"Title: {post.Title}");
            Console.WriteLine("Body:");
            Console.WriteLine(post.Body);
            var comments = _comments
                .GetManyAsync()
                .Where(c => c.PostId == post.Id)
                .OrderBy(c => c.Id)
                .ToList();

            if (comments.Count == 0)
            {
                Console.WriteLine("(no comments)");
                return;
            }

            Console.WriteLine("Comments:");
            foreach (var c in comments)
                Console.WriteLine($" - [{c.Id}] {c.Username ?? $"User {c.UserId}"}: {c.Body}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
