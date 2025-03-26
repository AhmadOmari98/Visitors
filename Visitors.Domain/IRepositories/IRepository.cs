using Common;
using System.Linq.Expressions;

namespace Visitors.Domain.IRepositories
{
    public interface IRepository<T> where T : DomainEntity
    {
        IQueryable<T> Query();
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetByAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAllAsync(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync();
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveAsync();
    }
}
