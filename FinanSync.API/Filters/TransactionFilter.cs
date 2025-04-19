using FinanSync.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FinanSync.API.Filters;

public class TransactionFilter : IActionFilter
{
    private readonly AppDbContext _dbContext;

    public TransactionFilter(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _dbContext.Database.BeginTransaction();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception == null)
        {
            _dbContext.Database.CommitTransaction();
        }
        else
        {
            _dbContext.Database.RollbackTransaction();
        }
    }
}