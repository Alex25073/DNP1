using System.Net.Http.Json;
using ApiContracts;

namespace BlazorApp.Services;

public class CommentsHttpClient : ICommentsService
{
    private readonly HttpClient _client;

    public CommentsHttpClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<CommentDto>> GetForPostAsync(int postId)
    {
        var result = await _client.GetFromJsonAsync<IEnumerable<CommentDto>>($"comments?postId={postId}");
        return result ?? Array.Empty<CommentDto>();
    }

    public async Task<CommentDto> CreateAsync(CreateCommentDto dto)
    {
        var response = await _client.PostAsJsonAsync("comments", dto);
        response.EnsureSuccessStatusCode();

        var created = await response.Content.ReadFromJsonAsync<CommentDto>();
        if (created is null) throw new InvalidOperationException("API returned no comment.");

        return created;
    }
}
