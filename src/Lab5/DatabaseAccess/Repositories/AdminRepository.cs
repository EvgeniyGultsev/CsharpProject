using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Models.User;
using Npgsql;

namespace DatabaseAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task AddNewCard(User.Card card)
    {
        const string sql = """
                           INSERT INTO users (card_id, pin_code, available_money)
                           VALUES (@cardId, @pin, 0)
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("cardId", card.CardId);
        command.Parameters.AddWithValue("pin", card.PinCode);
        await command.ExecuteNonQueryAsync();
    }
}