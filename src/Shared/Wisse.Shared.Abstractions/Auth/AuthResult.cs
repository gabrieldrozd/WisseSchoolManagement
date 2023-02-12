namespace Wisse.Shared.Abstractions.Auth;

public class AuthResult
{
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }
    public string[] Permissions { get; set; }

    public static AuthResult Create(Guid userId, string email, string fullName, string role, string token, string[] permissions)
    {
        return new AuthResult
        {
            UserId = userId,
            Email = email,
            FullName = fullName,
            Role = role,
            Token = token,
            Permissions = permissions
        };
    }
}
