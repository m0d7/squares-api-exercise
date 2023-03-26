using Squares.Contracts.Interfaces;
using Squares.Services.Repositories;

namespace Squares.DatabaseContext;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext context;

    public UnitOfWork(DatabaseContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
        Surfaces = new SurfaceRepository(this.context);
        Squares = new SquareRepository(this.context);
        Points = new PointRepository(this.context);
    }

    public ISurfaceRepository Surfaces { get; }
    public ISquareRepository Squares { get; }
    public IPointRepository Points { get; }

    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }

    public void Dispose()
    {
        context.DisposeAsync();
    }
}