using Squares.Api.Presenters;
using Squares.Application.Interfaces.Repositories;
using Squares.Application.Interfaces.UseCases;
using Squares.Application.UseCases;
using Squares.Infrastructure.Repositories;

namespace Squares.Api
{
    public static class ConfigureServices
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {    
            builder.Services.AddSingleton<ISquaresDetectionEntriesRepository, SquaresDetectionEntriesRepository>();

            builder.Services.AddScoped<ICreateSquaresDetectionEntryUseCase, CreateNewPointsListUseCase>();
            builder.Services.AddScoped<IGetSquaresDetectionEntriesListUseCase, GetIdentifiedSquaresListingUseCase>();
            builder.Services.AddScoped<IAddNewPointToDetectionSquaresEntryUseCase, AddNewPointToDetectionSquaresEntryUseCase>();
            builder.Services.AddScoped<IRemovePointFromDetectionSquaresEntryUseCase, RemovePointFromDetectionSquaresEntryUseCase>();

            builder.Services.AddScoped<SquaresDetectionEntryPresenter>();
            builder.Services.AddScoped<SquaresDetectionEntriesListPresenter>();
            return builder;
        }
    }
}
