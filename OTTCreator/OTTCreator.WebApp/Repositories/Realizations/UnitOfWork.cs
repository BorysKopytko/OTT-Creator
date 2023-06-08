using OTTCreator.WebApp.Data;
using OTTCreator.WebApp.Repositories.Interfaces;

namespace OTTCreator.WebApp.Repositories.Realizations;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationIdentityDbContext _dbContext;
    private bool disposed;

    public UnitOfWork(ApplicationIdentityDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<int> Commit()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        disposed = true;
    }
}
