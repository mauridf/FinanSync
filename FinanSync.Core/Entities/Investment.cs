namespace FinanSync.Core.Entities;
public class Investment
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Description { get; set; } = null!;
    public string Broker { get; set; } = null!;
    public decimal InvestedValue { get; set; }
    public decimal CurrentValue { get; set; }
    public DateTime Date { get; set; }

    // Navigation property
    public User User { get; set; } = null!;
}