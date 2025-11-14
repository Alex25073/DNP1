using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorApp.Auth;

public class SimpleAuthProvider : AuthenticationStateProvider
{
    private readonly SimpleAuthState _state;

    public SimpleAuthProvider(SimpleAuthState state)
    {
        _state = state;
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsIdentity identity;

        if (_state.CurrentUser is null)
        {
            identity = new ClaimsIdentity();
        }
        else
        {
            identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, _state.CurrentUser.UserName),
                new Claim(ClaimTypes.Email, _state.CurrentUser.Email)
            }, "simple");
        }

        var user = new ClaimsPrincipal(identity);
        return Task.FromResult(new AuthenticationState(user));
    }

    public void NotifyAuthStateChanged()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
