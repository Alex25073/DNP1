using System;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using RepositoryContracts;
using CliApp.UI.Utilities;

namespace CliApp.UI.ManageUsers;

public sealed class CreateUserView
{
    private readonly IUserRepository _users;
    public CreateUserView(IUserRepository users) => _users = users;

    public async Task ShowAsync()
    {
        Console.WriteLine();
        Console.WriteLine("Create User");

        var username = Input.ReadRequired("Username: ");
        var password = Input.ReadRequired("Password: ");

        var exists = _users.GetManyAsync()
            .Any(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase));
        if (exists)
        {
            Console.WriteLine("Username already taken.");
            return;
        }

        var created = await _users.AddAsync(new User { Username = username, Password = password });
        Console.WriteLine($"User created with Id={created.Id}");
    }
}
