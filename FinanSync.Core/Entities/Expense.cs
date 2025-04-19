using FinanSync.Core.Enums;

namespace FinanSync.Core.Entities;

public abstract class Expense
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Description { get; set; } = null!;
    public ExpenseCategory Category { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public Guid? CreditCardId { get; set; }
    public decimal Value { get; set; }

    // Navigation properties
    public User User { get; set; } = null!;
    public CreditCard? CreditCard { get; set; }
}