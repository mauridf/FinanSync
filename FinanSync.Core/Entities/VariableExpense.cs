namespace FinanSync.Core.Entities;
public class VariableExpense : Expense
{
    public int Installments { get; set; }
    public int PaidInstallments { get; set; }
}