using ApiContracts;

namespace BlazorApp.Services;

public interface ICommentsService
{
    Task<IEnumerable<CommentDto>> GetForPostAsync(int postId);
    Task<CommentDto> CreateAsync(CreateCommentDto dto);
}
