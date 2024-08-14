using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace DatabaseAccess.Migration;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type operation_type as enum
        (
            'add',
            'subtract'
        );
        
        create table users
        (
            card_id bigint primary key not null,
            pin_code bigint not null,
            available_money bigint not null
        );

        create table operations
        (
            operation_id bigint primary key generated always as identity,
            card_id bigint not null references users(card_id),
            operation operation_type not null,
            operation_sum bigint not null
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
            drop table users;
            drop table operations;

            drop type operation_type;
        """;
}