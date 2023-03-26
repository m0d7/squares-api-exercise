using Squares.API.Extensions;
using Squares.Contracts.Interfaces;
using Squares.DatabaseContext;
using Squares.Services.Repositories;
using Squares.Services.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register services
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<ISurfaceRepository, SurfaceRepository>();
builder.Services.AddTransient<ISquareRepository, SquareRepository>();
builder.Services.AddTransient<IPointRepository, PointRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<ISquareValidator, SquareValidator>();

builder.Services.AddObjectMappings();

// Add database
builder.Services.AddDatabaseContext(builder.Configuration);

var app = builder.Build();

// Ensure database is created
app.UseEnsureDatabaseIsCreated();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();