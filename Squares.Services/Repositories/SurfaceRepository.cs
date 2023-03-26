using Squares.Contracts.Interfaces;
using Squares.Entities.Models;

namespace Squares.Services.Repositories;

public class SurfaceRepository : Repository<Surface>, ISurfaceRepository
{
    public SurfaceRepository(DatabaseContext.DatabaseContext databaseContext) : base(databaseContext)
    {
    }
}