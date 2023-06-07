using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace OTTCreator.WebApp.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(string id);

    Task<IReadOnlyList<T>> GetAllAsync();

    Task AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);

    Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

    Task<IEnumerable<T>> GetData(Expression<Func<T, bool>>? filter = null,
                                                   Expression<Func<T, T>>? selector = null,
                                                   Func<IQueryable<T>, IQueryable<T>>? sorting = null,
                                                   Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
}
