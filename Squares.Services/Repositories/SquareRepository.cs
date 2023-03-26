using Squares.Contracts.Interfaces;
using Squares.Entities.Models;

namespace Squares.Services.Repositories;

public class SquareRepository : Repository<Square>, ISquareRepository
{
    public SquareRepository(DatabaseContext.DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}