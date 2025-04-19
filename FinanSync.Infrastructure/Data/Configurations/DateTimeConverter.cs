using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinanSync.Infrastructure.Data.Configurations;

public static class DateTimeConverter
{
    public static ValueConverter<DateTime, DateTime> UtcConverter =>
        new(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
}