using AutoMapper;
using Squares.API.Configurations;

namespace Squares.API.Extensions;

public static class ConfigurationHelpers
{
    internal static void AddObjectMappings(this IServiceCollection serviceCollection)
    {
        var mappingConfiguration = new MapperConfiguration(options =>
        {
            options.AddProfile(new CustomMapperConfiguration());
        });

        serviceCollection.AddSingleton(mappingConfiguration.CreateMapper());
    }
}