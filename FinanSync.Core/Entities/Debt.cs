namespace FinanSync.Core.Entities;
public class Debt
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Description { get; set; } = null!;
    public string Receiver { get; set; } = null!;
    public decimal TotalValue { get; set; }
    public int Installments { get; set; }
    public int PaidInstallments { get; set; }

    // Navigation property
    public User User { get; set; } = null!;
}