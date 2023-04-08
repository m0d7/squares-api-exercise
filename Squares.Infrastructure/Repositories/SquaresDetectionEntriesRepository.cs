using Squares.Application.Interfaces.Repositories;
using Squares.Domain.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares.Infrastructure.Repositories
{
    /// <summary>
    ///  Dummy implementation of persistance layer
    /// </summary>
    public class SquaresDetectionEntriesRepository : ISquaresDetectionEntriesRepository
    {

        public ConcurrentDictionary<string, SquaresDetectionEntry> IdentifiedSquares;
        public SquaresDetectionEntriesRepository() 
        {
            this.IdentifiedSquares = new ConcurrentDictionary<string, SquaresDetectionEntry>();
        }

        public void AddAsync(SquaresDetectionEntry entity)
        {
            IdentifiedSquares.TryAdd(entity.Id, entity);
        }

        public void DeleteAsync(string id)
        {
            IdentifiedSquares.TryRemove(id, out SquaresDetectionEntry entity);
        }

        public IList<SquaresDetectionEntry> GetAllAsync()
        {
            return IdentifiedSquares.Values.ToList();
        }

        public SquaresDetectionEntry? GetByIdAsync(string id)
        {
            IdentifiedSquares.TryGetValue(id, out SquaresDetectionEntry? entity);
            return entity;
        }

        public void UpdateAsync(SquaresDetectionEntry entity)
        {
            DeleteAsync(entity.Id);
            AddAsync(entity);
        }
    }
}
