using Squares.Contracts.Interfaces;
using Squares.Entities.Models;

namespace Squares.Services.Repositories;

public class PointRepository : Repository<Point>, IPointRepository
{
    public PointRepository(DatabaseContext.DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}