namespace FinanSync.Core.Entities;
public class RefreshToken
{
    public Guid Id { get; set; }
    public string Token { get; set; } = null!;
    public DateTime Expires { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Revoked { get; set; }
    public Guid UserId { get; set; }

    // Navigation property
    public User User { get; set; } = null!;
}