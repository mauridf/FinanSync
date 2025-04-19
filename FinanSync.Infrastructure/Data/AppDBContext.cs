using FinanSync.Core.Entities;
using FinanSync.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinanSync.Infrastructure.Data;

public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // DbSets permanecem os mesmos...

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração de conversores para DateTime
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                {
                    property.SetValueConverter(
                        new ValueConverter<DateTime, DateTime>(
                            v => v.ToUniversalTime(),
                            v => DateTime.SpecifyKind(v, DateTimeKind.Utc)));
                }
            }
        }

        // Configurações do Identity
        modelBuilder.Entity<User>(b =>
        {
            b.Property(u => u.Name).HasColumnName("name").HasMaxLength(100);
            b.Property(u => u.Phone).HasColumnName("phone").HasMaxLength(20);

            // Indexes para melhor performance
            b.HasIndex(u => u.Email).IsUnique();
            b.HasIndex(u => u.Phone).IsUnique();
        });

        // Configurações específicas do PostgreSQL
        modelBuilder.HasPostgresEnum<ExpenseCategory>();
        modelBuilder.HasPostgresEnum<PaymentMethod>();
        modelBuilder.HasPostgresEnum<PaymentStatus>();

        // Configuração do TPH para Expense
        modelBuilder.Entity<Expense>()
            .HasDiscriminator<string>("expense_type")
            .HasValue<FixedExpense>("Fixed")
            .HasValue<VariableExpense>("Variable");

        // Configurações para todas as entidades
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            // Configura o nome da tabela em snake_case
            entity.SetTableName(entity.GetTableName()?.ToLower());

            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName().ToLower());

                // Configurações específicas por tipo
                if (property.ClrType == typeof(decimal))
                {
                    property.SetPrecision(18);
                    property.SetScale(2);
                }
            }

            foreach (var key in entity.GetKeys())
            {
                key.SetName(key.GetName()?.ToLower());
            }

            foreach (var foreignKey in entity.GetForeignKeys())
            {
                foreignKey.SetConstraintName(foreignKey.GetConstraintName()?.ToLower());
            }
        }

        // Configurações específicas para RefreshToken
        modelBuilder.Entity<RefreshToken>(b =>
        {
            b.HasIndex(rt => rt.Token).IsUnique();
            b.Property(rt => rt.Token).HasMaxLength(64);
        });

        // Configurações para CreditCard
        modelBuilder.Entity<CreditCard>(b =>
        {
            b.Property(cc => cc.Name).HasMaxLength(50);
            b.HasIndex(cc => new { cc.UserId, cc.Name }).IsUnique();
        });

        // Configuração explícita do DeleteBehavior para relacionamentos importantes
        modelBuilder.Entity<Expense>()
            .HasOne(e => e.User)
            .WithMany(u => u.Expenses)
            .OnDelete(DeleteBehavior.Restrict);
    }
}