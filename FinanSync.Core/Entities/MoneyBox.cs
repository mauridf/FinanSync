namespace FinanSync.Core.Entities;
public class MoneyBox
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public decimal MonthlySavedValue { get; set; }
    public decimal MonthlyUsedValue { get; set; }
    public decimal TotalValue { get; set; }
    public string Description { get; set; } = null!;

    // Navigation property
    public User User { get; set; } = null!;
}