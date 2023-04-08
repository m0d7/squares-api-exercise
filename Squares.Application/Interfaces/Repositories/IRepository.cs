using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAllAsync();
        T GetByIdAsync(string id);
        void AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(string id);
    }
}
