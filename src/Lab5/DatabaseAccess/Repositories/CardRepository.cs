using Abstractions.Repositories;
using Contracts;
using Itmo.Dev.Platform.Postgres.Connection;
using Models.User;
using Npgsql;

namespace DatabaseAccess.Repositories;

public class CardRepository : ICardRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public CardRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<User.Card?> FindCardById(long id)
    {
        const string sql = """
                           select card_id, pin_code
                           from users
                           where card_id = @id
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", id);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync() is false)
            return null;

        return new User.Card(
            CardId: reader.GetInt64(0),
            PinCode: reader.GetInt32(1));
    }

    public async Task<OperationResult> AddMoney(long id, decimal amount)
    {
        const string sql = """
                           UPDATE users
                           SET available_money = available_money + @amount
                           WHERE card_id = @id
                           """;

        NpgsqlConnection connection =
            await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("amount", amount);
        command.Parameters.AddWithValue("id", id);

        if (await command.ExecuteNonQueryAsync() == 1)
            return new OperationResult.Success();
        return new OperationResult.Fail();
    }

    public async Task<OperationResult> SubtractMoney(long id, decimal amount)
    {
        const string sql = """
                           UPDATE users
                           SET available_money = available_money - @amount
                           WHERE card_id = @id
                           """;

        NpgsqlConnection connection =
            await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("amount", amount);
        command.Parameters.AddWithValue("id", id);

        if (await command.ExecuteNonQueryAsync() == 1)
            return new OperationResult.Success();
        return new OperationResult.Fail();
    }

    public async Task<decimal> ShowBalanceById(long id)
    {
        const string sql = """
                           SELECT available_money
                           from users
                           where card_id = @id
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", id);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        await reader.ReadAsync();
        return reader.GetDecimal(0);
    }
}