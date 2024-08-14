using Application.Extensions;
using Console;
using Console.Extensions;
using DatabaseAccess.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Models.Admin;
using Spectre.Console;

var collection = new ServiceCollection();
collection
    .AddApplication()
    .AddInfrastructureDataAccess(configuration =>
    {
        configuration.Host = "localhost";
        configuration.Port = 6432;
        configuration.Username = "postgres";
        configuration.Password = "postgres";
        configuration.Database = "postgres";
        configuration.SslMode = "Prefer";
    })
    .AddPresentationConsole();

collection.AddSingleton<AdminPassword>(_ => new AdminPassword("admin"));

ServiceProvider provider = collection.BuildServiceProvider();
using IServiceScope scope = provider.CreateScope();

scope.UseInfrastructureDataAccess();

ScenarioRunner scenarioRunner = scope.ServiceProvider
    .GetRequiredService<ScenarioRunner>();

// while (true)
// {
await scenarioRunner.Run();
AnsiConsole.Clear();

// }