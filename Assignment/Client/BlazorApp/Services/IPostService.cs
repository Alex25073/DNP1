using ApiContracts;

namespace BlazorApp.Services;

public interface IPostsService
{
    Task<IEnumerable<PostDto>> GetAllAsync(string? title = null);
    Task<PostDto> GetByIdAsync(int id);
    Task<PostDto> CreateAsync(CreatePostDto dto);
}
