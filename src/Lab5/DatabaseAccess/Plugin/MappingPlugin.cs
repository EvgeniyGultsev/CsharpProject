using Itmo.Dev.Platform.Postgres.Plugins;
using Models.Operation;
using Npgsql;

namespace DatabaseAccess.Plugin;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        builder.MapEnum<OperationType>();
    }
}