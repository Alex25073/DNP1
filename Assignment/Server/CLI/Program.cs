
using RepositoryContracts;
using CLI.UI;
using InMemoryRepositories;

namespace CLI;

internal static class Program
{
    private static async Task Main()
    {
        IUserRepository userRepo = new UserInMemoryRepositories();
        IPostRepository postRepo = new PostInMemoryRepositories();
        ICommentRepository commentRepo = new CommentInMemoryRepositories();

        UI.CliApp app = new UI.CliApp(userRepo, postRepo, commentRepo);
        await app.StartAsync();
    }
}
