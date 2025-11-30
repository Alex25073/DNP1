using System;

namespace ApiContracts;

public class CreateCommentDto
{
    public  string Body { get; set; } = string.Empty;
    public  int PostId { get; set; }
    public  int UserId { get; set; }
}
