namespace Wisse.Shared.Abstractions.Auth;

public class AccessToken
{
    public string Token { get; set; }
    public long Expires { get; set; }
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string[] Permissions { get; set; }
}
