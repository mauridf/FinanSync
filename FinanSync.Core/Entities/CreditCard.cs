namespace FinanSync.Core.Entities;
public class CreditCard
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = null!;
    public decimal Limit { get; set; }
    public int DueDay { get; set; }

    // Navigation properties
    public User User { get; set; } = null!;
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}