using System;

namespace ApiContracts;

public class CreateUserDto
{
    public required string UserName { get; set; } = string.Empty;
    public required string Email { get; set; } = string.Empty;
    public required string Password { get; set; } = string.Empty;

}
