using FinanSync.Core.Enums;

namespace FinanSync.Core.Entities;

public class FixedExpense : Expense
{
    public DateTime DueDate { get; set; }
    public PaymentStatus Status { get; set; }
}