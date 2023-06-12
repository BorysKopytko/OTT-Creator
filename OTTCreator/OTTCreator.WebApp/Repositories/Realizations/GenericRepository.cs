using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using OTTCreator.WebApp.Repositories.Interfaces;
using System.Linq.Expressions;
using OTTCreator.WebApp.Data;

namespace OTTCreator.WebApp.Repositories.Realizations;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationIdentityDbContext _dbContext;

    public GenericRepository(ApplicationIdentityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T> GetByIdAsync(string id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await this._dbContext.Set<T>().AddAsync(entity);
    }

    public Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;

        return Task.CompletedTask;
    }

    public Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);

        return Task.CompletedTask;
    }

    public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
    {
        return await this.GetQuery(predicate, include).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    private IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
    {
        var query = _dbContext.Set<T>().AsNoTracking();
        if (include != null)
            query = include(query);
        if (predicate != null)
            query = query.Where(predicate);
        return query;
    }

    public async Task<IEnumerable<T>> GetData(Expression<Func<T, bool>> filter = null,
                                                   Expression<Func<T, T>> selector = null,
                                                   Func<IQueryable<T>, IQueryable<T>> sorting = null,
                                                   Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
    {
        var query = _dbContext.Set<T>().AsNoTracking();

        if (include != null)
            query = include(query);

        if (filter != null)
            query = query.Where(filter);

        if (selector != null)
            query = query.Select(selector);

        if (sorting != null)
            query = sorting(query);

        return query;
    }
}
