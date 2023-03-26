using System.Linq.Expressions;

namespace Squares.Contracts.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int entityId);
    Task<IEnumerable<T>> ListAsync();
    Task AddAsync(T entity);
    Task RemoveByIdAsync(int entityId);
    Task UpdateAsync(T entity);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
}