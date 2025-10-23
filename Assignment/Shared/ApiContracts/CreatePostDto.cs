using System;

namespace ApiContracts;

public class CreatePostDto
{
    public required string Title { get; set; } = string.Empty;
    public required string Body { get; set; } = string.Empty;
    public required int UserId { get; set; }
    

}
