using System;
using System.Threading.Tasks;
using RepositoryContracts;

namespace CliApp.UI.ManageUsers;

public sealed class ManageUsersView
{
    private readonly IUserRepository _users;

    public ManageUsersView(IUserRepository users) => _users = users;

    public async Task ShowAsync()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Users:");
            Console.WriteLine("1) Create User");
            Console.WriteLine("2) List Users");
            Console.WriteLine("b) Back");
            Console.Write("> ");

            var cmd = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
            switch (cmd)
            {
                case "1": await new CreateUserView(_users).ShowAsync(); break;
                case "2": new ListUsersView(_users).Show(); break;
                case "b": return;
                default: Console.WriteLine("Unknown command."); break;
            }
        }
    }
}
