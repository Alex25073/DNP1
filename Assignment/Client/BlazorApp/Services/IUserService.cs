using ApiContracts;

namespace BlazorApp.Services;

public interface IUsersService
{
    Task<IEnumerable<UserDto>> GetAllAsync(string? contains = null);
    Task<UserDto> CreateAsync(CreateUserDto dto);
}
