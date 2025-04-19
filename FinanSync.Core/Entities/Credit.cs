namespace FinanSync.Core.Entities;

public class Credit
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Source { get; set; } = null!;
    public decimal Value { get; set; }
    public DateTime Date { get; set; }
    public string? Note { get; set; }

    // Navigation property
    public User User { get; set; } = null!;
}