using ApiContracts;

namespace BlazorApp.Services;

public interface IAuthService
{
    Task<UserDto?> LoginAsync(LoginRequest request);
    Task LogoutAsync();
}
