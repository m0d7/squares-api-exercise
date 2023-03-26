using Microsoft.EntityFrameworkCore;
using Squares.Entities.Models;

namespace Squares.DatabaseContext;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> optionsBuilder) : base(optionsBuilder)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Surface> Surfaces { get; set; }
    public DbSet<Square> Squares { get; set; }
    public DbSet<Point> Points { get; set; }
}