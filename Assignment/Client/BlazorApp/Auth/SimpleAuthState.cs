using ApiContracts;

namespace BlazorApp.Auth;

public class SimpleAuthState
{
    public UserDto? CurrentUser { get; private set; }

    public bool IsLoggedIn => CurrentUser is not null;

    public void SetUser(UserDto? user)
    {
        CurrentUser = user;
    }
}
