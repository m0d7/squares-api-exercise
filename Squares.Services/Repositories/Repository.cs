using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Squares.Contracts.Interfaces;

namespace Squares.Services.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DatabaseContext.DatabaseContext databaseContext;

    public Repository(DatabaseContext.DatabaseContext databaseContext)
    {
        this.databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
    }

    public async Task<T> GetByIdAsync(int entityId)
    {
        return await this.databaseContext.Set<T>().FindAsync(entityId);
    }

    public async Task<IEnumerable<T>> ListAsync()
    {
        return await this.databaseContext.Set<T>().ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await this.databaseContext.Set<T>().AddAsync(entity);
    }

    public async Task RemoveByIdAsync(int entityId)
    {
        var entity = await this.GetByIdAsync(entityId) ?? throw new ArgumentNullException(nameof(entityId));

        this.databaseContext.Set<T>().Remove(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        this.databaseContext.Set<T>().Update(entity);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
    {
        return this.databaseContext.Set<T>().Where(expression);
    }
}