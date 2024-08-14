using Abstractions.Repositories;
using DatabaseAccess.Plugin;
using DatabaseAccess.Repositories;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Itmo.Dev.Platform.Postgres.Plugins;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseAccess.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection,
        Action<PostgresConnectionConfiguration> configuration)
    {
        collection.AddPlatformPostgres(builder => builder.Configure(configuration));
        collection.AddPlatformMigrations(typeof(ServiceCollectionExtension).Assembly);

        collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        collection.AddScoped<IOperationsRepository, OperationRepository>(); // Добавить репозитории в di
        collection.AddScoped<ICardRepository, CardRepository>();
        collection.AddScoped<IAdminRepository, AdminRepository>();

        return collection;
    }
}