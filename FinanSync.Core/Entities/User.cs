using Microsoft.AspNetCore.Identity;

namespace FinanSync.Core.Entities;

public class User : IdentityUser<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;

    // Refresh Token (opcional)
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiry { get; set; }

    // Navigation properties
    public ICollection<Credit> Credits { get; set; } = new List<Credit>();
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    public ICollection<Debt> Debts { get; set; } = new List<Debt>();
    public ICollection<Investment> Investments { get; set; } = new List<Investment>();
    public ICollection<CreditCard> CreditCards { get; set; } = new List<CreditCard>();
    public ICollection<MoneyBox> MoneyBoxes { get; set; } = new List<MoneyBox>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}