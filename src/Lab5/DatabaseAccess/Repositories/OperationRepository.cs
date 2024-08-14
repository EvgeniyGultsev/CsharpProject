using Abstractions.Repositories;
using Contracts;
using Itmo.Dev.Platform.Postgres.Connection;
using Models.Operation;
using Npgsql;

namespace DatabaseAccess.Repositories;

public class OperationRepository : IOperationsRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public OperationRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async IAsyncEnumerable<Operation> GetAllCardsOperations(long cardId)
    {
        const string sql = """
                           select operation, operation_sum
                           from operations
                           where card_id = @cardId
                           order by operation_id
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("cardId", cardId);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            yield return new Operation(
                Type: await reader.GetFieldValueAsync<OperationType>(0),
                Sum: reader.GetInt64(1));
        }
    }

    public async Task<OperationResult> AddOperation(long cardNumber, Operation operation)
    {
        const string sql = """
                           INSERT INTO operations (card_id, operation, operation_sum)
                           VALUES (@cardNumber, @operation, @sum)
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("cardNumber", cardNumber);
        command.Parameters.AddWithValue("operation", operation.Type);
        command.Parameters.AddWithValue("sum", operation.Sum);

        if (await command.ExecuteNonQueryAsync() == 1)
            return new OperationResult.Success();
        return new OperationResult.Fail();
    }
}