namespace Squares.Contracts.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ISurfaceRepository Surfaces { get; }
    ISquareRepository Squares { get; }
    IPointRepository Points { get; }
    Task<int> SaveAsync();
}