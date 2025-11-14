using System.Net.Http.Json;
using ApiContracts;

namespace BlazorApp.Services;

public class PostsHttpClient : IPostsService
{
    private readonly HttpClient _client;

    public PostsHttpClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<PostDto>> GetAllAsync(string? title = null)
    {
        var url = "posts";
        if (!string.IsNullOrWhiteSpace(title))
        {
            url += $"?title={Uri.EscapeDataString(title)}";
        }

        var result = await _client.GetFromJsonAsync<IEnumerable<PostDto>>(url);
        return result ?? Array.Empty<PostDto>();
    }

    public async Task<PostDto> GetByIdAsync(int id)
    {
        var post = await _client.GetFromJsonAsync<PostDto>($"posts/{id}");
        if (post is null) throw new InvalidOperationException($"Post {id} not found.");
        return post;
    }

    public async Task<PostDto> CreateAsync(CreatePostDto dto)
    {
        var response = await _client.PostAsJsonAsync("posts", dto);
        response.EnsureSuccessStatusCode();

        var created = await response.Content.ReadFromJsonAsync<PostDto>();
        if (created is null) throw new InvalidOperationException("API returned no post.");

        return created;
    }
}
