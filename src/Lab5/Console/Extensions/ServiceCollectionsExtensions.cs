using Console.Scenarios.AdminOperations.MakeNewCard;
using Console.Scenarios.Login.AdminLogin;
using Console.Scenarios.Login.UnLoginScenario;
using Console.Scenarios.Login.UserLogin;
using Console.Scenarios.UserOperations.AddMoney;
using Console.Scenarios.UserOperations.SubtractMoney;
using Console.Scenarios.UserOperations.ViewBalance;
using Console.Scenarios.UserOperations.ViewOperations;
using Microsoft.Extensions.DependencyInjection;

namespace Console.Extensions;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, AdminMakeNewCardScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AdminLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, UserLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, UnLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AddMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, SubtractMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ViewBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ViewOperationsScenarioProvider>();

        return collection;
    }
}