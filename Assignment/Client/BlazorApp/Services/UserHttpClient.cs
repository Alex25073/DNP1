using System.Net.Http.Json;
using ApiContracts;

namespace BlazorApp.Services;

public class UsersHttpClient : IUsersService
{
    private readonly HttpClient _client;

    public UsersHttpClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync(string? contains = null)
    {
        var url = "user"; 
        if (!string.IsNullOrWhiteSpace(contains))
        {
            url += $"?contains={Uri.EscapeDataString(contains)}";
        }

        var result = await _client.GetFromJsonAsync<IEnumerable<UserDto>>(url);
        return result ?? Array.Empty<UserDto>();
    }

    public async Task<UserDto> CreateAsync(CreateUserDto dto)
    {
        var response = await _client.PostAsJsonAsync("user", dto);
        response.EnsureSuccessStatusCode();

        var created = await response.Content.ReadFromJsonAsync<UserDto>();
        if (created is null) throw new InvalidOperationException("API returned no user.");

        return created;
    }
}
