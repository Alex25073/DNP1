using System.Net.Http.Json;
using ApiContracts;
using BlazorApp.Auth;

namespace BlazorApp.Services;

public class AuthHttpClient : IAuthService
{
    private readonly HttpClient _client;
    private readonly SimpleAuthState _state;
    private readonly SimpleAuthProvider _provider;

    public AuthHttpClient(HttpClient client, SimpleAuthState state, SimpleAuthProvider provider)
    {
        _client = client;
        _state = state;
        _provider = provider;
    }

    public async Task<UserDto?> LoginAsync(LoginRequest request)
    {
        var response = await _client.PostAsJsonAsync("auth/login", request);
        if (!response.IsSuccessStatusCode)
        {
            _state.SetUser(null);
            _provider.NotifyAuthStateChanged();
            return null;
        }

        var user = await response.Content.ReadFromJsonAsync<UserDto>();
        _state.SetUser(user);
        _provider.NotifyAuthStateChanged();
        return user;
    }

    public Task LogoutAsync()
    {
        _state.SetUser(null);
        _provider.NotifyAuthStateChanged();
        return Task.CompletedTask;
    }
}
