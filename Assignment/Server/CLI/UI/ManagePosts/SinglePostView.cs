using System;
using System.Threading.Tasks;
using RepositoryContracts;
using CliApp.UI.Utilities;

namespace CliApp.UI.ManagePosts;

public sealed class SinglePostView
{
    private readonly IPostRepository _posts;
    public SinglePostView(IPostRepository posts) => _posts = posts;

    public async Task ShowAsync()
    {
        var id = Input.ReadInt("PostId: ");
        try
        {
            var post = await _posts.GetSingleAsync(id);
            Console.WriteLine();
            Console.WriteLine($"Post #{post.Id} by User {post.UserId}");
            Console.WriteLine($"Title: {post.Title}");
            Console.WriteLine("Body:");
            Console.WriteLine(post.Body);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
