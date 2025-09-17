using System;
using System.Linq;
using RepositoryContracts;

namespace CliApp.UI.ManageUsers;

public sealed class ListUsersView
{
    private readonly IUserRepository _users;
    public ListUsersView(IUserRepository users) => _users = users;

    public void Show()
    {
        Console.WriteLine();
        Console.WriteLine("All Users:");
        var list = _users.GetManyAsync().OrderBy(u => u.Id).ToList();
        if (list.Count == 0) { Console.WriteLine("(no users)"); return; }

        foreach (var u in list) Console.WriteLine($" { u.Username}");
    }
}
