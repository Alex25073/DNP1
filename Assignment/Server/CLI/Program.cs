
using RepositoryContracts;
using CLI.UI;
using FileRepositories;

namespace CLI;

internal static class Program
{
    private static async Task Main()
    {
        IUserRepository userRepo = new UserFileRepository();
        IPostRepository postRepo = new PostFileRepository();
        ICommentRepository commentRepo = new CommentFileRepository();

        UI.CliApp app = new UI.CliApp(userRepo, postRepo, commentRepo);
        await app.StartAsync();
    }
}
