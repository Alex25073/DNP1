using System;
using System.Linq;
using RepositoryContracts;

namespace CliApp.UI.ManagePosts;

public sealed class ListPostsView
{
    private readonly IPostRepository _posts;
    public ListPostsView(IPostRepository posts) => _posts = posts;

    public void Show()
    {
        Console.WriteLine();
        Console.WriteLine("Posts Overview:");
        var list = _posts.GetManyAsync().OrderBy(p => p.Id).ToList();
        if (list.Count == 0) { Console.WriteLine("(no posts)"); return; }

        foreach (var p in list) Console.WriteLine($"[{p.Id}] {p.Title}");
    }
}
